using KwikMedical.PatientCallCenter.Constants;
using KwikMedical.PatientCallCenter.Database.DataModels;
using KwikMedical.PatientCallCenter.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedical.PatientCallCenter.Application
{

    //To allocate the severity message will be analysed to look for keywords using
    //a system similar to this https://www.londonambulance.nhs.uk/calling-us/ambulance-response-categories/
    //It is not exhaustive list and different strategies to allocate severity could and should be investigated
    // for a full application

    
    internal class SeverityAllocator
    {

        private string message;
        private  string condition;

        public SeverityAllocator(string message, string condition = "")
        {
            //Setting to lower case to improve dictionary matches
            this.message = message.ToLower();
            this.condition = condition.ToLower();
        }
        public Severity Allocate()
        {
            if(MedicalConditionLibrary.MedicalConditionsWithSev.ContainsKey(this.condition))
            {
                return MedicalConditionLibrary.MedicalConditionsWithSev[this.condition];
            }
            if(this.containsKeywords(SeverityKeywords.Extreme))
            {
                return Severity.EXTREME;
            }
            else if(this.containsKeywords(SeverityKeywords.Major))
            {
                return Severity.MAJOR;
            }
            else if(this.containsKeywords(SeverityKeywords.Moderate))
            {
                return Severity.MODERATE;
            }
            else if(this.containsKeywords(SeverityKeywords.Minor))
            {
                return Severity.MINOR;
            }
            return Severity.NO_ALLOCATED;
        }

        private bool containsKeywords(string[] keywords)
        {
            foreach (string keyword in keywords)
            {
                if(this.message.Contains(keyword))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
