using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class AddItemCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                AllCategories();
            if (Convert.ToInt16(Request.QueryString["CategoryID"]) != 0)
            {
                DataTable dtCategory = LogicKernal.ItemCategory.GetItemCategoryByID(Convert.ToInt16(Request.QueryString["CategoryID"]));
                txtname.Text = dtCategory.Rows[0]["CategoryName"].ToString();
                TxtRemarks.Text = dtCategory.Rows[0]["Remarks"].ToString();
                
                imgCategory.ImageUrl = dtCategory.Rows[0]["CategoryImage"].ToString();
                chkEnabled.Checked = Convert.ToBoolean(dtCategory.Rows[0]["IsEnabled"]);

                if (Convert.ToInt16(dtCategory.Rows[0]["ParentCategoryID"]) != 0)
                    ddlCategories.SelectedValue = dtCategory.Rows[0]["ParentCategoryID"].ToString();
                else
                    chkMaster.Checked = true;

            }

        }

        public void AllCategories()
        {
            DataTable DtCategory = LogicKernal.ItemCategory.GetAllItemCategory();
            if (DtCategory.Rows.Count > 0)
            { 
                ddlCategories.DataSource = DtCategory;
                ddlCategories.DataBind();
                ddlCategories.DataTextField = "CategoryName";
                ddlCategories.DataValueField = "CategoryID";
                ddlCategories.DataBind();
             }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileImage.HasFile)
            {
                string file_path = Server.MapPath("CustomerImages") + "/" + fileImage.FileName;
                fileImage.SaveAs(file_path);
                imgCategory.ImageUrl = "CustomerImages//" + fileImage.FileName;

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BusinessEntities.ItemCategory objCategory = new BusinessEntities.ItemCategory();
            if (Convert.ToInt16(Request.QueryString["CategoryID"]) != 0)
            {
                objCategory.CategoryID = Convert.ToInt16(Request.QueryString["CategoryID"]);
                DataTable dtCategory = LogicKernal.ItemCategory.GetItemCategoryByID(Convert.ToInt16(Request.QueryString["CategoryID"]));
                objCategory.DateCreated =Convert.ToDateTime(dtCategory.Rows[0]["DateCreated"]);
            }
            else
            {
                objCategory.CategoryID = 0;
                objCategory.DateCreated = System.DateTime.Now;
            }
               
            objCategory.CategoryName = txtname.Text;
            objCategory.CategoryImage = imgCategory.ImageUrl;
            
            if (chkMaster.Checked == true)
                objCategory.ParentCategoryID =0;
            else
                objCategory.ParentCategoryID = Convert.ToInt32(ddlCategories.SelectedValue);

            objCategory.IsEnabled = chkEnabled.Checked;
            objCategory.AdminID = Convert.ToInt32(Session["AdminID"]);
            objCategory.Remarks = TxtRemarks.Text;
            if (LogicKernal.ItemCategory.InsertUpdateItemCategory(objCategory).Rows.Count > 0)
           
                Response.Redirect("AdminDefault.aspx");
            
            else
                lblerror.Text = "Cannot SignUp";

        }
    }
}