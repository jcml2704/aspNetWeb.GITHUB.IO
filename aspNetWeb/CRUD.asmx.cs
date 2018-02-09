using aspNetWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using MySql.Data.MySqlClient;
using System.Data;

namespace aspNetWeb
{
    /// <summary>
    /// Descripción breve de CRUD
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class CRUD : System.Web.Services.WebService
    {
        public BBDD conectar;
        public Respuesta datoDevuelto;

        MySqlCommand cmd;
        MySqlConnection baseDeDatos;
        MySqlConnectionStringBuilder builder;
        List<Usuario> lista;

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
           
        [WebMethod]
        [ScriptMethod (ResponseFormat=ResponseFormat.Json)]
        public Respuesta insert(Usuario usuario)
        {
            conectar = new BBDD();
            conectar.insert(usuario.nombre, usuario.apellido, int.Parse(usuario.telefono), usuario.email, usuario.puesto, usuario.organizacion_id);
            datoDevuelto = new Respuesta() {info="dato guardado" };
            return datoDevuelto;
            
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Usuario> getTable()
        {
            conectar = new BBDD();
            lista = new List<Usuario>();
            lista = conectar.tabla();
            return lista; 
        }


        //Comando para eliminar una fila, para ello necesitamos recibir el id correspondiente de la fila que se quiere eliminar

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Respuesta delete(string id)
        {
            conectar = new BBDD();
            conectar.delete(int.Parse(id));
            datoDevuelto = new Respuesta() { info="dato eliminado"};
            return datoDevuelto;
        }

        //Comando para actualizar una fila, para ello necesitamos recibir los datos correspondiente que se van a modificar


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object update(Usuario usuario)
        {
            conectar = new BBDD();
            conectar.update(usuario.Id, usuario.nombre, usuario.apellido, int.Parse(usuario.telefono), usuario.email, usuario.puesto, usuario.organizacion_id);
            datoDevuelto = new Respuesta() { info = "dato actualizado" };
            return datoDevuelto;

        }

    }
}
