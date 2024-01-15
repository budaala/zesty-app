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

        public RecipesController( IBlobStorageService blobStorageService)
        {
            //_recipesService = recipesService;
            //_ratingService = ratingService;
            //_commentsService = commentsService;
            _blobStorageService = blobStorageService;
        }

        [HttpGet]
        public ActionResult<ICollection<Recipe>> GetAllRecipes()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<Recipe> GetRecipe(int RecipeId)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult<Recipe> CreateRecipe([FromBody] Recipe recipe, IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            //var imageUrl = await _blobStorageService.UploadFile(image);

            //recipe.ImageUrl = imageUrl;


            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<Recipe> UpdateRecipe(int RecipeId, [FromBody] Recipe recipe)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Recipe> DeleteRecipe(int RecipeId)
        {
            return Ok();
        }

        [HttpPost("{id}/rating")]
        public ActionResult<Rating> AddRating(int RecipeId, [FromBody] Rating rating)
        {
            return Ok();
        }

        [HttpGet("{id}/rating")]
        public ActionResult<double> GetRating(int RecipeId)
        {

            double averageRating = 0;
            return Ok(averageRating);
        }

        [HttpPost("{id}/comments")]
        public ActionResult<Comment> AddComment(int RecipeId, [FromBody] Comment comment)
        {
            return Ok();
        }

        [HttpPost("/photo")]
        public async Task<ActionResult<string>> AddImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var imageUrl = await _blobStorageService.UploadFile(image);

            return Ok(imageUrl);
        }

        [HttpPost("/photo/delete")]
        public async Task<ActionResult<string>> DeleteImage(string fileUrl)
        {
            await _blobStorageService.DeleteFile(fileUrl);

            return Ok(fileUrl);
        }


        //[HttpGet("{id}/comments")]
        //public ActionResult<ICollection<Comment>> GetComments(int RecipeId)
        //{
        //    return Ok();
        //}
    }
}
