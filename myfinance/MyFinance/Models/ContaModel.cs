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
    public class ContaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Informe o nome da conta")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="Informe o saldo da conta")]
        public Double Saldo { get; set; }

        public int Usuario_Id { get; set; }

        public IHttpContextAccessor _httpContextAccessor { get; set; }

        public ContaModel()
        {

        }

        //recebe o contexto para acesso as variaveis de secao por injecao de dependencia.
        public ContaModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<ContaModel> ListaConta()
        {
            List<ContaModel> lista = new List<ContaModel>();
            ContaModel item;

            string id_usuario_logado = _httpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            if (id_usuario_logado != null && id_usuario_logado != "0") { 
                string sql = $"SELECT ID, NOME, SALDO, USUARIO_ID FROM CONTA WHERE USUARIO_ID = {id_usuario_logado}";

                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new ContaModel();
                    item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                    item.Nome = dt.Rows[i]["NOME"].ToString();
                    item.Saldo = double.Parse(dt.Rows[i]["SALDO"].ToString());
                    item.Usuario_Id = int.Parse(dt.Rows[i]["USUARIO_ID"].ToString());
                    lista.Add(item);
                }
            }
            else
            {
                item = new ContaModel();
                item.Id = 0;
                item.Nome = null;
                item.Saldo = 0;
                item.Usuario_Id = 0;
                lista.Add(item);
            }
            return lista;
        }

        public void Insert()
        {
            string id_usuario_logado = _httpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"INSERT INTO CONTA (NOME, SALDO, USUARIO_ID) VALUES ('{Nome}','{Saldo}','{id_usuario_logado}')";
            DAL objDAL = new DAL();
            objDAL.ExecutaComandoSql(sql);
        }

        public void Excluir(int id_conta)
        {
            new DAL().ExecutaComandoSql($"DELETE FROM CONTA WHERE ID = '{id_conta}'") ;
            
        }
    }
}
