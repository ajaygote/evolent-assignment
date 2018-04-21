using evolent.data.Repository;
using System;
namespace evolent.data.UnitOfWork
    
{
    public interface IUnitOfWork : IDisposable
    {
        #region Properties

        IGenericRepository<Contact> ContactRepository { get; }
        
        #endregion

        #region Public methods
        
        /// <summary>
        /// Save all the changes of the context to the database.
        /// </summary>
        void Commit();

        #endregion
    }
}
