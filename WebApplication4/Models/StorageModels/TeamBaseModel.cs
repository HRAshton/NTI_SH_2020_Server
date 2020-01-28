using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models.StorageModels
{
    public abstract class TeamBaseModel
    {
        protected TeamBaseModel(string name, string password)
        {
            Name = name;
            Password = password;
        }

        [Key] 
        public string Login { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public DateTime? LastRequestTime { get; set; }
    }
}