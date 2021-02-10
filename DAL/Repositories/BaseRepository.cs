using BLL.Interfaces.Repositories;
using DAL.ApiContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BaseRepository<T> : IDisposable,IBaseRepository<T> where T:class
    {
        protected EFContext _ctx;
        private bool disposed = false;

        public BaseRepository()
        {
            _ctx = new EFContext();
        }

        public void Delete(Guid id)
        {
            var obj = _ctx.Set<T>().Find(id);
            _ctx.Set<T>().Remove(obj);
            _ctx.SaveChanges();
           
        }

        public int Add(T model)
        {
            _ctx.Set<T>().Add(model);
            var result=  _ctx.SaveChanges();
            return result;

        }
        public void DeleteFull(T obj)
        {          
            _ctx.Set<T>().Remove(obj);
            _ctx.SaveChanges();
        }
        public void DeleteRange(IEnumerable<T> obj)
        {
            _ctx.Set<T>().RemoveRange(obj);
            _ctx.SaveChanges();
        }
        public IEnumerable<T> GetwithExpression(Expression<Func<T, bool>> expression = null)
        {
            return _ctx.Set<T>().Where(expression.Compile()).ToList();
        }

        //dispose est utilisé pour le Garbage collector pour liberer le memoire et supprimer les objets non utilisés
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<T> GetAll()
        {
            return _ctx.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public void Save(T obj)
        {
            _ctx.Set<T>().Add(obj);
            _ctx.SaveChanges();
        }

       

        public T Update(T obj)
        {
            _ctx.Entry<T>(obj).State = EntityState.Modified;
            _ctx.SaveChanges();
            return (obj);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }
        ~BaseRepository()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }
    }
}
