using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

public partial class _Default : System.Web.UI.Page
{
    
    veritabani vtab = new veritabani();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
    }

    public bool kullaniciLogin(string kadi, string pass) {
        Session["UserID"] = "";
        Session["Isim"] = "";
        Session["Email"] = "";
        bool snc = false;
      
       var user =  vtab.GetDataRow("SELECT * From users where userEmail ='" + kadi + "' AND userPas='" + pass + "'");
        

        if (user != null) {
            string isim = user["userAdSoyad"].ToString();
            string email = user["userEmail"].ToString();
            string uid2 = user["userID"].ToString();

            Session["UserID"] = uid2;
            Session["Isim"] = isim;
            Session["Email"] = email;
            snc = true;
        }


        return snc;

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        Label1.Text = "";

        if (kullaniciLogin(TextBox1Em.Text, TextBox1Pas.Text))
        {

            Response.Redirect("Default2.aspx");
        }
        else
        {
            Label1.Visible = true;
            Label1.Text += "<br> HATALI GIRIS";

        }

    }

    
}