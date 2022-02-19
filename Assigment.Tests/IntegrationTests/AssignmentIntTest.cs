using Assignment.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Assigment.Tests.IntegrationTests
{
    public class AssignmentIntTest  : IClassFixture<AssignmentWebApplicationFactory>
    {
        protected readonly AssignmentWebApplicationFactory _customWebApplicationFactory;
        protected HttpClient _httpClientWithFullIntegration;
        protected dynamic _token;
        string issuer = "https://localhost:5001";
        string audience = "https://localhost:5001";

        public AssignmentIntTest(AssignmentWebApplicationFactory customWebApplicationFactory)
        {
            _customWebApplicationFactory = customWebApplicationFactory;
            _httpClientWithFullIntegration ??= _customWebApplicationFactory.CreateClient();
            var user = new User()
            {
                UserName = "string",
                Password = "string"
            };
            _token = GetToken(user);
        }

        private string GetToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("key"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer, audience, null, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
