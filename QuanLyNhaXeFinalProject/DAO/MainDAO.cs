using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXeFinalProject.DAO
{
    public class MainDAO
    {
        private static MainDAO instance;

        public static MainDAO Instance
        {
            get { if (instance == null) instance = new MainDAO(); return instance; }
            private set { instance = value; }
        }

        private MainDAO() { }

        public bool InsertBill(string tenkh, string sdt, string ghe, string chuyen, string gio, string bienso, string idxe)
        {
            string query = String.Format("INSERT INTO TT_VE VALUES(N'{0}', '{1}', '{2}', N'{3}', '{4}', '{5}', '{6}', GETDATE())", tenkh, sdt, ghe, chuyen, gio, bienso, idxe);
            int result = dataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteVE(string idve)
        {
            string query = String.Format("DELETE TT_VE WHERE ID = '{0}'", idve);
            int result = dataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
