using System;
using Xunit;
using MyFinance.Models;

namespace ProjetoTestes
{
    public class UnitTestModels
    {
        [Fact]
        public void TestLoginUsuario()
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            usuarioModel.Email = "weslen.mariano@hotmail.com";
            usuarioModel.Senha = "1234";
            bool result = usuarioModel.ValidarLogin();
            Assert.True(result);

        }
    }
}
