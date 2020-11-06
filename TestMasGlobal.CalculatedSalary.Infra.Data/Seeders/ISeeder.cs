using System.Threading.Tasks;

namespace TestMasGlobal.CalculatedSalary.Infra.Data.Seeders
{
    public interface ISeeder
    {
        Task ExecuteSeederAsync();
    }
}
