using System;
using System.Collections.Generic;
using csharp_contract.Models;
using csharp_contracted.Repositories;

namespace csharp_contracted.Services
{
    public class CompaniesService
    {
        private readonly CompaniesRepository _repo;
        public CompaniesService(CompaniesRepository repo)
        {
            _repo = repo;
        }

        internal List<Company> GetAll()
        {
            return _repo.GetAll();
        }

        internal Company GetById(int companyId)
        {
            Company foundCompany = _repo.GetById(companyId);
            if (foundCompany == null)
            {
                throw new Exception("Invalid id");
            }
            return foundCompany;
        }

        internal Company Create(Company newCompany)
        {
            return _repo.Create(newCompany);
        }

        internal Company Edit(Company companyUpdates)
        {
            Company origCompany = GetById(companyUpdates.Id);
            origCompany.Name = companyUpdates.Name;
            _repo.Edit(origCompany);
            return (origCompany);
        }
    }
}