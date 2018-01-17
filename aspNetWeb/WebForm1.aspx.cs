﻿using System;
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
            if (!IsPostBack)
            {
                actualizarGridview();
            }
                
        }


        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            actualizarGridview();
            Response.Redirect("WebForm1.aspx");
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse( GridView1.DataKeys[e.RowIndex].Value.ToString());
            bdatos.delete(id);
            actualizarGridview();
            Response.Redirect("WebForm1.aspx");
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            actualizarGridview(); 
        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            TextBox nombre_text = (TextBox)GridView1.Rows[e.RowIndex].FindControl("nombre_text");
            TextBox apellido_text = (TextBox)GridView1.Rows[e.RowIndex].FindControl("apellido_text");
            TextBox telefono_text = (TextBox)GridView1.Rows[e.RowIndex].FindControl("telefono_text");
            TextBox email_text = (TextBox)GridView1.Rows[e.RowIndex].FindControl("email_text");
            TextBox puesto_text = (TextBox)GridView1.Rows[e.RowIndex].FindControl("puesto_text");
            TextBox organizacion_id_text = (TextBox)GridView1.Rows[e.RowIndex].FindControl("organizacion_id_text");
            bdatos.update(id, nombre_text.Text, apellido_text.Text,int.Parse(telefono_text.Text),email_text.Text,puesto_text.Text,int.Parse(organizacion_id_text.Text));
            GridView1.EditIndex = -1;
            actualizarGridview();
            Response.Redirect("WebForm1.aspx");
        }


        public void actualizarGridview()
        {
            GridView1.DataSource = bdatos.consulta();
            GridView1.DataBind();
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("insert"))
            {
                TextBox nombre_text = (TextBox)GridView1.FooterRow.FindControl("nombre_insert_text");
                TextBox apellido_text = (TextBox)GridView1.FooterRow.FindControl("apellido_insert_text");
                TextBox telefono_text = (TextBox)GridView1.FooterRow.FindControl("telefono_insert_text");
                TextBox email_text = (TextBox)GridView1.FooterRow.FindControl("email_insert_text");
                TextBox puesto_text = (TextBox)GridView1.FooterRow.FindControl("puesto_insert_text");
                TextBox organizacion_id_text = (TextBox)GridView1.FooterRow.FindControl("organizacion_id_insert_text");
                bdatos.insert( nombre_text.Text, apellido_text.Text, int.Parse(telefono_text.Text), email_text.Text, puesto_text.Text, int.Parse(organizacion_id_text.Text));
                actualizarGridview();
                Response.Redirect("WebForm1.aspx");
            }
        }
    }
}