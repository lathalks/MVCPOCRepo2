using MVCPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPOC.Repository
{
    public class ApplicantTypeRepository : IApplicantTypeRepository
    {
        private readonly SampleContext sampleContext = null;
        public ApplicantTypeRepository(SampleContext sc)
        {
            sampleContext = sc;
        }
        IEnumerable<ApplicantType> IApplicantTypeRepository.GetAllApplicantType()
        {
            return sampleContext.ApplicantTypes;
        }

        ApplicantType IApplicantTypeRepository.GetApplicantType(ApplicantType at)
        {
            ApplicantType appType= sampleContext.ApplicantTypes.Where(q => q.Id == at.Id && q.TypeName.Contains(at.TypeName)).SingleOrDefault();
            return appType;
        }
        ApplicantType IApplicantTypeRepository.GetApplicantTypeById(int id)
        {
            ApplicantType appType = sampleContext.ApplicantTypes.Where(q => q.Id == id).SingleOrDefault();
            return appType;
        }
    }
}
