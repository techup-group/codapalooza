using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TampaInnovation.GimmeServices;
using TampaInnovation.GimmeServices.Business;
using TampaInnovation.GimmeServices.Models;
using TampaInnovation.Models;
using Address = TampaInnovation.Models.Address;

namespace TampaInnovation.Business
{
    public class ResourcesServices
    {
        public static List<ServiceGeography> TestCall()
        {
            GimmeshelterClient client = new GimmeshelterClient();
            client.GetAddress<List<Address>>();
            client.GetAreasServed<List<AreaServered>>();
            client.GetBedUnitInventory<List<BedUnitInventory>>();
            client.GetContactNumbers<List<ContactNumber>>();
            client.GetGeography<List<Geography>>(33607);
            client.GetServices<List<Services>>();
            client.GetProviders<List<Provider>>();
            return client.GetServicesGeography<List<ServiceGeography>>(33607);
        }

        public static List<ProviderWrapper> Search(string query, int? range, int? limit)
        {
            return new List<ProviderWrapper>
            {
                new ProviderWrapper
                {
                    Distance = 1.1,
                    Providers = new ProviderResult
                    {
                        ContactInformations = new List<ContactInformation>
                        {
                            new ContactInformation
                            {
                                ContactType = "Phone",
                                IsActive = true,
                                Number = "(813) 375-3933"
                            },
                            new ContactInformation
                            {
                                ContactType = "Fax",
                                IsActive = true,
                                Number = "(813) 375-3933"
                            }
                        },
                        Addresses = new List<Address>
                        {
                            new Address
                            {
                                IsActive = true,
                                Additional = "",
                                AddressType = "Physical",
                                City = "Tampa",
                                Country = "USA",
                                Longitude = -82.45938,
                                Latitude = 27.95493,
                                State = "FL",
                                ZipCode = "33612",
                                StreetAddress = "10049 N Florida Ave"
                            }
                        },
                        ContactPeople = new List<ContactPersonnel>
                        {
                            new ContactPersonnel
                            {
                                Number = "(813) 375-3933",
                                Name = "Tomi Steinruck",
                                Title = "Program Manager, HIV/AIDS Services",
                                Email = "tsteinruck@ccdosp.org"
                            }
                        },
                        Name = "Catholic Charities - Mercy Apartments (PSH)",
                        AvailableUnits = "9",
                        OperationHours = "8:00 am - 5:00 pm",
                        ProvidedServices = new List<string>
                        {
                            "Housing",
                            "Food"
                        },
                        TotalUnits = "20"
                    }
                }
            };
        }

        public static ProviderResult Find(string providerId)
        {
            return new ProviderResult();
        }
    }
}
