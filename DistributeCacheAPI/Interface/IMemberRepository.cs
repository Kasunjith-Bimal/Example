using DistributeCacheAPI.Model;

namespace DistributeCacheAPI.Interface
{
    public interface IMemberRepository
    {
        Task<Member> GetById(int id, CancellationToken cancellationToken);
    }
}
