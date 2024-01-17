using zesty_api.Data;
using zesty_api.Data.Entities;
using zesty_api.Interfaces;
using zesty_api.Models;

namespace zesty_api.Services
{
    //TODO: DO we need to implement this? Shouldn't we just return the comments with the recipe?
    public class CommentsService : ICommentsService
    { 
        private readonly DataContext db;

        public CommentsService(DataContext db)
        {
            this.db = db;
        }

        Comment ICommentsService.AddComment(Comment comment)
        {
            var commentEntity = CommentEntity.Create(comment.RecipeId, comment.UserId, comment.Content);
            db.Comments.Add(commentEntity);
            db.SaveChanges();
            return MapToDTO(commentEntity);
        }

        public Task DeleteComment(int CommentId)
        {
            var comment = db.Comments.FirstOrDefault(c => c.Id == CommentId) ?? throw new Exception("Comment not found");
            db.Comments.Remove(comment);
            db.SaveChanges();
            return Task.CompletedTask;
        }

        public IEnumerable<Comment> GetComments(int RecipeId)
        {
            var comments = db.Comments.Where(c => c.RecipeId == RecipeId).ToList();
            return comments.Select(MapToDTO);
        }

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
