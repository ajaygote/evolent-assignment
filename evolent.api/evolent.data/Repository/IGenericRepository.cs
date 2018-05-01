using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolent.data.Repository
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        /// <summary>
        /// Returns all the entities. 
        /// </summary>
        /// <returns>List of Entities</returns>
        IEnumerable<Entity> GetAll();

        /// <summary>
        /// Return the entity based on the primery key provided.
        /// </summary>
        /// <param name="key">Primary key of the entity</param>
        /// <returns>Entity if exists with the primary key provied else null</returns>
        Entity GetByKey(object key);

        /// <summary>
        /// Insert the new entity. 
        /// </summary>
        /// <param name="entity">Entity to be inserted</param>
        Entity Insert(Entity entity);

        /// <summary>
        /// Update the provided entity.
        /// </summary>
        /// <param name="entity">Entity needs to be updated</param>
        void Update(Entity entity); 

        /// <summary>
        /// Delete the entity based on the primary key provided.
        /// </summary>
        /// <param name="key">Primary key</param>
        void Delete(object key);
    }
}
