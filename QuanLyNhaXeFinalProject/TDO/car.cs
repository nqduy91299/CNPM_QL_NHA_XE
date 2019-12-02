using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXeFinalProject.TDO
{
    public class car
    {
        public car(int id, int soghe, string tenxe, string bienso, int idGio)
        {
            this.ID = id;
            this.Soghe = soghe;
            this.Tenxe = tenxe;
            this.Bienso = bienso;
            this.IdGio = idGio;
        }

        public car(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Soghe = (int)row["SO_GHE"];
            this.Tenxe = row["TEN_XE"].ToString(); 
            this.Bienso = row["BIEN_SO"].ToString(); 
            this.IdGio = (int)row["ID_GIOKH"];
        }

        private int iD;
        private int soghe;
        private string tenxe;
        private string bienso;
        private int idGio;

        public int ID {
            get { return iD; }
            set { iD = value; }
        }
        public int Soghe {
            get { return soghe; }
            set { soghe = value; }
        }
        public string Tenxe {
            get { return tenxe; }
            set { tenxe = value; }
        }
        public string Bienso {
            get { return bienso; }
            set { bienso = value; }
        }
        public int IdGio {
            get { return idGio; }
            set { idGio = value; }
        }
    }
}
