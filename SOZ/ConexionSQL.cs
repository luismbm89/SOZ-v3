using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SOZ
{
    public static class ConexionSQL
    {
        public static SqlConnection ConexionBD()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                SqlConnectionStringBuilder osql = new SqlConnectionStringBuilder();
                osql.InitialCatalog = "SOZ_BD";
                osql.UserID = "master";
                osql.Password = "Empagro2017";
                osql.DataSource = "192.168.0.3";
                conn = new SqlConnection(osql.ConnectionString);
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                //
            }

            return conn;
        }
        public static void CerrarConexionBD()
        {
            ConexionBD().Close();
        }
        public static void CerrarConexionBD1()
        {
            ConexionBD().Close();
            ConexionBD().Dispose();
        }
        //Metodo para consultar usuario
        public static SqlDataReader consultaDataReader(string osql) //Salen las credenciasles en blanco
        {
            SqlCommand comando = new SqlCommand(osql);
            SqlConnection con = ConexionBD();
            comando.Connection = con;
            SqlDataReader reader = comando.ExecuteReader();
            con.Close();
            return reader;

        }
        //DEvuelve un DataSet
        public static DataSet consulta(string instruccion, string nombre_tabla)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = ConexionBD();
                SqlCommand cmd = new SqlCommand(instruccion, con);
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(ds, nombre_tabla);
                con.Close();
            }
            catch (Exception ex)
            {
                //
            }
            return ds;
        }



        //Devuelve un DataTable
        public static DataTable consultaDataTable(string instruccion, string nombre_tabla)
        {
            SqlConnection con = ConexionBD();
            System.Data.SqlClient.SqlDataAdapter adaptador = new SqlDataAdapter(instruccion, con);
            System.Data.DataSet dsDataSet = new System.Data.DataSet();
            DataTable dtDataTable = null;
            adaptador.Fill(dsDataSet, nombre_tabla);
            dtDataTable = dsDataSet.Tables[0];
            con.Close();
            return dtDataTable;
        }

        // Data Manipulation Language => DML
        // Metodo DML q se dedica a realizar cambios en las tablas (insert, delete, update)
        public static int DML(string instruccion)
        {
            int result = 0;
            SqlConnection con = ConexionBD();
            SqlCommand cmd = new SqlCommand(instruccion, con);
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // es para ver si existen datos con

        public static int existencia(string strSQL)
        {

            SqlConnection con = ConexionBD();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, con);
            da.Fill(dt);
            con.Close();
            return dt.Rows.Count;
        }

        public static string ConsultaUnica(string comando)
        {
            SqlCommand cmd = new SqlCommand(comando);
            SqlConnection con = ConexionBD();
            cmd.Connection = con;
            String resultado = cmd.ExecuteScalar().ToString();
            con.Close();
            return resultado;

        }
        //-----------------------------------------------------------------------------------------------------------------------









    }
}