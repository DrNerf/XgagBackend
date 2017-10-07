using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public interface ICryptoService
    {
        string HashPassword(string password);

        bool VerifyHashedPassword(string hashedPassword, string password);
    }
}
