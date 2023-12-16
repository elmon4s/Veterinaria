using ClassLibrary.Data.AdmDatos;
using ClassLibrary.Data.Interface;
using ClassLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data.Implementation
{
    public class CustomerDao : ICustomerDao
    {
        private readonly DbHelper dbHelper;
        public CustomerDao()
        {
            dbHelper = DbHelper.GetInstance();
        }

        public List<Customer> Get(DateTime fromDate, DateTime toDate, int code, string name, bool? sex)
        {
            List<Parameter> parametersList = new List<Parameter>
            {
                new Parameter("@from_date", fromDate.ToString("yyyyMMdd")),
                new Parameter("@to_date", toDate.ToString("yyyyMMdd")),
                new Parameter("@name", name)
            };
            if (sex != null)
                parametersList.Add(new Parameter("@sex", sex));
            if (code > 0)
                parametersList.Add(new Parameter("@code", code));
            
            DataTable dt = dbHelper.Query("SP_GET_CUSTOMERS_FILTERED", parametersList);

            return Parse(dt);
        }
        public List<Customer> GetAll()
        {
            DataTable dt = dbHelper.Query("SP_GET_CUSTOMERS");
            return Parse(dt);
        }
        public Customer GetByCode(int code)
        {
            DataTable dt = dbHelper.Query("SP_GET_CUSTOMER", new Parameter("@code", code));
            return Parse(dt.Rows[0]);
        }
        public bool Delete(int code)
        {
            return dbHelper.Modify("SP_DELETE_CUSTOMER", new Parameter("@code", code));
        }
        public bool Modify(Customer c, bool newRecord)
        {
            List<Parameter> parameterLst = new List<Parameter>();
            parameterLst.Add(new Parameter("@name", c.Name));
            parameterLst.Add(new Parameter("@sex", c.Sex));
            if (!newRecord)
                parameterLst.Add(new Parameter("@code", c.Code));

            dbHelper.Connect();
            SqlTransaction t = dbHelper.CreateTransaction();

            int customerCode = dbHelper.ModifyAndGet(newRecord ? "SP_ADD_CUSTOMER" : "SP_MODIFY_CUSTOMER", parameterLst, t);
            bool res = customerCode >= 0;

            if (!res)
                goto end;

            foreach (Pet p in c.GetPets())
            {

                if (p.Code == 0)
                {
                    List<Parameter> parametersPet = new List<Parameter>();
                    parametersPet.Add(new Parameter("@name", p.Name));
                    parametersPet.Add(new Parameter("@type", p.Type.Code));
                    parametersPet.Add(new Parameter("@birth_date", p.BirthDate));
                    parametersPet.Add(new Parameter("@owner_code", customerCode));

                    int petCode = dbHelper.ModifyAndGet("SP_ADD_PET", parametersPet, t);

                    if (petCode < 1)
                    {
                        res = false;
                        goto end;
                    }

                    foreach (Attention a in p.Attentions)
                    {
                        List<Parameter> parametersAttention = new List<Parameter>();
                        parametersAttention.Add(new Parameter("@description", a.Description));
                        parametersAttention.Add(new Parameter("@amount", a.Amount));
                        parametersAttention.Add(new Parameter("@date", a.Date.ToString("yyyyMMdd")));
                        parametersAttention.Add(new Parameter("@pet_code", petCode));
                        if (!dbHelper.Modify("SP_ADD_ATTENTION", parametersAttention, t))
                        {
                            res = false;
                            goto end;
                        }
                    }
                }
                if (p.Code < 0 && !dbHelper.Modify("SP_DELETE_PET", new Parameter("@code", p.Code * -1), t))
                {
                    res = false;
                    goto end;
                }
            }
            end:
            if (res)
                t.Commit();
            else
                t?.Rollback();
            dbHelper.Disconnect();
            return res;
        }

        private List<Customer> Parse(DataTable dt)
        {
            List<Customer> res = new List<Customer>();

            foreach (DataRow row in dt.Rows)
            {
                res.Add(Parse(row));
            }

            return res;
        }
        private Customer Parse(DataRow row)
        {
            string n = (string)row["customer_name"];
            bool s = (bool)row["customer_sex"];
            int c = (int)row["customer_code"];

            Customer cu = new Customer(n, s, c);

            return cu;
        }
    }
}
