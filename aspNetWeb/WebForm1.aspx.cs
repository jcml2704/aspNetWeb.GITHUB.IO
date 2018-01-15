using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace aspNetWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        usuario usuarioPrueba;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void update_btn_Click(object sender, EventArgs e)
        {
            usuarioPrueba = new usuario(nombre_text.Text, puesto_text.Text, organizacion_text.Text);
            
        }
    }
}