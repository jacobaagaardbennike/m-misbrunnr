using ServicePortalen_CVR_1.CvrService;
using ServicePortalen_CVR_1.Models;
using ServicePortalen_CVR_1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebAPP.Models;

namespace ServicePortalen_CVR_1
{
    public class CallService
    {

        public static ProductionUnitType GetProductionUnit(string productionUnitIdentifier)
        {
            ProductionUnitType productionUnit = null;

            try
            {
                using (CvrPortTypeClient client = new CvrPortTypeClient())
                {


                    GetProductionUnitRequestType request = new GetProductionUnitRequestType();
                    request.InvocationContext = GetInvocationContextType();
                    request.level = "3";
                    request.ProductionUnitIdentifier = productionUnitIdentifier;

                    var response = client.getProductionUnit(request);

                    productionUnit = response.ProductionUnit;
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine(ex.InnerException);
            }
            return productionUnit;
        }

        public static ProductionUnitObject GetProductionUnitObject(string productionUnitIdentifier)
        {
            ProductionUnitType productionUnit = null;
            ProductionUnitObject company = null;

            try
            {
                using (CvrPortTypeClient client = new CvrPortTypeClient())
                {


                    GetProductionUnitRequestType request = new GetProductionUnitRequestType();
                    request.InvocationContext = GetInvocationContextType();
                    request.level = "3";
                    request.ProductionUnitIdentifier = productionUnitIdentifier;

                    var response = client.getProductionUnit(request);

                    productionUnit = response.ProductionUnit;

                    if (productionUnit != null)
                    {
                        company = new ProductionUnitObject();
                        if (productionUnit.ProductionUnitName != null)
                        {
                            company.ProductionUnit_name = productionUnit.ProductionUnitName.name;
                        }
                        company.ProductionUnit_identifier = productionUnit.ProductionUnitIdentifier;
                        if (productionUnit.LegalUnitAffiliation != null)
                        {
                            company.ProductionUnit_legalUnitIdentifier = productionUnit.LegalUnitAffiliation.LegalUnitIdentifier;
                        }
                        if (productionUnit.AddressLocation != null && productionUnit.AddressLocation.AddressPostalExtended != null)
                        {
                            company.ProductionUnit_careOfName = productionUnit.AddressLocation.AddressPostalExtended.CareOfName;
                            company.ProductionUnit_streetName = productionUnit.AddressLocation.AddressPostalExtended.StreetName;
                            company.ProductionUnit_streetBuildingIdentifier = productionUnit.AddressLocation.AddressPostalExtended.StreetBuildingIdentifier;
                            company.ProductionUnit_floorIdentifier = productionUnit.AddressLocation.AddressPostalExtended.FloorIdentifier;
                            company.ProductionUnit_suiteIdentifier = productionUnit.AddressLocation.AddressPostalExtended.SuiteIdentifier;
                            company.ProductionUnit_districtSubdivisionIdentifier = productionUnit.AddressLocation.AddressPostalExtended.DistrictSubdivisionIdentifier;
                            company.ProductionUnit_postCodeIdentifier = productionUnit.AddressLocation.AddressPostalExtended.PostCodeIdentifier;
                            company.ProductionUnit_districtName = productionUnit.AddressLocation.AddressPostalExtended.DistrictName;
                        }


                        if (productionUnit.ContactInformation != null && productionUnit.ContactInformation.Telephone != null)
                        {
                            company.ProductionUnit_telephoneNumber = productionUnit.ContactInformation.Telephone.TelephoneNumberIdentifier;
                        }
                        if (productionUnit.ContactInformation != null && productionUnit.ContactInformation.Email != null)
                        {
                            company.ProductionUnit_email = productionUnit.ContactInformation.Email.EmailAddressIdentifier;
                        }

                        company.ProductionUnit_addressLine01Concatted = GetProductionUnit_addressLine01Concatted(company);
                        company.ProductionUnit_addressLine02Concatted = GetProductionUnit_addressLine02Concatted(company);
                        company.ProductionUnit_addressLine03Concatted = GetProductionUnit_addressLine03Concatted(company);
                    }


                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine(ex.InnerException);
            }
            return company;
        }


        public static LegalUnitType GetLegalUnit(string legalUnitIdentifier)
        {
            LegalUnitType legalUnit = null;

            try
            {
                using (CvrPortTypeClient client = new CvrPortTypeClient())
                {


                    GetLegalUnitRequestType request = new GetLegalUnitRequestType();
                    request.InvocationContext = GetInvocationContextType();
                    request.level = "3";
                    request.LegalUnitIdentifier = legalUnitIdentifier;

                    var response = client.getLegalUnit(request);
                    legalUnit = response.LegalUnit;
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine(ex.InnerException);
            }
            return legalUnit;
        }

        public static LegalUnitObject GetLegalUnitObject(string legalUnitIdentifier)
        {
            LegalUnitType legalUnit = null;
            LegalUnitObject company = null;

            try
            {
                using (CvrPortTypeClient client = new CvrPortTypeClient())
                {


                    GetLegalUnitRequestType request = new GetLegalUnitRequestType();
                    request.InvocationContext = GetInvocationContextType();
                    request.level = "3";
                    request.LegalUnitIdentifier = legalUnitIdentifier;

                    var response = client.getLegalUnit(request);
                    legalUnit = response.LegalUnit;

                    if (legalUnit != null)
                    {
                        company = new LegalUnitObject();
                        if (legalUnit.LegalUnitName != null)
                        {
                            company.LegalUnit_name = legalUnit.LegalUnitName.name;
                        }
                        company.LegalUnit_identifier = legalUnit.LegalUnitIdentifier;
                        if (legalUnit.AddressOfficial != null && legalUnit.AddressOfficial.AddressPostalExtended != null)
                        {
                            company.LegalUnit_careOfName = legalUnit.AddressOfficial.AddressPostalExtended.CareOfName;
                            company.LegalUnit_streetName = legalUnit.AddressOfficial.AddressPostalExtended.StreetName;
                            company.LegalUnit_streetBuildingIdentifier = legalUnit.AddressOfficial.AddressPostalExtended.StreetBuildingIdentifier;
                            company.LegalUnit_floorIdentifier = legalUnit.AddressOfficial.AddressPostalExtended.FloorIdentifier;
                            company.LegalUnit_suiteIdentifier = legalUnit.AddressOfficial.AddressPostalExtended.SuiteIdentifier;
                            company.LegalUnit_districtSubdivisionIdentifier = legalUnit.AddressOfficial.AddressPostalExtended.DistrictSubdivisionIdentifier;
                            company.LegalUnit_postCodeIdentifier = legalUnit.AddressOfficial.AddressPostalExtended.PostCodeIdentifier;
                            company.LegalUnit_districtName = legalUnit.AddressOfficial.AddressPostalExtended.DistrictName;
                        }


                        if (legalUnit.ContactInformation != null && legalUnit.ContactInformation.Telephone != null)
                        {
                            company.LegalUnit_telephoneNumber = legalUnit.ContactInformation.Telephone.TelephoneNumberIdentifier;
                        }
                        if (legalUnit.ContactInformation != null && legalUnit.ContactInformation.Email != null)
                        {
                            company.LegalUnit_email = legalUnit.ContactInformation.Email.EmailAddressIdentifier;
                        }

                        company.LegalUnit_addressLine01Concatted = GetLegalUnit_addressLine01Concatted(company);
                        company.LegalUnit_addressLine02Concatted = GetLegalUnit_addressLine02Concatted(company);
                        company.LegalUnit_addressLine03Concatted = GetLegalUnit_addressLine03Concatted(company);
                    }

                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine(ex.InnerException);
            }
            return company;
        }

        private static string GetProductionUnit_addressLine01Concatted(ProductionUnitObject company)
        {
            string addressLine01Concatted = "";

            if (company != null)
            {
                if (company.ProductionUnit_name != null)
                {
                    addressLine01Concatted = company.ProductionUnit_name;
                }
                if (company.ProductionUnit_careOfName != null)
                {
                    addressLine01Concatted = addressLine01Concatted + ", c/o " + company.ProductionUnit_careOfName;
                }
            }
            return addressLine01Concatted;
        }


        private static string GetProductionUnit_addressLine02Concatted(ProductionUnitObject company)
        {
            string addressLine02Concatted = "";

            if (company != null)
            {
                if (company.ProductionUnit_streetName != null)
                {
                    addressLine02Concatted = company.ProductionUnit_streetName;
                }
                if (company.ProductionUnit_streetBuildingIdentifier != null)
                {
                    addressLine02Concatted = addressLine02Concatted + " " + company.ProductionUnit_streetBuildingIdentifier;
                }
                if (company.ProductionUnit_floorIdentifier != null)
                {
                    addressLine02Concatted = addressLine02Concatted + " " + company.ProductionUnit_floorIdentifier;
                }
                if (company.ProductionUnit_suiteIdentifier != null)
                {
                    addressLine02Concatted = addressLine02Concatted + " " + company.ProductionUnit_suiteIdentifier;
                }
                if (company.ProductionUnit_districtSubdivisionIdentifier != null)
                {
                    addressLine02Concatted = addressLine02Concatted + ", " + company.ProductionUnit_districtSubdivisionIdentifier;
                }
            }
            return addressLine02Concatted;
        }

        private static string GetProductionUnit_addressLine03Concatted(ProductionUnitObject company)
        {
            string addressLine03Concatted = "";

            if (company != null)
            {
                if (company.ProductionUnit_postCodeIdentifier != null)
                {
                    addressLine03Concatted = company.ProductionUnit_postCodeIdentifier;
                }
                if (company.ProductionUnit_districtName != null)
                {
                    addressLine03Concatted = addressLine03Concatted + " " + company.ProductionUnit_districtName;
                }
            }

            return addressLine03Concatted;
        }

        private static string GetLegalUnit_addressLine01Concatted(LegalUnitObject company)
        {
            string addressLine01Concatted = "";

            if (company != null)
            {
                if (company.LegalUnit_name != null)
                {
                    addressLine01Concatted = company.LegalUnit_name;
                }
                if (company.LegalUnit_careOfName != null)
                {
                    addressLine01Concatted = addressLine01Concatted + ", c/o " + company.LegalUnit_careOfName;
                }
            }
            return addressLine01Concatted;
        }

        private static string GetLegalUnit_addressLine03Concatted(LegalUnitObject company)
        {
            string addressLine03Concatted = "";

            if (company != null)
            {
                if (company.LegalUnit_postCodeIdentifier != null)
                {
                    addressLine03Concatted = company.LegalUnit_postCodeIdentifier;
                }
                if (company.LegalUnit_districtName != null)
                {
                    addressLine03Concatted = addressLine03Concatted + " " + company.LegalUnit_districtName;
                }
            }

            return addressLine03Concatted;
        }

        private static string GetLegalUnit_addressLine02Concatted(LegalUnitObject company)
        {
            string addressLine02Concatted = "";

            if (company != null )
            {
                if (company.LegalUnit_streetName != null)
                {
                    addressLine02Concatted = company.LegalUnit_streetName;
                }
                if (company.LegalUnit_streetBuildingIdentifier != null)
                {
                    addressLine02Concatted = addressLine02Concatted + " " + company.LegalUnit_streetBuildingIdentifier;
                }
                if (company.LegalUnit_floorIdentifier != null)
                {
                    addressLine02Concatted = addressLine02Concatted + " " + company.LegalUnit_floorIdentifier;
                }
                if (company.LegalUnit_suiteIdentifier != null)
                {
                    addressLine02Concatted = addressLine02Concatted + " " + company.LegalUnit_suiteIdentifier;
                }
                if (company.LegalUnit_districtSubdivisionIdentifier != null)
                {
                    addressLine02Concatted = addressLine02Concatted + ", " + company.LegalUnit_districtSubdivisionIdentifier;
                }
            }
            return addressLine02Concatted;
        }


        private CallContextType GetCallContextType()
        {
            return new CallContextType()
            {
                AccountingInfo = "",
                CallersServiceCallIdentifier = "",
                OnBehalfOfUser = ""
            };
        }


        private static InvocationContextType GetInvocationContextType()
        {
            return new InvocationContextType()
            {
                //Serviceaftale UUID
                ServiceAgreementUUID = "", //Properties.Settings.Default.serviceAgreementUUID, //
                //System UUID
                UserSystemUUID = "", //Properties.Settings.Default.userSystemUUID, //
                //Kommune UUID
                UserUUID = "", //Properties.Settings.Default.userUUID, //
                //Servicenavn
                ServiceUUID = "" //Properties.Settings.Default.serviceUUID //
            };
        }

        public string GetCertificates_currentUser()
        {
            X509Store Store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            Store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection CertColl = Store.Certificates.Find(X509FindType.FindBySubjectKeyIdentifier, "", true);
            List<string> list = new List<string>();

            foreach (X509Certificate2 Cert in CertColl)
            {
                list.Add("Cert: " + Cert.IssuerName.Name + " " + Cert.SerialNumber);
                //Console.WriteLine("Cert: " + Cert.IssuerName.Name);
            }
            return "CurrentUser: " + list.Count().ToString();
        }

        public string GetCertificates_localMachine()
        {
            X509Store Store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            Store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection CertColl = Store.Certificates.Find(X509FindType.FindBySubjectKeyIdentifier, "", true);
            List<string> list = new List<string>();

            foreach (X509Certificate2 Cert in CertColl)
            {
                list.Add("Cert: " + Cert.IssuerName.Name + " " + Cert.SerialNumber);
                //Console.WriteLine("Cert: " + Cert.IssuerName.Name);
            }
            return "LocalMachine: " + list.Count().ToString();
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

