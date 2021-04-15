using MVCPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPOC.Repository
{
   public interface IApplicantTypeRepository
    {
        IEnumerable<ApplicantType> GetAllApplicantType();
        ApplicantType GetApplicantType(ApplicantType at);
        ApplicantType GetApplicantTypeById(int id);


    }
}
