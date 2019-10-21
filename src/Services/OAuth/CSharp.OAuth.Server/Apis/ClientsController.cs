namespace CSharp.OAuth.Server.Apis
{
    using CSharp.Core.ModelBase;
    using CSharp.OAuth.Server.Dtos;
    using CSharp.OAuth.Server.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class ClientsController : ApiBase<ClientsController>
    {

        private readonly IClientService _clientService;

        public ClientsController(ILogger<ClientsController> logger,
            IClientService clientService) : base(logger)
        {
            _clientService = clientService;
        }

        [HttpGet("clientId")]
        public async Task<IActionResult> GetByClientId(string clientId)
        => Ok(await _clientService.FindClientByIdAsync(clientId));

        [HttpGet("search")]
        public async Task<IActionResult> SearchAsync([FromQuery]QuerySearchDefault @param) 
        => Ok(await _clientService.SearchAsync(@param));

        #region ResourceOwnerPassword
        
        [HttpPost("resource-owner-password")]
        public async Task<IActionResult> CreateResourceOwnerPassword([FromBody] AddClientResourceOwnerPasswordDto dto)
        {
            var result = CheckValidation(dto);

            if (!result.IsValid) return BadRequest(result.Errors);

            await _clientService.CreateResourceOwnerPasswordAsync(dto);

            return Success();
        }

        [HttpPost("resource-owner-password/credential/{clientId}")]
        public async Task<IActionResult> GenerateHeaderCredentialAsync(string clientId)
        => Ok(await _clientService.GenerateHeaderCredentialAsync(clientId));

        #endregion ResourceOwnerPassword

    }
}
