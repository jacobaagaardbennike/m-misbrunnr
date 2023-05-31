using ServicePortalen_CVR_1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPP.Models;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace ServicePortalen_CVR_1.Services
{
    class Aws : IConvertAddress
    {
        private List<Address> addresses;
        public Aws()
        {
            this.addresses = new List<Address>();
        }

        public IEnumerable<Address> GetAdresses(string streetCode, string municipalityCode, string streetBuildingIdentifier)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 20, 0);
                httpClient.BaseAddress = new Uri("https://dawa.aws.dk/");
                string query = "vejkode=" + streetCode + "&kommunekode=" + municipalityCode + "&husnr=" + streetBuildingIdentifier;
                string url = "adresser" + (query.Length == 0 ? "" : "?") + query;
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                dynamic adresser = JArray.Parse(responseBody);

                foreach (dynamic adresse in adresser)
                {
                    addresses.Add(new Address()
                    {
                        Street = adresse.adgangsadresse.vejstykke.navn + " " + adresse.adgangsadresse.husnr + " " + adresse.etage + adresse.dør,
                        City = adresse.adgangsadresse.postnummer.navn,
                        PostalCode = adresse.adgangsadresse.postnummer.nr
                    });
                }
                int temp;
                if (addresses.Count == 0 && streetBuildingIdentifier.Any(p => char.IsLetter(p)))
                {
                    GetAdresses(streetCode, municipalityCode, Regex.Replace(streetBuildingIdentifier, "[^0-9.]", ""));
                }
                return addresses;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }
    }
}
