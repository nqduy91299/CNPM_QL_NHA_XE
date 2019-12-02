using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaXeFinalProject.DAO
{
    public class adminDAO
    {
        private static adminDAO instance;

        public static adminDAO Instance
        {
            get { if (instance == null) instance = new adminDAO(); return instance; }
            private set { instance = value; }
        }

        private adminDAO() { }

        public bool InsertNV(string id, string ten, string ngaysinh, string gt, string cmnd, string diachi, string sdt, string ngayvao, string chucvu)
        {
            string query = String.Format("INSERT INTO NHAN_VIEN VALUES('{8}', N'{0}', '{1}', N'{2}', '{3}', N'{4}', '{5}', '{6}', N'{7}')", ten, ngaysinh, gt, cmnd, diachi, sdt, ngayvao, chucvu, id);
            int result = dataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateNV(string ten, string ngaysinh, string gt, string cmnd, string diachi, string sdt, string ngayvao, string chucvu, string msnv)
        {
            string query = String.Format("UPDATE NHAN_VIEN SET TEN_NV = N'{0}', NGAY_SINH = '{1}', GIOI_TINH = N'{2}', CMND = '{3}', DIA_CHI = N'{4}', SDT = '{5}', NGAY_VAO_LAM = '{6}', CHUC_VU = N'{7}' WHERE MA_NV = '{8}'", ten, ngaysinh, gt, cmnd, diachi, sdt, ngayvao, chucvu, msnv);
            int result = dataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteNV(string msnv)
        {
            string query = String.Format("DELETE NHAN_VIEN WHERE MA_NV = '{0}'", msnv);
            int result = dataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }


        public bool InsertXE(string bienso, string soghe, string tenxe, string idgiokh)
        {
            string query = String.Format("INSERT INTO XE VALUES('{0}', '{1}', '{2}', '{3}')", soghe, tenxe, bienso, idgiokh);
            int result = dataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateXE(string bienso, string soghe, string tenxe, string msxe, string idgiokh)
        {
            string query = String.Format("UPDATE XE SET SO_GHE = '{0}', TEN_XE = '{1}', BIEN_SO = '{2}', ID_GIOKH = '{4}' WHERE ID = '{3}'", soghe, tenxe, bienso, msxe, idgiokh);
            int result = dataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteXE(string msxe)
        {
            string query = String.Format("DELETE XE WHERE ID = '{0}'", msxe);
            int result = dataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }


        public bool UpdateLUONG(string chucvu, string tienluong)
        {
            string query = String.Format("UPDATE LUONG_COBAN SET TIEN_LUONG = '{1}' WHERE CHUC_VU = N'{0}'", chucvu, tienluong);
            int result = dataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteCHUYEN(string machuyen)
        {
            string query = String.Format("DELETE LICH_TRINH WHERE ID = '{0}'", machuyen);
            int result = dataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateCHUYEN(string id, string idxe, string giave, string idnv)
        {
            string query = String.Format("UPDATE LICH_TRINH SET ID_XE = '{1}', GIA_VE = '{2}', MA_NV = '{3}' WHERE ID = '{0}'", id, idxe, giave, idnv);
            int result = dataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool InsertCHUYEN(string idxe, string giave, string idnv)
        {
            string query = String.Format("INSERT INTO LICH_TRINH VALUES('{0}', '{1}', '{2}')", idxe, giave, idnv);
            int result = dataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }


    }
}
