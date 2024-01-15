using zesty_api.Models;

namespace zesty_api.Interfaces
{
    public interface ICommentsService
    {
        Comment AddComment(Comment comment);
        //ICollection<Comment> GetComments(int Id);
    }
}
