using System;
using System.Collections.Generic;
using System.Text;

namespace TestNetCore.DataAccessLayer.infrastructures
{
    public interface IDBFactory
    {
        TestAzureContext Intialize();
    }
}
