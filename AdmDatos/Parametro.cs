using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.AdmDatos
{
    public class Parametro
    {
        private SqlParameter sqlParametro;

        public SqlParameter Obtener
        {
            get { return sqlParametro; }
        }

        //Crea un parametro de entrada
        public Parametro(string nombre, object valor)
        {
            sqlParametro = new SqlParameter(nombre, valor);
        }
        //Crea un parametro de salida
        public Parametro(string nombre, SqlDbType tipo)
        {
            sqlParametro = new SqlParameter
            {
                ParameterName = nombre,
                Direction = ParameterDirection.Output,
                SqlDbType = tipo
            };
        }
    }
}
