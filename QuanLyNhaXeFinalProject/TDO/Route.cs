using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXeFinalProject.TDO
{
    public class Route
    {
        public Route(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public Route(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Name = row["NAME"].ToString();
        }
        private string name;

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public string Name {
            get { return name; }
            set { name = value; }
        }
    }
}
