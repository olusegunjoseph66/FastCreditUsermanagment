using FastCreditCodingChallange.Enum;
using FastCreditCodingChallange.Repository;
using FastCreditCodingChallange.Utility.Constants;
using FastCreditCodingChallange.Utility;
using FastCreditCodingChallange.ViewModels.QueryFilters;
using FastCreditCodingChallange.ViewModels.Requests;
using FastCreditCodingChallange.ViewModels.Response;
using Microsoft.Extensions.Options;
using System.Data;
using Microsoft.EntityFrameworkCore;
using FastCreditCodingChallange.DatabaseModels;
using LinqKit;
using FastCreditCodingChallange.Utility.QueryObjects;
using FastCreditCodingChallange.ViewModels.Request;

namespace FastCreditCodingChallange.Services
{
    public class UserServices : BaseService, IUserServices
    {

        private readonly IAsyncRepository<User> _userRepository;
        private readonly IAsyncRepository<Role> _roleRepository;
        private readonly IAsyncRepository<UserRole> _userRoleRepository;
        private readonly IAsyncRepository<UserStatus> _userStatusRepository;
        private readonly IAsyncRepository<National> _nationalRepository;
        private readonly IAsyncRepository<UserNational> _userNationalRepository;



        public UserServices(IAsyncRepository<User> userRepository,
            IAsyncRepository<Role> roleRepository, IAsyncRepository<UserStatus> userStatusRepository,
            IAsyncRepository<National> nationalRepository, IAsyncRepository<UserNational> userNationalRepository,
        IAsyncRepository<UserRole> userRoleRepository,
            IAuthenticatedUserService authenticatedUserService) : base(authenticatedUserService)
        {

            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userStatusRepository = userStatusRepository;
            _userRoleRepository = userRoleRepository;
            _userNationalRepository = userNationalRepository;
            _nationalRepository = nationalRepository;
        }


        public async Task<ApiResponse> GetUsers(UserQueryFilter filter, CancellationToken cancellationToken)
        {
            //GetUserId();

            BasePageFilter pageFilter = new(filter.PageSize, filter.PageIndex);
            UserSortingDto sorting = new();
            if (filter.Sort == UserSortingEnum.NameDescending)
                sorting.IsNameDescending = true;
            else if (filter.Sort == UserSortingEnum.NameAscending)
                sorting.IsNameAscending = true;
            else if (filter.Sort == UserSortingEnum.DateAscending)
                sorting.IsDateAscending = true;
            else if (filter.Sort == UserSortingEnum.DateDescending)
                sorting.IsDateDescending = true;

            UserFilterDto userFilter = new()
            {
                RoleName = filter.RoleName,
                UserStatusCode = filter.UserStatusCode,
                SearchText = filter.SearchKeyword
            };

            var expression = new UserQueryObject(userFilter).Expression;
            var orderExpression = ProcessOrderFunc(sorting);
            var query = _userRepository.Table.AsNoTrackingWithIdentityResolution()
                .Select(ux => new User
                {
                    Id = ux.Id,
                    FirstName = ux.FirstName,
                    LastName = ux.LastName,
                    EmailAddress = ux.EmailAddress,
                    UserRoles = new UserRole
                    {
                         Id = ux.UserRoles.Id,
                         RoleId = ux.UserRoles.RoleId,
                         UserId = ux.Id
                    },
                    UserStatus = new UserStatus
                    {
                        Id = ux.UserStatus.Id,
                        Name = ux.UserStatus.Name
                    },
                    DateCreated = ux.DateCreated,
                    IsDeleted = ux.IsDeleted,
                    PhoneNumber = ux.PhoneNumber, DateOfBirth = ux.DateOfBirth, Gender = ux.Gender,
                    UserNationals = new UserNational { NationalId = (short)ux.UserNationals.Id  }
                    // UserNationals = new National { Name = ux.UserNationals.National.Name }
                }).OrderByWhere(expression, orderExpression);

            var ff = query.Count();
            var totalCount = await query.CountAsync(cancellationToken);
            var queryResult = query.Paginate(pageFilter.PageNumber, pageFilter.PageSize);
            var users = await queryResult.ToListAsync(cancellationToken);
            var totalPages = NumberManipulator.PageCountConverter(totalCount, pageFilter.PageSize);
            var response = new PaginatedList<UserResponse>(ProcessQuery(users), new PaginationMetaData(filter.PageIndex, filter.PageSize, totalPages, totalCount));

            return ResponseHandler.SuccessResponse(SuccessMessages.SUCCESSFUL_RETRIEVAL_OF_USER_LIST, response);
        }

