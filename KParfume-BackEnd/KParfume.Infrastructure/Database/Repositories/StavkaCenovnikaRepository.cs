﻿using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class StavkaCenovnikaRepository : IStavkaCenovnikaRepository
    {
        private readonly Context _dbContext;

        public StavkaCenovnikaRepository(Context context)
        {
            _dbContext = context;
        }

        public StavkaCenovnika Create(StavkaCenovnika stavkaCenovnika)
        {
            _dbContext.StavkaCenovnika.Add(stavkaCenovnika);
            _dbContext.SaveChanges();
            return stavkaCenovnika;
        }

        public StavkaCenovnika Get(long id)
        {
            return _dbContext.StavkaCenovnika.Find(id);
        }

        public List<StavkaCenovnika> GetAll()
        {
            return _dbContext.StavkaCenovnika.ToList();
        }

        public List<StavkaCenovnika> GetAllByCenovnikId( long cenovnikId)
        {
            return _dbContext.StavkaCenovnika.Where(s=> s.sc_cen_id == cenovnikId).ToList();
        }

        public void Remove(StavkaCenovnika stavkaCenovnika)
        {
            _dbContext.StavkaCenovnika.Remove(stavkaCenovnika);
            _dbContext.SaveChanges();
        }



    }
}