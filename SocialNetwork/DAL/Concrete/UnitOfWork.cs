using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;
using NLog;

namespace DAL.Concrete
{
    public class UnitOfWork: IUnitOfWork
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public DbContext Context { get; private set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    logger.Error("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        logger.Error("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public void Dispose()
        {
           Context?.Dispose();
        }

    }
}
