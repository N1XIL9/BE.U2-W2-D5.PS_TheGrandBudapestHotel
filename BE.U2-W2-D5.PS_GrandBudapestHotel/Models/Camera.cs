using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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
    }
}