using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for veritabani
/// </summary>
public class veritabani
{
 
          public SqlConnection baglan()
    {

        //SqlConnection baglanti = new SqlConnection("Data Source=172.16.36.246;Initial Catalog=emreDb;User ID=part;Password=1q2w3e4r;");
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8GG3N5D;Initial Catalog=sites;Integrated Security=SSPI;MultipleActiveResultSets=True");

        baglanti.Open();

        return baglanti;

    }
    //********************************************************************
    //Sql Sorgu Çalıştırma
    public int cmd(string sqlcumle)
    {
        SqlConnection baglan = this.baglan();
        SqlCommand sorgu = new SqlCommand(sqlcumle, baglan);
        int sonuc = 0;

        try
        {
            sonuc = sorgu.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message + " (" + sqlcumle + ")");
        }
        finally
        {
            sorgu.Connection.Close();
        }
        return (sonuc);
    }
    //Sql Sorgu Çalıştırma
    public int cmdp(string sqlcumle, string parametre)
    {
        SqlConnection baglan = this.baglan();
        SqlCommand sorgu = new SqlCommand(sqlcumle, baglan);
        sorgu.Parameters.Add("@sicilno", SqlDbType.VarChar, 500);
        sorgu.Parameters["@sicilno"].Value = parametre;
        int sonuc = 0;

        try
        {
            sonuc = sorgu.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message + " (" + sqlcumle + ")");
        }
        finally
        {
            sorgu.Connection.Close();
        }
        return (sonuc);
    }
    //********************************************************************
    //Kayıt Sayısı Bulma

    public string GetDataCell(string sql)
    {
        DataTable table = GetDataTable(sql);
        if (table.Rows.Count == 0)
            return null;
        return table.Rows[0][0].ToString();
    }

    //Kayıt Çekme
    public DataRow GetDataRow(string sql)
    {
        DataTable table = GetDataTable(sql);
        if (table.Rows.Count == 0) return null;
        return table.Rows[0];

    }


    //DataTable ye veri çekme
    public DataTable GetDataTable(string sql)
    {
        SqlConnection baglan = this.baglan();
        SqlDataAdapter adapter = new SqlDataAdapter(sql, baglan);
        DataTable dt = new DataTable();

        try
        {
            adapter.Fill(dt);

        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message + " (" + sql + ")");
        }
        finally
        {
            adapter.Dispose();
            baglan.Close();
        }
        return dt;
    }

    //Datasete veri çekme
    public DataSet GetDataSet(string sql)
    {
        SqlConnection baglan = this.baglan();
        SqlDataAdapter adapter = new SqlDataAdapter(sql, baglan);
        DataSet ds = new DataSet();
        try
        {
            adapter.Fill(ds);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message + " (" + sql + ")");
        }
        finally
        {
            ds.Dispose();
            adapter.Dispose();
            baglan.Close();
        }
        return ds;
    }
 
}
