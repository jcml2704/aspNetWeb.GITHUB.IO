﻿using System;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = bdatos.consulta();
            GridView1.DataBind();


        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm3.aspx");
        }
    }
}