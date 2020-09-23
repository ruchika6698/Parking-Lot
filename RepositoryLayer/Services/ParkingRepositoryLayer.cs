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
                command.Parameters.AddWithValue("@VehicleOwnerName", data.VehicleOwnerName);
                command.Parameters.AddWithValue("@VehicleOwnerAddress", data.VehicleOwnerAddress);
                command.Parameters.AddWithValue("@VehicleNumber", data.VehicleNumber);
                command.Parameters.AddWithValue("@VehicalBrand", data.VehicalBrand);
                command.Parameters.AddWithValue("@VehicalColor", data.VehicalColor);
                command.Parameters.AddWithValue("@ParkingSlot", data.ParkingSlot);
                command.Parameters.AddWithValue("@ParkingUserCategory", data.ParkingUserCategory);
                command.Parameters.AddWithValue("@ParkingStatus", data.ParkingStatus);
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
