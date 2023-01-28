using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class EmployeeController
    {
        public DataTable dayExpenseAmount(int subeler_id,int personel_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "GunlukMasrafTutariEmployee";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subeler_id", subeler_id);
                    cmd.Parameters.AddWithValue("@personel_id", personel_id);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dt);
                        }
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable monthExpenseAmount(int subeler_id, int personel_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AylikMasrafTutariEmployee";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subeler_id", subeler_id);
                    cmd.Parameters.AddWithValue("@personel_id", personel_id);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dt);
                        }
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable yearExpenseAmount(int subeler_id, int personel_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "YillikMasrafTutariEmployee";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subeler_id", subeler_id);
                    cmd.Parameters.AddWithValue("@personel_id", personel_id);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dt);
                        }
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable totalExpenseAmount(int subeler_id, int personel_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "ToplamMasrafTutariEmployee";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subeler_id", subeler_id);
                    cmd.Parameters.AddWithValue("@personel_id", personel_id);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dt);
                        }
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable dayVoyageCount(int subeler_id, int personel_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "GunlukSeferSayisiEmployee";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subeler_id", subeler_id);
                    cmd.Parameters.AddWithValue("@personel_id", personel_id);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dt);
                        }
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable monthVoyageCount(int subeler_id, int personel_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AylikSeferSayisiEmployee";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subeler_id", subeler_id);
                    cmd.Parameters.AddWithValue("@personel_id", personel_id);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dt);
                        }
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable yearVoyageCount(int subeler_id, int personel_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "YillikSeferSayisiEmployee";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subeler_id", subeler_id);
                    cmd.Parameters.AddWithValue("@personel_id", personel_id);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dt);
                        }
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable totalVoyageCount(int subeler_id, int personel_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "ToplamSeferSayisiEmployee";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subeler_id", subeler_id);
                    cmd.Parameters.AddWithValue("@personel_id", personel_id);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dt);
                        }
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable dailyTickets(int subeler_id, int personel_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "GunlukSatilanBiletEmployee";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subeler_id", subeler_id);
                    cmd.Parameters.AddWithValue("@personel_id", personel_id);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dt);
                        }
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable monthlyTickets(int subeler_id, int personel_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AylikSatilanBiletEmployee";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subeler_id", subeler_id);
                    cmd.Parameters.AddWithValue("@personel_id", personel_id);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dt);
                        }
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable yearlyTickets(int subeler_id, int personel_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "YillikSatilanBiletEmployee";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subeler_id", subeler_id);
                    cmd.Parameters.AddWithValue("@personel_id", personel_id);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dt);
                        }
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable totalTickets(int subeler_id,int personel_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "ToplamSatilanBiletEmployee";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subeler_id", subeler_id);
                    cmd.Parameters.AddWithValue("@personel_id", personel_id);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dt);
                        }
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
    }
}
