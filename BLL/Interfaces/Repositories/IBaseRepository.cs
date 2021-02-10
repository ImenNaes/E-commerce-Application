using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetwithExpression(Expression<Func<T, bool>> expression = null);
        T GetById(Guid id);
        void Save(T obj);
        T Update(T obj);
        void Delete(Guid id);
        void Dispose();
    }
}
