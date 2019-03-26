using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jobPortal
{
    public partial class Company_listPost : System.Web.UI.Page
    {
		SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JobPortalConnectionString"].ConnectionString);// SqlConnection con = new SqlConnection("Data Source=DESKTOP-VOEEFUJ\\MSSQLSERVER2017;Initial Catalog=JobPortal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

		private void BindGrid()
        {
            con.Open();
            string sQuery = "SELECT PostId,PostHead as Header,case when Status = 1 then 'Active' when Status = 0 then 'Deactive' else 'UNDEFINED' end AS Status FROM JobPost where CId="+ Session["Cid"] +" ";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            gdPost.DataSource = dt;
            gdPost.DataKeyNames = new string[] { "PostId" };
            gdPost.DataBind();




			//using (SqlCommand cmd1 = new SqlCommand("SELECT [PostId],[PostHead], [Loc], [Salary], [JobType], [JobField],[Status] FROM[JobPost]"))
			//{
			//	using (SqlDataAdapter sda = new SqlDataAdapter())
			//	{
			//		cmd1.Connection = con;
			//		sda.SelectCommand = cmd1;
			//		using (DataTable dt1 = new DataTable())
			//		{
			//			sda.Fill(dt1);
			//			GridView1.DataSource = dt1;
			//			GridView1.DataBind();
			//		}
			//	}
			//}

		}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Session["company"] == null)
            {
                Response.Redirect("Company_userLogin.aspx");
            }
            else
            {
                BindGrid();
            }
        }
       
        protected void gdPost_SelectedIndexChange(object sender, GridViewSelectEventArgs e)
        {
            int id = e.NewSelectedIndex;
            string getpostid = gdPost.Rows[id].Cells[0].Text;
            Response.Redirect("Company_ViewPost.aspx?id=" + Convert.ToInt16(getpostid));
        }

        protected void gdPost_RowEditing(object sender, GridViewEditEventArgs e)
        {

            int id = e.NewEditIndex;
            string getpostid = gdPost.Rows[id].Cells[0].Text;
            Response.Redirect("Company_EditPost.aspx?id=" + Convert.ToInt16(getpostid));

        }

        protected void gdPost_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = e.RowIndex;
            string getpostid = gdPost.Rows[id].Cells[0].Text;

            string s = "Update JobPost set Status= 0 where PostId=" + Convert.ToInt16(getpostid);
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
            BindGrid();
        }
		
		public DataTable GetDataTable(string field)
		{
			string query = string.Format("SELECT DISTINCT {0} FROM Customers", field);

			String ConnString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
			SqlConnection conn = new SqlConnection(ConnString);
			SqlDataAdapter adapter = new SqlDataAdapter();
			adapter.SelectCommand = new SqlCommand(query, conn);

			DataTable myDataTable = new DataTable();

			conn.Open();
			try
			{
				adapter.Fill(myDataTable);
			}
			finally
			{
				conn.Close();
			}

			return myDataTable;
		}
		protected void dlst1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (dlst1.Text == "PostHead")
			{
				dlst2.Items.Clear();
				dlst2.DataSource = SqlDataSource1;
				dlst2.DataTextField = "PostHead";
				dlst2.DataValueField = "PostHead";
				dlst2.DataBind();

				dlst2.Items.Insert(0, "--Select--");

			}
			else if (dlst1.Text == "JobField")
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