using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bodytech.Application.Repository
{
    /// <summary>
    /// Classe do Repository
    /// </summary>
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T Find(int Id);
        T Add(T entity);
        T Update(T entity);
        void Delete(int Id);
    }
}