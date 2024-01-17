using zesty_api.Models;

namespace zesty_api.Interfaces
{
    public interface ICommentsService
    {
        Comment AddComment(Comment comment);
        Task DeleteComment(int CommentId);
        
        IEnumerable<Comment> GetComments(int RecipeId);
    }
}
