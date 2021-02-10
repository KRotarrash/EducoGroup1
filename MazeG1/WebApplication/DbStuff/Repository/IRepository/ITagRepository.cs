using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Repository
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        Tag GetByName(string name);
    }
}