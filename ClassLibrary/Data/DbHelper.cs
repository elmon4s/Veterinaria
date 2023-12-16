using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ClassLibrary.Domain;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace ClassLibrary.Data.AdmDatos
{
    public class DbHelper
    {
        private SqlConnection connection;
        private SqlCommand command;
        private static DbHelper? instance;

        private DbHelper()
        {
            connection = new SqlConnection
            {
                ConnectionString = @"Data Source=(localdb)\local;Initial Catalog=Veterinaria_404888;Integrated Security=True"
            };

            command = new SqlCommand
            {
                Connection = connection
            };
        }

        public static DbHelper GetInstance()
        {
            instance ??= new DbHelper();
            return instance;
        }

        public void Connect()
        {
            if (connection.State == ConnectionState.Open)
                Disconnect();
            connection.Open();
        }
        public void Disconnect()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
            command = new SqlCommand
            {
                Connection = connection
            };
        }
        public SqlTransaction CreateTransaction()
        {
            return connection.BeginTransaction();
        }

        public DataTable Query(string spName)
        {
            return Query(spName, new List<Parameter>());
        }
        public DataTable Query(string spName, Parameter parameter)
        {
            List<Parameter> list = new List<Parameter>
            {
                parameter
            };
            return Query(spName, list);
        }
        public DataTable Query(string spName, List<Parameter> parameterLst)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = spName;
            command.Parameters.Clear();

            DataTable tabla = new DataTable();
            foreach (Parameter p in parameterLst)
            {
                command.Parameters.Add(p.Get);
            }

            Connect();
            tabla.Load(command.ExecuteReader());
            Disconnect();
            return tabla;
        }

        public bool Modify(string spName, Parameter parameter)
        {
            List<Parameter> list = new List<Parameter>
            {
                parameter
            };
            return Modify(spName, list);
        }
        public bool Modify(string spName, Parameter parameter, SqlTransaction t)
        {
            List<Parameter> list = new List<Parameter>
            {
                parameter
            };
            return Modify(spName, list, t);
        }

        public bool Modify(string spName, List<Parameter> parameterLst)
        {
            bool res = false;
            SqlTransaction t;

            try
            {
                Connect();

                t = connection.BeginTransaction();
                res = Modify(spName, parameterLst, t);

                t.Commit();
            }
            catch
            {
                t?.Rollback();
            }
            finally
            {
                if (connection != null)
                    Disconnect();
            }

            return res;
        }
        public bool Modify(string spName, List<Parameter> parameterLst, SqlTransaction t)
        {
            bool res = false;

            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = spName;
                command.Transaction = t;

                command.Parameters.Clear();
                foreach (Parameter p in parameterLst)
                {
                    command.Parameters.Add(p.Get);
                }

                command.ExecuteNonQuery();
                res = true;
            }
            catch
            {
            }

            return res;
        }

        public int ModifyAndGet(string spName, List<Parameter> parameterLst, SqlTransaction t)
        {
            int res = -1;

            try
            {

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = spName;
                command.Transaction = t;

                command.Parameters.Clear();
                foreach (Parameter p in parameterLst)
                {
                    command.Parameters.Add(p.Get);
                }

                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                res = (int) dt.Rows[0].ItemArray[0];
            }
            catch
            {
            }

            return res;
        }
    }
}