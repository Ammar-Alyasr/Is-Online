using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default8 : System.Web.UI.Page
{
    veritabani vtab = new veritabani();
    public class SiteHareket {
        public string sid { get; set; }
        public string sad { get; set; }
        public string tarih { get; set; }
        public string Aciklama { get; set; }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (KapListe.DataSource == null)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Site Adi"), new DataColumn("Aciklama"), new DataColumn("Tarih") });
            KapListe.DataSource = dt;
            KapListe.DataBind();
        }

        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                ilk_gelis();
            }
            
        }
        else
        {
            Response.Redirect("Default.aspx");
        }

        

    }
    public void ilk_gelis() {
        listele();
       //iframe();
    }
    public void iframe() {

        string url = "https://getbootstrap.com/";
        Literal1.Text = " <iframe id=\"frame\" width=\"680\" height='360' class='embed-responsive-item' src='" + url+ "' frameborder='0' allowfullscreen'></iframe>";
            
    }
    public string siteURLGetir(string sid)
    {
        string st = "";
        string sad = vtab.GetDataCell("Select siteURL FROM Siteler Where siteID=" + sid + "");
        st = sad.ToString();
        return st;
    }
    public void listele() {
       
        string sid = Session["siteid"].ToString();
        DataTable dt = vtab.GetDataTable("Select * FROM Degisiklikler WHERE siteID=" + sid + "");

        List<SiteHareket> siteler = new List<SiteHareket>();

        if (dt.Rows.Count > 0) {
            foreach (DataRow dr in dt.Rows) {
                SiteHareket st = new SiteHareket();
                st.sid = dr["siteID"].ToString();
                st.sad = siteAdiGetir(sid);
                st.tarih = dr["zaman"].ToString();
                string durum = dr["GosterilenDegisiklik"].ToString();
                string icon = "";
                icon = "<span class='label label-danger'><span class='glyphicon  glyphicon-arrow-down'></span> Down</span>";
                if (durum == "OK") {
                    icon = "<span class='label label-success'><span class='glyphicon glyphicon-arrow-up'></span> Up</span>";
                }
                st.Aciklama = icon + "<br/> " + durum;
                siteler.Add(st);
            }
            siteler = siteler.OrderBy(p => p.sad).ToList();

            KapListe.DataSource = siteler;
            KapListe.DataBind();
        }
       
       string url= siteURLGetir(sid);

        Yazdir(sid);
        
       Literal1.Text = " <iframe id=\"frame\" width=\"680\" height='360' class='if' src='" + url + "'></iframe>";

    }
    void Yazdir(string sid)
    {
        string adi = "";
        string url = "";
        string contol = "";
        var sad = vtab.GetDataRow("Select siteAd,siteURL,controlSuresi FROM Siteler Where siteID=" + sid + "");
        adi =sad["siteAd"].ToString();
        TextBox2.Text = adi;

        url = sad["siteURL"].ToString();
        TextBox1.Text = url;

        contol = sad["controlSuresi"].ToString();
        DropDownList1.Text = contol;
    }
    public string siteAdiGetir(string sid) {
        string st = "";
        string sad = vtab.GetDataCell("Select siteAd FROM Siteler Where siteID=" + sid + "");
        st = sad.ToString();
        return st;
    }


    protected void KapListe_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //  ClientScript.RegisterStartupScript(GetType(), "ScrollScript", "window.onload = function() {document.getElementById('objectid').scrollIntoView(true);}", true);
        if (IsPostBack)
        {
            string script = @"window.onload = function SetButtonScroll() {
                var height = document.body.scrollHeight;
                var width = document.body.scrollWidth;
                window.scrollTo(0, height);
        }";
            this.ClientScript.RegisterStartupScript(this.GetType(), "setScroll", script, true);
        }

        if (Panel2.Visible == false)
        {

            Panel2.Visible = true;
        }
        else
        {
            Panel2.Visible = false;
        }

    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;

    }


    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        vtab.GetDataCell("DELETE FROM Degisiklikler WHERE siteID='" + Session["siteid"].ToString() + "'");
        vtab.GetDataCell("DELETE FROM Siteler WHERE siteID='" + Session["siteid"].ToString() + "'");
        Response.Redirect("Default2.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        string ad = TextBox2.Text;
        
        string url = TextBox1.Text;
        string contol = DropDownList1.Text;
        
        vtab.cmd("UPDATE Siteler SET siteAd='" + TextBox2.Text + "' , siteURL='" + url + "' ,  controlSuresi='" + DropDownList1.Text + "' WHERE siteID='" + Session["siteid"].ToString() + "'");
        Response.Redirect("Default8.aspx");
    }
}
