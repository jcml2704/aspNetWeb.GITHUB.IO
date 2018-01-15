using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspNetWeb
{
    public class usuario
    {
        string nombre;
        string puesto;
        int organizacion;


        public usuario(string nomb,string puest,int org)
        {
            nombre = nomb;
            puesto = puest;
            organizacion = org;

        }

        //Métodos de consulta

        public string getNombre()
        {
            return nombre;
        }

        public string getPuesto()
        {
            return puesto;
        }

        public int getOrganizacion()
        {
            return organizacion;
        }

        //Métodos modificación

        public void setNombre(string nomb)
        {
            nombre = nomb;
        }

        public void setPuesto(string puest)
        {
            puesto=puest;
        }

        public void setOrganizacion(int org)
        {
            organizacion = org;
        }
    }
}