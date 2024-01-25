using Auktionssajt.Data.Interfaces;
using Auktionssajt.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Auktionssajt.Data.Repository
{
    public class BidRepo : IBidRepo
    {

        public void DeleteBid(int id)
        {

            using (IDbConnection db = new SqlConnection(ConnectionString.str))
            {
                string sql = "DeleteBid";

                db.Execute(sql, new { @id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public BidEntity GetBid(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", id);

            return conn.QueryFirstOrDefault<BidEntity>("SelectBid", parameters, commandType: CommandType.StoredProcedure)!;
        }

        public List<BidEntity> GetBidsFromAuction(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString.str))
            {
                string sql = "GetBidsFromAuctionID";

                var model = db.Query<BidEntity>(sql, new { @id = id }, commandType: CommandType.StoredProcedure).ToList();

                return model;
            }
        }

        public List<BidEntity> GetBidsFromUser(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString.str))
            {
                string sql = "GetBidsFromUserID";

                var model = db.Query<BidEntity>(sql, new { @id = id }, commandType: CommandType.StoredProcedure).ToList();

                return model;
            }
        }

        public void InsertBid(BidEntity bid)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString.str))
            {
                string sql = "InsertBid";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserID", bid.UserId);
                parameters.Add("@BidPrice", bid.BidPrice);
                parameters.Add("@AuctionId", bid.AuctionId);


                db.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}