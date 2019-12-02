using QuanLyNhaXeFinalProject.TDO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXeFinalProject.DAO
{
    public class routeDAO
    {
        private static routeDAO instance;

        public static routeDAO Instance
        {
            get { if (instance == null) instance = new routeDAO(); return routeDAO.instance; }
            private set { routeDAO.instance = value; }
        }
        private routeDAO()
        {
            
        }

        public List<Route> GetListRoute()
        {
            List<Route> list = new List<Route>();
            string query = "SELECT * FROM TUYEN_XE";
            DataTable data = dataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                Route route = new Route(item);
                list.Add(route);
            }

            return list;

        }
        
        
    }
}
