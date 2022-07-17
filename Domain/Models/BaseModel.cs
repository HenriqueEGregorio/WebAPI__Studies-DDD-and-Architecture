using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
    }
}