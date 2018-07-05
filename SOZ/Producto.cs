using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SOZ
{
    public class Producto
    {
        private int NoSeq, Categoria, Marca;
        private string BarCode, Code, Descripcion;
        private decimal Costo, PrecioVenta;

        public decimal Costo1 { get => Costo; set => Costo = value; }
        public decimal PrecioVenta1 { get => PrecioVenta; set => PrecioVenta = value; }
        public string BarCode1 { get => BarCode; set => BarCode = value; }
        public string Code1 { get => Code; set => Code = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public int NoSeq1 { get => NoSeq; set => NoSeq = value; }
        public int Categoria1 { get => Categoria; set => Categoria = value; }
        public int Marca1 { get => Marca; set => Marca = value; }

        public Producto()
        {
            Costo1 = 0.0m;
            PrecioVenta1 = 0.0m;
            BarCode1 = "";
            Code1 = "";
            Descripcion1 = "";
            NoSeq1 = 0;
            Categoria1 = 0;
            Marca1 = 0;
        }
        public Producto(int pnoseq, int pcategoria, int pmarca, string pbarcode, string pcode, string pdescripcion, decimal pcosto, decimal pprecioventa)
        {
            Costo1 = pcosto;
            PrecioVenta1 = pprecioventa;
            BarCode1 = pbarcode;
            Code1 = pcode;
            Descripcion1 = pdescripcion;
            NoSeq1 = pnoseq;
            Categoria1 = pcategoria;
            Marca1 = pmarca;
        }
        public List<Producto> GetList()
        {
            List<Producto> productlist = new List<Producto>();
            //"SELECT [NoSeq],[BarCode],[Code],[Descripcion],[Categoria],[Marca],[Costo],[PrecioVenta] FROM [SOZ_BD].[dbo].[Producto]", "Producto")
            DataTable dt;   // datatable should contains datacolumns with Id,Name

            List<Producto> lst = new List<Producto>();  // Employee should contain  EmployeeId, EmployeeName as properties

            foreach (DataRow dr in ConexionSQL.consultaDataTable("SELECT [NoSeq],[BarCode],[Code],[Descripcion],[Categoria],[Marca],[Costo],[PrecioVenta] FROM [SOZ_BD].[dbo].[Producto]", "Producto").Rows)
            {
                lst.Add(new Producto {
                    NoSeq1 = Convert.ToInt32(dr[0].ToString()),
                    BarCode1 = dr[1].ToString(),
                    Code1 = dr[2].ToString(),
                    Descripcion1 = dr[3].ToString(),
                    Categoria1 = Convert.ToInt32(dr[4].ToString()),
                    Marca1 = Convert.ToInt32(dr[5].ToString()),
                    Costo1 = Convert.ToDecimal(dr[6].ToString()),
                    PrecioVenta1 = Convert.ToDecimal(dr[7].ToString())
                });
            }
            return lst;
        }
    }
}