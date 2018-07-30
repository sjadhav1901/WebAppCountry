using Contracts.DataModels;
using Db.Core.Repositories;
using Db.Core.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Country.Repositories
{
    public interface IUserRepository : IOrmRepository<User>
    {
        User GetByEmail(string email);
        User GetByAllAltId(Guid altId);
        User GetByAltId(Guid altId);
    }

    public class UserRepository : OrmRepository<User>, IUserRepository
    {
        public UserRepository(IDataSettings dataSettings) : base(dataSettings)
        {
        }

        public User GetByEmail(string email)
        {
            return GetAll(s => s.Where($"{nameof(User.Email):C} = @Email AND IsEnabled=1")
                .WithParameters(new { Email = email })
            ).FirstOrDefault();
        }

        public User GetByAltId(Guid altId)
        {
            return GetAll(s => s.Where($"{nameof(User.AltId):C} = @AltId AND IsEnabled=1")
                .WithParameters(new { AltId = altId })
            ).FirstOrDefault();
        }

        public User GetByAllAltId(Guid altId)
        {
            return GetAll(s => s.Where($"{nameof(User.AltId):C} = @AltId")
                .WithParameters(new { AltId = altId })
            ).FirstOrDefault();
        }
    }
}
