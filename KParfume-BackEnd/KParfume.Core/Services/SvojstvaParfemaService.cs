using KParfume.API.DTOs;
using KParfume.API.Public;
using KParfume.Core.Domain.RepositoryInterfaces;


namespace KParfume.Core.Services
{
    public class SvojstvaParfemaService : ISvojstvaParfemaService
    {
        protected readonly IVrstaParfemaRepository _vrstaParfemaRepository;
        protected readonly ITipParfemaRepository _tipParfemaRepository;
        protected readonly IKategorijaParfemaRepository _kategorijaParfemaRepository;

        public SvojstvaParfemaService(IVrstaParfemaRepository vrstaParfemaRepository, ITipParfemaRepository tipParfemaRepository, IKategorijaParfemaRepository kategorijaParfemaRepository) 
        {
            _vrstaParfemaRepository = vrstaParfemaRepository;
            _tipParfemaRepository = tipParfemaRepository;
            _kategorijaParfemaRepository = kategorijaParfemaRepository;
        }


        public List<VrstaParfemaDto> GetAllVrstaParfema()
        {
            var vrstaParfema = _vrstaParfemaRepository.GetAll().ToList();
            return vrstaParfema.Select(x => new VrstaParfemaDto
            {
                Id = x.Id,
                vp_naziv = x.vp_naziv
            }).ToList();
        }

        public List<TipParfemaDto> GetAllTipParfema()
        {
            var tipParfema = _tipParfemaRepository.GetAll().ToList();
            return tipParfema.Select(x => new TipParfemaDto
            {
                Id = x.Id,
                tp_naziv = x.tp_naziv
            }).ToList();
        }

        public List<KategorijaParfemaDto> GetAllKategorijaParfema()
        {
            var kategorijaParfema = _kategorijaParfemaRepository.GetAll().ToList();
            return kategorijaParfema.Select(x => new KategorijaParfemaDto
            {
                Id = x.Id,
                kp_naziv = x.kp_naziv
            }).ToList();
        }

        public VrstaParfemaDto GetVrstaParfema(long id)
        {
            var vrstaParfema = _vrstaParfemaRepository.Get(id);
            if (vrstaParfema == null)
            {
                return null;
            }

            return new VrstaParfemaDto
            {
                Id = vrstaParfema.Id,
                vp_naziv = vrstaParfema.vp_naziv
            };
        }

        public TipParfemaDto GetTipParfema(long id)
        {
            var tipParfema = _tipParfemaRepository.Get(id);
            if (tipParfema == null)
            {
                return null;
            }

            return new TipParfemaDto
            {
                Id = tipParfema.Id,
                tp_naziv = tipParfema.tp_naziv
            };
        }

        public KategorijaParfemaDto GetKategorijaParfema(long id)
        {
            var kategorijaParfema = _kategorijaParfemaRepository.Get(id);
            if (kategorijaParfema == null)
            {
                return null;
            }

            return new KategorijaParfemaDto
            {
                Id = kategorijaParfema.Id,
                kp_naziv = kategorijaParfema.kp_naziv
            };
        }


    }
}
