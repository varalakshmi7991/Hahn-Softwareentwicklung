using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Domain.Data.Models;

namespace Hahn.ApplicatonProcess.December2020.Domain.Data.Validators
{
    public class ApplicantValidator: AbstractValidator<Applicant>
    {
        public ApplicantValidator()
        {
            RuleFor(applicant => applicant.Name).MinimumLength(5);
            RuleFor(applicant => applicant.FamilyName).MinimumLength(5);
            RuleFor(applicant => applicant.Address).MinimumLength(10);
            RuleFor(applicant => applicant.Age).InclusiveBetween(20, 60);
            RuleFor(applicant => applicant.Hired).NotNull();
            RuleFor(applicant => applicant.EMailAdress).EmailAddress();
            RuleFor(applicant => applicant.CountryOfOrigin).NotNull();
        }
    }
}
