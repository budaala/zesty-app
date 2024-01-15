using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zesty_api.Interfaces;
using zesty_api.Models;

namespace zesty_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesService _recipesService;
        private readonly IRatingService _ratingService;
        private readonly ICommentsService _commentsService;
        private readonly IBlobStorageService _blobStorageService;

        public RecipesController(IRecipesService recipesService, IRatingService ratingService, ICommentsService commentsService, IBlobStorageService blobStorageService)
        {
            _recipesService = recipesService;
            _ratingService = ratingService;
            _commentsService = commentsService;
            _blobStorageService = blobStorageService;
        }

        [HttpGet]
        public ActionResult<ICollection<Recipe>> GetAllRecipes()
        {
            var recipes = _recipesService.GetAllRecipes();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public ActionResult<Recipe> GetRecipe(int RecipeId)
        {
            var recipe = _recipesService.GetRecipe(RecipeId);
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRecipe([FromBody] Recipe recipe, IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                recipe.ImageUrl = "https://zestyappimages.blob.core.windows.net/zestyappimages/placeholder.png";
            }
            else
            {
                var imageUrl = await _blobStorageService.UploadFile(image);
                recipe.ImageUrl = imageUrl;
            }
            _recipesService.CreateRecipe(recipe);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<Recipe> UpdateRecipe(int RecipeId, [FromBody] Recipe recipe)
        {
            recipe.Id = RecipeId;
            var updatedRecipe = _recipesService.UpdateRecipe(recipe);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Recipe> DeleteRecipe(int RecipeId)
        {
            _blobStorageService.DeleteFile(_recipesService.GetRecipe(RecipeId).ImageUrl);
            _recipesService.DeleteRecipe(RecipeId);
            return Ok();
        }

        [HttpPost("{id}/rating")]
        public ActionResult<Rating> AddRating([FromBody] Rating rating)
        {
            _ratingService.AddRating(rating);
            return Ok();
        }

        [HttpGet("{id}/rating")]
        public ActionResult<int> GetRating(int UserId)
        {
            var averageRating = _ratingService.GetRating(UserId);
            return Ok(averageRating);
        }

        [HttpGet("{id}/rating")]
        public ActionResult<int> GetAverageRating(int recipeId)
        {
            var averageRating = _ratingService.GetAverageRating(recipeId);
            return Ok(averageRating);
        }

        [HttpPost("{id}/comments")]
        public ActionResult<Comment> AddComment([FromBody] Comment comment)
        {
            _commentsService.AddComment(comment);
            return Ok();
        }

        [HttpDelete("{id}/comments")]
        public ActionResult<Comment> DeleteComment(int commentId)
        {
            _commentsService.DeleteComment(commentId);
            return Ok();
        }

        [HttpGet("{id}/comments")]
        public ActionResult<ICollection<Comment>> GetComments(int recipeId)
        {
            _commentsService.GetComments(recipeId);
            return Ok();
        }

        //[HttpPost("/photo")]
        //public async Task<ActionResult<string>> AddImage(IFormFile image)
        //{
        //    if (image == null || image.Length == 0)
        //    {
        //        return BadRequest("No file uploaded.");
        //    }

        //    var imageUrl = await _blobStorageService.UploadFile(image);

        //    return Ok(imageUrl);
        //}

        //[HttpPost("/photo/delete")]
        //public async Task<ActionResult<string>> DeleteImage(string fileUrl)
        //{
        //    await _blobStorageService.DeleteFile(fileUrl);

        //    return Ok(fileUrl);
        //}
    }
}
