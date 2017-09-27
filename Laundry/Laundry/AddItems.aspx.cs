using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class AddItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AllCategories();
                if (Convert.ToInt16(Request.QueryString["ItemID"]) != 0)
                {
                    DataTable dtItems = LogicKernal.Items.GetItemsByID(Convert.ToInt16(Request.QueryString["ItemID"]));
                    txtname.Text = dtItems.Rows[0]["ItemName"].ToString();
                    txtPrice.Text = dtItems.Rows[0]["UnitPrice"].ToString();
                    imgItem.ImageUrl = dtItems.Rows[0]["ItemImage"].ToString();
                    TxtRemarks.Text = dtItems.Rows[0]["Remarks"].ToString();
                    chkEnabled.Checked = Convert.ToBoolean(dtItems.Rows[0]["IsEnabled"]);
                    ddlCategory.SelectedValue = dtItems.Rows[0]["CategoryID"].ToString();
                }
            }

         }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileImage.HasFile)
            {
                string file_path = Server.MapPath("CustomerImages") + "/" + fileImage.FileName;
                fileImage.SaveAs(file_path);
                imgItem.ImageUrl = "CustomerImages//" + fileImage.FileName;

            }
        }

        public void AllCategories()
        {
            DataTable DtCategory = LogicKernal.ItemCategory.GetAllItemCategory();
            if (DtCategory.Rows.Count > 0)
            {
                ddlCategory.DataSource = DtCategory;
                ddlCategory.DataBind();
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BusinessEntities.Items objItem = new BusinessEntities.Items();
            if (Convert.ToInt16(Request.QueryString["ItemID"]) != 0)
            {
                DataTable dtItems = LogicKernal.Items.GetItemsByID(Convert.ToInt16(Request.QueryString["ItemID"]));
                objItem.ItemID = Convert.ToInt16(Request.QueryString["ItemID"]);
                objItem.DateCreated = Convert.ToDateTime(dtItems.Rows[0]["DateCreated"]);
            }
            else
            {
                objItem.ItemID = 0;
                objItem.DateCreated = System.DateTime.Now;
            }
               
            objItem.ItemName = txtname.Text;
            objItem.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
            objItem.UnitPrice = txtPrice.Text;
            objItem.ItemImage = imgItem.ImageUrl;
            
            objItem.AdminID = Convert.ToInt32(Session["AdminID"]);
            objItem.IsEnabled = chkEnabled.Checked;
            objItem.Remarks = TxtRemarks.Text;
            if (LogicKernal.Items.InsertUpdateItems(objItem).Rows.Count > 0)

                Response.Redirect("AdminDefault.aspx");

            else
                lblerror.Text = "Cannot Add";
        }
    }
}