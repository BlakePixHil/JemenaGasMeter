using JemenaGasMeter.WebApi.Data;
using JemenaGasMeter.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JemenaGasMeter.WebApi.Repository
{
    public class UserRepository : IDataRepository<User, string>
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get all the users
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        // Get single user by ID 
        public User Get(string id)
        {
            return _context.Users.Find(id);
        }

       // Add new user and return new user's PayRollID
        public string Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.PayRollID;
        }

        // Edit user by PayRollID
        public string Update(string id, User user)
        {
            var u = _context.Users.FirstOrDefault(x => x.PayRollID == id);
            if (u != null)
            {
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.PIN = user.PIN;
                u.Status = user.Status;
                u.UserType = user.UserType;
                u.ModifyDate = user.ModifyDate;

                _context.SaveChanges();
                return id;
            }
            else
            {
                return "-1";
            }
        }

        // Remove user by PayRollID
        public string Delete(string id)
        {
            _context.Users.Remove(_context.Users.Find(id));
            _context.SaveChanges();

            return id;
        }

        // This set the Inactive to active by passing PayRollID
        public bool Active(string id)
        {
            var user = Get(id);
            if (user == null)
            {
                return false;
            }
            else
            {
                user.Status = Status.Active;
                _context.SaveChanges();
                return true;
            }
        }

        // This set the Active to inactive by passing PayRollID
        public bool InActive(string id)
        {
            var user = Get(id);
            if (user == null)
            {
                return false;
            }
            else
            {
                user.Status = Status.Inactive;
                _context.SaveChanges();
                return true;
            }
        }

        // This check the logging user exist or not
        public bool LoginUser(string id, string pin)
        {
            var loggedUser = _context.Users.FirstOrDefault(x => x.PayRollID == id);
            if(loggedUser == null){
                return false;
            }
            else
            {
                var payRollId = loggedUser.PayRollID;
                var pinNum = loggedUser.PIN;

                if ((payRollId.Equals(id)) && (pinNum.Equals(pin)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
