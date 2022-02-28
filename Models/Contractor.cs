
using csharp_contract.Models;

namespace csharp_contracted.Models
{
    public class Contractor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}