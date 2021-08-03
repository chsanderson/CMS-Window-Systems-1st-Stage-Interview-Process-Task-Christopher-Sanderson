﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Window_Systems_Christopher_Sanderson.Models
{
    public class QRTable
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(8)]
        public int JobKeyID { get; set; }

        [MaxLength(3)]
        public int ItemKeyID { get; set; }

        [DataType(DataType.Date)]
        public DateTime ScanDate { get; set; }
    }
}