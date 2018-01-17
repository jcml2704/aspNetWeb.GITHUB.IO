using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace aspNetWeb
{
    public class BBDD
    {
        MySqlCommand cmd;
        MySqlConnection baseDeDatos;
        MySqlConnectionStringBuilder builder;


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

        public void insert(string nomb,string puest, int org)
        {
            cmd.CommandText = "INSERT INTO usuario (nombre,puesto,organizacion_id) values ('"+nomb +"','"+puest+"',"+org+")";
            cmd.ExecuteNonQuery();
        }

        public void delete(int id)
        {
            cmd.CommandText = "Delete from usuario where id=" + id;    
            cmd.ExecuteNonQuery();
        }

        public void update(int id,string nomb,string apell,int tlf,string ema,string pues,int org_id)
        {
            cmd.CommandText = " Update usuario set nombre='" + nomb + "',apellido='"+apell+ "',telefono='" + tlf + "',email='" + ema + "',puesto='" + pues + "',organizacion_id='" + org_id + "' where id='" + id+"'";
            cmd.ExecuteNonQuery();
        }




        public DataTable consulta()
        {
            cmd = new MySqlCommand("SELECT * FROM usuario", baseDeDatos);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);
            return dataTable;
        }

    }
}


