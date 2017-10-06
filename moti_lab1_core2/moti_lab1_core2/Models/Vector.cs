using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace moti_lab1_core2.Models
{
    public class Vector
    {
        [Key]
        public int VNum { get; set; }
        public int Anum { get; set; }
        public Alternative Alternative { get; set; }
        public int MNum { get; set; }
        public Mark Mark { get; set; }
    }
}
