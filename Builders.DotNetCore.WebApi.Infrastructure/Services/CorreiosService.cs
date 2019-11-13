using Builders.DotNetCore.WebApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Builders.DotNetCore.WebApi.Infrastructure.Services
{
    public class CorreiosService : ICorreiosService
    {
        public bool PingServer(string cep)
        {
            var result = new Correios.consultaCEP(cep);
            return cep.Equals(result?.cep);
        }
    }
}
