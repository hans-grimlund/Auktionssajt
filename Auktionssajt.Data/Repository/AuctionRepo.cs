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
            parameters.Add("Title", auction.Title);
            parameters.Add("Description", auction.Description);
            parameters.Add("Category", auction.Category);
            parameters.Add("User", auction.User);

            conn.Execute("InsertAuction", parameters, commandType: System.Data.CommandType.Text);
        }

        public void EditAuction(AuctionEntity auction)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("Id", auction.Id);
            parameters.Add("Title", auction.Title);
            parameters.Add("Description", auction.Description);
            parameters.Add("Category", auction.Category);
            parameters.Add("User", auction.User);

            conn.Execute("UpdateAuction", parameters, commandType: System.Data.CommandType.Text);
        }

        public void DeleteAuction(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("Id", id);

            conn.Execute("DeleteAuction", parameters, commandType: System.Data.CommandType.Text);
        }

        AuctionEntity IAuctionRepo.GetAuction(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("Id", id);

            return conn.QueryFirstOrDefault<AuctionEntity>("GetAuction", parameters, commandType: System.Data.CommandType.Text)!;
        }

        public List<AuctionEntity> GetAuctionsFromUser(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("Id", id);

            return conn.Query<AuctionEntity>("GetAuctionsFromEmail", parameters, commandType: System.Data.CommandType.Text).ToList();
        }

        public List<AuctionEntity> GetAuctionsFromUser(string username)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("Username", username);

            return conn.Query<AuctionEntity>("GetAuctionsFromUsername", parameters, commandType: System.Data.CommandType.Text).ToList();
        }

        public List<AuctionEntity> GetAllAuctions()
        {
            using SqlConnection conn = new(ConnectionString.str);

            return conn.Query<AuctionEntity>("GetAllAuctions", commandType: System.Data.CommandType.Text).ToList();
        }
    }
}