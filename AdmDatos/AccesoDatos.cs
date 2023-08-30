using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Veterinaria.Dominio;

namespace Veterinaria.AdmDatos
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;

        public AccesoDatos()
        {
            conexion = new SqlConnection
            {
                ConnectionString = @"Data Source=(localdb)\local;Initial Catalog=Veterinaria_404888;Integrated Security=True"
            };

            comando = new SqlCommand
            {
                Connection = conexion
            };
        }
        private void Desconectar()
        {
            conexion.Close();
            comando = new SqlCommand
            {
                Connection = conexion
            };
        }

        private DataTable Consultar(string nombreSp)
        {
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSp;

            DataTable tabla = new DataTable();

            conexion.Open();
            tabla.Load(comando.ExecuteReader());
            Desconectar();

            return tabla;
        }
        private DataTable Consultar(string nombreSp, Parametro parametro)
        {
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSp;

            DataTable tabla = new DataTable();
            comando.Parameters.Add(parametro.Obtener);

            conexion.Open();
            tabla.Load(comando.ExecuteReader());
            Desconectar();
            
            return tabla;
        }
        private DataTable Consultar(string nombreSp, List<Parametro> lstParametros)
        {
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSp;
            comando.Parameters.Clear();

            DataTable tabla = new DataTable();
            foreach (Parametro p in lstParametros)
            {
                comando.Parameters.Add(p.Obtener);
            }

            conexion.Open();
            tabla.Load(comando.ExecuteReader());
            Desconectar();

            return tabla;
        }
        private void Insertar(string nombreSp, List<Parametro> lstParametros)
        {
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSp;
            comando.Parameters.Clear();

            DataTable tabla = new DataTable();
            foreach (Parametro p in lstParametros)
            {
                comando.Parameters.Add(p.Obtener);
            }

            conexion.Open();
            comando.ExecuteNonQuery();
            Desconectar();
        }
        public DataTable ObetenerClientes()
        {
            return Consultar("SP_OBTENER_CLIENTES");
        }

        public DataTable ObtenerMascotas(int codCliente)
        {
            Parametro parametro = new Parametro("@cod_cliente", codCliente);
            return Consultar("SP_OBTENER_MASCOTAS", parametro);
        }

        public DataTable ObtenerAtenciones(int codMascota)
        {
            Parametro parametro = new Parametro("@cod_mascota", codMascota);
            return Consultar("SP_OBTENER_ATENCIONES", parametro);
        }

        public void AgregarAtencion(int codMascota, Atencion a)
        {
            List<Parametro> lstParametros = new List<Parametro>();
            lstParametros.Add(new Parametro("@descripcion", a.Descripcion));
            lstParametros.Add(new Parametro("@importe", a.Importe));
            lstParametros.Add(new Parametro("@fecha_atencion", a.FechaAtencion.ToString("yyyyMMdd")));
            lstParametros.Add(new Parametro("@cod_mascota", codMascota));

            Insertar("SP_AGREGAR_ATENCION", lstParametros);
        }
    }
}