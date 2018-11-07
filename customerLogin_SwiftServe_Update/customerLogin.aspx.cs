using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class customerLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblErrorMessage.Visible = false;
        lblUsernameMessage.Visible = false;
        lblPasswordMessage.Visible = false;
    }

    protected void btnLog_Click(object sender, EventArgs e)
    {
        //connection string to the database****DESKTOP-R6TVRP1(My computer server name); "student_login" is the database name****
        using (SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-R6TVRP1;Initial Catalog=student_login;Integrated Security=True;"))
        {
            sqlCon.Open();
            string query = "SELECT COUNT(1) FROM tbl_customerUser WHERE username=@username AND password=@password";
            SqlCommand SqlCmd = new SqlCommand(query, sqlCon);
            SqlCmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());//parameter values from the database
            SqlCmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());//parameter values from the database
            int count = Convert.ToInt32(SqlCmd.ExecuteScalar());
            if (count == 1)
            {
                Session["username"] = txtUserName.Text.Trim();
                Response.Redirect("Dashboard.aspx");
            }
            //if the user enters a wrong username
            else if(count!=1)
            {
                lblUsernameMessage.Visible = true;
            }
            else if(count!=1)
            {
                //Session["password"] = txtPassword.Text.Trim();
                lblPasswordMessage.Visible = true;
            }
            else
            {
                lblErrorMessage.Visible = true;
            }

        }
    }
}