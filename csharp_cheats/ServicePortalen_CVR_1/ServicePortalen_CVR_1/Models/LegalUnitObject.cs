using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPP.Models
{
    public class LegalUnitObject
    {
        public string LegalUnit_name {get; set;}
        public string LegalUnit_identifier { get; set; }
        public string LegalUnit_careOfName { get; set; }
        public string LegalUnit_streetName { get; set; }
        public string LegalUnit_streetBuildingIdentifier { get; set; }
        public string LegalUnit_floorIdentifier { get; set; }
        public string LegalUnit_suiteIdentifier { get; set; }
        public string LegalUnit_districtSubdivisionIdentifier { get; set; }
        public string LegalUnit_postCodeIdentifier { get; set; }
        public string LegalUnit_districtName { get; set; }
        public string LegalUnit_telephoneNumber { get; set; }
        public string LegalUnit_email { get; set; }
        public string LegalUnit_addressLine01Concatted { get; set; }
        public string LegalUnit_addressLine02Concatted { get; set; }
        public string LegalUnit_addressLine03Concatted { get; set; }


        public LegalUnitObject()
        { }

        public LegalUnitObject(string legalUnit_name, string legalUnit_identifier, string legalUnit_careOfName, string legalUnit_streetName,
            string legalUnit_streetBuildingIdentifier, string legalUnit_floorIdentifier, string legalUnit_suiteIdentifier,
            string legalUnit_districtSubdivisionIdentifier, string legalUnit_postCodeIdentifier, string legalUnit_districtName,
            string legalUnit_telephoneNumber, string legalUnit_email,
            string legalUnit_addressLine01Concatted,  string legalUnit_addressLine02Concatted, string legalUnit_addressLine03Concatted)
        {
            LegalUnit_name = legalUnit_name;
            LegalUnit_identifier = legalUnit_identifier;
            LegalUnit_careOfName = legalUnit_careOfName;
            LegalUnit_streetName = legalUnit_streetName;
            LegalUnit_streetBuildingIdentifier = legalUnit_streetBuildingIdentifier;
            LegalUnit_floorIdentifier = legalUnit_floorIdentifier;
            LegalUnit_suiteIdentifier = legalUnit_suiteIdentifier;
            LegalUnit_districtSubdivisionIdentifier = legalUnit_districtSubdivisionIdentifier;
            LegalUnit_postCodeIdentifier = legalUnit_postCodeIdentifier;
            LegalUnit_districtName = legalUnit_districtName;
            LegalUnit_telephoneNumber = legalUnit_telephoneNumber;
            LegalUnit_email = legalUnit_email;
            LegalUnit_addressLine01Concatted = legalUnit_addressLine01Concatted;
            LegalUnit_addressLine02Concatted = legalUnit_addressLine02Concatted;
            LegalUnit_addressLine03Concatted = legalUnit_addressLine03Concatted;
        }
    }
}