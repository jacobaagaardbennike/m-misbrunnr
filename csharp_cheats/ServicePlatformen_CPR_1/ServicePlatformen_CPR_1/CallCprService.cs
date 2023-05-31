using ServicePlatformen_CPR_1.CPRservice_servicePortalen;
using ServicePlatformen_CPR_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServicePlatformen_CPR_1
{
    public class CallCprService
    {

        public static Person GetPersonData(string cpr)
        {
            if (cpr.Contains("-"))
            {
               cpr = cpr.Replace("-", "");
            }

            if (IsValidCpr(cpr))
            {
                using (CPRservice_servicePortalen.CPRBasicInformationWebServicePortTypeClient client = new CPRBasicInformationWebServicePortTypeClient())
                {
                    var request = new CPRBasicInformationRequestType();
                    request.InvocationContext = GetInvocationContextType();
                    request.PNR = cpr;

                    try
                    {
                        var response = client.callCPRBasicInformationService(request);

                        Person person = new Person()
                        {
                            Pnr = response.pnr,
                            Koen = response.koen.ToString(),
                            Foedselsdato = response.foedselsdato,
                            FoedselsdatoUsikkerhedsmarkering = response.foedselsdatoUsikkerhedsmarkering,
                            Status = response.status,
                            Civilstand = response.civilstand.ToString(),
                            NavneOgAdressebeskyttelse = response.navneOgAdressebeskyttelse,
                            Adresseringsnavn = response.adresseringsnavn,
                            Standardadresse = response.standardadresse,
                            Postnummer = response.postnummer,
                            Postdistrikt = response.postdistrikt,
                            Vejadresseringsnavn = response.vejadresseringsnavn,
                            Husnummer = response.husnummer,
                            Etage = response.etage,
                            Sidedoer = response.sidedoer,
                            Kommunekode = response.kommunekode,
                            Vejkode = response.vejkode,
                            Tilflytningsdato = response.tilflytningsdato,

                        };
                        return person;
                    }
                    catch (Exception e)
                    {
                        string exception = e.ToString();
                        return null;
                    }
                   


                }
            }
            else
            {
                //throw new Exception("Invalid CPR");
                return null;
            }            
        }


        public static CPRBasicInformationResponseType GetCPRBasicInformationResponseType(string cpr)
        {
            if (cpr.Contains("-"))
            {
                cpr = cpr.Replace("-", "");
            }

            if (IsValidCpr(cpr))
            {
                using (CPRservice_servicePortalen.CPRBasicInformationWebServicePortTypeClient client = new CPRBasicInformationWebServicePortTypeClient())
                {
                    var request = new CPRBasicInformationRequestType();
                    request.InvocationContext = GetInvocationContextType();
                    request.PNR = cpr;

                    try
                    {
                        var response = client.callCPRBasicInformationService(request);
                        return response;
                    }
                    catch (Exception e)
                    {
                        string exception = e.ToString();
                        return null;
                    }

                }
            }
            else
            {
                //throw new Exception("Invalid CPR");
                return null;
            }
        }

        public static string GetCPRBasicInformation_name(string cpr)
        {
            if (cpr.Contains("-"))
            {
                cpr = cpr.Replace("-", "");
            }

            if (IsValidCpr(cpr))
            {
                using (CPRservice_servicePortalen.CPRBasicInformationWebServicePortTypeClient client = new CPRBasicInformationWebServicePortTypeClient())
                {
                    var request = new CPRBasicInformationRequestType();
                    request.InvocationContext = GetInvocationContextType();
                    request.PNR = cpr;

                    try
                    {
                        var response = client.callCPRBasicInformationService(request);
                        return response.adresseringsnavn;
                    }
                    catch (Exception e)
                    {
                        string exception = e.ToString();
                        return null;
                    }

                }
            }
            else
            {
                //throw new Exception("Invalid CPR");
                return null;
            }
        }

        public static bool CPRBasicInformationPNR_isValid(string cpr)
        {
            if (cpr.Contains("-"))
            {
                cpr = cpr.Replace("-", "");
            }

            if (IsValidCpr(cpr))
            {
                using (CPRservice_servicePortalen.CPRBasicInformationWebServicePortTypeClient client = new CPRBasicInformationWebServicePortTypeClient())
                {
                    var request = new CPRBasicInformationRequestType();
                    request.InvocationContext = GetInvocationContextType();
                    request.PNR = cpr;

                    try
                    {
                        var response = client.callCPRBasicInformationService(request);
                        var name = response.adresseringsnavn;
                        if (name != null && name != string.Empty)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        string exception = e.ToString();
                        return false;
                    }

                }
            }
            else
            {
                //throw new Exception("Invalid CPR");
                return false;
            }
        }


        private static InvocationContextType GetInvocationContextType()
        {
            return new InvocationContextType()
            {
                ServiceAgreementUUID = "",  //hedder: Serviceaftale UUID på serviceplatformen
                UserSystemUUID = "",        //hedder: System UUID på serviceplatofmren
                UserUUID = "",              //hedder: Kommune UUID på serviceplatformen
                ServiceUUID = ""            //hedder: Servicenavn på serviceplatformen (den services der benyttes)
            };
        }

        private static bool IsValidCpr(string cpr)
        {
            Regex cprRegEx_IngenBindestreg = new Regex("^(?:(?:31(?:0[13578]|1[02])|(?:30|29)(?:0[13-9]|1[0-2])|(?:0[1-9]|1[0-9]|2[0-8])(?:0[1-9]|1[0-2]))[0-9]{3}|290200[4-9]|2902(?:(?!00)[02468][048]|[13579][26])[0-3])[0-9]{3}|0000000000$");
            return cprRegEx_IngenBindestreg.IsMatch(cpr);
        }

        /*
 * Retrieve a certificate from Windows LocalMachine TrustedPeople certificate store by name.
 * The name must be unique. 
 */
        public static X509Certificate2 GetCertificate_currentUser(string subjectKeyIdentifier)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);//CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindBySubjectKeyIdentifier, subjectKeyIdentifier, false);

            X509Certificate2 cert = null;
            switch (certs.Count)
            {
                case 0:
                    //throw new Exception("Certificate not Found! " + subjectKeyIdentifier);
                    break;
                case 1:
                    cert = certs[0];
                    break;
                default:
                    throw new Exception("To many certificates match: " + subjectKeyIdentifier);
            }
            return cert;
        }

        public static X509Certificate2 GetCertificate_localMachine(string subjectKeyIdentifier)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);//CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindBySubjectKeyIdentifier, subjectKeyIdentifier, false);

            X509Certificate2 cert = null;
            switch (certs.Count)
            {
                case 0:
                    //throw new Exception("Certificate not Found! " + subjectKeyIdentifier);
                    break;
                case 1:
                    cert = certs[0];
                    break;
                default:
                    throw new Exception("To many certificates match: " + subjectKeyIdentifier);
            }
            return cert;
        }
    }
}
