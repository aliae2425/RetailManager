using RMDataManager.Library.Internal.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string id)
        {
            SQLDataAccess sql = new SQLDataAccess();

            var p = new { Id = id };
            return sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "RMDataAPI");

        }
    }
}
