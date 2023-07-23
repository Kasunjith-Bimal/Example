using DistributeCacheAPI.Interface;
using DistributeCacheAPI.Model;
using Microsoft.Extensions.Caching.Memory;

namespace DistributeCacheAPI.Repository
{
    public class CachingMemberRepository : IMemberRepository
    {
        //first Step cashed repository
        private readonly MemberRepository _decorate;
        private readonly IMemoryCache _cache;

        public CachingMemberRepository(MemberRepository decorate, IMemoryCache cache)
        {
            _decorate = decorate;
            _cache = cache;
        }

        public Member GetById(int id)
        {
            string key = $"members-{id}";

            return _cache.GetOrCreate(key, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                return _decorate.GetById(id);
            });
        }
        //first Step cashed repository
    }
}
