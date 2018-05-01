using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace evolent.data.Repository
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        #region Private variables
        
        private evolentDBContext _evolentDBContext;
        private DbSet<Entity> _dbSet;
        
        #endregion

        #region Constructors
        
        public GenericRepository(evolentDBContext _dbContext)
        {
            _evolentDBContext = _dbContext;
            _dbSet = _evolentDBContext.Set<Entity>();
        }
        
        #endregion

        #region Public Methods (Generics)
        /// <summary>
        /// Returns all the entities. 
        /// </summary>
        /// <returns>List of Entities</returns>
        public IEnumerable<Entity> GetAll()
        {
            return _dbSet.AsEnumerable().ToList();
        }

        /// <summary>
        /// Return the entity based on the primery key provided.
        /// </summary>
        /// <param name="key">Primary key of the entity</param>
        /// <returns>Entity if exists with the primary key provied else null</returns>
        public Entity GetByKey(object key)
        {
            var entity = _evolentDBContext.Set<Entity>().Find(key);
            if (entity != null)
                _evolentDBContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        /// <summary>
        /// Insert the new entity. 
        /// </summary>
        /// <param name="entity">Entity to be inserted</param>
        public Entity Insert(Entity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        /// <summary>
        /// Update the provided entity.
        /// </summary>
        /// <param name="entity">Entity needs to be updated</param>
        public void Update(Entity entity)
        {
            if (_evolentDBContext.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _evolentDBContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Deleted the entity 
        /// </summary>
        /// <param name="entity">Entity needs to be deleted</param>
        public void Delete(Entity entity)
        {
            if (_evolentDBContext.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Delete the entity based on the primary key provided.
        /// </summary>
        /// <param name="key">Primary key</param>
        public void Delete(object key)
        {
            Entity entityToDelete = _dbSet.Find(key);
            Delete(entityToDelete);
        }
        #endregion
    }
}
