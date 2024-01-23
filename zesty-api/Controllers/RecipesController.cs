using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public ActionResult<IEnumerable<Recipe>> GetAllRecipes()
        {
            try
            {
                var recipes = _recipesService.GetAllRecipes();
                return Ok(recipes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Recipe> GetRecipe(int id)
        {
            try
            {
                var recipe = _recipesService.GetRecipe(id);
                return Ok(recipe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateRecipe([FromForm] string recipeJson, [FromForm]IFormFile image = null)
        {
            try
            {
                var recipe = JsonConvert.DeserializeObject<Recipe>(recipeJson);

                if (image == null || image.Length == 0)
                {
                    recipe!.ImageUrl = "https://zestyappblob.blob.core.windows.net/zestyappimages/placeholder.png";
                }
                else
                {
                    var imageUrl = await _blobStorageService.UploadFile(image);
                    recipe!.ImageUrl = imageUrl;
                }

                _recipesService.CreateRecipe(recipe);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<Recipe>> UpdateRecipe(int id, [FromForm] string recipeJson, [FromForm] IFormFile image = null)
        {
            try
            {
                var recipe = JsonConvert.DeserializeObject<Recipe>(recipeJson);
                var oldImageUrl = _recipesService.GetRecipe(id).ImageUrl;
                if (image == null || image.Length == 0)
                {
                    recipe!.ImageUrl = oldImageUrl;
                }
                else
                {
                    await _blobStorageService.DeleteFile(oldImageUrl);
                    var newImageUrl = await _blobStorageService.UploadFile(image);
                    recipe!.ImageUrl = newImageUrl;
                }
                recipe.Id = id;
            
                var updatedRecipe = _recipesService.UpdateRecipe(recipe);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public ActionResult<Recipe> DeleteRecipe(int id)
        {
            try
            {
                _blobStorageService.DeleteFile(_recipesService.GetRecipe(id).ImageUrl);
                _recipesService.DeleteRecipe(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
            
        }

        [HttpPost("{id}/rating")]
        public ActionResult<Rating> AddRating([FromBody] Rating rating, int id)
        {
            try
            {
                rating.RecipeId = id;
                _ratingService.AddRating(rating);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }    
        }

        [HttpGet("{id}/rating")]
        public ActionResult<int> GetRating(int id, [FromBody]int userId)
        {
            try
            {
                var averageRating = _ratingService.GetRating(userId, id);
                return Ok(averageRating);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }   
        }

        [HttpGet("{id}/averagerating")]
        public ActionResult<double> GetAverageRating(int id)
        {
            try
            {
                var averageRating = _ratingService.GetAverageRating(id);
                return Ok(averageRating);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }  
        }

        [HttpPost("{id}/comments")]
        public ActionResult AddComment([FromBody] Comment comment, int id)
        {
            try
            {   
                comment.RecipeId = id;
                _commentsService.AddComment(comment);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }


        [HttpDelete("{id}/comments")]
        public ActionResult DeleteComment(int id)
        {
            try
            {
                _commentsService.DeleteComment(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpGet("{id}/comments")]
        public ActionResult<IEnumerable<Comment>> GetComments(int id)
        {
            try
            {
                _commentsService.GetComments(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
