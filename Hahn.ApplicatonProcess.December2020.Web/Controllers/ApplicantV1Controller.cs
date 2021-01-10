using Hahn.ApplicatonProcess.December2020.Domain.Data.Models;
using Hahn.ApplicatonProcess.December2020.Web.Swagger.Examples;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    /// <summary>
    /// This controller exposes Apis related to Applicants of Hahn application
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantV1Controller : ControllerBase
    {
        /// <summary>
        /// Get the Applicants by Id
        /// </summary>
        /// <param name="id" example="123">The product id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerResponse(200, "The list of countries", typeof(IEnumerable<Applicant>))]
        public async Task<IActionResult> GetApplicants(int id)
        {
           return Ok();
        }
        /// <summary>
        /// Add a new Applicant to the application
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [SwaggerRequestExample(typeof(Applicant), typeof(ApplicantRequestExamples))]
        public async Task<IActionResult> AddApplicants([FromBody] Applicant applicant)
        {
            return Created(new Uri("/api/Applicants"), new object());
        }
        /// <summary>
        /// Update the applicant's data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplicants(int id)
        {
            return Ok();
        }
        /// <summary>
        /// Delete the applicants by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicants(int id)
        {
            return Ok();
        }
    }
}
