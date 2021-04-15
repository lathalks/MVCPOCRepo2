using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPOC.Models;
namespace MVCPOC.Repository
{
   public interface IApplicantRepository
    {
        IEnumerable<Applicant> GetAllApplicant();
        Applicant GetApplicant(Applicant at);
        Applicant GetApplicantById(int id);
        int CreateApplicant(Applicant newApplicant);

        void UpdateApplicant(Applicant updtApplicant);

    }
}
