using System;
using System.Linq;
using TaskRobo.Models;

namespace TaskRobo.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly TaskDbContext context;
        public UserRepository()
        {
            context = new TaskDbContext();
        }

        // This method should be used to save user details into database
        public int CreateUser(AppUser user)
        {
            int result = 0;
            try
            {
                context.AppUsers.Add(user);
                context.SaveChanges();
                result = 1;
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }

        // This method should be used to return boolean value. If user is authenticated successfully it should return true else return false
        public bool IsAuthenticated(AppUser user)
        {
            bool status = false;
            AppUser userData = new AppUser();
            try
            { 
                userData = context.AppUsers.Where(p => p.Email == user.Email && p.Password == user.Password).FirstOrDefault();
                if(userData != null)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
    }
}