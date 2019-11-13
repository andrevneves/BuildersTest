using System;
using System.Collections.Generic;
using System.Text;

namespace Builders.DotNetCore.Domain.Interfaces.Services
{
    public interface ICorreiosService
    {
        bool PingServer(string cep);
    }
}
