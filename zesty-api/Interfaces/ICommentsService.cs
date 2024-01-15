using zesty_api.Models;

namespace zesty_api.Interfaces
{
    public interface ICommentsService
    {
        Task<Comment> AddComment(Comment comment);
        Task DeleteComment(int CommentId);
        
        Task<ICollection<Comment>> GetComments(int RecipeId);
    }
}
