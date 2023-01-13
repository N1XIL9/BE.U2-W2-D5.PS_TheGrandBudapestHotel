using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BE.U2_W2_D5.PS_GrandBudapestHotel.Models
{
    public class UserLog
    {
        public int IdUtente { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public static bool Autenticato(string username, string password)
        {
            SqlConnection con = Connessioni.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [AUTENTICAZIONE] WHERE Username = @username and [Password]=@Password", con);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
            return false;
        }


    }
}
