using KwikMedicalResponseCenter.PatientCallCenter.Database;
using KwikMedicalResponseCenter.PatientCallCenter.Database.DataModels;
using KwikMedicalResponseCenter.PatientCallCenter.Enums;
using KwikMedicalResponseCenter.PatientCallCenter.Presentation;
using KwikMedicalResponseCenter.SharedResources;
using KwikMedicalResponseCenter.SharedResources.SharedDataStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalResponseCenter.PatientCallCenter.Application
{
    internal class RequestResolver
    {
        // Checking the parameters is handled in presentation layer and
        // therefore will not be done here, due to time critical nature 

        private Request request;
        private SeverityAllocator sevAllocator;
        private DB db;
        private NHSDB nHSdb;

        public RequestResolver(Req req, SeverityAllocator sevAllocator, NHSDB nHSdb)
        {
        this.nHSdb = nHSdb;
        this.request = new Request(req, nHSdb);
        this.sevAllocator = sevAllocator;

        }

        public void HandleRequest()
        {         
                try
                {
                if (!this.AllocateSeverity())
                {
                    throw new NoSeverityAllocated();
                }
                }
                catch(Exception e)
                {
                    throw e;
                }
            return;
        }
        public bool AllocateSeverity()
        {
            
                if (request.Severity != Severity.NO_ALLOCATED)
                {
                    request.manualSeverity = true;
                    return true;
                }
                request.Severity = sevAllocator.Allocate();
                return request.Severity != Severity.NO_ALLOCATED;     
        }
    }
}
