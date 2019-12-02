using QuanLyNhaXeFinalProject.TDO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXeFinalProject.DAO
{
    public class lichtrinhDAO
    {
        private static lichtrinhDAO instance;
        public static lichtrinhDAO Instance
        {
            get { if (instance == null) instance = new lichtrinhDAO(); return instance; }
            private set { instance = value; }
        } 

        private lichtrinhDAO() { }

        public int GetCast(int id)
        {
            DataTable data = dataProvider.Instance.ExecuteQuery("SELECT * FROM LICH_TRINH WHERE ID_XE = " + id);
            if (data.Rows.Count > 0)
            {
                lichtrinh lichtrinh = new lichtrinh(data.Rows[0]);
                return lichtrinh.Giave;
            }
            return 0;
        }
    }
}
