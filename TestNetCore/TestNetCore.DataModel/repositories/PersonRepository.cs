using System;
using System.Collections.Generic;
using System.Text;
using TestNetCore.DataAccessLayer.infrastructures;
using TestNetCore.Model.Models;

namespace TestNetCore.DataAccessLayer.repositories
{
    public interface IPersSonRepository: IGenericRepository<Persons>
    {

    }
    public class PersonRepository: RepositoryBase<Persons>, IPersSonRepository
    {
        public PersonRepository(IDBFactory dBFactory):base(dBFactory)
        {
           
        }
    }
}
