using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TampaInnovation.DataAccess;
using TampaInnovation.GimmeServices.Models;
using TampaInnovation.Models;
using Address = TampaInnovation.GimmeServices.Models.Address;

namespace TampaInnovation.TempIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                
            }
        }

        private static void GetDataFromFile()
        {
            string directory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\", "SampleData"));

            string file = Path.Combine(directory, "providers.txt");
            List<Provider> providers = JsonConvert.DeserializeObject<List<Provider>>(File.ReadAllText(file));

            file = Path.Combine(directory, "addresses.txt");
            List<Address> addresses = JsonConvert.DeserializeObject<List<Address>>(File.ReadAllText(file));
            addresses.ForEach(t =>
            {
                var provider = t.Provider.Replace(" ", "").Replace("INACTIVE", "").ToLower();
                if (provider.StartsWith("-"))
                    provider = provider.Substring(1, provider.Length - 1);
                t.Provider = provider;
            });

            file = Path.Combine(directory, "bedunitinventory.txt");
            List<BedUnitInventory> bedUnitInventories = JsonConvert.DeserializeObject<List<BedUnitInventory>>(File.ReadAllText(file));

            bedUnitInventories.ForEach(t => t.Provider = t.Provider.Replace(" ", ""));

            file = Path.Combine(directory, "contactnumbers.txt");
            List<ContactNumber> contactNumbers = JsonConvert.DeserializeObject<List<ContactNumber>>(File.ReadAllText(file));
            contactNumbers.ForEach(t => t.Provider = t.Provider.Replace(" ", ""));

            file = Path.Combine(directory, "services.txt");
            List<GimmeServices.Models.Services> services = JsonConvert.DeserializeObject<List<GimmeServices.Models.Services>>(File.ReadAllText(file));
            services.ForEach(t => t.Provider = t.Provider.Replace(" ", "").Replace("INACTIVE", ""));

            using (ApplicationContext context = new ApplicationContext())
            {
                foreach (Provider provider in providers)
                {
                    ProviderResult providerResult = new ProviderResult
                    {
                        Name = provider.Name,
                        OperationHours = "08:00 am - 05:00 pm"
                    };
                    var initialCharacters = provider.Name.Replace(" ", "").ToLower();
                    if (initialCharacters.Length > 20)
                        initialCharacters = initialCharacters.Substring(0, 20);

                    BedUnitInventory bedUnit = bedUnitInventories.FirstOrDefault(t => t.Provider.StartsWith(initialCharacters, StringComparison.OrdinalIgnoreCase));

                    if (bedUnit != null)
                    {
                        providerResult.AvailableUnits = bedUnit.UnitInventory;
                        providerResult.TotalUnits = bedUnit.BedInventory;
                    }

                    List<Address> gimmeAddress = addresses.Where(t => t.Provider.StartsWith(initialCharacters, StringComparison.OrdinalIgnoreCase) && t.Active.Equals("yes", StringComparison.OrdinalIgnoreCase) &&
                                                                      !string.IsNullOrEmpty(t.Latitude) && !string.IsNullOrEmpty(t.Longitude)).ToList();

                    if (!gimmeAddress.Any())
                        continue;

                    foreach (Address address1 in gimmeAddress)
                    {
                        double latitude;
                        double longitude;
                        double.TryParse(address1.Latitude, out latitude);
                        double.TryParse(address1.Longitude, out longitude);
                        Models.Address address = new Models.Address
                        {
                            Latitude = latitude,
                            Longitude = longitude,
                            Landmarks = address1.Landmarks,
                            AddressType = address1.AddressType,
                            State = address1.State,
                            City = address1.City,
                            ZipCode = address1.ZipCode,
                            Additional = address1.Additional,
                            StreetAddress = address1.StreetAddress,
                            Country = address1.Country
                        };
                        providerResult.Addresses.Add(address);
                    }

                    List<ContactNumber> gimmeContacts = contactNumbers.Where(t => t.Provider.StartsWith(initialCharacters, StringComparison.OrdinalIgnoreCase)).ToList();

                    foreach (ContactNumber contactNumber in gimmeContacts)
                    {
                        ContactInformation contact = new ContactInformation
                        {
                            Name = contactNumber.Name,
                            Number = contactNumber.Number,
                            Extension = contactNumber.TelephoneExtension
                        };

                        providerResult.ContactInformations.Add(contact);
                    }

                    List<GimmeServices.Models.Services> gimmeServices = services.Where(t => t.Provider.StartsWith(initialCharacters, StringComparison.OrdinalIgnoreCase)).ToList();

                    foreach (GimmeServices.Models.Services service in gimmeServices)
                    {
                        providerResult.ProvidedServices.Add(new Models.Services
                        {
                            Name = service.Name
                        });
                    }

                    context.ProviderResult.Add(providerResult);
                }
                context.SaveChanges();
            }
        }
    }
}