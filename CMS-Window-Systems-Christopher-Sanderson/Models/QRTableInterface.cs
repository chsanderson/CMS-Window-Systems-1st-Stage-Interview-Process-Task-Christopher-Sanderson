//Christopher Sanderson
//CMS-Window-Systems-Christopher-Sanderson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CMS_Window_Systems_Christopher_Sanderson.Models
{
    public interface QRTableInterface
    {
        public IQueryable<QRTable> qrTablesContext { get; }
        public bool CreateRecord(QRTable qRTable);
    }
}
