using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXeFinalProject.TDO
{
    public class gioKH
    {

        public gioKH(int id, string gio, int idtuyen)
        {
            this.ID = id;
            this.Gio = gio;
            this.iDtuyen = idtuyen;
        }

        public gioKH(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Gio = row["GIO"].ToString(); ;
            this.iDtuyen = (int)row["ID_TUYEN_XE"];
        }



        private int iD;
        private string gio;
        private int iDtuyen;


        public int ID {
            get { return iD; }
            set { iD = value; }
        }
        public string Gio {
            get { return gio; }
            set { gio = value; }
        }
        public int IDtuyen
        {
            get { return iDtuyen; }
            set { iDtuyen = value; }
        }
    }
}
