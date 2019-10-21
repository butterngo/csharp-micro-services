namespace CSharp.OAuth.Server.Services
{
    using CSharp.Core.ModelBase;
    using CSharp.OAuth.Server.Dtos;
    using IdentityServer4.Stores;
    using System.Threading.Tasks;

    public interface IClientService: IClientStore
    {
        Task CreateIdentityResourceAsync();

        Task CreateApiResourceAsync();

        Task CreateResourceOwnerPasswordAsync(AddClientResourceOwnerPasswordDto dto);

        Task<PageResultDto<IdentityServer4.Models.Client>> SearchAsync(QuerySearchDefault @param);

        Task<IdentityServer4.Models.Client> FindEnabledClientByIdAsync(string clientId);

        Task<bool> IsPkceClientAsync(string clientId);

        Task<string> GenerateHeaderCredentialAsync(string clientId);
    }
}
