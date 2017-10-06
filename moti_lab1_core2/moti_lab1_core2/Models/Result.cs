﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace moti_lab1_core2.Models
{
    public class Result
    {
        [Key]
        public int RNum { get; set; }
        public int LNum { get; set; }
        public LPR LPR { get; set; }
        public int ANum { get; set; }
        public Alternative Alternative { get; set; }
        public int Range { get; set; }
        public int AWeight { get; set; }
    }
}
