using Ortho.Shared.Models;
using Ortho.Shared.ViewModels;

namespace Ortho.Shared.Mappings
{
    public static class UserMapping
    {
        public static AppUserViewModel ToUser(this AppUser appUser)
        {
            return new AppUserViewModel
            {
                Id = appUser.userId,
                Name = appUser.firstName + " " + appUser.lastName,
                Title = appUser.title
            };
        }
    }
}
