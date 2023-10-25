using FastCreditCodingChallange.DatabaseModels;
using FastCreditCodingChallange.Enum;
using FastCreditCodingChallange.Repository;
using FastCreditCodingChallange.Utility;
using FastCreditCodingChallange.Utility.Constants;
using FastCreditCodingChallange.ViewModels.Requests;
using FastCreditCodingChallange.ViewModels.Response;
using Microsoft.EntityFrameworkCore;

namespace FastCreditCodingChallange.Services
{
    public class RoleService : BaseService, IRoleService
    {

        private readonly IAsyncRepository<Role> _roleRepository;
        private readonly IAsyncRepository<National> _nationalRepository;
        public RoleService(IAsyncRepository<Role> roleRepository, IAsyncRepository<National> nationalRepository,IAuthenticatedUserService authenticatedUserService) : base(authenticatedUserService)
        {
            _roleRepository = roleRepository;
            _nationalRepository = nationalRepository;
        }

        public async Task<ApiResponse> GetRoles(CancellationToken cancellationToken)
        {
            //GetUserId();

            var roles = await _roleRepository.Table.Select(x => new Role
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync(cancellationToken);

            return ResponseHandler.SuccessResponse(SuccessMessages.SUCCESSFUL_RETRIEVAL_OF_ROLE_LIST, roles.ToList());
        }

        public async Task<ApiResponse> AddRoles(string name, CancellationToken cancellationToken)
        {
            //GetUserId();

            if (await _roleRepository.Table.AnyAsync(p => p.Name.ToLower() == name.ToLower(), cancellationToken))
                throw new ConflictException(ErrorMessages.ROLE_ALEADY_EXIST, ErrorCodes.ROLE_ALEADY_EXIST);

                    

            Role rol = new()
            { Name = name    
            };
                       
            await _roleRepository.AddAsync(rol, cancellationToken);
           
            await _roleRepository.CommitAsync(cancellationToken);

            
            return ResponseHandler.SuccessResponse(SuccessMessages.SUCCESSFUL_CREATING_OF_ROLE);
        }

        public async Task<ApiResponse> GetNationality(CancellationToken cancellationToken)
        {
            //GetUserId();

            var nationals = await _nationalRepository.Table.Select(x => new National
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync(cancellationToken);

            return ResponseHandler.SuccessResponse(SuccessMessages.SUCCESSFUL_RETRIEVAL_OF_ROLE_LIST, nationals.ToList());
        }
    }
}
