using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace BE.U2_W2_D5.PS_GrandBudapestHotel.Models
{
    public class Camera
    {
        [Display(Name = "Nr Camera")]
        public int IdCamera { get; set; }
        public int NumeroCamera { get; set; }

        public string Descrizione { get; set; }

        [Display(Name = "Tipologia camera")]
        public string TipoCamera { get; set;}

        // DROPDOWN
        public static List<SelectListItem> ListaCamera
        {
            get
            {
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                SqlConnection sql = Connessioni.GetConnection();
                sql.Open();
                SqlCommand com = Connessioni.GetCommand("SELECT * FROM CAMERA", sql);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    SelectListItem s = new SelectListItem
                    {
                       
                        Text = reader["TipoCamera"].ToString() + " " + reader["Descrizione"],
                        Value = reader["IdCamera"].ToString(),
                    };

                    selectListItems.Add(s);
                }
                return selectListItems;
            }

        }
    }
}