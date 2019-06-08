using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TestNetCore.DataAccessLayer.infrastructures
{
   public interface IUnitOfWork 
    {
        void Commit();
    }
}
