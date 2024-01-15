using zesty_api.Data.Entities;
using zesty_api.Interfaces;
using zesty_api.Models;

namespace zesty_api.Services
{
    //TODO: DO we need to implement this? Shouldn't we just return the comments with the recipe?
    public class CommentsService : ICommentsService
    {
        public static Comment MapToDTO(CommentEntity entity)
        {
            return new Comment
            {
                Id = entity.Id,
                RecipeId = entity.RecipeId,
                UserId = entity.UserId,
                Content = entity.Content,
                CreatedAt = entity.CreatedAt
            };
        }

        Task<Comment> ICommentsService.AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteComment(int CommentId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Comment>> GetComments(int RecipeId)
        {
            throw new NotImplementedException();
        }
    }
}
