using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TestNetCore.DataAccessLayer.infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDBFactory _dBFactory;
        private TestAzureContext _dbContext;

        public UnitOfWork(IDBFactory dBFactory)
        {
            this._dBFactory = dBFactory;
        }

        public TestAzureContext dbContext
        {
            //Check dbContext != null if null reIntialize 
            get { return _dbContext ?? (_dbContext = _dBFactory.Intialize()); }
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
