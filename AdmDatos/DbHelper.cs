using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Veterinaria.Dominio;
using System.Runtime.Remoting.Messaging;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace Veterinaria.AdmDatos
{
    public class DbHelper
    {
        private SqlConnection conexion;
        private SqlCommand comando;

        public DbHelper()
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
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            comando = new SqlCommand
            {
                Connection = conexion
            };
        }
        private void Conectar()
        {
            conexion.Open();
        }

        private DataTable Consultar(string nombreSp)
        {
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSp;

            DataTable tabla = new DataTable();

            Conectar();
            tabla.Load(comando.ExecuteReader());
            Desconectar();

            return tabla;
        }
        private DataTable Consultar(string nombreSp, Parametro parametro)
        {
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSp;

            DataTable tabla = new DataTable();
            comando.Parameters.Clear();
            comando.Parameters.Add(parametro.Obtener);

            Conectar();
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

            Conectar();
            tabla.Load(comando.ExecuteReader());
            Desconectar();
            return tabla;
        }

        private bool ModificarRegistro(string nombreSp, Parametro parametro)
        {
            bool res = false;
            SqlTransaction t = null;

            try
            {
                Conectar();
                t = conexion.BeginTransaction();

                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nombreSp;
                comando.Transaction = t;

                comando.Parameters.Clear();
                comando.Parameters.Add(parametro.Obtener);

                comando.ExecuteNonQuery();

                res = true;
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (conexion != null)
                    Desconectar();
            }

            return res;
        }
        private bool ModificarRegistro(string nombreSp, Parametro parametro, SqlTransaction t)
        {
            bool res = false;

            try
            {

                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nombreSp;
                comando.Transaction = t;

                comando.Parameters.Clear();
                comando.Parameters.Add(parametro.Obtener);

                comando.ExecuteNonQuery();
                res = true;
            }
            catch
            {

            }

            return res;
        }

        private bool ModificarRegistro(string nombreSp, List<Parametro> lstParametros)
        {
            bool res = false;
            SqlTransaction t = null;

            try
            {
                Conectar();
                t = conexion.BeginTransaction();

                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nombreSp;
                comando.Transaction = t;

                comando.Parameters.Clear();
                foreach (Parametro p in lstParametros)
                {
                    comando.Parameters.Add(p.Obtener);
                }

                comando.ExecuteNonQuery();
                res = true;
                t.Commit();
            }
            catch
            {
                t?.Rollback();
            }
            finally
            {
                if (conexion != null)
                    Desconectar();
            }

            return res;
        }
        private bool ModificarRegistro(string nombreSp, List<Parametro> lstParametros, SqlTransaction t)
        {
            bool res = false;

            try
            {

                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nombreSp;
                comando.Transaction = t;

                comando.Parameters.Clear();
                foreach (Parametro p in lstParametros)
                {
                    comando.Parameters.Add(p.Obtener);
                }

                comando.ExecuteNonQuery();
                res = true;
            }
            catch
            {
            }

            return res;
        }

        private int ModificarObtenerRegistro(string nombreSp, List<Parametro> lstParametros, SqlTransaction t)
        {
            int res = -1;

            try
            {

                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nombreSp;
                comando.Transaction = t;

                comando.Parameters.Clear();
                foreach (Parametro p in lstParametros)
                {
                    comando.Parameters.Add(p.Obtener);
                }

                DataTable tabla = new DataTable();
                tabla.Load(comando.ExecuteReader());
                res = (int) tabla.Rows[0].ItemArray[0];
            }
            catch
            {
            }

            return res;
        }


        public DataTable ObetenerClientes()
        {
            return Consultar("SP_OBTENER_CLIENTES");
        }
        public DataTable ObtenerClientes(DateTime fechaDesde, DateTime fechaHasta, int codigo, string nomCliente, bool masculino, bool femenino)
        {
            List<Parametro> lstParametros = new List<Parametro>();
            lstParametros.Add(new Parametro("@fecha_desde", fechaDesde.ToString("yyyyMMdd")));
            lstParametros.Add(new Parametro("@fecha_hasta", fechaHasta.ToString("yyyyMMdd")));
            lstParametros.Add(new Parametro("@nom_cliente", nomCliente));
            if (masculino ^ femenino)
            {
                lstParametros.Add(new Parametro("@sexo", femenino));
            }
            if (codigo > 0)
                lstParametros.Add(new Parametro("@cod", codigo));
            return Consultar("SP_OBTENER_CLIENTES_FILTRO", lstParametros);
        }
        public DataTable ObtenerTiposMascota()
        {
            return Consultar("SP_OBTENER_TIPOS");
        }

        public DataTable ObtenerMascotas(int codCliente)
        {
            return Consultar("SP_OBTENER_MASCOTAS_CLIENTE", new Parametro("@cod_cliente", codCliente));
        }
        public DataTable ObtenerMascotas(DateTime fechaDesde, DateTime fechaHasta, string edad, int codigo, TipoMascota tipo, string nomMascota, string nomCliente)
        {

            List<Parametro> lstParametros = new List<Parametro>();
            lstParametros.Add(new Parametro("@fecha_desde", fechaDesde.ToString("yyyyMMdd")));
            lstParametros.Add(new Parametro("@fecha_hasta", fechaHasta.ToString("yyyyMMdd")));
            lstParametros.Add(new Parametro("@nom_cliente", nomCliente));
            lstParametros.Add(new Parametro("@nom_mascota", nomMascota));
            if (codigo > 0)
                lstParametros.Add(new Parametro("@cod", codigo));
            if (tipo.Codigo > 0)
                lstParametros.Add(new Parametro("@tipo", tipo.Codigo));
            if (int.TryParse(edad, out int edadInt))
                lstParametros.Add(new Parametro("@edad", edadInt));

            return Consultar("SP_OBTENER_MASCOTAS", lstParametros);
        }

        public DataTable ObtenerAtenciones(DateTime fechaDesde, DateTime fechaHasta, int codigo, decimal importeMin, decimal importeMax, string nomCliente, string nomMascota, string descripcion)
        {
            List<Parametro> lstParametros = new List<Parametro>();
            lstParametros.Add(new Parametro("@fecha_desde", fechaDesde.ToString("yyyyMMdd")));
            lstParametros.Add(new Parametro("@fecha_hasta", fechaHasta.ToString("yyyyMMdd")));
            lstParametros.Add(new Parametro("@nom_cliente", nomCliente));
            lstParametros.Add(new Parametro("@nom_mascota", nomMascota));
            lstParametros.Add(new Parametro("@descripcion", descripcion));
            if (importeMin > -99999999.99M)
                lstParametros.Add(new Parametro("@importe_min", importeMin));
            if (importeMax < 99999999.99M)
                lstParametros.Add(new Parametro("@importe_max", importeMax));
            if (codigo > 0)
                lstParametros.Add(new Parametro("@cod", codigo));
            return Consultar("SP_OBTENER_ATENCIONES", lstParametros);
        }
        public DataTable ObtenerAtenciones(int codMascota)
        {
            return Consultar("SP_OBTENER_ATENCIONES_MASCOTA", new Parametro("@cod_mascota", codMascota));
        }

        public bool ModificarMascota(Mascota m, Cliente c, bool nuevo)
        {
            
            Conectar();
            SqlTransaction t = conexion.BeginTransaction();
            bool res = true;

            List<Parametro> lstParametros = new List<Parametro>();
            lstParametros.Add(new Parametro("@nombre", m.Nombre));
            lstParametros.Add(new Parametro("@tipo", m.TipoMascota.Codigo));
            lstParametros.Add(new Parametro("@fecha_nacimiento", m.FechaNacimiento));
            if (nuevo)
                lstParametros.Add(new Parametro("@cod_dueno", c.Codigo));
            else
                lstParametros.Add(new Parametro("@cod", m.Codigo));

            if (c.Codigo == 0)
            {
                Desconectar();
                c.AgregarMascota(m);
                return ModificarCliente(c, true);
            }

            if (!ModificarRegistro(nuevo ? "SP_AGREGAR_MASCOTA" : "SP_MODIFICAR_MASCOTA", lstParametros, t))
                res = false;

            foreach (Atencion a in m.Atenciones)
            {
                List<Parametro> lstParametrosAtencion = new List<Parametro>();
                lstParametros.Add(new Parametro("@descripcion", a.Descripcion));
                lstParametros.Add(new Parametro("@importe", a.Importe));
                lstParametros.Add(new Parametro("@fecha_atencion", a.FechaAtencion.ToString("yyyyMMdd")));
                lstParametros.Add(new Parametro("@cod_mascota", m.Codigo));
                if (!ModificarRegistro("SP_AGREGAR_ATENCION", lstParametrosAtencion, t))
                {
                    res = false;
                    break;
                }

            }
            if (res)
                t.Commit();
            else
                t?.Rollback();
            
            Desconectar();
            return res;
        }
        public bool AgregarTipoMascota(TipoMascota tipo)
        {
            return ModificarRegistro("SP_AGREGAR_TIPO", new Parametro("@desc", tipo.Nombre));
        }

        public Cliente ObtenerCliente(int cod)
        {
            DataTable tabla = Consultar("SP_OBTENER_CLIENTE", new Parametro("@cod", cod));
            DataRow fila = tabla.Rows[0];

            return new Cliente(fila.ItemArray[0].ToString(), (bool)fila.ItemArray[1], (int)fila.ItemArray[2]);
        }
        public bool BajarCliente(int cod)
        {
            return ModificarRegistro("SP_BAJAR_CLIENTE", new Parametro("@cod", cod));
        }
        public bool ModificarCliente(Cliente c, bool nuevo)
        {
            List<Parametro> lstParametros = new List<Parametro>();
            lstParametros.Add(new Parametro("@nombre", c.Nombre));
            lstParametros.Add(new Parametro("@sexo", c.Sexo));
            if (!nuevo)
                lstParametros.Add(new Parametro("@cod", c.Codigo));

            Conectar();
            SqlTransaction t = conexion.BeginTransaction();

            int codCliente = ModificarObtenerRegistro(nuevo ? "SP_AGREGAR_CLIENTE" : "SP_MODIFICAR_CLIENTE", lstParametros, t);
            bool res = codCliente > 0;

            if (!res)
                goto terminar;
         
            foreach (Mascota m in c.ObtenerMascotas())
            {

                if (m.Codigo == 0)
                {
                    List<Parametro> lstParametrosMascota = new List<Parametro>();
                    lstParametrosMascota.Add(new Parametro("@nombre", m.Nombre));
                    lstParametrosMascota.Add(new Parametro("@tipo", m.TipoMascota.Codigo));
                    lstParametrosMascota.Add(new Parametro("@fecha_nacimiento", m.FechaNacimiento));
                    lstParametrosMascota.Add(new Parametro("@cod_dueno", codCliente));

                    int codMascota = ModificarObtenerRegistro("SP_AGREGAR_MASCOTA", lstParametrosMascota, t);

                    if (codMascota < 1)
                    {
                        res = false;
                        goto terminar;
                    }

                    foreach (Atencion a in m.Atenciones)
                    {
                        List<Parametro> lstParametrosAtencion = new List<Parametro>();
                        lstParametros.Add(new Parametro("@descripcion", a.Descripcion));
                        lstParametros.Add(new Parametro("@importe", a.Importe));
                        lstParametros.Add(new Parametro("@fecha_atencion", a.FechaAtencion.ToString("yyyyMMdd")));
                        lstParametros.Add(new Parametro("@cod_mascota", codMascota));
                        if (!ModificarRegistro("SP_AGREGAR_ATENCION", lstParametrosAtencion, t))
                        {
                            res = false;
                            goto terminar;
                        }
                    }
                }
                if (m.Codigo < 0 && !ModificarRegistro("SP_BAJAR_MASCOTA", new Parametro("@cod", m.Codigo * -1), t))
                {
                    res = false;
                    goto terminar;
                }
            }
            terminar:
            if (res)
                t.Commit();
            else
            {
                res = false;
                t?.Rollback();
            }
            Desconectar();
            return res;
        }

        public Atencion ObtenerAtencion(int cod)
        {
            DataTable tabla = Consultar("SP_OBTENER_ATENCION", new Parametro("@cod", cod));
            DataRow fila = tabla.Rows[0];

            return new Atencion((int)fila.ItemArray[0], fila.ItemArray[1].ToString(), (decimal)fila.ItemArray[2], (DateTime)fila.ItemArray[3]);
        }
        public bool AgregarAtencion(int codMascota, Atencion a)
        {
            List<Parametro> lstParametros = new List<Parametro>();
            lstParametros.Add(new Parametro("@descripcion", a.Descripcion));
            lstParametros.Add(new Parametro("@importe", a.Importe));
            lstParametros.Add(new Parametro("@fecha_atencion", a.FechaAtencion.ToString("yyyyMMdd")));
            lstParametros.Add(new Parametro("@cod_mascota", codMascota));

            return ModificarRegistro("SP_AGREGAR_ATENCION", lstParametros);
        }
        public bool BajarAtencion(int cod)
        {
            return ModificarRegistro("SP_BAJAR_ATENCION", new Parametro("@cod", cod));
        }
        public bool ModificarAtencion(Atencion a)
        {
            List<Parametro> lstParametros = new List<Parametro>();
            lstParametros.Add(new Parametro("@descripcion", a.Descripcion));
            lstParametros.Add(new Parametro("@importe", a.Importe));
            lstParametros.Add(new Parametro("@fecha_atencion", a.FechaAtencion.ToString("yyyyMMdd")));
            lstParametros.Add(new Parametro("@cod", a.Codigo));
            return ModificarRegistro("SP_MODIFICAR_ATENCION", lstParametros);
        }

    }
}