///-----------------------------------------------------------------
///   Class:       ParkingRepositoryLayer
///   Description: Repository Layer Services for Parking
///   Author:      Ruchika                   Date: 25/9/2020
///-----------------------------------------------------------------
using CommonLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class ParkingRepositoryLayer : IParkingRepositoryLayer
    {
        private readonly IConfiguration configuration;

        public ParkingRepositoryLayer(IConfiguration configur)
        {
            configuration = configur;
        }

        /// <summary>
        ///  database connection for Registrion
        /// </summary>
        /// <param name="data"> store the Complete Employee information</param>
        /// <returns></returns>
        public async Task<bool> VehicleParking(VehicleModel data)
        {
            try
            {
                SqlConnection connection = DatabaseConnection();
                //for store procedure and connection to database
                SqlCommand command = StoreProcedureConnection("spVehicleParking", connection);
                command.Parameters.AddWithValue("@UserID", data.UserID);
                command.Parameters.AddWithValue("@VehicleOwnerAddress", data.VehicleOwnerAddress);
                command.Parameters.AddWithValue("@VehicleNumber", data.VehicleNumber);
                command.Parameters.AddWithValue("@VehicalBrand", data.VehicalBrand);
                command.Parameters.AddWithValue("@VehicalColor", data.VehicalColor);
                command.Parameters.AddWithValue("@ParkingSlot", data.ParkingSlot);
                command.Parameters.AddWithValue("@ParkingUserCategory", data.ParkingUserCategory);
                command.Parameters.AddWithValue("@ParkingStatus", data.ParkingStatus);
                command.Parameters.AddWithValue("@Charges", data.Charges);
                command.Parameters.AddWithValue("@EntryTime", data.EntryTime);
                command.Parameters.AddWithValue("@ExitTime", data.ExitTime);
                connection.Open();
                int Response = await command.ExecuteNonQueryAsync();
                connection.Close();
                if (Response != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  database connection for get all user details
        /// </summary>
        public IEnumerable<ParkingDetails> GetAllParkingDetails()
        {
            try
            {
                List<ParkingDetails> listuser = new List<ParkingDetails>();
                SqlConnection connection = DatabaseConnection();
                //for store procedure and connection to database 
                SqlCommand command = StoreProcedureConnection("spAllVehicleParking", connection);
                connection.Open();
                //Read data from database
                SqlDataReader Response = command.ExecuteReader();
                while (Response.Read())
                {
                    ParkingDetails user = new ParkingDetails();
                    user.ParkingID = Convert.ToInt32(Response["ParkingID"]);
                    user.UserID = Convert.ToInt32(Response["UserID"]);
                    user.VehicleOwnerAddress = Response["VehicleOwnerAddress"].ToString();
                    user.VehicleNumber = Response["VehicleNumber"].ToString();
                    user.VehicalBrand = Response["VehicalBrand"].ToString();
                    user.VehicalColor = Response["VehicalColor"].ToString();
                    user.ParkingSlot = Response["ParkingSlot"].ToString();
                    user.ParkingUserCategory = Response["ParkingUserCategory"].ToString();
                    user.ParkingStatus = Response["ParkingStatus"].ToString();
                    user.Charges = Response["Charges"].ToString();
                    user.EntryTime = Convert.ToDateTime(Response["EntryTime"]);
                    user.ExitTime = Convert.ToDateTime(Response["ExitTime"]);
                    listuser.Add(user);
                }
                connection.Close();
                return listuser;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        ///  database connection with connection string
        /// </summary>
        private SqlConnection DatabaseConnection()
        {
            //connection string
            string connectionString = configuration.GetSection("ConnectionStrings").GetSection("ParkingData").Value;
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// sqlcommand for storeprocedure
        /// </summary>
        /// <param name="Procedurename">Store Procedure</param>
        /// <param name="connection">sql connection</param>
        /// <returns></returns>
        public SqlCommand StoreProcedureConnection(string Procedurename, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(Procedurename, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                return command;
            }
        }
    }
}
