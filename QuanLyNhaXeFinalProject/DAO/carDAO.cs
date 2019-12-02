using QuanLyNhaXeFinalProject.TDO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXeFinalProject.DAO
{
    public class carDAO
    {
        public static carDAO instance;

        public static carDAO Instance
        {
            get { if (instance == null) instance = new carDAO(); return carDAO.instance; }
            private set { carDAO.instance = value; }
        }
        private carDAO()
        {

        }

        public List<car> GetListCar(int id)
        {
            List<car> list = new List<car>();
            string query = "SELECT * FROM XE WHERE ID_GIOKH = " + id;
            DataTable data = dataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                car car= new car(item);
                list.Add(car);
            }
            return list;
        }

        public int GetGhe(int id)
        {
            DataTable data = dataProvider.Instance.ExecuteQuery("SELECT * FROM XE WHERE ID = " + id);
            if (data.Rows.Count > 0)
            {
                car car = new car(data.Rows[0]);
                return car.Soghe;
            }
            return 0;
        }
        public int Getidxe(int id)
        {
            DataTable data = dataProvider.Instance.ExecuteQuery("SELECT * FROM XE WHERE ID = " + id);
            if (data.Rows.Count > 0)
            {
                car car = new car(data.Rows[0]);
                return car.ID;
            }
            return 0;
        }

    }
}
