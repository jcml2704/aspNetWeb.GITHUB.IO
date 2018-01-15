using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;


namespace aspNetWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        BBDD bdatos;

        public WebForm1()
        {
          bdatos = new BBDD();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = bdatos.consulta();
            GridView1.DataBind();
        }

        protected void update_btn_Click(object sender, EventArgs e)
        {   
            bdatos.insert(nombre_text.Text, puesto_text.Text, int.Parse(organizacion_text.Text));
        }


    }
}