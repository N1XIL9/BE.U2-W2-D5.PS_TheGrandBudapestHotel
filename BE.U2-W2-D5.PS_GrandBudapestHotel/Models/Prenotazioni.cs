using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BE.U2_W2_D5.PS_GrandBudapestHotel.Models
{
    public class Prenotazioni
    {
        [Display(Name = "Prenotazione")]
        public int IdPrenotazione { get; set; }
        [Display(Name = "Cognome")]

        public string Cognome { get; set; }

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Numero Camera")]
        public int NumeroCamera { get; set; }

        [Display(Name ="Data Prenotazione")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode= true)]
        public DateTime DataPrenotazione { set; get; }

        [Display(Name = "Check-In")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Checkin { set; get; }

        [Display(Name = "Check-Out")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CheckOut { set; get; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Caparra { set; get; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Tariffa Soggiorno")]
        public decimal TariffaSoggiorno { set; get; }
        [Display(Name = "Tipo Pensione")]
        public string TipoPensione { get; set; }
        public int IdCamera { get; set; }

        



    }
}