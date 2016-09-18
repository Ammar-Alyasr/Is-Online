using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

public partial class Default3 : System.Web.UI.Page
{
    KontrolEt ktrl = new KontrolEt();
    veritabani vtb = new veritabani();
    
    public bool siteEkle(string siteAd, string url, string controlSuresi)
    {
        try
        {
            bool snc = false;
            
            string gelenmsj = ktrl.konrolEt(TextBox2.Text);

            if (gelenmsj == "OK")
            {
                var sql = vtb.GetDataSet("INSERT INTO siteler (siteAd, siteURL, controlSuresi, siteDurum2, zaman, userID) values  ('" + TextBox1.Text + "' , '" + TextBox2.Text + "', '" + DropDownList1.Text + "' ,'" + gelenmsj + "', '" + DateTime.Now.ToString() + "', '" + Session["UserID"] + "' ) ");
                uyari1.show("Bilgi", TextBox2.Text + " Eklendi");
                if (sql != null)
                {
                    snc = true;
                }

                return snc;
            }

            else if (gelenmsj == "Hatali Giris")
            {
                uyari1.show("Hata", "Yanlis Bir URL Girdiniz , Tekrar Deneyin....");
                snc = false;
                return snc;
            }

            else
            {
                var sql = vtb.GetDataSet("INSERT INTO siteler (siteAd, siteURL, controlSuresi, siteDurum2, zaman, userID) values  ('" + TextBox1.Text + "' , '" + TextBox2.Text + "', '" + DropDownList1.Text + "' ,'" + gelenmsj + "', '" + DateTime.Now.ToString() + "', '" + Session["UserID"] + "' ) ");

                if (sql != null)
                {
                    uyari1.show("Hata", "Girdiğiniz URL Bozuk ya da kapalı bir Siteye Aittir, Siteyi Konterol Etmeyi Unutmayınız!!  ");
                    snc = true;
                }

                return snc;

            }
           
        }
        catch (Exception exe)
        {
            ktrl.Send("ammar.ahmet@gmail.com", exe.ToString(), "Site ekle Fonks.", "Site Eklemede ", Session["Isim"].ToString());
            return false;
        }

    }
 

    void GuncelSitelereekle()
    {

        string gelenmsj= ktrl.konrolEt(TextBox2.Text);
        if (gelenmsj != "Hatali Giris")
        {
            var sql = vtb.cmd("insert into GuncelSiteler (siteDurum2, zaman) values('" + gelenmsj + "' , '" + DateTime.Now.ToString() + "' ) ");

        }
    }

    void yapilanDegisiklik(string siteID, string userID, string zaman, string degisik)
    {

        var sql = vtb.cmd("INSERT INTO Degisiklikler (siteID, userID, zaman, GosterilenDegisiklik) values  ('" + siteID + "' , '" + userID + "', '" + zaman + "' ,'" + degisik + "' ) ");

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            GuncelSitelereekle();

            if (TextBox1.Text != "" || TextBox2.Text != "")
            {
                if (siteEkle(TextBox1.Text, TextBox2.Text, DropDownList1.Text) == true)
                {

                }

            }

            else
            {
                uyari1.show("Hata", " bos veri girilmez...");

            }
        }
        catch (Exception exe)
        {
            ktrl.Send("ammar.ahmet@gmail.com", exe.ToString(), "Site ekle Fonks.", "Site Eklemede ", Session["Isim"].ToString());
            
        }


    }


    protected void Page_Load(object sender, EventArgs e)
    {
        //DropDownList1.SelectedIndex = 2;
    }

}