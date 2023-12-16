using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data
{
    public class Parameter
    {
        private SqlParameter sqlParameter;

        public SqlParameter Get
        {
            get { return sqlParameter; }
        }
        public Parameter(string name, object value)
        {
            sqlParameter = new SqlParameter(name, value);
        }
        public Parameter(string name, SqlDbType type)
        {
            sqlParameter = new SqlParameter
            {
                ParameterName = name,
                Direction = ParameterDirection.Output,
                SqlDbType = type
            };
        }
    }
}
