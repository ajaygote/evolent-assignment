using System;
using evolent.data.Repository;
using System.Transactions;
using System.Data.Entity.Validation;

namespace evolent.data.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        #region Private variables
        private evolentDBContext _evolentDBContext;
        private IGenericRepository<Contact> _contactRepository;
        private TransactionScope _transaction;
        #endregion

        #region Constructors
        
        /// <summary>
        /// Constructor - Initiallize all the necessary private variables. 
        /// </summary>
        public UnitOfWork()
        {
            _evolentDBContext = new evolentDBContext();
        }
        
        #endregion

        #region Properties

        public Repository.IGenericRepository<Contact> ContactRepository
        {
            get
            {
                return _contactRepository ?? new GenericRepository<Contact>(_evolentDBContext);
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// <see cref="IUnitOfWork"/>
        /// Save all the changes of the context to the database.
        /// </summary>
        public void Commit()
        {
            try
            {
                using (_transaction = new TransactionScope())
                {
                    _evolentDBContext.SaveChanges();
                    _transaction.Complete();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Dispose the context object used.
        /// </summary>
        public void Dispose()
        {
            if (_evolentDBContext != null)
            {
                _evolentDBContext.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        #endregion 
    }
}
