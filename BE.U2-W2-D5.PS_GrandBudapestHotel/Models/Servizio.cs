using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BE.U2_W2_D5.PS_GrandBudapestHotel.Models
{
    public class Servizio
    {
        public int IdServizio { get; set; }

        public string TipoServizio { get; set; }
        [Display(Name = "Quantità")]
        public int Quantita { get; set; }
        [Display(Name = "Prezzo Totale")]

        public decimal  PrezzoTot { get; set; }

        [Display(Name = "Data Aggiunta")]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime DataAggiunta { get; set; }

        public int IdPrenotazione { get; set; }
    }
}