using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BE.U2_W2_D5.PS_GrandBudapestHotel.Models
{
    public class Prenotazioni
    {
        [Display(Name = "Nr Prenotazione")]
        public int IdPrenotazione { get; set; }

        [Display(Name ="Data Prenotazione")]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd", ApplyFormatInEditMode= true)]
        public DateTime DataPrenotazione { set; get; }

        [Display(Name = "Check-In")]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime Checkin { set; get; }

        [Display(Name = "Check-Out")]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime CheckOut { set; get; }

        public decimal Caparra { set; get; }

        public decimal TariffaSoggiorno { set; get; }

        public int IdPensione { get; set; }

        public int IdCliente { get; set; }

        public int IdCamera { get; set; }





    }
}