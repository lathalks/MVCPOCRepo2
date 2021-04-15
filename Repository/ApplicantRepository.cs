using MVCPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPOC.Repository
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly SampleContext sampleContext = null;
        public ApplicantRepository(SampleContext sc)
        {
            sampleContext = sc;
        }
        public int CreateApplicant(Applicant newApplicant)
        {
            sampleContext.Applicants.Add(newApplicant);
            sampleContext.SaveChanges();
            return newApplicant.Id;
        }

        public IEnumerable<Applicant> GetAllApplicant()
        {
            throw new NotImplementedException();
        }

        public Applicant GetApplicant(Applicant at)
        {
            Applicant app = sampleContext.Applicants.Where(q => q.Password == at.Password.Trim() && q.Username==at.Username.Trim() && q.TypeId==at.TypeId).Single();
            return app;
        }

        public Applicant GetApplicantById(int id)
        {
            Applicant app = sampleContext.Applicants.Where(q => q.Id == id).SingleOrDefault();
            return app;
        }
        public void UpdateApplicant(Applicant updtApplicant)
        {
            sampleContext.Applicants.Update(updtApplicant);
            sampleContext.SaveChanges();
        }
    }
}
