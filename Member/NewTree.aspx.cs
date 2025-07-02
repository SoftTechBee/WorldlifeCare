using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TripleITConnection;
using System.Data;
using Newtonsoft.Json;
using System.Web.Services;
using System.Web.Script.Serialization;
public partial class User_Default : System.Web.UI.Page
{
    clsConnection objCon = new clsConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (SessionData.Get<string>("newuser") != null)
            {
                LoadTree(SessionData.Get<string>("newuser"));
            }
           
        }
    }

    private void LoadTree(string username)
    {
        try {
            string sql = "exec [GetBinaryTreeView] '" + username + "','A' ";
            DataTable dt = objCon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                   //Level0
                    Img1.Src = "../TreeCode/TreeImg/"+ dt.Rows[0]["Img"].ToString();
                    LinkButton1.Text = dt.Rows[0]["UserName"].ToString() + "<br/>" + dt.Rows[0]["Name"].ToString();
                hnduserid1.Value = dt.Rows[0]["UserName"].ToString();
                //Level1
                Img2.Src = "../TreeCode/TreeImg/" + dt.Rows[1]["Img"].ToString();
                LinkButton2.Text = dt.Rows[1]["UserName"].ToString() + "<br/>" + dt.Rows[1]["Name"].ToString();
                hnduserid2.Value = dt.Rows[1]["UserName"].ToString();

                Img3.Src = "../TreeCode/TreeImg/" + dt.Rows[2]["Img"].ToString();
                LinkButton3.Text = dt.Rows[2]["UserName"].ToString() + "<br/>" + dt.Rows[2]["Name"].ToString();
                hnduserid3.Value = dt.Rows[2]["UserName"].ToString();
                //Level2
                Img4.Src = "../TreeCode/TreeImg/" + dt.Rows[3]["Img"].ToString();
                LinkButton4.Text = dt.Rows[3]["UserName"].ToString()+"<br/>"+ dt.Rows[3]["Name"].ToString() ;
                hnduserid4.Value = dt.Rows[3]["UserName"].ToString();

                Img5.Src = "../TreeCode/TreeImg/" + dt.Rows[4]["Img"].ToString();
                LinkButton5.Text = dt.Rows[4]["UserName"].ToString()+"<br/>"+ dt.Rows[4]["Name"].ToString() ;
                hnduserid5.Value = dt.Rows[4]["UserName"].ToString();

                Img6.Src = "../TreeCode/TreeImg/" + dt.Rows[5]["Img"].ToString();
                LinkButton6.Text = dt.Rows[5]["UserName"].ToString() + "<br/>" + dt.Rows[5]["Name"].ToString();
                hnduserid6.Value = dt.Rows[5]["UserName"].ToString();

                Img7.Src = "../TreeCode/TreeImg/" + dt.Rows[6]["Img"].ToString();
                LinkButton7.Text = dt.Rows[6]["UserName"].ToString() + "<br/>" + dt.Rows[6]["Name"].ToString();
                hnduserid7.Value = dt.Rows[6]["UserName"].ToString();

                //level3
                //Img8.Src = "../TreeCode/TreeImg/" + dt.Rows[7]["Img"].ToString();
                //LinkButton8.Text = dt.Rows[7]["Name"].ToString();
                //hnduserid8.Value = dt.Rows[7]["UserName"].ToString();

                //Img9.Src = "../TreeCode/TreeImg/" + dt.Rows[8]["Img"].ToString();
                //LinkButton9.Text = dt.Rows[8]["Name"].ToString();
                //hnduserid9.Value = dt.Rows[8]["UserName"].ToString();

                //Img10.Src = "../TreeCode/TreeImg/" + dt.Rows[9]["Img"].ToString();
                //LinkButton10.Text = dt.Rows[9]["Name"].ToString();
                //hnduserid10.Value = dt.Rows[9]["UserName"].ToString();

                //Img11.Src = "../TreeCode/TreeImg/" + dt.Rows[10]["Img"].ToString();
                //LinkButton11.Text = dt.Rows[10]["Name"].ToString();
                //hnduserid11.Value = dt.Rows[10]["UserName"].ToString();

                //Img12.Src = "../TreeCode/TreeImg/" + dt.Rows[11]["Img"].ToString();
                //LinkButton12.Text = dt.Rows[11]["Name"].ToString();
                //hnduserid12.Value = dt.Rows[11]["UserName"].ToString();

                //Img13.Src = "../TreeCode/TreeImg/" + dt.Rows[12]["Img"].ToString();
                //LinkButton13.Text = dt.Rows[12]["Name"].ToString();
                //hnduserid13.Value = dt.Rows[12]["UserName"].ToString();

                //Img14.Src = "../TreeCode/TreeImg/" + dt.Rows[13]["Img"].ToString();
                //LinkButton14.Text = dt.Rows[13]["Name"].ToString();
                //hnduserid14.Value = dt.Rows[13]["UserName"].ToString();

                //Img15.Src = "../TreeCode/TreeImg/" + dt.Rows[14]["Img"].ToString();
                //LinkButton15.Text = dt.Rows[14]["Name"].ToString();
                //hnduserid15.Value = dt.Rows[14]["UserName"].ToString();
            }



        }
        catch (Exception ex)
        { }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LoadTree(hnduserid1.Value);
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        LoadTree(hnduserid2.Value);
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        LoadTree(hnduserid3.Value);
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        LoadTree(hnduserid4.Value);
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        LoadTree(hnduserid5.Value);

    }

    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        LoadTree(hnduserid6.Value);
    }

    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        LoadTree(hnduserid7.Value);
    }

    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        LoadTree(hnduserid8.Value);

    }

    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        LoadTree(hnduserid9.Value);

    }

    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        LoadTree(hnduserid10.Value);
    }

    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        LoadTree(hnduserid11.Value);
    }

    protected void LinkButton12_Click(object sender, EventArgs e)
    {
        LoadTree(hnduserid12.Value);

    }

    protected void LinkButton13_Click(object sender, EventArgs e)
    {
        LoadTree(hnduserid13.Value);
    }

    protected void LinkButton14_Click(object sender, EventArgs e)
    {
        LoadTree(hnduserid14.Value);
    }

    protected void LinkButton15_Click(object sender, EventArgs e)
    {
        LoadTree(hnduserid15.Value);
    }

    [WebMethod]
    public static string TreeDetails(string UserId)
    {
        //try
        //{
            //string UserId = "CN723631";
            
            clsConnection objCon = new clsConnection();
            string sql = "exec GetBinaryTreeView '" + UserId + "','D' ";
            DataTable table = objCon.ReturnDataTableSql(sql);
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);

        //}
        //catch (Exception ex)
        //{
        //    System.Diagnostics.Debug.WriteLine(ex.Message);
        //    return null;
        //}

    }


    protected void btnsearch_Click(object sender, EventArgs e)
    {
        LoadTree(txtsearch.Text);
    }
}