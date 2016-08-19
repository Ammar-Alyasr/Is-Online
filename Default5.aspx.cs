using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default5 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string date2  = "6.08.2016 22:21:15";
      
        string date1 = "5.08.2016 23:21:15";
        
        TimeSpan sonuc = DateTime.Parse(date2).Subtract(DateTime.Parse(date1));

        string a = Convert.ToString (sonuc);
        
        Label1.Text = a.ToString();
        if (a == "-1.01:58:49" || a== "-1.01:58:49")
        {
            Label1.Text = a.ToString();

        }
    }
}