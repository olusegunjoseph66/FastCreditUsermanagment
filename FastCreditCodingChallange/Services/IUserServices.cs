using FastCreditCodingChallange.ViewModels.QueryFilters;
using FastCreditCodingChallange.ViewModels.Request;
using FastCreditCodingChallange.ViewModels.Requests;
using FastCreditCodingChallange.ViewModels.Response;

namespace FastCreditCodingChallange.Services
{
    public interface IUserServices
    {
        Task<ApiResponse> GetUsers(UserQueryFilter filter, CancellationToken cancellationToken);
        Task<ApiResponse> AddUsers(CreatUserRequest request, CancellationToken cancellationToken);
        Task<ApiResponse> UpdateUsers(UpdateUserRequest request, CancellationToken cancellationToken);
        Task<ApiResponse> DeletedUser(DeleteUserRequest request, CancellationToken cancellationToken);
        Task<ApiResponse> GetUserById(UserprofileResponse response, CancellationToken cancellationToken);
    }
}