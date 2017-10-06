using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace moti_lab1_core2.Models
{
    public class LPR
    {
        [Key]
        public int LNum { get; set; }
        public string LName { get; set; }
        public int LRange { get; set; }
    }
}
