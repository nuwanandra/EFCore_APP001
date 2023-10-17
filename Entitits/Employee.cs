namespace EFCore_APP001.Entitits
{
    public class Employee
    {
        public long Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public decimal Salary { get; set; }

        public long CompanyId { get; set; }


    }
}
