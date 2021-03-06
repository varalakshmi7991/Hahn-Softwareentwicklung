﻿using Hahn.ApplicatonProcess.December2020.Domain.Business.Services.Interfaces;
using Hahn.ApplicatonProcess.December2020.Domain.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Business.Services
{
    public class ApplicantRepository : IApplicantRepository
    {
        private ApplicationContext myApplicationContext;
        public ApplicantRepository(ApplicationContext applicationContext)
        {
            myApplicationContext = applicationContext;
        }

        public async Task AddApplicant(Applicant applicant)
        {
            await myApplicationContext.Applicants.Add(applicant).ReloadAsync();
            await myApplicationContext.SaveChangesAsync();
        }

        public async Task DeleteApplicant(int id)
        {
            var applicantToBeRemoved = await myApplicationContext.Applicants.Where(a => a.ID == id).FirstOrDefaultAsync();
            myApplicationContext.Applicants.RemoveRange(applicantToBeRemoved);
            await myApplicationContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Applicant>> GetAllApplicants()
        {
            return await myApplicationContext.Applicants.ToListAsync();
        }

        public async Task<Applicant> GetApplicant(int id)
        {
            return await myApplicationContext.Applicants.Where(a => a.ID == id).FirstOrDefaultAsync();
        }

        public async Task ModifyApplicant(Applicant applicant, int id)
        {
            var applicantToBeUpdated = await myApplicationContext.Applicants.Where(a => a.ID == id).FirstOrDefaultAsync();
            if(applicantToBeUpdated == null)
            {
                throw new Exception("Applicant Not found");
            }
            applicantToBeUpdated.Name = applicant.Name;
            applicantToBeUpdated.Address = applicant.Address;
            applicantToBeUpdated.FamilyName = applicant.FamilyName;
            applicantToBeUpdated.CountryOfOrigin = applicant.CountryOfOrigin;
            applicantToBeUpdated.EmailAddress = applicant.EmailAddress;
            applicantToBeUpdated.Age = applicant.Age;
            applicantToBeUpdated.Hired = applicant.Hired;
            await myApplicationContext.SaveChangesAsync();
        }
    }
}
