﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspNetWeb
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        //conecta con el formulario que enseña la tabla
        protected void ver_btn_Click(object sender, EventArgs e)
        {

            Response.Redirect("WebForm2.aspx");
        }
        //conecta con el formulario que edita la tabla
        protected void edit_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }
}