using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BE.U2_W2_D5.PS_GrandBudapestHotel.Models
{
    public class Pensione
    {
        public int IdPensione { get; set; }

        public string TipoPensione { get;}

        // DROPDOWN
        public static List<SelectListItem> ListaPensioni
        {
            get
            {
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                SqlConnection sql = Connessioni.GetConnection();
                sql.Open();
                SqlCommand com = Connessioni.GetCommand("SELECT * FROM PENSIONE", sql);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    SelectListItem s = new SelectListItem
                    {
                        Text = reader["TipoPensione"].ToString(),
                        Value = reader["IdPensione"].ToString()
                    };

                    selectListItems.Add(s);
                }
                return selectListItems;
            }

        }
    }
}