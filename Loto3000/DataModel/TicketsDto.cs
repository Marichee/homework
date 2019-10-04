using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels
{
    public class TicketsDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ticket { get; set; }
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public virtual UserDto User { get; set; }
        public virtual SessionDto Session { get; set; }
        [NotMapped]
        public virtual ICollection<TicketsDto> Tickets { get; set; }
    }
}
