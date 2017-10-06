using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace moti_lab1_core2.Models
{
    public class Alternative
    {
        [Key]
        public int ANum { get; set; }
        public string AName { get; set; }
    }
}
