using Microsoft.EntityFrameworkCore;
using zesty_api.Data;
using zesty_api.Data.Entities;
using zesty_api.Interfaces;
using zesty_api.Models;

namespace zesty_api.Services;

// TODO: DO we need to implement this? Shouldn't we just return the comments with the recipe?
public abstract class CommentsService(DataContext db) : ICommentsService
{
    Comment ICommentsService.AddComment(Comment comment)
    {
        var user = db.Users.Find(comment.UserId) ?? throw new Exception("User not found");
        var commentEntity = CommentEntity.Create(comment.RecipeId, comment.UserId, comment.Content);
        commentEntity.User = user;
        db.Comments.Add(commentEntity);
        db.SaveChanges();
        comment.Id = commentEntity.Id;
        return MapToDto(commentEntity);
    }

    public Task DeleteComment(int commentId)
    {
        var comment = db.Comments.FirstOrDefault(c => c.Id == commentId) ?? throw new Exception("Comment not found");
        db.Comments.Remove(comment);
        db.SaveChanges();
        return Task.CompletedTask;
    }

    public IEnumerable<Comment> GetComments(int recipeId)
    {
        var comments = db.Comments.Include(c => c.User).Where(c => c.RecipeId == recipeId).ToList();
        return comments.Select(MapToDto);
    }

    private static Comment MapToDto(CommentEntity entity)
    {
        return new Comment
        {
            Id = entity.Id,
            RecipeId = entity.RecipeId,
            UserId = entity.UserId,
            Username = entity.User.Username,
            Content = entity.Content,
            CreatedAt = entity.CreatedAt
        };
    }
}