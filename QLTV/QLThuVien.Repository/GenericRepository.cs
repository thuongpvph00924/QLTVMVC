using QLThuVien.IRepository;
using QLThuVien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;


namespace QLThuVien.Repository
{
    public class GenericRepository<T> : IGenericReposity<T> where T : class
    {
        protected QLThuVienDbContext db { get; set; }
        protected DbSet<T> table = null;

        //Phương thức khởi tạo mặc định
        public GenericRepository()
        {
            db = new QLThuVienDbContext();
            table = db.Set<T>();
        }

        //phương thức khởi tạo có tham số
        public GenericRepository(QLThuVienDbContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(int id)
        {
            return table.Find(id);
        }

        public int Update(T item)
        {
            table.Attach(item);
            db.Entry(item).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            T existring = table.Find(id);
            table.Remove(existring);
            return db.SaveChanges();
        }

        public int Create(T item)
        {
            table.Add(item);
            return db.SaveChanges();
        }
    }
}
