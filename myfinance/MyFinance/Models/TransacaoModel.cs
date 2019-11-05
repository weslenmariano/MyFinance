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
    public class TransacaoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe a Data!")]
        public string Data { get; set; }

        public string Tipo { get; set; }
        public Double Valor { get; set; }
        [Required(ErrorMessage = "Informe a Descricao!")]
        public string Descricao { get; set; }
        public int Conta_Id { get; set; }
        public string NomeConta { get; set; }
        public int Plano_Conta_Id { get; set; }
        public string DescricaoPlanoConta { get; set; }

        public IHttpContextAccessor _httpContextAccessor { get; set; }

        public TransacaoModel()
        {

        }

        public TransacaoModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<TransacaoModel> ListaTransacao()
        {
            List<TransacaoModel> lista = new List<TransacaoModel>();
            TransacaoModel item;

            string id_usuario_logado = _httpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            if (id_usuario_logado != null && id_usuario_logado != "0")
            {
                string sql = $"select   t.id, "+
                                        "t.data, "+
                                        "t.tipo, "+
                                        "t.valor, "+
                                        "t.descricao as historico, "+
                                        "t.conta_id, "+
                                        "c.nome as conta, "+
                                        "t.plano_contas_id, "+
                                        "p.descricao as plano_conta "+
                                "from transacao t "+
                                "inner join conta c "+
                                "on t.conta_id = c.id "+
                                "inner join plano_contas p "+
                                "on t.plano_contas_id = p.id "+
                                $" where t.Usuario_Id = {id_usuario_logado} order by t.data desc limit 10";

                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new TransacaoModel();
                    item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                    item.Data = DateTime.Parse(dt.Rows[i]["DATA"].ToString()).ToString("dd/MM/yyyy");
                    item.Tipo = dt.Rows[i]["TIPO"].ToString();
                    item.Valor = Double.Parse(dt.Rows[i]["VALOR"].ToString());
                    item.Descricao = dt.Rows[i]["HISTORICO"].ToString();
                    item.Conta_Id = int.Parse(dt.Rows[i]["CONTA_ID"].ToString());
                    item.NomeConta = dt.Rows[i]["CONTA"].ToString();
                    item.Plano_Conta_Id = int.Parse(dt.Rows[i]["PLANO_CONTAS_ID"].ToString());
                    item.DescricaoPlanoConta = dt.Rows[i]["PLANO_CONTA"].ToString();
                    //item.Usuario_Id = int.Parse(dt.Rows[i]["USUARIO_ID"].ToString());
                    lista.Add(item);
                }
            }
           
            return lista;
        }

        public void Insert()
        {
            string id_usuario_logado = _httpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql="";
            if (Id == 0)
            {
                sql = $"INSERT INTO TRANSACAO (DATA, TIPO, DESCRICAO, VALOR, CONTA_ID, PLANO_CONTAS_ID, USUARIO_ID) " +
                    $"VALUES ('{DateTime.Parse(Data).ToString("yyyy/MM/dd")}','{Tipo}','{Descricao}','{Valor}','{Conta_Id}','{Plano_Conta_Id}','{id_usuario_logado}')";
            }
            else
            {
                sql = $"UPDATE TRANSACAO SET DATA = '{DateTime.Parse(Data).ToString("yyyy/MM/dd")}',"+
                      $"TIPO = '{Tipo}', DESCRICAO='{Descricao}', VALOR='{Valor}', CONTA_ID='{Conta_Id}', PLANO_CONTAS_ID='{Plano_Conta_Id}', USUARIO_ID='{id_usuario_logado}'"+
                      $"WHERE USUARIO_ID = '{id_usuario_logado}' and ID = '{Id}'";
            }
            DAL objDAL = new DAL();
            objDAL.ExecutaComandoSql(sql);
        }

        public void Excluir(int id)
        {
            new DAL().ExecutaComandoSql($"DELETE FROM TRANSACAO WHERE ID = '{id}'");

        }

        public TransacaoModel CarregarRegistro(int? id)
        {
            TransacaoModel item = new TransacaoModel();

            string id_usuario_logado = _httpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"select   t.id, " +
                                        "t.data, " +
                                        "t.tipo, " +
                                        "t.valor, " +
                                        "t.descricao, " +
                                        "t.conta_id, " +
                                        "c.nome as conta, " +
                                        "t.plano_contas_id, " +
                                        "p.descricao as plano_conta " +
                                "from transacao t " +
                                "inner join conta c " +
                                "on t.conta_id = c.id " +
                                "inner join plano_contas p " +
                                "on t.plano_contas_id = p.id " +
                                $" where t.Usuario_Id = {id_usuario_logado} AND t.id = {id} ";
            



            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);


            item.Id = int.Parse(dt.Rows[0]["ID"].ToString());
            item.Data = dt.Rows[0]["DATA"].ToString();
            item.Tipo = dt.Rows[0]["TIPO"].ToString();
            item.Descricao = dt.Rows[0]["DESCRICAO"].ToString();
            item.Valor = double.Parse(dt.Rows[0]["VALOR"].ToString());
            item.Conta_Id = int.Parse(dt.Rows[0]["CONTA_ID"].ToString());
            item.Plano_Conta_Id = int.Parse(dt.Rows[0]["PLANO_CONTAS_ID"].ToString());


            //item.Usuario_Id = int.Parse(dt.Rows[0]["USUARIO_ID"].ToString());

            return item;


        }
    }
}
