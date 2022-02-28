using System.Collections.Generic;
using csharp_contract.Models;
using csharp_contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace csharp_contracted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly CompaniesService _cs;
        public CompaniesController(CompaniesService cs)
        {
            _cs = cs;
        }

        [HttpGet]
        public ActionResult<List<Company>> GetAllCompanies()
        {
            try
            {
                return Ok(_cs.GetAll());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{int companyId}")]
        public ActionResult<Company> GetById(int companyId)
        {
            try
            {
                Company foundCompany = _cs.GetById(companyId);
                return (foundCompany);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public ActionResult<Company> Create([FromBody] Company newCompany)
        {
            try
            {
                Company createdCompany = _cs.Create(newCompany);
                return Ok(createdCompany);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{companyId}")]
        public ActionResult<Company> Edit([FromBody] Company companyUpdates, int companyId)
        {
            try
            {
                companyUpdates.Id = companyId;
                Company editedCompany = _cs.Edit(companyUpdates);
                return Ok(editedCompany);

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}