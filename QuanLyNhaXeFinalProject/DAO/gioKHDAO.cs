using QuanLyNhaXeFinalProject.TDO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXeFinalProject.DAO
{
    public class gioKHDAO
    {
        private static gioKHDAO instance;

        public static gioKHDAO Instance
        {
            get { if (instance == null) instance = new gioKHDAO(); return gioKHDAO.instance; }
            private set { gioKHDAO.instance = value; }
        }
        private gioKHDAO()
        {

        }

        public List<gioKH> GetListGioKH(int id)
        {
            List<gioKH> list = new List<gioKH>();
            string query = "SELECT * FROM GIO_CHAY WHERE ID_TUYEN_XE = " + id;
            DataTable data = dataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                gioKH giokh = new gioKH(item);
                list.Add(giokh);
            }
            return list;
        }
    }
}
