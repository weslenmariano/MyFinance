using Microsoft.AspNetCore.Http;
using MyFinance.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class PlanoContaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Informe a Descrição!")]
        public string Descricao { get; set; }
        public string Tipo { get; set; }

        public int Usuario_Id { get; set; }

        public IHttpContextAccessor _httpContextAccessor { get; set; }

        public PlanoContaModel()
        {

        }

        private string IdUsuarioLogado()
        {
            return _httpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
        }

        public PlanoContaModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<PlanoContaModel> ListaPlanoConta()
        {
            List<PlanoContaModel> lista = new List<PlanoContaModel>();
            PlanoContaModel item;

           
            if (IdUsuarioLogado() != null && IdUsuarioLogado() != "0")
            {
                string sql = $"SELECT ID, DESCRICAO, TIPO, USUARIO_ID FROM PLANO_CONTAS WHERE USUARIO_ID = {IdUsuarioLogado()}";

                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new PlanoContaModel();
                    item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                    item.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                    item.Tipo = dt.Rows[i]["TIPO"].ToString();
                    item.Usuario_Id = int.Parse(dt.Rows[i]["USUARIO_ID"].ToString());
                    lista.Add(item);
                }
            }
            else
            {
                item = new PlanoContaModel();
                item.Id = 0;
                item.Descricao = "";
                item.Tipo = "";
                item.Usuario_Id = 0;
                lista.Add(item);
            }
            return lista;
        }

        public void Insert()
        {
            
            string sql;
            if (Id == 0)
            {
                 sql = $"INSERT INTO PLANO_CONTAS (DESCRICAO, TIPO, USUARIO_ID) VALUES ('{Descricao}','{Tipo}','{IdUsuarioLogado()}')";
            }
            else
            {
                sql = $"UPDATE PLANO_CONTAS SET DESCRICAO = '{Descricao}', " +
                      $"TIPO ='{Tipo}' " +
                      $"WHERE USUARIO_ID = '{IdUsuarioLogado()}' and ID = '{Id}'";
            }
            DAL objDAL = new DAL();
            objDAL.ExecutaComandoSql(sql);
        }

        public void Excluir(int id_conta)
        {
            new DAL().ExecutaComandoSql($"DELETE FROM PLANO_CONTAS WHERE ID = '{id_conta}'");

        }

        public PlanoContaModel CarregarRegistro(int? id_conta)
        {
            PlanoContaModel item = new PlanoContaModel();

            
            string sql = $"SELECT ID, DESCRICAO, TIPO, USUARIO_ID FROM PLANO_CONTAS WHERE id = {id_conta} AND USUARIO_ID = {IdUsuarioLogado()}";

            

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

           
            item.Id = int.Parse(dt.Rows[0]["ID"].ToString());
            item.Descricao = dt.Rows[0]["DESCRICAO"].ToString();
            item.Tipo = dt.Rows[0]["TIPO"].ToString();
            item.Usuario_Id = int.Parse(dt.Rows[0]["USUARIO_ID"].ToString());

            return item;


        }



    }
}
