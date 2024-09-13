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

        public IzvestajService(IIzvestajRepository izvestajRepository, IParfemRepository parfemRepository, IStavkaKupovineRepository stavkaKupovineRepository, IMapper mapper) : base(mapper)
        {
            _izvestajRepository = izvestajRepository;
            _parfemRepository = parfemRepository;
            _stavkaKupovineRepository = stavkaKupovineRepository;
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
            var stavke = _stavkaKupovineRepository.GetAllByFabrikaId(fabrikaId).ToList();

            foreach (var stavka in stavke)
            {
                // Fetch Parfem entity for each StavkaKupovine
                var parfem = _parfemRepository.Get(stavka.sk_par_id);
                stavka.SetParfem(parfem);  // Use the setter method
            }

            return stavke;
        }


        private string CreateIzvestajPdf(IzvestajDto izvestajDto, long fabrikaId)
        {
            string vr = DateTime.Now.ToString("dd_MM_yy_HH_mm_ss");
            string path = "..\\KParfume-BackEnd\\Resources\\Pdfs\\Izvestaj" + izvestajDto.izv_kor_id+ "_" + vr + ".pdf";

            var stavke = GetData(fabrikaId);
            double totalPrice = stavke.Sum(s => s.sk_cena_pj * s.sk_kolicina);

            Document document = new Document(PageSize.A4, 36, 36, 54, 54);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

            document.Open();

            // Fonts for styling
            Font titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
            Font headerFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            Font regularFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
            Font boldFont = FontFactory.GetFont("Arial", 12, Font.BOLD);

            // Title
            Paragraph title = new Paragraph("Izvestaj o Kupovini", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            document.Add(new Paragraph("\n"));

            PdfPTable table = new PdfPTable(3); // 3 columns: Parfem, Price, Quantity
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 50f, 25f, 25f }); // Set the relative widths of the columns

            // Adding header cells
            table.AddCell(new PdfPCell(new Phrase("Parfem", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase("Cena po stavci", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase("Kolicina", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });

            // Grouping by Kupovina
            var groupedStavke = stavke.GroupBy(s => s.sk_kup_id).ToList();  

            // Colors for alternating rows
            BaseColor color1 = new BaseColor(230, 240, 255); // Light blue
            BaseColor color2 = new BaseColor(255, 230, 230); // Light red
            bool useColor1 = true;

            // Loop through each group and color rows
            foreach (var group in groupedStavke)
            {
                // Toggle between colors
                BaseColor currentColor = useColor1 ? color1 : color2;
                useColor1 = !useColor1;

                foreach (var item in group)
                {
                    PdfPCell parfemCell = new PdfPCell(new Phrase(item.Parfem.par_naziv, regularFont));
                    parfemCell.BackgroundColor = currentColor;
                    parfemCell.Padding = 5;
                    table.AddCell(parfemCell);

                    PdfPCell priceCell = new PdfPCell(new Phrase(item.sk_cena_pj.ToString() + " RSD", regularFont));
                    priceCell.BackgroundColor = currentColor;
                    priceCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    priceCell.Padding = 5;
                    table.AddCell(priceCell);

                    PdfPCell quantityCell = new PdfPCell(new Phrase(item.sk_kolicina.ToString(), regularFont));
                    quantityCell.BackgroundColor = currentColor;
                    quantityCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    quantityCell.Padding = 5;
                    table.AddCell(quantityCell);
                }
            }

            document.Add(table);

            document.Add(new Paragraph("\n"));

            PdfPTable totalTable = new PdfPTable(1); // Single column for total price
            totalTable.WidthPercentage = 100;

            PdfPCell totalCell = new PdfPCell(new Phrase($"Ukupna Cena: {totalPrice.ToString() + " RSD"}", boldFont));
            totalCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            totalCell.Padding = 10;
            totalCell.Border = PdfPCell.NO_BORDER;

            totalTable.AddCell(totalCell);
            document.Add(totalTable);

            document.Add(new Paragraph("\n"));
            Paragraph footer = new Paragraph("Stavke su podeljene po bojama u zavisnosti kojoj kupovini pripadaju!", boldFont);
            footer.Alignment = Element.ALIGN_CENTER;
            document.Add(footer);

            document.Close();
            writer.Close();

            // Automatically open the PDF after it's generated
            Process.Start(new ProcessStartInfo(path)
            {
                UseShellExecute = true // This is needed to open the file with the default PDF viewer
            });


            return "/pdfs/Izvestaj" + izvestajDto.izv_kor_id + '_' + vr + ".pdf";
            //return path;
        }

    }
}
