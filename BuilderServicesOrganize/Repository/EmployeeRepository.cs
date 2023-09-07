using BuilderServicesOrganize.Interface;
using BuilderServicesOrganize.Model;

namespace BuilderServicesOrganize.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<List<Employee>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
