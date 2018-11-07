using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateCustomerAccount : System.Web.UI.Page
{

    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = "Data source=pr-e216-43\\mssqlserver2016; initial catalog = SwiftServe; integrated Security = true";
        con.Open();

    }

    protected void btnCreateCustomerAccount_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("insert into tbl_CustomerLogin" + "(Username,Password)values(@Username,@Password)", con);
        cmd.Parameters.AddWithValue("@Username", txtEmail.Text);
        cmd.Parameters.AddWithValue("@Password", txtPwd.Text);
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();



        SqlCommand cmd1 = new SqlCommand("insert into tbl_CustomerCreateAccount" + "(Firstname,Lastname,CentennialEmail,Address,Phonenumber)values(@Firstname,@Lastname,@CentennialEmail,@Address,@Phonenumber)", con);
        cmd1.Parameters.AddWithValue("@Firstname", txtFName.Text);
        cmd1.Parameters.AddWithValue("@Lastname", txtLName.Text);
        cmd1.Parameters.AddWithValue("@CentennialEmail", txtEmail.Text);
        cmd1.Parameters.AddWithValue("@Address", txtAddress.Text);
        cmd1.Parameters.AddWithValue("@Phonenumber", txtPhone.Text);
        cmd1.ExecuteNonQuery();
        cmd1.Parameters.Clear();

      
       





    }
}