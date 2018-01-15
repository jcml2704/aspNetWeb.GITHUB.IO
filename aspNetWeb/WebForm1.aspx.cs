using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;


namespace aspNetWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        usuario usuarioPrueba;


        public WebForm1()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "curso2018.clxnqp6pxj8t.eu-west-1.rds.amazonaws.com";
            builder.UserID = "cursomaster";
            builder.Password = "cursomaster2018";
            builder.Database = "Proyecto";

            MySqlConnection baseDeDatos = new MySqlConnection(builder.ToString());
            MySqlCommand cmd = baseDeDatos.CreateCommand();
            baseDeDatos.Open();
            cmd.CommandText = "INSERT INTO usuario (Id,nombre,puesto,organizacion_id) values (0,'b','b',1)";
            cmd.ExecuteNonQuery();

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void update_btn_Click(object sender, EventArgs e)
        {
            usuarioPrueba = new usuario(nombre_text.Text, puesto_text.Text, int.Parse(organizacion_text.Text));
            
        }
    }
}