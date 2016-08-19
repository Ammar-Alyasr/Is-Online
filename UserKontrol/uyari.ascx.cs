using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserKontrol_uyari : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void show(string durum, string mesaj) {

        lbl_uyari.Text = mesaj;
       
        messageBox1.Show();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        messageBox1.Hide();
    }
}