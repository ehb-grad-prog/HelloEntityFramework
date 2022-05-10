using HelloEntityFramework.Entities;

namespace HelloEntityFramework.Data;

public class UserRepository : BaseRepository<User>
{
    public UserRepository(HelloEntityFrameworkContext context) : base(context)
    {
        //
    }
}
