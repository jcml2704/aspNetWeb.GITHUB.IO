using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspNetWeb
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        BBDD bdatos;

        public WebForm2()
        {
            bdatos = new BBDD();
        }
        // Enseña la base de datos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = bdatos.consulta();
                GridView1.DataBind();

                DropDownList1.DataSource = bdatos.desplegable();
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataBind();
            }

        }
        //Conecta con el formulario de inicio
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm3.aspx");
        }
    }
}