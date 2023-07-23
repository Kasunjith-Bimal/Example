using DistributeCacheAPI.Model;

namespace DistributeCacheAPI.Interface
{
    public interface IMemberRepository
    {
        Member GetById(int id);
    }
}
