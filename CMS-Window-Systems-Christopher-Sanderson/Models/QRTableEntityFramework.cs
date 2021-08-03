//Christopher Sanderson
//CMS-Window-Systems-Christopher-Sanderson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CMS_Window_Systems_Christopher_Sanderson.Models
{
    public class QRTableEntityFramework: QRTableInterface
    {
        //creating a private databse context variable that can only be used in this class
        private ApplicationDbContext context;

        //assigning a 
        public QRTableEntityFramework(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }

        //creating and assigning a 
        public IQueryable<QRTable> qrTablesContext => context.QRTable;
        public bool CreateRecord(QRTable qRTableRecord)
        {
            //creating a boolean variable to determine if the database 
            bool recordCreated = true;
            try
            {
                //if(qRTable.ItemKeyID.ToString().Length >= 1 && qRTable.ItemKeyID.ToString().Length <= 3 && qRTable.JobKeyID.ToString().Length >= 1 && qRTable.JobKeyID.ToString().Length <= 8)
                //{
                //    qRTable.ScanDate = DateTime.Now;
                this.context.QRTable.Add(qRTableRecord);// context.QRTable.Add(qRTable);
                context.SaveChanges();
                //}
            }
            catch(Exception ex)
            {
                recordCreated = false;
                return recordCreated;
            }
            recordCreated = true;
            return recordCreated;
        }


    }
}
