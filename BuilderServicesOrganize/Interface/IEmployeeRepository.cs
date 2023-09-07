using BuilderServicesOrganize.Model;

namespace BuilderServicesOrganize.Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetById(int id, CancellationToken cancellationToken);

        Task<List<Employee>> GetAll(CancellationToken cancellationToken);
    }
}
