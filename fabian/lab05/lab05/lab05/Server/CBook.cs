using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05.Server
{
    public class CBook
    {
        [Required]
        [Key]
        public int bookId { get; set; }

        [Required]
        [MaxLength(50)]
        public string title { get; set; }

        [Required]
        [MaxLength(50)]
        public string author { get; set; }
        
        [MaxLength(50)]
        public string publisher { get; set; }
    }
}
