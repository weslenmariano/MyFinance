using System;
using Xunit;
using MyFinance.Models;

namespace ProjetoDeTeste
{
    public class UnitTestModels
    {
        [Fact]
        public void TesteLoginUsuario()
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            usuarioModel.Email = "weslen.mariano@hotmail.com";
            usuarioModel.Senha = "1234";
            bool result = usuarioModel.ValidarLogin();
            Assert.True(result);
        }

        [Fact]
        public void TesteRegistrarUsuario()
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            usuarioModel.Nome = "Teste3";
            usuarioModel.Data_Nascimento = "1987/05/22";
            usuarioModel.Email = "weslen3.mariano@hotmail.com";
            usuarioModel.Senha = "1234";
            usuarioModel.RegistrarUsuario();
            bool result = usuarioModel.ValidarLogin();
            Assert.True(result);
        }
    }
}
