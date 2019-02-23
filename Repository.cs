using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyEvernote.DAL;
namespace MyEvernote.BusinessLayer
{
    public class Repository<T> where T : class
    {
        private DatabaseContext db = new DatabaseContext();
        private DbSet<T> _objectSet;

        // db.Set<T>() => _objectSet dönüşümü

        public Repository()
        {
            _objectSet = db.Set<T>();
        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public int Insert(T obj)
        {
            _objectSet.Add(obj);
            return Save();
        }
        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();
        }

        public int Update(T obj)
        {
            return Save();
        }

        public List<T> List(Expression<Func<T,bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
    }
}
