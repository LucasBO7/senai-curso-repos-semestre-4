using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalApiMongoDB.Domains;
using MinimalApiMongoDB.Services;
using MinimalApiMongoDB.ViewModels;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MinimalApiMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClientController(MongoDbService mongoDbService) : ControllerBase
    {
        private readonly IMongoCollection<Client> _clients = mongoDbService.GetDatabase().GetCollection<Client>("clients");
        private readonly IMongoCollection<User> _users = mongoDbService.GetDatabase().GetCollection<User>("users");

        [HttpPost]
        public async Task<ActionResult> Post(PostClientUserViewModel newClientUserViewModel)
        {
            try
            {
                User newUser = new()
                {
                    Name = newClientUserViewModel.Name,
                    Email = newClientUserViewModel.Email,
                    Password = newClientUserViewModel.Password,
                    AdditionalValues = newClientUserViewModel.UserAdditionalValues
                };

                Client newClient = new()
                {
                    // Associa a User ao Client
                    UserId = newUser.Id.ToString(),
                    Cpf = newClientUserViewModel.Cpf,
                    Address = newClientUserViewModel.Address,
                    Phone = newClientUserViewModel.Phone,
                    AdditionalValues = newClientUserViewModel.ClientAdditionalValues,
                };

                // Insere os dados no banco
                await _users.InsertOneAsync(newUser);
                await _clients.InsertOneAsync(newClient);

                return Ok("Usuário/Cliente cadastrado com sucesso!");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            try
            {
                Client searchedClient = await _clients.Find(u => u.Id.ToString() == id).FirstOrDefaultAsync();
                User searchedUser = _users.Find(u => u.Id.ToString() == searchedClient.UserId).FirstOrDefault();


                if (searchedClient is not null & searchedUser is not null)
                {
                    ClientUserViewModel clientUserViewModel = new()
                    {
                        ClientId = searchedClient!.Id.ToString(),
                        Cpf = searchedClient.Cpf,
                        Phone = searchedClient.Phone,
                        Address = searchedClient.Address,
                        ClientAdditionalValues = searchedClient.AdditionalValues,
                        IdUser = searchedUser!.Id.ToString(),
                        Name = searchedUser.Name,
                        Email = searchedUser.Email,
                        Password = searchedUser.Password,
                        UserAdditionalValues = searchedUser.AdditionalValues,
                    };
                    return Ok(clientUserViewModel);
                }

                return NotFound();
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
                List<Client> searchedClient = await _clients.Find(FilterDefinition<Client>.Empty).ToListAsync();

                return searchedClient is null ? NotFound() : Ok(searchedClient);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(string id)
        {
            try
            {
                // Busca o Client existente
                var clientUserId = await _clients.Find(c => c.Id.ToString() == id).FirstOrDefaultAsync();

                // Deleta o Client e User
                await _clients.DeleteOneAsync(c => c.Id == clientUserId.Id);
                await _users.DeleteOneAsync(u => u.Id.ToString() == clientUserId.UserId);

                return Ok("Cliente removido com sucesso!");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, UpdateClientUserViewModel newClientUserViewModel)
        {
            try
            {
                // Pega Client e User do banco
                Client clientInDb = await _clients.Find(c => c.Id.ToString() == id).FirstOrDefaultAsync();
                User userInDb = await _users.Find(u => u.Id.ToString() == clientInDb.UserId).FirstOrDefaultAsync();

                // Passa os novos valores (se houver novo valor na propriedade)
                Client newClient = new()
                {
                    Id = clientInDb.Id,
                    UserId = clientInDb.UserId,
                    Cpf = String.IsNullOrEmpty(newClientUserViewModel.Cpf) ? clientInDb.Cpf : newClientUserViewModel.Cpf,
                    Phone = String.IsNullOrEmpty(newClientUserViewModel.Phone) ? clientInDb.Phone : newClientUserViewModel.Phone,
                    Address = String.IsNullOrEmpty(newClientUserViewModel.Address) ? clientInDb.Address : newClientUserViewModel.Address,
                    AdditionalValues = newClientUserViewModel.ClientAdditionalValues!.Any() ? clientInDb.AdditionalValues : newClientUserViewModel.ClientAdditionalValues
                };

                User newUser = new()
                {
                    Id = userInDb.Id,
                    Name = String.IsNullOrEmpty(newClientUserViewModel.Name) ? userInDb.Name : newClientUserViewModel.Name,
                    Email = String.IsNullOrEmpty(newClientUserViewModel.Email) ? userInDb.Email : newClientUserViewModel.Email,
                    Password = String.IsNullOrEmpty(newClientUserViewModel.Password) ? userInDb.Password : newClientUserViewModel.Password,
                    AdditionalValues = newClientUserViewModel.UserAdditionalValues!.Any() ? userInDb.AdditionalValues : newClientUserViewModel.UserAdditionalValues
                };

                // Atualiza no banco
                await _clients.ReplaceOneAsync(c => c.Id.ToString() == id, newClient);
                await _users.ReplaceOneAsync(u => u.Id == userInDb.Id, newUser);

                // Retorna
                return Ok("Cliente atualizado com sucesso!");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}
