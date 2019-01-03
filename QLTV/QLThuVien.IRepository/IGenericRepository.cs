using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien.IRepository
{
    public interface IGenericReposity<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Update(T item);
        int Delete(int id);
        int Create(T item);

    }
}
