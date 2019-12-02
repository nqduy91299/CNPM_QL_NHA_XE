using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXeFinalProject.TDO
{
    public class lichtrinh
    {

        public lichtrinh(int id, int idxe, int giave, int manv)
        {
            this.ID = id;
            this.Giave = giave;
            this.Idxe = idxe;
            this.Manv = manv;
        }

        public lichtrinh(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Idxe = (int)row["ID_XE"];
            this.Giave = (int)row["GIA_VE"];
            this.Manv = row["MA_NV"].GetHashCode();
        }

        private int manv;
        private int iD;
        private int idxe;
        private int giave;

        public int ID {
            get { return iD; }
            set { iD = value; }
        }
        public int Idxe {
            get { return idxe; }
            set { idxe = value; }
        }
      

        public int Giave {
            get { return giave; }
            set { giave = value; }
        }

        public int Manv {
            get { return manv; }
            set { manv = value; }
        }
    }
}
