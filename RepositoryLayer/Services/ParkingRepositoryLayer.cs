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
        /// <param name="data"> store the Complete Parking information</param>
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
        ///   database connection for Update Excisting entry
        /// </summary>
        /// <param name="ParkingID">Primary key</param>
        /// <param name="data">Update data</param>
        /// <returns></returns>
        public int UpdateParkingDetail(int ParkingID, UpdateParking data)
        {
            try
            {
                SqlConnection connection = DatabaseConnection();
                //for store procedure and connection to database 
                SqlCommand command = StoreProcedureConnection("spUpdateParkingdetails", connection);
                command.Parameters.Add("@ParkingID", SqlDbType.Int).Value = ParkingID;
                command.Parameters.AddWithValue("@ParkingStatus", data.ParkingStatus);
                command.Parameters.AddWithValue("@ExitTime", data.ExitTime);
                connection.Open();
                int Response = command.ExecuteNonQuery();
                connection.Close();
                if (Response == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  database connection get specific parking details
        /// </summary>
        /// <param name="ParkingID">Get specific parking details</param>
        /// <returns></returns>
        public ParkingDetails GetspecificParkingDetails(int ParkingID)
        {
            try
            {
                ParkingDetails parking = new ParkingDetails();
                SqlConnection connection = DatabaseConnection();
                //for store procedure and connection to database 
                SqlCommand command = StoreProcedureConnection("spSpecificParkingDetails", connection);
                command.Parameters.Add("@ParkingID", SqlDbType.Int).Value = ParkingID;
                connection.Open();
                //Read data from database
                SqlDataReader Response = command.ExecuteReader();
                while (Response.Read())
                {
                    parking.ParkingID = Convert.ToInt32(Response["ParkingID"]);
                    parking.UserID = Convert.ToInt32(Response["UserID"]);
                    parking.VehicleOwnerAddress = Response["VehicleOwnerAddress"].ToString();
                    parking.VehicleNumber = Response["VehicleNumber"].ToString();
                    parking.VehicalBrand = Response["VehicalBrand"].ToString();
                    parking.VehicalColor = Response["VehicalColor"].ToString();
                    parking.ParkingSlot = Response["ParkingSlot"].ToString();
                    parking.ParkingUserCategory = Response["ParkingUserCategory"].ToString();
                    parking.ParkingStatus = Response["ParkingStatus"].ToString();
                    parking.Charges = Response["Charges"].ToString();
                    parking.EntryTime = Convert.ToDateTime(Response["EntryTime"]);
                    parking.ExitTime = Convert.ToDateTime(Response["ExitTime"]);
                }
                connection.Close();
                return parking;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  database connection for get all Parking details
        /// </summary>
        public IEnumerable<ParkingDetails> GetAllParkingDetails()
        {
            try
            {
                List<ParkingDetails> listparking = new List<ParkingDetails>();
                SqlConnection connection = DatabaseConnection();
                //for store procedure and connection to database 
                SqlCommand command = StoreProcedureConnection("spAllVehicleParking", connection);
                connection.Open();
                //Read data from database
                SqlDataReader Response = command.ExecuteReader();
                while (Response.Read())
                {
                    ParkingDetails parking = new ParkingDetails();
                    parking.ParkingID = Convert.ToInt32(Response["ParkingID"]);
                    parking.UserID = Convert.ToInt32(Response["UserID"]);
                    parking.VehicleOwnerAddress = Response["VehicleOwnerAddress"].ToString();
                    parking.VehicleNumber = Response["VehicleNumber"].ToString();
                    parking.VehicalBrand = Response["VehicalBrand"].ToString();
                    parking.VehicalColor = Response["VehicalColor"].ToString();
                    parking.ParkingSlot = Response["ParkingSlot"].ToString();
                    parking.ParkingUserCategory = Response["ParkingUserCategory"].ToString();
                    parking.ParkingStatus = Response["ParkingStatus"].ToString();
                    parking.Charges = Response["Charges"].ToString();
                    parking.EntryTime = Convert.ToDateTime(Response["EntryTime"]);
                    parking.ExitTime = Convert.ToDateTime(Response["ExitTime"]);
                    listparking.Add(parking);
                }
                connection.Close();
                return listparking;
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
