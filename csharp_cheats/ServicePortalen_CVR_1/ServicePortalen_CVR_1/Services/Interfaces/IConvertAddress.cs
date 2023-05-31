using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPP.Models;

namespace ServicePortalen_CVR_1.Services.Interfaces
{
    interface IConvertAddress
    {
        IEnumerable<Address> GetAdresses(string streetCode, string municipalityCode, string streetBuildingIdentifier);
    }
}
