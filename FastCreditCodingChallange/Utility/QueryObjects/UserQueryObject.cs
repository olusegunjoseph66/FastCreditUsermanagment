using FastCreditCodingChallange.DatabaseModels;
using FastCreditCodingChallange.ViewModels.Requests;

namespace FastCreditCodingChallange.Utility.QueryObjects
{
    public class UserQueryObject : QueryObject<User>
    {
        public UserQueryObject(UserFilterDto filter)
        {
            if (filter == null)
                And(u => !u.IsDeleted);

            And(u => !u.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.UserStatusCode))
                And(u => u.UserStatus.Id.ToString() == filter.UserStatusCode);

            

            if (!string.IsNullOrWhiteSpace(filter.SearchText))
            {
                And(u => u.FirstName.Contains(filter.SearchText)
                  || u.LastName.Contains(filter.SearchText));
            }
        }
    }
}

