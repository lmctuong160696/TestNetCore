using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestNetCore.Model;
using TestNetCore.DataAccessLayer;
using TestNetCore.DataAccessLayer.infrastructures;
using TestNetCore.DataAccessLayer.repositories;
using TestNetCore.Model.Models;

namespace TestNetCore.UnitTest.RepositoryTest
{
    [TestClass]
   public  class PersonRepositoryTest
    {
        private IDBFactory dBFactory;
        private IPersSonRepository personRepository;
        private IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dBFactory = new DBFactory();
            personRepository = new PersonRepository(dBFactory);
            unitOfWork = new UnitOfWork(dBFactory);
            
        }

        [TestMethod]
        public void Get_List_Person()
        {
            IEnumerable<Persons> listResult;
            listResult =  personRepository.GetAll();

            Assert.IsNotNull(listResult);

        }
    }
}
