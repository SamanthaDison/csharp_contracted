using System.Collections.Generic;
using System.Data;
using System.Linq;
using csharp_contract.Models;
using csharp_contracted.Interfaces;
using Dapper;

namespace csharp_contracted.Repositories
{
    public class CompaniesRepository : IRepository<Company, int>
    {
        private readonly IDbConnection _db;
        public CompaniesRepository(IDbConnection db)
        {
            _db = db;
        }

        public Company Create(Company newData)
        {
            string sql = @"
           INSERT INTO companies(name)
           VALUES(@Name)
           SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newData);
            newData.Id = id;
            return newData;
        }

        public void Delete(int objectId)
        {
            string sql = @"
            DELETE FROM companies
            WHERE id =@id;";
            _db.Execute(sql, new { id = objectId });
        }

        public void Edit(Company update)
        {
            string sql = @"
            UPDATE companies
            SET
            name = @Name
            WHERE id=@Id;
            ";
            _db.Execute(sql, update);
        }

        public List<Company> GetAll()
        {
            string sql = @"
            SELECT * FROM companies
            ";
            return _db.Query<Company>(sql).ToList();
        }

        public Company GetById(int id)
        {
            string sql = @"
           SELECT * 
           FROM companies
           WHERE id=@id;
           ";
            return _db.QueryFirstOrDefault<Company>(sql, new { id });
        }


    }
}