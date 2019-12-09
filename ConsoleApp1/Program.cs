using System;
using System.ServiceModel;
using System.ServiceModel.Security;
using Asi.Soa.ClientServices;
using Asi.Soa.Core.DataContracts;
using Asi.Soa.Core.DataContracts.Faults;
using Asi.Soa.Membership.DataContracts;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                string userName = "manager";
                string password = "admin123!";
                var entityManager = new EntityManager(userName, password);
                var query = new QueryData("Party")
                {
                    Criteria = new CriteriaDataCollection { CriteriaData.Equal("PartyId", "101") }
                };
                var result = entityManager.Find(query);

                foreach (PartyData party in result.Result)
                {
                    Console.WriteLine("Party - Id: {0}, Name: {1}", party.PartyId, party.Name);
                }
            }
            catch (FaultException<ServiceNotAvailableFault> error)
            {
                Console.WriteLine(error.Message);
            }
            catch (MessageSecurityException)
            {
                Console.WriteLine("Invalid Credentials");
            }
            catch (Exception error)
            {
                Console.WriteLine(string.Format("Other error: {0}.", error.Message));
            }

            Console.WriteLine("done");
            Console.ReadLine();

        }
    }
}
