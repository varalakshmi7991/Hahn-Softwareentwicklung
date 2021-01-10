using Hahn.ApplicatonProcess.December2020.Domain.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Business.Services.Interfaces
{
    public interface IApplicantRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Applicant>> GetAllApplicants();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Applicant> GetApplicant(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicant"></param>
        Task AddApplicant(Applicant applicant);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicant"></param>
        /// <param name="id"></param>
        Task ModifyApplicant(Applicant applicant, int id );
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        Task DeleteApplicant(int id);

    }
}
