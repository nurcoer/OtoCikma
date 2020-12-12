
using DevFramework.Core.DataAccess;
using DevFramework.Nortwind.Entities.ComplexTypes;
using DevFramework.Nortwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {
        List<UserRoleItem> GetUserRoles(User user);
    }
}
