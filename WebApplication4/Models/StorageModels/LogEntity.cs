using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models.StorageModels
{
    public class LogEntity
    {
        [Key] public Guid Id { get; set; }

        public string Login { get; set; }

        public DateTime? Time { get; set; }

        public string Method { get; set; }

        public string AdditionalData { get; set; }
    }
}