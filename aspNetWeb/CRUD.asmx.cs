﻿using aspNetWeb.Data;
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
        BBDD conectar;
        Respuesta datoDevuelto;

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
           //(ResponseFormat=ResponseFormat.Json)
        [WebMethod]
        [ScriptMethod ]
        public Respuesta insert(Usuario usuario)
        {
            conectar = new BBDD();
            conectar.insert(usuario.nombre, usuario.apellido, int.Parse(usuario.telefono), usuario.email, usuario.puesto, usuario.organizacion_id);
            datoDevuelto = new Respuesta(true,"Dato guardado");
            return datoDevuelto;
            
        }
        

        //Comando para eliminar una fila, para ello necesitamos recibir el id correspondiente de la fila que se quiere eliminar
        /*
        public object delete(int id)
        {
            cmd.CommandText = "DELETE FROM usuario WHERE id=" + id;
            cmd.ExecuteNonQuery();
            return null;
        }

        //Comando para actualizar una fila, para ello necesitamos recibir los datos correspondiente que se van a modificar

        public object update(Usuario usuario)
        {
            cmd.CommandText = " UPDATE usuario SET nombre='" + nomb + "',apellido='" + apell + "',telefono='" + tlf + "',email='" + ema + "',puesto='" + pues + "',organizacion_id='" + org_id + "' WHERE id='" + id + "'";
            cmd.ExecuteNonQuery();
            return null;
        } */

    }
}
