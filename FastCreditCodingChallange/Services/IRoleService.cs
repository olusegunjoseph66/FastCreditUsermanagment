using FastCreditCodingChallange.ViewModels.Response;

namespace FastCreditCodingChallange.Services
{
    public interface IRoleService
    {
        Task<ApiResponse> GetRoles(CancellationToken cancellationToken);
        Task<ApiResponse> AddRoles(string name, CancellationToken cancellationToken);
        Task<ApiResponse> GetNationality(CancellationToken cancellationToken);
    }
}