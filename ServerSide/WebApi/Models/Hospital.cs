using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Hospital
    {
        //        -référence hôpital
        //-Nom Hôpital
        //-position géographique
        //-ville
        //-région
        //-adresse
        //-tel

        [Key]
        public int ID { get; set; }
        
        public string Ref { get; set; }
        public string Nom { get; set; }
        public string PositionGeographique { get; set; }
        public string Ville { get; set; }
        public string Region { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public int AdminID { get; set; }
        

        [ForeignKey("HospitalID")]
        public ICollection<Machine> Machines { get; set; }

    }
}
