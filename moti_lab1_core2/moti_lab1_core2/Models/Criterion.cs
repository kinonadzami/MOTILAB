using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace moti_lab1_core2.Models
{
    public class Criterion
    {
        [Key]
        public int CNum { get; set; }
        public string CName { get; set; }
        public int CRange { get; set; }
        public int CWeight { get; set; }
        public string CType { get; set; }
        public string OptimType { get; set; }
        public string Edizmer { get; set; }
        public string ScaleType { get; set; }
    }
}
