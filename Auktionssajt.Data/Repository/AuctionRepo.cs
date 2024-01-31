using Auktionssajt.Data.Interfaces;
using Auktionssajt.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Auktionssajt.Data.Repository
{
    public class AuctionRepo : IAuctionRepo
    {
        public void NewAuction(AuctionEntity auction)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Title", auction.Title);
            parameters.Add("@Description", auction.Description);
            parameters.Add("@UserId", auction.UserId);
            parameters.Add("@StartingPrice", auction.StartingPrice);
            parameters.Add("@StartTime", DateTime.Now);
            parameters.Add("@EndTime", auction.EndTime);

            conn.Execute("InsertAuction", parameters, commandType: CommandType.StoredProcedure);
        }

        public void EditAuction(AuctionEntity auction)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", auction.Id);
            parameters.Add("@Title", auction.Title);
            parameters.Add("@Description", auction.Description);
            parameters.Add("@UserId", auction.UserId);
            parameters.Add("@StartingPrice", auction.StartingPrice);

            conn.Execute("UpdateAuction", parameters, commandType: CommandType.StoredProcedure);
        }

        public void DeleteAuction(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", id);

            conn.Execute("DeleteAuction", parameters, commandType: CommandType.StoredProcedure);
        }

        public void CloseAuction(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", id);
            parameters.Add("@EndTime", DateTime.Now);

            conn.Execute("CloseAuction", parameters, commandType: CommandType.StoredProcedure);
        }

        public AuctionEntity GetAuction(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", id);

            return conn.QueryFirstOrDefault<AuctionEntity>("GetAuction", parameters, commandType: CommandType.StoredProcedure)!;
        }

        public List<AuctionEntity> FindAuction(string searchterm)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Searchterm", searchterm);

            return conn.Query<AuctionEntity>("FindAuction", parameters, commandType: CommandType.StoredProcedure).ToList();
        }

        public List<AuctionEntity> GetAuctionsFromUser(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", id);

            return conn.Query<AuctionEntity>("GetAuctionsFromUser", parameters, commandType: CommandType.StoredProcedure).ToList();
        }

        public List<AuctionEntity> GetAllAuctions()
        {
            using SqlConnection conn = new(ConnectionString.str);

            return conn.Query<AuctionEntity>("GetAllAuctions", commandType: CommandType.StoredProcedure).ToList();
        }
    }
}