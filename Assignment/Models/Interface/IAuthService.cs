using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models.Interface
{
  public interface IAuthService
    {
        string GetToken(string userName, string password);
    }
}
