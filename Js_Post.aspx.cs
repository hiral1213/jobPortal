using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jobPortal
{
    public partial class Js_Post : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-VOEEFUJ\\MSSQLSERVER2017;Initial Catalog=JobPortal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void BindGrid()
        {
			con.Open();
			// string sQuery = "SELECT PostId,PostHead as Header,Descr FROM JobPost" ;
			string sQuery = "SELECT PostId,PostHead as Header,Descr,case when Status = 1 then 'Active' when Status = 0 then 'Deactive' else 'UNDEFINED' end AS Status FROM JobPost where CId=9";
			//	"" + Session["Cid"] + " ";
			SqlCommand cmd = new SqlCommand(sQuery, con);
			SqlDataReader sdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(sdr);
			gdPost.DataSource = dt;
			gdPost.DataKeyNames = new string[] { "PostId" };
			gdPost.DataBind();


		

		}
	
        protected void Page_Load(object sender, EventArgs e)
        {
        //    if (Session["JsUser"] == null)
        //    {
        //        Response.Redirect("Js_Login.aspx");
        //    }
        //    else
        //    {
              BindGrid();
            //}
        }

        protected void gdPost_RowCommand(object sender, GridViewCommandEventArgs e)
        {
			if (e.CommandName == "Apply")
			{
				GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

				int id = gvr.RowIndex;
				string getpostid = gdPost.Rows[id].Cells[0].Text;
				Response.Redirect("Js_Apply.aspx?id=" + Convert.ToInt16(getpostid));
			}
			else if (e.CommandName == "View")
			{
				// int id = Convert.ToInt16(e.CommandArgument);
				GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

				int id = gvr.RowIndex;
				string getpostid = gdPost.Rows[id].Cells[0].Text;
				Response.Redirect("Js_ViewPost.aspx?id=" + Convert.ToInt16(getpostid));
			}
		}

		
		protected void dlst1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if( dlst1.Text== "PostHead")
			{
				dlst2.Items.Clear();
				dlst2.DataSource = SqlDataSource1;
				dlst2.DataTextField = "PostHead";
				dlst2.DataValueField = "PostHead";
				dlst2.DataBind();

				dlst2.Items.Insert(0,"--Select--");

			}
			else if(dlst1.Text == "JobField")
			{
				dlst2.Items.Clear();
				dlst2.DataSource = SqlDataSource2;
				dlst2.DataTextField = "JobField";
				dlst2.DataValueField = "JobField";
				dlst2.DataBind();

				dlst2.Items.Insert(0, "--Select--");


			}
			else if (dlst1.Text == "Loc")
			{
				dlst2.Items.Clear();
				dlst2.DataSource = SqlDataSource3;
				dlst2.DataTextField = "Loc";
				dlst2.DataValueField = "Loc";
				dlst2.DataBind();
				dlst2.Items.Insert(0, "--Select--");

			}



		}

		protected void dlst2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (dlst1.Text == "PostHead")
			{
				GridView2.DataSource = SqlDataSource5;
				GridView2.DataBind();
			

			}
			else if (dlst1.Text == "JobField")
			{
				GridView2.DataSource = SqlDataSource6;
				GridView2.DataBind();
				


			}
			else if (dlst1.Text == "Loc")
			{
				GridView2.DataSource = SqlDataSource7;
				GridView2.DataBind();

			}
			Panel1.Visible = false;
			Panel2.Visible = true;
		}

		protected void btnRefresh_Click(object sender, EventArgs e)
		{
			Panel1.Visible = true;
			Panel2.Visible = false;

		}

		
	}
}