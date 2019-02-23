using MyEvernote.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.BusinessLayer
{
    public class RepositoryBase
    {
        private static DatabaseContext _db;
        private static object _lockSync = new object(); // İstediğin ismi verebilirsin.

        protected RepositoryBase() { }

        public static DatabaseContext CreateContex()
        {
            if (_db == null)
            {
                lock (_lockSync)
                {
                    if (_db == null)
                    {
                        _db = new DatabaseContext();
                    }
                }
            }
            return _db;
        }
    }
}
