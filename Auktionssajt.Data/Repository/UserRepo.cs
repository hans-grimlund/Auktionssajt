using Auktionssajt.Data.Interfaces;
using Auktionssajt.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Auktionssajt.Data.Repository
{
    public class UserRepo : IUserRepo
    {
        public void DeleteUser(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString.str))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);

                db.Execute("DeleteUser", parameters, commandType: CommandType.Text);
            }
        } 
        public List<UserEntity> GetAllUsers()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString.str))
            {
                return db.Query<UserEntity>("GetAllUsers", commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public UserEntity GetUser(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString.str))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);

                return db.QueryFirstOrDefault<UserEntity>("GetUserFromId", commandType: CommandType.StoredProcedure)!;
            }
        }
        public void NewUser(UserEntity user)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString.str))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserName", user.UserName);
                parameters.Add("@Psw", user.UserPsw);

                db.Execute("InsertUser", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateUser(UserEntity user)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString.str))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserID", user.UserID);
                parameters.Add("@UserPsw", user.UserPsw);

                db.Execute("UpdateUser", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
