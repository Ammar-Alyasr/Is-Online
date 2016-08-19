using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default8 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Session["siteid"].ToString();
       // SqlDataSource1.SelectCommand = "Select Siteler.* , users.userAdSoyad , users.userID from Siteler inner join users on Siteler.userID=users.userID where users.userID= '" + Session["UserID"].ToString() + "' ";
        SqlDataSource1.SelectCommand = "SELECT Degisiklikler.zaman ,Degisiklikler.GosterilenDegisiklik , Siteler.siteID FROM Degisiklikler INNER JOIN Siteler on   Degisiklikler.siteID=Siteler.siteID WHERE Degisiklikler.siteID='"+ Session["siteid"] + "' ORDER BY Degisiklikler.zaman DESC ";

        //SqlDataSource1.SelectCommand = "SELECT [zaman], [GosterilenDegisiklik], [siteID] FROM [Degisiklikler] WHERE siteID= '" + Session["siteid"]+"' ORDER BY [zaman] DESC";
    }
}