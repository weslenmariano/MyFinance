using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFinance.Util;
using System.Data;
namespace MyFinance.Models
{
    public class HomeModel
    {
        public string LerNomeUsuario()
        {
            DAL objDal = new DAL();
            DataTable dt =  objDal.RetDataTable("SELECT * FROM USUARIO");

            if(dt != null)
            {
                if(dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["Nome"].ToString();
                }
            }

            return "Nome não encontrado.";
        }
    }
}
