using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePortalen_CVR_1.Models
{
    public class ProductionUnitObject
    {
        public string ProductionUnit_name { get; set; }
        public string ProductionUnit_identifier { get; set; }
        public string ProductionUnit_legalUnitIdentifier { get; set; }
        public string ProductionUnit_careOfName { get; set; }
        public string ProductionUnit_streetName { get; set; }
        public string ProductionUnit_streetBuildingIdentifier { get; set; }
        public string ProductionUnit_floorIdentifier { get; set; }
        public string ProductionUnit_suiteIdentifier { get; set; }
        public string ProductionUnit_districtSubdivisionIdentifier { get; set; }
        public string ProductionUnit_postCodeIdentifier { get; set; }
        public string ProductionUnit_districtName { get; set; }
        public string ProductionUnit_telephoneNumber { get; set; }
        public string ProductionUnit_email { get; set; }
        public string ProductionUnit_addressLine01Concatted { get; set; }
        public string ProductionUnit_addressLine02Concatted { get; set; }
        public string ProductionUnit_addressLine03Concatted { get; set; }


        public ProductionUnitObject()
        { }

        public ProductionUnitObject(string productionUnit_name, string productionUnit_identifier, 
            string productionUnit_legalUnitIdentifier, string productionUnit_careOfName, string productionUnit_streetName,
            string productionUnit_streetBuildingIdentifier, string productionUnit_floorIdentifier, string productionUnit_suiteIdentifier,
            string productionUnit_districtSubdivisionIdentifier, string productionUnit_postCodeIdentifier, string productionUnit_districtName,
            string productionUnit_telephoneNumber, string productionUnit_email,
            string productionUnit_addressLine01Concatted, string productionUnit_addressLine02Concatted, string productionUnit_addressLine03Concatted)
        {
            ProductionUnit_name = productionUnit_name;
            ProductionUnit_identifier = productionUnit_identifier;
            ProductionUnit_legalUnitIdentifier = productionUnit_legalUnitIdentifier;
            ProductionUnit_careOfName = productionUnit_careOfName;
            ProductionUnit_streetName = productionUnit_streetName;
            ProductionUnit_streetBuildingIdentifier = productionUnit_streetBuildingIdentifier;
            ProductionUnit_floorIdentifier = productionUnit_floorIdentifier;
            ProductionUnit_suiteIdentifier = productionUnit_suiteIdentifier;
            ProductionUnit_districtSubdivisionIdentifier = productionUnit_districtSubdivisionIdentifier;
            ProductionUnit_postCodeIdentifier = productionUnit_postCodeIdentifier;
            ProductionUnit_districtName = productionUnit_districtName;
            ProductionUnit_telephoneNumber = productionUnit_telephoneNumber;
            ProductionUnit_email = productionUnit_email;
            ProductionUnit_addressLine01Concatted = productionUnit_addressLine01Concatted;
            ProductionUnit_addressLine02Concatted = productionUnit_addressLine02Concatted;
            ProductionUnit_addressLine03Concatted = productionUnit_addressLine03Concatted;
        }
    }
}
