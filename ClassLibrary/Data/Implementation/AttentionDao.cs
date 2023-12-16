using ClassLibrary.Data.AdmDatos;
using ClassLibrary.Data.Interface;
using ClassLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data.Implementation
{
    public class AttentionDao: IAttentionDao
    {
        private readonly DbHelper dbHelper;
        public AttentionDao()
        {
            dbHelper = DbHelper.GetInstance();
        }

        public List<Attention> Get(DateTime fromDate, DateTime toDate, int code, decimal minAmount, decimal maxAmount, string customerName, string petName, string description)
        {
            List<Parameter> parametersLst = new List<Parameter>();
            parametersLst.Add(new Parameter("@from_date", fromDate.ToString("yyyyMMdd")));
            parametersLst.Add(new Parameter("@to_date", toDate.ToString("yyyyMMdd")));
            parametersLst.Add(new Parameter("@customer_name", customerName));
            parametersLst.Add(new Parameter("@pet_name", petName));
            parametersLst.Add(new Parameter("@description", description));
            if (minAmount > -99999999.99M)
                parametersLst.Add(new Parameter("@min_amount", minAmount));
            if (maxAmount < 99999999.99M)
                parametersLst.Add(new Parameter("@max_amount", maxAmount));
            if (code > 0)
                parametersLst.Add(new Parameter("@code", code));
            DataTable dt = dbHelper.Query("SP_GET_ATTENTIONS", parametersLst);

            return Parse(dt);
        }
        public List<Attention> GetByPet(int code)
        {
            DataTable dt = dbHelper.Query("SP_GET_ATTENTIONS_BY_PET", new Parameter("@pet_code", code));
            return Parse(dt);
        }
        public Attention Get(int code)
        {
            DataTable dt = dbHelper.Query("SP_GET_ATTENTION", new Parameter("@code", code));
            DataRow row = dt.Rows[0];

            return Parse(row);
        }
        public bool Add(int petCode, Attention a)
        {
            List<Parameter> parametersLst = new List<Parameter>();
            parametersLst.Add(new Parameter("@description", a.Description));
            parametersLst.Add(new Parameter("@amount", a.Amount));
            parametersLst.Add(new Parameter("@date", a.Date.ToString("yyyyMMdd")));
            parametersLst.Add(new Parameter("@pet_code", petCode));

            return dbHelper.Modify("SP_ADD_ATTENTION", parametersLst);
        }
        public bool Delete(int code)
        {
            return dbHelper.Modify("SP_DELETE_ATTENTION", new Parameter("@code", code));
        }
        public bool Modify(Attention a)
        {
            List<Parameter> parametersLst = new List<Parameter>();
            parametersLst.Add(new Parameter("@description", a.Description));
            parametersLst.Add(new Parameter("@amount", a.Amount));
            parametersLst.Add(new Parameter("@date", a.Date.ToString("yyyyMMdd")));
            parametersLst.Add(new Parameter("@code", a.Code));
            return dbHelper.Modify("SP_MODIFY_ATTENTION", parametersLst);
        }

        private List<Attention> Parse(DataTable dt)
        {
            List<Attention> res = new List<Attention> ();

            foreach (DataRow row in dt.Rows)
            {
                res.Add(Parse(row));
            }

            return res;
        }
        private Attention Parse(DataRow row)
        {
            int c = (int)row["attention_code"];
            string d = (string)row["attention_description"];
            decimal a = (decimal)row["attention_amount"];
            DateTime da = DateTime.Parse((string)row["attention_date"]);

            Attention at = new Attention(c, d, a, da);

            return at;
        }
    }
}
