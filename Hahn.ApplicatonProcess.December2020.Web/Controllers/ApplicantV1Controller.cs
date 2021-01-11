using Hahn.ApplicatonProcess.December2020.Domain.Business.Services.Interfaces;
using Hahn.ApplicatonProcess.December2020.Domain.Data.Models;
using Hahn.ApplicatonProcess.December2020.Web.Helpers;
using Hahn.ApplicatonProcess.December2020.Web.Swagger.Examples;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Net;
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
        private IApplicantRepository myApplicantRepository;
        private CountryValidator myCountryValidator;
        public ApplicantV1Controller(IApplicantRepository applicantRepository, CountryValidator countryValidator)
        {
            myApplicantRepository = applicantRepository;
            myCountryValidator = countryValidator;
        }
        /// <summary>
        /// Get the Applicants by Id
        /// </summary>
        /// <param name="id" example="123">The product id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerResponse(200, "The list of countries", typeof(IEnumerable<Applicant>))]
        public async Task<IActionResult> GetApplicantDetails(int id)
        {
            return Ok(await myApplicantRepository.GetApplicant(id).ConfigureAwait(false));
        }
        /// <summary>
        /// Add a new Applicant to the application
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [SwaggerRequestExample(typeof(Applicant), typeof(ApplicantRequestExamples))]
        public async Task<IActionResult> AddApplicants([FromBody] Applicant applicant)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            else if (!await myCountryValidator.IsCountryValid(applicant.CountryOfOrigin))
            {
                return BadRequest("Invalid CountryName");
            }
            else
            {
                await myApplicantRepository.AddApplicant(applicant).ConfigureAwait(false);
                return Created(new Uri($"https://localhost:5001/api/ApplicantV1/{applicant.ID}"), applicant);
            }
        }
        /// <summary>
        /// Update the applicant's data by Id
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplicants([FromBody] Applicant applicant, int id)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            else if (!await myCountryValidator.IsCountryValid(applicant.CountryOfOrigin))
            {
                return BadRequest("Invalid CountryName");
            }
            else
            {
                await myApplicantRepository.ModifyApplicant(applicant, id).ConfigureAwait(false);
                return Ok();
            }
        }
        /// <summary>
        /// Delete the applicants by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicants(int id)
        {
            await myApplicantRepository.DeleteApplicant(id).ConfigureAwait(false);
            return Ok();
        }
    }
}
