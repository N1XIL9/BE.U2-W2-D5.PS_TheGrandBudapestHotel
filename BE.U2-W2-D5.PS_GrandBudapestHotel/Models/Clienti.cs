using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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
        public int IdPrenotazione { get; set;}
    }
}