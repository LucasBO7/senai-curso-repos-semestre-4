using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalApiMongoDB.Domains;
using MinimalApiMongoDB.Services;
using MongoDB.Driver;

namespace MinimalApiMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController(MongoDbService mongoDbService) : ControllerBase
    {
        private readonly IMongoCollection<User> _users = mongoDbService.GetDatabase().GetCollection<User>("users");

        // CRUD
        [HttpPost]
        public async Task<ActionResult> Post(User newUser)
        {
            try
            {
                await _users.InsertOneAsync(newUser);
                return StatusCode(201, newUser);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorId")]
        public async Task<ActionResult> GetById(string id)
        {
            try
            {
                User searchedUser = await _users.Find(u => u.Id.ToString() == id).FirstOrDefaultAsync();

                return searchedUser is null ? NotFound() : Ok(searchedUser);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                List<User> searchedUser = await _users.Find(FilterDefinition<User>.Empty).ToListAsync();

                return searchedUser is null ? NotFound() : Ok(searchedUser);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteById(string id)
        {
            try
            {
                var deletedUser = await _users.DeleteOneAsync(p => p.Id.ToString() == id);

                return deletedUser is null ? NotFound() : NoContent();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}
