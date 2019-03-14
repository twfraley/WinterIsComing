using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;
using WinterIsComing.Data;

namespace WinterIsComing.Services
{
    public class AdminService : IAdminService
    {
        private readonly Guid _userId;

        public AdminService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<ApplicationUser> GetUserList()
        {
            using (var context = new ApplicationDbContext())
            {
                var userList = context.Users.ToList();
                return userList.ToArray();
            }
        }

        public IEnumerable<IdentityRole> GetRolesList()
        {
            using (var context = new ApplicationDbContext())
            {
                var rolesList = context.Roles.ToList();
                return rolesList.ToArray();
            }
        }

        public bool IsAdminUser()
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                    var s = userManager.GetRoles(_userId.ToString());
                    if (s.Count != 0 && s[0].ToString() == "Admin")
                        return true;
                    else
                        return false;
                }

                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}