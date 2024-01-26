using Auktionssajt.Data.Interfaces;
using Auktionssajt.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

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

            conn.Execute("InsertAuction", parameters, commandType: System.Data.CommandType.Text);
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

            conn.Execute("UpdateAuction", parameters, commandType: System.Data.CommandType.Text);
        }

        public void DeleteAuction(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", id);

            conn.Execute("DeleteAuction", parameters, commandType: System.Data.CommandType.Text);
        }

        public void CloseAuction(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", id);
            parameters.Add("@EndTime", DateTime.Now);

            conn.Execute("CloseAuction", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public AuctionEntity GetAuction(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", id);

            return conn.QueryFirstOrDefault<AuctionEntity>("SelectAuction", parameters, commandType: System.Data.CommandType.Text)!;
        }

        public List<AuctionEntity> FindAuction(string searchterm)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Searchterm", searchterm);

            return conn.Query<AuctionEntity>("FindAuction", parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
        }

        public List<AuctionEntity> GetAuctionsFromUser(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", id);

            return conn.Query<AuctionEntity>("SelectAuctionsFromUser", parameters, commandType: System.Data.CommandType.Text).ToList();
        }

        public List<AuctionEntity> GetAllAuctions()
        {
            using SqlConnection conn = new(ConnectionString.str);

            return conn.Query<AuctionEntity>("SelectAllAuctions", commandType: System.Data.CommandType.Text).ToList();
        }
    }
}