using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class AddVehicle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Agents();
                Driver();
                if (Convert.ToInt16(Request.QueryString["VehicleID"]) != 0)
                {
                    DataTable dtVehicle = LogicKernal.Vehicles.GetVehiclesByID(Convert.ToInt16(Request.QueryString["VehicleID"]));
                    ddlAgent.SelectedValue = dtVehicle.Rows[0]["AgentID"].ToString();
                    ddlDriver.SelectedValue = dtVehicle.Rows[0]["DriverID"].ToString();
                    txtMake.Text = dtVehicle.Rows[0]["VehicleMake"].ToString();
                    txtRegNO.Text = dtVehicle.Rows[0]["VehicleRegNO"].ToString();
                    TxtRemarks.Text = dtVehicle.Rows[0]["Remarks"].ToString();
                    imgvehicle.ImageUrl = dtVehicle.Rows[0]["VehicalImage"].ToString();
                    chkEnabled.Checked = Convert.ToBoolean(dtVehicle.Rows[0]["IsEnabled"]);

                }

             }
        }
        public void Agents()
        {
            DataTable dtAgent = LogicKernal.LaundryAgent.GetAllLaundryAgent();
            ddlAgent.DataSource = dtAgent;
            ddlAgent.DataBind();
            ddlAgent.DataTextField = "AgentName";
            ddlAgent.DataValueField = "AgentID";
            ddlAgent.DataBind();

        }

        public void Driver()
        {
            DataTable dtDriver = LogicKernal.LaundryDrivers.GetAllLaundryDrivers();
            ddlDriver.DataSource = dtDriver;
            ddlDriver.DataBind();
            ddlDriver.DataTextField = "DriverName";
            ddlDriver.DataValueField = "DriverID";
            ddlDriver.DataBind();

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
          
            if (fileImage.HasFile)
            {
                string file_path = Server.MapPath("CustomerImages") + "/" + fileImage.FileName;
                fileImage.SaveAs(file_path);
                imgvehicle.ImageUrl = "CustomerImages//" + fileImage.FileName;
            
        }
    }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BusinessEntities.Vehicles objVehicle = new BusinessEntities.Vehicles();
            if (Convert.ToInt16(Request.QueryString["VehicleID"]) != 0)
            {
                objVehicle.VehicleID = Convert.ToInt16(Request.QueryString["VehicleID"]);
            }
            else
                objVehicle.VehicleID = 0;
            objVehicle.VehicleMake = txtMake.Text;
            objVehicle.VehicleRegNO = txtRegNO.Text;
            objVehicle.VehicleColor = "N/A";
            objVehicle.VehicalImage = imgvehicle.ImageUrl;
            objVehicle.AgentID =Convert.ToInt32( ddlAgent.SelectedValue);
            if (chkDriver.Checked == true)
            {
                objVehicle.DriverID = 0;
            }
            else
                objVehicle.DriverID = Convert.ToInt32(ddlDriver.SelectedValue);

            objVehicle.AdminID = Convert.ToInt32(Session["AdminID"]);
            objVehicle.DateCreated = System.DateTime.Now;
            objVehicle.IsEnabled = chkEnabled.Checked;
            objVehicle.Remarks = TxtRemarks.Text;

            if (LogicKernal.Vehicles.InsertUpdateVehicles(objVehicle).Rows.Count > 0)
                Response.Redirect("AdminDefault.aspx");
            else
                lblerror.Text = "Try Again";

        }
    }
}