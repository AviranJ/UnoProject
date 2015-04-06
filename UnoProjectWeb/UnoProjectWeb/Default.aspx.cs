using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace UnoProjectWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string login = TextBoxUserName.Text;
            string password = TextBoxPassword.Text;

            string strSql = @"
                               SELECT * FROM USERS U WHERE U.LOGIN = @LOGIN AND PASSWORD=@PASSWORD";
            DataTable dt = DB.ExecuteSelect("SYSTEM_USERS", strSql, new SqlParameter[] { new SqlParameter("@LOGIN", login), new SqlParameter("@PASSWORD", password) });
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("Play.aspx");
            }
            else
            {
            }

        
        }

        protected void ButtonSignup_Click(object sender, EventArgs e)
        {
            Page.Validate("Signup");
            if (Page.IsValid)
            {
                string login = TextBoxUserName.Text;
                string password = TextBoxPassword.Text;

                string cmdText = @"
				        INSERT INTO USERS
					        (LOGIN,PASSWORD)
				        VALUES (@LOGIN, @PASSWORD) ";
                int sign = DB.ExecuteNonQuery(cmdText, new SqlParameter[] { new SqlParameter("@LOGIN", login), new SqlParameter("@PASSWORD", password) });
                if (sign > 0)
                {
                    Response.Redirect("Play.aspx");
                }
            }


        }

        protected void CustomValidatorButtonLogin(object source, ServerValidateEventArgs args)
        {
            string login = TextBoxUserName.Text;
            string password = TextBoxPassword.Text;

            string strSql = @"
                               SELECT * FROM USERS U WHERE U.LOGIN = @LOGIN AND PASSWORD=@PASSWORD";
            DataTable dt = DB.ExecuteSelect("SYSTEM_USERS", strSql, new SqlParameter[] { new SqlParameter("@LOGIN", login), new SqlParameter("@PASSWORD", password) });
            if (dt.Rows.Count > 0)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }

        }
        protected void CustomValidatorButtonSignUp(object source, ServerValidateEventArgs args)
        
        {
            RequiredFieldValidator1.IsValid = false;
            
            string login = TextBoxUserName.Text;
            if (login.Equals(""))
                RequiredFieldValidator1.IsValid = false;
            else
                RequiredFieldValidator1.IsValid = true;

            string password = TextBoxPassword.Text;
            if (password.Equals(""))
                RequiredFieldValidator2.IsValid = false;
            else
                RequiredFieldValidator2.IsValid = true;

            if (!login.Equals("") && !password.Equals(""))
            {
                string strSql = @"
                               SELECT * FROM USERS U WHERE U.LOGIN = @LOGIN";
                DataTable dt = DB.ExecuteSelect("SYSTEM_USERS", strSql, new SqlParameter[] { new SqlParameter("@LOGIN", login) });

                if (dt.Rows.Count > 0)
                {
                    args.IsValid = false;
                }
                else args.IsValid = true;
            }

        }


    }
}
