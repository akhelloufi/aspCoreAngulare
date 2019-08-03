using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Machine
    {
            [Key]
            public int ID { get; set; }

            //[index("codeapp", IsUnique = true)]
            public string Code { get; set; }
            public string Nom { get; set; }
            //

            public DateTime DatePurchase { get; set; }
            public DateTime DateFabrication { get; set; }
            public DateTime LastDateUse { get; set; }
            public String NatureDiseaseTreat { get; set; }
            public double prixPurchase { get; set; }
            //-Fréquence d utilisation : quotidienne ,semaine , mensuel.
            public String FrequencyUsage{ get; set; }
            public string ConditionUse { get; set; }
            public Boolean Available { get; set; }

            public int HospitalID { get; set; }

    }
}
