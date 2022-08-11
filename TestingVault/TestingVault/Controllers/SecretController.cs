using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;

namespace TestingVault.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecretController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SecretController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<Secret<SecretData>> GetAsync()
        {

            IAuthMethodInfo authMethod = new TokenAuthMethodInfo(_configuration.GetSection("VaultToken").Value);

            var vaultClientSettings = new VaultClientSettings(_configuration.GetSection("VaultUrl").Value, authMethod);

            IVaultClient vaultClient = new VaultClient(vaultClientSettings);

            var kv2Secret = await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(path: "tdc", mountPoint: "secret");

            return kv2Secret;
        }
    }
}

