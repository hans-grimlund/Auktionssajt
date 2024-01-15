using Auktionssajt.Data.Interfaces;
using Auktionssajt.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return db.Query<UserEntity>("SelectAllUsers", commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public UserEntity GetUser(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString.str))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);

                return db.QueryFirstOrDefault<UserEntity>("SelectUserID", commandType: CommandType.StoredProcedure)!;
            }
        }
        public UserEntity GetUser(string userName)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString.str))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@userName", userName);

                return db.QueryFirstOrDefault<UserEntity>("SelectuserName", commandType: CommandType.StoredProcedure)!;
            }

        }
        public void NewUser(UserEntity user)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString.str))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserName", user.UserName);
                parameters.Add("@Psw", user.Psw);

                db.Execute("InsertAdvertisement", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateUser(UserEntity user)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString.str))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserID", user.UserID);
                parameters.Add("@UserName", user.UserName);
                parameters.Add("@UserPsw", user.UserPsw);

                db.Execute("UpdateUser", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
