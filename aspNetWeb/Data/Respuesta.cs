using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspNetWeb.Data
{
    public class Respuesta
    {
        public bool ok;
        public string info;
        public Respuesta(bool OK, string INFO)
        {
            ok = OK;
            info = INFO;
        }
    }
}