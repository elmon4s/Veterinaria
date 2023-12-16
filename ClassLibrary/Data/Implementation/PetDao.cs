using ClassLibrary.Data.Interface;
using ClassLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Data.AdmDatos;

namespace ClassLibrary.Data.Implementation
{
    public class PetDao: IPetDao
    {
        private readonly DbHelper dbHelper;
        private readonly ICustomerDao customerDao;
        public PetDao() 
        {
            dbHelper = DbHelper.GetInstance();
            customerDao = new CustomerDao();
        }

        public List<PetType> GetAllTypes()
        {
            DataTable dt = dbHelper.Query("SP_GET_TYPES");
            return ParseType(dt);
        }
        public List<Pet> GetByCustomer(int code)
        {
            DataTable dt = dbHelper.Query("SP_GET_PETS_BY_CUSTOMER", new Parameter("@customer_code", code));
            return Parse(dt);
        }
        public List<Pet> Get(DateTime fromDate, DateTime toDate, string age, int code, int type, string petName, string customerName)
        {

            List<Parameter> parameterLst = new List<Parameter>();
            parameterLst.Add(new Parameter("@from_date", fromDate.ToString("yyyyMMdd")));
            parameterLst.Add(new Parameter("@to_date", toDate.ToString("yyyyMMdd")));
            parameterLst.Add(new Parameter("@customer_name", customerName));
            parameterLst.Add(new Parameter("@pet_name", petName));
            if (code > 0)
                parameterLst.Add(new Parameter("@code", code));
            if (type > 0)
                parameterLst.Add(new Parameter("@type", type));
            if (int.TryParse(age, out int edadInt))
                parameterLst.Add(new Parameter("@age", edadInt));
            DataTable dt = dbHelper.Query("SP_GET_PETS_FILTERED", parameterLst);

            return Parse(dt);
        }
        public bool Modify(Pet p, Customer c, bool newRecord)
        {

            dbHelper.Connect();
            SqlTransaction t = dbHelper.CreateTransaction();
            bool res = true;

            List<Parameter> parametersLst = new List<Parameter>();
            parametersLst.Add(new Parameter("@name", p.Name));
            parametersLst.Add(new Parameter("@type", p.Type.Code));
            parametersLst.Add(new Parameter("@birth_date", p.BirthDate));
            if (newRecord)
                parametersLst.Add(new Parameter("@cod_dueno", c.Code));
            else
                parametersLst.Add(new Parameter("@cod", p.Code));

            if (c.Code == 0)
            {
                dbHelper.Disconnect();
                c.AddPet(p);
                return customerDao.Modify(c, true);
            }

            if (!dbHelper.Modify(newRecord ? "SP_ADD_PET" : "SP_MODIFY_PET", parametersLst, t))
                res = false;

            foreach (Attention a in p.Attentions)
            {
                List<Parameter> parametersAttention = new List<Parameter>();
                parametersAttention.Add(new Parameter("@descripcion", a.Description));
                parametersAttention.Add(new Parameter("@importe", a.Amount));
                parametersAttention.Add(new Parameter("@fecha_atencion", a.Date.ToString("yyyyMMdd")));
                parametersAttention.Add(new Parameter("@cod_mascota", p.Code));
                if (!dbHelper.Modify("SP_ADD_ATTENTION", parametersAttention, t))
                {
                    res = false;
                    break;
                }

            }
            if (res)
                t.Commit();
            else
                t?.Rollback();

            dbHelper.Disconnect();
            return res;
        }
        public bool AddType(PetType type)
        {
            return dbHelper.Modify("SP_ADD_TYPE", new Parameter("@description", type.Name));
        }

        private List<Pet> Parse(DataTable dt)
        {
            List<Pet> res = new List<Pet>();

            foreach (DataRow row in dt.Rows)
            {
                res.Add(Parse(row));
            }

            return res;
        }
        private List<PetType> ParseType(DataTable dt)
        {
            List<PetType> res = new List<PetType>();

            foreach (DataRow row in dt.Rows)
            {
                res.Add(ParseType(row));
            }

            return res;
        }
        private Pet Parse(DataRow row)
        {
            int c = (int)row["pet_code"];
            string n = (string)row["pet_name"];
            PetType t = ParseType(row);
            DateTime b = DateTime.Parse((string)row["birth_date"]);

            Pet p = new Pet(n, t, c, b);

            return p;
        }
        private PetType ParseType(DataRow row)
        {
            int c = (int)row["type_code"];
            string d = (string)row["type_description"];

            PetType t = new PetType(c, d);

            return t;
        }
    }
}
