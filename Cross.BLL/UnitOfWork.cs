using Cross.DbFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cross.BLL
{
    public class UnitOfWork : IDisposable
    {
        [ThreadStatic]
        private readonly static Lazy<CrossContext> _db = new Lazy<CrossContext>();

        public Lazy<AccountBLL> UserBLL = new Lazy<AccountBLL>(() =>
        {
            return new AccountBLL(_db.Value);
        });



        #region IDisposable Support

        public UnitOfWork()
        {

        }

        ~UnitOfWork()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose();
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            if (_db != null && _db.IsValueCreated)
            {
                _db.Value.Dispose();
            }

        }

        #endregion

    }
}
