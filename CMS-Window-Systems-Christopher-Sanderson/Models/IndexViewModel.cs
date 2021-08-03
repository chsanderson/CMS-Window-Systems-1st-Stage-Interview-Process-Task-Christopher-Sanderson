using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Window_Systems_Christopher_Sanderson.Models
{
    public class IndexViewModel
    {
        public long barcode { get; set; }
        public KeyValuePair<string,Byte[]> qrKVP { get; set; }
        public bool isKVP { get; set; }
    }
}
