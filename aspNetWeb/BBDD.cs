using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using aspNetWeb.Data;

namespace aspNetWeb
{
    public class BBDD
    {
        MySqlCommand cmd;
        MySqlConnection baseDeDatos;
        MySqlConnectionStringBuilder builder;
        List<Usuario> listaUsuario;
        List<organizacion> listaOrg;

        //Constructor, conexión a la base de dato

        public BBDD()
        {
            builder = new MySqlConnectionStringBuilder();
            builder.Server = "curso2018.clxnqp6pxj8t.eu-west-1.rds.amazonaws.com";
            builder.UserID = "cursomaster";
            builder.Password = "cursomaster2018";
            builder.Database = "Proyecto";
            baseDeDatos = new MySqlConnection(builder.ToString());
            cmd = baseDeDatos.CreateCommand();
            baseDeDatos.Open();
        }
        
        //Comando para insertar una nueva fila, para ello necesitamos recibir los datos correspondiente que se van a insertar

        public void insert(string nomb,string ape,int tlf,string ema,string puest, int org)
        {
            cmd.CommandText = "INSERT INTO usuario (nombre,apellido,telefono,email,puesto,organizacion_id) VALUES ('"+nomb + "','" + ape + "','" + tlf + "','" + ema + "','" + puest+"',"+org+")";
            cmd.ExecuteNonQuery();
        }

        //Comando para eliminar una fila, para ello necesitamos recibir el id correspondiente de la fila que se quiere eliminar

        public void delete(int id)
        {
            cmd.CommandText = "DELETE FROM usuario WHERE id=" + id;    
            cmd.ExecuteNonQuery();
        }

        //Comando para actualizar una fila, para ello necesitamos recibir los datos correspondiente que se van a modificar

        public void update(int id,string nomb,string apell,int tlf,string ema,string pues,int org_id)
        {
            cmd.CommandText = " UPDATE usuario SET nombre='" + nomb + "',apellido='"+apell+ "',telefono='" + tlf + "',email='" + ema + "',puesto='" + pues + "',organizacion_id='" + org_id + "' WHERE id='" + id+"'";
            cmd.ExecuteNonQuery();
        }

        //Consulta y recogida de datos

        public DataTable consulta()
        {
            cmd = new MySqlCommand("SELECT * FROM usuario", baseDeDatos);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);
            return dataTable;
        }

       

        public DataTable desplegable()
        {
            cmd = new MySqlCommand("SELECT * FROM organizacion", baseDeDatos);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);
            return dataTable;
        }

        public List<Usuario> tabla()
        {
          listaUsuario=new List<Usuario>();

            cmd = new MySqlCommand("SELECT * FROM usuario", baseDeDatos);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                string ID = row[0].ToString();
                string NOMBRE = row[1].ToString();
                string APELLIDO = row[2].ToString();
                string TELEFONO = row[3].ToString();
                string EMAIL = row[4].ToString();
                string PUESTO = row[5].ToString();
                string ORGANIZACION_ID = row[6].ToString();

                listaUsuario.Add(new Usuario() { Id = int.Parse(ID), nombre = NOMBRE, apellido = APELLIDO, telefono = TELEFONO, email = EMAIL, puesto = PUESTO, organizacion_id = int.Parse(ORGANIZACION_ID), organizacion = null });
            }
            return listaUsuario;
        }

        public List<organizacion> tablaOrg()
        {
            listaOrg = new List<organizacion>();
            DataTable dataTable= desplegable();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                string ID = row[0].ToString();
                string ORG = row[1].ToString();
                listaOrg.Add(new organizacion() { id = int.Parse(ID), org = ORG });
            }
            return listaOrg;
        }


    }
}


