using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _23_02_2024_LAB.Data
{
    internal class EventDao
    {
        private string connectionStr = "Server=MOON09\\SQLEXPRESS;Database=LAB_2;Trusted_Connection=true";
        public int InsertEvent(string name,string desc,string address,DateOnly startdate,TimeOnly starttime,TimeOnly endtime)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "insert into Events(name, desc, address, startdate, starttime, endtime) values (@name, @desc, @address, @startdate, @starttime, @endtime)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@desc", desc);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@startdate", startdate);
                    cmd.Parameters.AddWithValue("@starttime", starttime);
                    cmd.Parameters.AddWithValue("@endtime", endtime);

                    result = cmd.ExecuteNonQuery();
                    
                }
            }
            return result;
        }

        public int DeleteEvent(int id)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "delete from events where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
    }
}
