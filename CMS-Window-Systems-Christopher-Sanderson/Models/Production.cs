//Christopher Sanderson
//CMS-Window-Systems-Christopher-Sanderson
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Window_Systems_Christopher_Sanderson.Models
{
    public class Production
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(8)]
        public long JobKeyID { get; set; }
        //public int JobKeyID { get; set; }
        [MaxLength(3)]
        public int ItemKeyID { get; set; }
        [MaxLength(100)]
        public string productName { get; set; }
    }
}
