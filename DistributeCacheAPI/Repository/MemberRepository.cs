using DistributeCacheAPI.Interface;
using DistributeCacheAPI.Model;

namespace DistributeCacheAPI.Repository
{
    public class MemberRepository : IMemberRepository
    {
        List<Member> members = new List<Member>
        {
            new Member { Id = 1, Name = "John Doe", Age = 30 },
            new Member { Id = 2, Name = "Jane Smith", Age = 25 },
            new Member { Id = 3, Name = "Michael Johnson", Age = 40 },
            new Member { Id = 4, Name = "Emily Adams", Age = 22 },
            new Member { Id = 5, Name = "Robert Williams", Age = 50 },
            new Member { Id = 6, Name = "Sophia Lee", Age = 28 },
            new Member { Id = 7, Name = "William Brown", Age = 34 },
            new Member { Id = 8, Name = "Olivia Davis", Age = 19 },
            new Member { Id = 9, Name = "James Miller", Age = 42 },
            new Member { Id = 10, Name = "Ava Wilson", Age = 29 },
            new Member { Id = 11, Name = "Alexander Garcia", Age = 31 },
            new Member { Id = 12, Name = "Isabella Rodriguez", Age = 26 },
            new Member { Id = 13, Name = "Daniel Martinez", Age = 38 },
            new Member { Id = 14, Name = "Mia Anderson", Age = 23 },
            new Member { Id = 15, Name = "David Taylor", Age = 45 }
        };


        public Member GetById(int id)
        {
            return members.First(member => member.Id == id);
        }
    }
}
