using KwikMedicalResponseCenter.SharedResources.SharedDataStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalResponseCenter.SharedResources
{
    // In a non prototype application this would host authentication, authorization,
    // data sanitisation calls and similar to protect integrity of NHS database
    public  class NHSDatabaseConnector
    {
        public static NHSDB database = new NHSDB();
    }
}
