using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TestNetCore.DataAccessLayer.infrastructures
{
    public class DBFactory : Disposable, IDBFactory
    {
        #region Properties

        private TestAzureContext dBContext;
        public TestAzureContext Intialize()
        {
            return dBContext ?? (dBContext = new TestAzureContext());
           
        }
        #endregion

        protected override void DisposeCore()
        {
            if (dBContext != null)
            {
                dBContext.Dispose();
            }
        }
    }
}

