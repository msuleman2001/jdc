using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing.Imaging;

namespace Laundry
{
    public partial class CustomerMobile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int action = Convert.ToInt32(Request.QueryString["Action"]);
            switch (action)
            {
                case 1:
                    //insert or edit 
                    string str = Request.QueryString.ToString();
                    Response.Write(str);
                    BusinessEntities.CustomerProfile objCustomer = new BusinessEntities.CustomerProfile();
                    objCustomer.CustomerEmail = Request.QueryString["UserEmail"];
                    objCustomer.CustomerName = Request.QueryString["UserName"];
                    objCustomer.CustomerPhoneNo = Request.QueryString["UserContect"];
                    objCustomer.CustomerAddress = Request.QueryString["UserAddress"];
                    objCustomer.CustomerPassword = Request.QueryString["UserPassword"];
                    objCustomer.CustomerImage = "";
                    objCustomer.DateJoind = System.DateTime.Now;
                    objCustomer.CustomerRemarks = "";

                    if (LogicKernal.CustomerProfile.InsertUpdateCustomerProfile(objCustomer).Rows.Count > 0)
                        Response.Write("Added");
                    else
                        Response.Write("Error");
                    break;
                case 2:
                    //upload image
                    if (Request["image"] != null)
                    {
                        string data = Request["image"].ToString();
                        string name = "123wer";
                        SaveImage(data, name);
                        Response.Write("Image Uploaded");
                    }
                    break;
                case 3:
                    //select by id
                    break;
                case 4:
                    //delete
                    break;
                case 5:
                    string user_email = Request.QueryString["UserEmail"];
                    string user_password = Request.QueryString["UserPassword"];
                    int user_id = LogicKernal.CustomerProfile.Login(user_email, user_password);
                    Response.Write("{\"UserID\": \"" + user_id.ToString() + "\"}");
                    break;
            }
        }

        public System.Drawing.Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image

            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
        public bool SaveImage(string ImgStr, string ImgName)
        {
            String path = Server.MapPath("\\images"); //Path

            //Check if directory exist
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }

            string imageName = ImgName.ToString() + ".jpg";

            //set the image path
            string imgPath = Path.Combine(path, imageName);

            byte[] imageBytes = Convert.FromBase64String(ImgStr);

            File.WriteAllBytes(imgPath, imageBytes);

            return true;
        }
    }
}