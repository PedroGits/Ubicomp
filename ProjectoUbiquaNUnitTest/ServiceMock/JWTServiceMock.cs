using Microsoft.IdentityModel.Tokens;
using ProjetoUbiqua.Autenticacao.JWT.JWTLogic.Interface;
using ProjetoUbiqua.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoUbiquaNUnitTest.ServiceMock
{
    internal class JWTServiceMock : IJWTService
    {
        public JwtSecurityToken GetToken(Utilizador utilizador)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("chaveSecretaDeTeste2022"));

            var token = new JwtSecurityToken(
                issuer: "teste",
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
