using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace moti_lab1_core2.Models
{
    public class Mark
    {
        [Key]
        public int MNum { get; set; }
        public int CNum { get; set; }
        public Criterion Criterion { get; set; }
        public string MNAme { get; set; }
        public int MRange { get; set; }
        public int NumMark { get; set; }
        public int NormMark { get; set; }
    }
}
