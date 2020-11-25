//-----------------------------------------------------------------------------
// Utilities                                                        (25/Nov/20)
//
// Código de Hannes DuPreez 
//
//
// (c) Guillermo (elGuille) Som, 2020
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Editar_Colores
{
    public class Utilities
    {
        private Utilities()
        {
        }

        public static void CheckValidEnumValue(string arg, object val, Type Class)
        {
            if (!Enum.IsDefined(Class, val))
            {
                throw new InvalidEnumArgumentException(arg, (int)val, Class);
            }
        }
    }
}
