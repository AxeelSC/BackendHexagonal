using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.UseCases.Auth.Register
{
    public record RegisterResult(AuthSession Session); //Creo un AuthSession para cuando escale y anyada mas campos esta parte que es comun no haga falta repetirla.
}
