using MyFinance.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyFinance.Models
{
    public class UsuarioModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Informe o Nome!")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="Informe o E-mail!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe uma Senha!")]
        public string Senha { get; set; }
        [Required(ErrorMessage ="Informe uma Data de nascimento.")]
        [DataType(DataType.Date, ErrorMessage = "Informe uma Data de Nascimento Válida.")]
        public string Data_Nascimento { get; set; }



        public bool ValidarLogin()
        {
            string sql = $"select ID, NOME, DATA_NASCIMENTO FROM USUARIO WHERE EMAIL='{Email}' and SENHA ='{Senha}'";
            DAL objDal = new DAL();
            DataTable dt = objDal.RetDataTable(sql);

            if (dt != null)
            {
                if(dt.Rows.Count == 1)
                {
                    Id = int.Parse(dt.Rows[0]["ID"].ToString());
                    Nome = dt.Rows[0]["Nome"].ToString();
                    Data_Nascimento = dt.Rows[0]["DATA_NASCIMENTO"].ToString();
                    return true;
                }
            }

            return false;
        }

        public void RegistrarUsuario()
        {
            string dataNascimento = DateTime.Parse(Data_Nascimento).ToString("yyyy/MM/dd");
            string sql = $"insert into USUARIO (NOME, EMAIL, SENHA, DATA_NASCIMENTO) VALUES('{Nome}','{Email}','{Senha}','{dataNascimento}')";
            DAL objDal = new DAL();
            objDal.ExecutaComandoSql(sql);

        }
    }
}
