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
    public class Clienti
    {
        public int IdCliente { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }

        [Display(Name = "Codice Fiscale")]

        public string CF { get; set; }

        [Display(Name = "Città")]

        public string Citta { get; set; }
        public string Provincia { get; set;}
        public string Email { get; set;}

        public string Telefono { get; set;}

        public string Cellulare { get; set; }

        public int IdPrenotazione { get; set;}


        // DROPDOWN
        public static List<SelectListItem> ListaClienti
        {
            get
            {
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                SqlConnection sql = Connessioni.GetConnection();
                sql.Open();
                SqlCommand com = Connessioni.GetCommand("SELECT * FROM CLIENTE", sql);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    SelectListItem s = new SelectListItem
                    {
                        Text = reader["Cognome"].ToString() + " " + reader["Nome"].ToString(),
                        Value = reader["IdCliente"].ToString()
                    };

                    selectListItems.Add(s);
                }
                return selectListItems;
            }

        }
    }
}