        public async Task<ApiResponse> AddUsers(CreatUserRequest request, CancellationToken cancellationToken)
        {
            //GetUserId();

            if (await _userRepository.Table.AnyAsync(p => p.EmailAddress.ToLower() == request.EmailAddress.ToLower() && !p.IsDeleted, cancellationToken))
                throw new ConflictException(ErrorMessages.USERNAME_ALREADY_EXIST, ErrorCodes.USERNAME_ALEADY_EXIST);

          
            var userPassword = "Passw@rd123";
            var hash = EncryptionHelper.Hash(userPassword);

            User user = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Password = hash,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                DateCreated = DateTime.UtcNow,
                EmailAddress = request.EmailAddress,
                //CreatedByUserId = LoggedInUserId,
                IsDeleted = false,
                UserStatusId = (int)UserStatusEnum.Active,
            };

            UserNational userNation = new()
            {
                NationalId = request.Nationality,
                UserId = user.Id,

            };

         
            UserRole userRole = new()
            {
                UserId = user.Id,
                RoleId = request.RoleId
            };

            

            user.UserNationals = userNation;
            user.UserRoles = userRole;
            await _userRepository.AddAsync(user, cancellationToken);            
            await _userRepository.CommitAsync(cancellationToken);

            return ResponseHandler.SuccessResponse(SuccessMessages.SUCCESSFUL_CREATING_OF_USER);
        }

        public async Task<ApiResponse> UpdateUsers(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            //GetUserId();

            var userDetail = await _userRepository.Table.Where(p => p.Id == request.UserId && !p.IsDeleted)
                .Select(x => new User
                {
                    Id = x.Id,
                    CreatedByUserId = x.CreatedByUserId,
                    IsDeleted = x.IsDeleted,
                    DateCreated = x.DateCreated,
                    DateDeleted = x.DateDeleted,
                    DateModified = x.DateModified,
                    DeletedByUserId = x.DeletedByUserId,
                    EmailAddress = x.EmailAddress,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    LockedOutDate = x.LockedOutDate,
                    ModifiedByUserId = x.ModifiedByUserId,
                    Password = x.Password,
                    PasswordExpiryDate = x.PasswordExpiryDate,
                    Gender = x.Gender,
                    PhoneNumber = x.PhoneNumber,
                    DateOfBirth = x.DateOfBirth,                    
                    UserName = x.UserName,
                    UserStatusId = x.UserStatusId,
                    UserStatus = new UserStatus
                    {
                        Id = x.UserStatus.Id,
                        Name = x.UserStatus.Name
                    },
                    UserRoles = new UserRole
                    {
                        Id = x.UserRoles.Id,
                        RoleId = x.UserRoles.RoleId,
                        UserId = x.Id
                    }
                }).FirstOrDefaultAsync(cancellationToken);

            if (userDetail == null)
                throw new ConflictException(ErrorMessages.USER_RECORD_NOT_FOUND, ErrorCodes.USER_RECORD_NOT_FOUND);

            
            

            var oldUser = new User
            {
                FirstName = userDetail.FirstName,
                LastName = userDetail.LastName,
                EmailAddress = userDetail.EmailAddress,
                Id = userDetail.Id, 
                UserName = userDetail.UserName, PhoneNumber = userDetail.PhoneNumber,
                Gender = userDetail.Gender,DateOfBirth = userDetail.DateOfBirth,
                UserStatus = userDetail.UserStatus
            };
            userDetail.FirstName = request.FirstName;
            userDetail.LastName = request.LastName;
            userDetail.EmailAddress = request.EmailAddress;
            userDetail.PhoneNumber = request.PhoneNumber;
            userDetail.Gender = request.Gender;
            userDetail.DateOfBirth = request.DateOfBirth;
            userDetail.DateModified = DateTime.UtcNow;
            userDetail.ModifiedByUserId = LoggedInUserId;
            userDetail.UserRoles = new UserRole
            {
                RoleId = (short)request.RoleId,

            };
            
            _userRepository.Update(userDetail);
            await _userRepository.CommitAsync(cancellationToken);


            return ResponseHandler.SuccessResponse(SuccessMessages.SUCCESSFUL_UPDATED_USER);
        }



