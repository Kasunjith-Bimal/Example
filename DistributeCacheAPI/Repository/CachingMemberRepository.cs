using DistributeCacheAPI.Interface;
using DistributeCacheAPI.Model;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace DistributeCacheAPI.Repository
{
    public class CachingMemberRepository : IMemberRepository
    {
        //first Step // 2nd step cashed repository
        //private readonly MemberRepository _decorate;
        //3rd step
        private readonly IMemberRepository _decorate;
        // private readonly IMemoryCache _cache;
        private readonly IDistributedCache _distributedCache;

        //public CachingMemberRepository(IMemberRepository decorate, IMemoryCache cache)
        //{
        //    _decorate = decorate;
        //    _cache = cache;
        //}
        public CachingMemberRepository(IMemberRepository decorate, IDistributedCache distributedCache)
        {
            _decorate = decorate;
            _distributedCache = distributedCache;
        }

        public async Task<Member> GetById(int id,CancellationToken cancellationToken)
        {
            string key = $"members-{id}";
            Member? member = new Member();
            string? cacheMember = await _distributedCache.GetStringAsync(key, cancellationToken);
            if (string.IsNullOrEmpty(cacheMember))
            {
                member = await _decorate.GetById(id, cancellationToken);

                if (member is null)
                {
                    return null;
                }

                await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(member));

                return member;
            }

            member = JsonSerializer.Deserialize<Member>(cacheMember);

            if (member is not null)
            {
                return member;
            }
            else
            {
                return null;
            }
           

            //return _cache.GetOrCreate(key, entry =>
            //{
            //    entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

            //    return _decorate.GetById(id);
            //});


        }
        //first Step cashed repository
    }
}
