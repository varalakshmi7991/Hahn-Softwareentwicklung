using Hahn.ApplicatonProcess.December2020.Domain.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.December2020.Web.Swagger.Examples
{
    public class ApplicantRequestExamples : IExamplesProvider<Applicant>
    {
        public Applicant GetExamples()
        {
            return new Applicant { ID = 1, Name = "TestApplicant1", Address = "TestAddress1", Age = 20, CountryOfOrigin = "India", EMailAdress = "TestApplicant1@yopmail.com", FamilyName = "TestFamilyName1", Hired = true };
        }
    }

    public class ApplicantResponseExamples : IExamplesProvider<IEnumerable<Applicant>>
    {
        public IEnumerable<Applicant> GetExamples()
        {
            return new List<Applicant>
            {
               new Applicant { ID = 1, Name = "TestApplicant1", Address = "TestAddress1", Age = 20, CountryOfOrigin = "India", EMailAdress = "TestApplicant1@yopmail.com", FamilyName = "TestFamilyName1", Hired = true },
               new Applicant { ID = 2, Name = "TestApplicant2", Address = "TestAddress2", Age = 59, CountryOfOrigin = "Germany", EMailAdress = "TestApplicant2@yopmail.com", FamilyName = "TestFamilyName2", Hired = true }
            };
        }
    }
}