        public async Task<ApiResponse> DeletedUser(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            //GetUserId();

            var userDetail = await _userRepository.Table.FirstOrDefaultAsync(p => p.Id == request.UserId && !p.IsDeleted, cancellationToken);

            if (userDetail == null)
                throw new ConflictException(ErrorMessages.USER_RECORD_NOT_FOUND, ErrorCodes.USER_RECORD_NOT_FOUND);

            userDetail.IsDeleted = true;
            userDetail.DateDeleted = DateTime.UtcNow;
            userDetail.DeletedByUserId = LoggedInUserId;

            _userRepository.Update(userDetail);
            await _userRepository.CommitAsync(cancellationToken);


            return ResponseHandler.SuccessResponse(SuccessMessages.SUCCESSFUL_DELETED_USER);
        }



        public async Task<ApiResponse> GetUserById(UserprofileResponse response, CancellationToken cancellationToken)
        {
            //GetUserId();

            var userDetail = await _userRepository.Table.Where(p => p.Id == response.UserId).Select(ux => new User
            {
                Id = ux.Id,
                FirstName = ux.FirstName,
                LastName = ux.LastName,
                EmailAddress = ux.EmailAddress,
                UserName = ux.UserName, PhoneNumber = ux.PhoneNumber,
                Gender = ux.Gender, DateOfBirth = ux.DateOfBirth,                
                DateCreated = ux.DateCreated,
                UserRoles = new UserRole
                {
                    Id = ux.UserRoles.Id,
                    RoleId = ux.UserRoles.RoleId,
                    UserId = ux.Id
                },
                UserStatus = new UserStatus
                {
                    Id = ux.UserStatus.Id,
                    Name = ux.UserStatus.Name
                },

            }).FirstOrDefaultAsync(cancellationToken);

            var userResponse = ProcessQuery(userDetail);

            return ResponseHandler.SuccessResponse(SuccessMessages.SUCCESSFUL_RETRIEVAL_OF_USER, userResponse);
        }

        #region Private Methods
        private static Func<IQueryable<User>, IOrderedQueryable<User>> ProcessOrderFunc(UserSortingDto? orderExpression = null)
        {
            IOrderedQueryable<User> orderFunction(IQueryable<User> queryable)
            {
                if (orderExpression == null)
                    return queryable.OrderByDescending(p => p.DateCreated);

                var orderQueryable = orderExpression.IsNameAscending
                   ? queryable.OrderBy(p => p.LastName).ThenByDescending(p => p.DateCreated)
                   : orderExpression.IsNameDescending
                       ? queryable.OrderByDescending(p => p.LastName).ThenByDescending(p => p.DateCreated)
                       : orderExpression.IsDateAscending
                           ? queryable.OrderBy(p => p.DateCreated)
                           : orderExpression.IsDateDescending
                               ? queryable.OrderByDescending(p => p.DateCreated)
                               : queryable.OrderByDescending(p => p.DateCreated);
                return orderQueryable;
            }
            return orderFunction;
        }

        private static IReadOnlyList<UserResponse> ProcessQuery(IReadOnlyList<User> users)
        {
            return users.Select(p =>
            {
              
                var userStatus = new UserStatusResponse
                {
                    Code = p.UserStatus.Id.ToString(),
                    Name = p.UserStatus.Name
                };
                var nationel =  p.UserNationals?.National?.Name;

                var item = new UserResponse(p.Id, p.FirstName, p.LastName, p.EmailAddress, p.Gender, p.PhoneNumber, nationel,userStatus, p.UserRoles?.Role?.Name,p.DateOfBirth);
                return item;
            }).ToList();
        }

        private static UserDetailResponse ProcessQuery(User user)
        {
            if (user == null)
                return null;

            var userResponse = new UserDetailResponse()
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user?.EmailAddress,
                Phone = user?.PhoneNumber,
                Gender = user?.Gender,
                Nationality = user?.UserNationals?.National?.Name,
                RoleId = user?.UserRoles?.Role?.Name,
                DateOfBirth = user?.DateOfBirth,
            };
            return userResponse;
        }
        #endregion
    }
}

