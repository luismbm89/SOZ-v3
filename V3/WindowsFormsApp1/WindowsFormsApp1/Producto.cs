using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Producto
    {
        private int NoSeq, Categoria, Marca;
        private string BarCode, Code, Descripcion;
        private decimal Costo, PrecioVenta,entradas,salidas,saldo;
        private bool IV;

        public decimal Costo1 { get => Costo; set => Costo = value; }
        public decimal PrecioVenta1 { get => PrecioVenta; set => PrecioVenta = value; }
        public string BarCode1 { get => BarCode; set => BarCode = value; }
        public string Code1 { get => Code; set => Code = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public int NoSeq1 { get => NoSeq; set => NoSeq = value; }
        public int Categoria1 { get => Categoria; set => Categoria = value; }
        public int Marca1 { get => Marca; set => Marca = value; }
        public bool IV1 { get => IV; set => IV = value; }
        public decimal Entradas { get => entradas; set => entradas = value; }
        public decimal Salidas { get => salidas; set => salidas = value; }
        public decimal Saldo { get => saldo; set => saldo = value; }

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
            IV1 = false;
            Entradas = 0.0m;
            Salidas = 0.0m;
            Saldo = 0.0m;
        }
        public Producto(int pnoseq, int pcategoria, int pmarca, string pbarcode, string pcode, string pdescripcion, decimal pcosto, decimal pprecioventa,decimal pEntradas,decimal pSalidas,decimal psaldo,bool pIV)
        {
            Costo1 = pcosto;
            PrecioVenta1 = pprecioventa;
            BarCode1 = pbarcode;
            Code1 = pcode;
            Descripcion1 = pdescripcion;
            NoSeq1 = pnoseq;
            Categoria1 = pcategoria;
            Marca1 = pmarca;
            IV1 = pIV;
            Entradas = pEntradas;
            Salidas = pSalidas;
            Saldo = psaldo;

        }
        public List<Producto> GetList()
        {
            List<Producto> lst = new List<Producto>();  // Employee should contain  EmployeeId, EmployeeName as properties

            foreach (DataRow dr in ConexionSQL.consultaDataTable("SELECT [NoSeq],[BarCode],[Code],[Descripcion],[Categoria],[Marca],[Costo],[PrecioVenta],IVA FROM [Producto]", "Producto").Rows)
            {
                lst.Add(new Producto
                {
                    NoSeq1 = Convert.ToInt32(dr[0].ToString()),
                    BarCode1 = dr[1].ToString(),
                    Code1 = dr[2].ToString(),
                    Descripcion1 = dr[3].ToString(),
                    Categoria1 = Convert.ToInt32(dr[4].ToString()),
                    Marca1 = Convert.ToInt32(dr[5].ToString()),
                    Costo1 = Convert.ToDecimal(dr[6].ToString()),
                    PrecioVenta = Convert.ToDecimal(dr[7].ToString()),
                    IV1 = Convert.ToBoolean(dr[8].ToString())
                });
            }
            return lst;
        }
        public List<Producto> GetInventory()
        {
            List<Producto> lst = new List<Producto>();  // Employee should contain  EmployeeId, EmployeeName as properties

            foreach (DataRow dr in ConexionSQL.consultaDataTable("select * from VwInventario", "Inventario").Rows)
            {
                lst.Add(new Producto
                {
                    NoSeq1 = Convert.ToInt32(dr[0].ToString()),
                    Salidas = Convert.ToDecimal(dr[2].ToString()),
                    Entradas = Convert.ToDecimal(dr[1].ToString()),
                    Saldo = Convert.ToDecimal(dr[3].ToString())
                });
            }
            return lst;
        }
    }
}