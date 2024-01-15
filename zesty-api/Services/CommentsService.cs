using zesty_api.Data.Entities;
using zesty_api.Interfaces;
using zesty_api.Models;

namespace zesty_api.Services
{
    //TODO: DO we need to implement this? Shouldn't we just return the comments with the recipe?
    public class CommentsService : ICommentsService
    {
        public Comment AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        //public ICollection<Comment> GetComments(int Id)
        //{
        //    throw new NotImplementedException();
        //}

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
    }
}
