using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models.StorageModels
{
    [Table("Houses")]
    public class HouseTeamModel : TeamBaseModel
    {
        public HouseTeamModel(string name, string password) : base(name, password)
        {
        }

        public double? Temperature { get; set; }

        public double? Humidity { get; set; }

        public DateTime? LastGuardCall { get; set; }

        public string StatusString
        {
            get
            {
                if ((Temperature < 100 || Temperature == null) && Humidity >= 100)
                {
                    return "Потоп";
                }

                if (Temperature >= 100 && (Humidity < 100 || Humidity == null))
                {
                    return "Потоп";
                }

                if (Temperature >= 100 && Humidity >= 100)
                {
                    return "Потоп и пожар?";
                }

                return "Всё хорошо";
            }
        }
    }

}