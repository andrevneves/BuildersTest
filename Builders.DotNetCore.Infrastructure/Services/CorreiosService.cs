using Builders.DotNetCore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Builders.DotNetCore.Infrastructure.Services
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
