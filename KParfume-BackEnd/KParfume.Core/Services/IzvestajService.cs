using AutoMapper;
using FluentResults;
using KParfume.API.DTOs;
using KParfume.API.Public;
using KParfume.BuildingBlocks.Core.UseCases;
using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;

using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;



namespace KParfume.Core.Services
{
    public class IzvestajService : BaseService<IzvestajDto, Izvestaj>, IIzvestajService
    {
        protected readonly IIzvestajRepository _izvestajRepository;
        protected readonly IParfemRepository _parfemRepository;
        protected readonly IStavkaKupovineRepository _stavkaKupovineRepository;
        protected readonly IKuponRepository _kuponRepository;

        public IzvestajService(IIzvestajRepository izvestajRepository, IParfemRepository parfemRepository, IStavkaKupovineRepository stavkaKupovineRepository, IKuponRepository kuponRepository, IMapper mapper) : base(mapper)
        {
            _izvestajRepository = izvestajRepository;
            _parfemRepository = parfemRepository;
            _stavkaKupovineRepository = stavkaKupovineRepository;
            _kuponRepository = kuponRepository;
        }


        public Result<IzvestajDto> Create(IzvestajDto izvestajDto,long fabrikaId)
        {
            try
            {
                string path = CreateIzvestajPdf(izvestajDto,fabrikaId);
                izvestajDto.izv_putanja = path;
                Izvestaj izvestaj = MapToDomain(izvestajDto);
                return MapToDto(_izvestajRepository.Create(izvestaj));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

        public Result<List<IzvestajDto>> GetAllForAuthor(long authorId)
        {
            try
            {
                return MapToDto(_izvestajRepository.GetAllForAuthor(authorId));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }


        private List<StavkaKupovine> GetData(long fabrikaId)
        {
            var stavke = _stavkaKupovineRepository.GetAllByFabrikaId(fabrikaId);
            foreach (var stavka in stavke)
            {
                var parfem = _parfemRepository.Get(stavka.sk_par_id);
                stavka.SetParfem(parfem);
            }
            return stavke;
        }

        private string CreateIzvestajPdf(IzvestajDto izvestajDto, long fabrikaId)
        {
            string vr = DateTime.Now.ToString("dd_MM_yy_HH_mm_ss");
            string path = $"..\\KParfume-BackEnd\\Resources\\Pdfs\\Izvestaj{izvestajDto.izv_kor_id}_{vr}.pdf";

            Document document = new Document(PageSize.A4, 36, 36, 54, 54);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
            writer.PageEvent = new PageEventHelper(); // Assign the custom page event helper
            document.Open();

            // Adding a logo
            try
            {
                Image logo = Image.GetInstance($"..\\KParfume-BackEnd\\Resources\\Images\\Kparfumelogo.png");
                logo.ScaleToFit(100f, 100f);
                logo.Alignment = Image.ALIGN_BASELINE;
                document.Add(logo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding logo: " + ex.Message);
            }

            // Define fonts
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font titleFont = new Font(bf, 18, Font.BOLD, new BaseColor(75, 110, 142));
            Font headerFont = new Font(bf, 12, Font.BOLD, BaseColor.WHITE);
            Font regularFont = new Font(bf, 12, Font.NORMAL);
            Font boldFont = new Font(bf, 12, Font.BOLD);

            // Title
            Paragraph title = new Paragraph("Izveštaj o kupovini za vašu fabriku", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 10;
            document.Add(title);

            PdfPTable table = new PdfPTable(3); // 3 columns: Parfem, Price, Quantity
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 50f, 25f, 25f });
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;

            // Adding header cells
            PdfPCell header1 = new PdfPCell(new Phrase("Parfem", headerFont));
            header1.BackgroundColor = new BaseColor(75, 110, 142); // Dark blue
            header1.HorizontalAlignment = Element.ALIGN_CENTER;
            header1.Padding = 8;
            table.AddCell(header1);

            PdfPCell header2 = new PdfPCell(new Phrase("Cena po stavci", headerFont));
            header2.BackgroundColor = new BaseColor(75, 110, 142); // Dark blue
            header2.HorizontalAlignment = Element.ALIGN_CENTER;
            header2.Padding = 8;
            table.AddCell(header2);

            PdfPCell header3 = new PdfPCell(new Phrase("Kolicina", headerFont));
            header3.BackgroundColor = new BaseColor(75, 101, 152); // Dark blue
            header3.HorizontalAlignment = Element.ALIGN_CENTER;
            header3.Padding = 8;
            table.AddCell(header3);

            double totalPrice = 0;
            var stavke = GetData(fabrikaId);
            var groupedStavke = stavke.GroupBy(s => s.sk_kup_id).ToList();
            bool alternateColor = true;

            foreach (var group in groupedStavke)
            {
                foreach (var stavka in group)
                {
                    double price = stavka.sk_cena_pj;
                    if (stavka.Kupovina.kup_kpn_id != null)
                    {
                        var kupon = _kuponRepository.Get(stavka.Kupovina.kup_kpn_id.Value);
                        if (kupon != null && kupon.kpn_aktivan)
                        {
                            price -= price * (kupon.kpn_popust / 100.0);
                        }
                    }

                    string priceText = $"{price.ToString("F2")} €";
                    if (stavka.Kupovina.kup_kpn_id != null && stavka.Kupovina.Kupon != null && stavka.Kupovina.Kupon.kpn_aktivan)
                    {
                        priceText += $" (Upotrebljen kupon: -{stavka.Kupovina.Kupon.kpn_popust}% popusta)";
                    }

                    PdfPCell cell1 = new PdfPCell(new Phrase(stavka.Parfem.par_naziv, regularFont));
                    PdfPCell cell2 = new PdfPCell(new Phrase(priceText, regularFont));
                    PdfPCell cell3 = new PdfPCell(new Phrase(stavka.sk_kolicina.ToString(), regularFont));

                    if (alternateColor)
                    {
                        cell1.BackgroundColor = new BaseColor(230, 240, 255); // Light blue
                        cell2.BackgroundColor = new BaseColor(230, 240, 255);
                        cell3.BackgroundColor = new BaseColor(230, 240, 255);
                    }
                    else
                    {
                        cell1.BackgroundColor = new BaseColor(255, 230, 230); // Light red
                        cell2.BackgroundColor = new BaseColor(255, 230, 230);
                        cell3.BackgroundColor = new BaseColor(255, 230, 230);
                    }

                    cell1.Padding = 5;
                    cell2.Padding = 5;
                    cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell3.Padding = 5;
                    cell3.HorizontalAlignment = Element.ALIGN_RIGHT;

                    table.AddCell(cell1);
                    table.AddCell(cell2);
                    table.AddCell(cell3);

                    totalPrice += price * stavka.sk_kolicina;
                }
                alternateColor = !alternateColor; // Toggle color for next group
            }

            document.Add(table);

            // Display total price
            PdfPCell totalCell = new PdfPCell(new Phrase($"Ukupna cena: {totalPrice.ToString("F2")} €", boldFont));
            totalCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            totalCell.Padding = 10;
            totalCell.Border = PdfPCell.NO_BORDER;
            PdfPTable totalTable = new PdfPTable(1);
            totalTable.WidthPercentage = 100;
            totalTable.AddCell(totalCell);
            document.Add(totalTable);

            document.Close();
            writer.Close();

            // Automatically open the PDF
            Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });

            return $"/pdfs/Izvestaj{izvestajDto.izv_kor_id}_{vr}.pdf";
        }

    }

    internal class PageEventHelper : PdfPageEventHelper
    {
        Font footerFont = FontFactory.GetFont("Arial", 8, Font.NORMAL);

        // This method is called when a document page is finished, allowing us to add footers.
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            PdfPTable footer = new PdfPTable(1);
            footer.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin; // Fit footer within page margins
            footer.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell cell = new PdfPCell(new Phrase("" + writer.PageNumber, footerFont));
            cell.Border = PdfPCell.NO_BORDER;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            footer.AddCell(cell);

            footer.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin - 10, writer.DirectContent); // Positioning footer at the bottom
        }
    }
}
