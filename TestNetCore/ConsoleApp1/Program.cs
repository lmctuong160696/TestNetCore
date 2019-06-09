using System;
using System.Collections.Generic;
using TestNetCore.DataAccessLayer.infrastructures;
using TestNetCore.DataAccessLayer.repositories;
using TestNetCore.Model.Models;

namespace ConsoleApp1
{
    public class Program
    {
        public static IDBFactory dBFactory;
        public static IPersSonRepository personRepository;
        public static IUnitOfWork unitOfWork;
        public static IEnumerable<Persons> listResult;
        public static void  Initialize()
        {
            dBFactory = new DBFactory();
            personRepository = new PersonRepository(dBFactory);
            unitOfWork = new UnitOfWork(dBFactory);

            listResult = personRepository.GetAll();
        }
    
        static void Main(string[] args)
        {
            Initialize();

            foreach (var item in listResult)
            {
                Console.WriteLine("My FullName:{0}-{1}\n\r",item.FirstName,item.LastName);
                Console.WriteLine("My Address:{0} \n\r", item.Address);
                Console.WriteLine("Message: {0}", item.Message);

            }

            Console.ReadKey();
        }
    }
}
