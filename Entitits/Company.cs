namespace EFCore_APP001.Entitits
{
    public class Company
    {
        public long Id { get; set; }

        public string Name { get; set; } = String.Empty;


        public DateTime? LastSaleryUpdate { get; set; }


        public List<Employee>? Employees { get; set; }


    }
}
