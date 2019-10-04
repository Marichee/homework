using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels
{
    public class SessionDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Numbers { get; set; }
        public string WinnerBoard { get; set; }
        public virtual ICollection<TicketsDto> Tickets { get; set; }
        [NotMapped]
        public virtual ICollection<UserDto> Winners { get; set; }

    }
}
