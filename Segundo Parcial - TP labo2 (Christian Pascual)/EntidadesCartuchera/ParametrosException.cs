using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCartuchera
{
    public sealed class ParametrosException : Exception
    {
        public ParametrosException(string texto) : this(texto, null)
        {
            
        }

        public ParametrosException(string texto, Exception inner) : base(texto, inner)
        {

        }
    }

    public sealed class SinTintaException : Exception
    {
        public SinTintaException(string texto) : this(texto, null)
        {

        }

        public SinTintaException(string texto, Exception inner) : base(texto, inner)
        {

        }
    }
}
