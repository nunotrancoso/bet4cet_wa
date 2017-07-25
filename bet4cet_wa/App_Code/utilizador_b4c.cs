using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

namespace b4c_classes
{
	public class utilizador_b4c
	{
		private dbdata_utilizador_b4c _user; private b4c_message _message;
		private string _email, _pswd;
		//
		public long Message_Res	{ get {	return _message.msg_res; } set { _message.msg_res = value; } }
		public long Message_ErrNum { get { return _message.msg_errnum; } set { _message.msg_errnum = value; } }
		public string Message_ErrMsg { get { return _message.msg_errmsg; } set { _message.msg_errmsg = value; } }
		//
		public utilizador_b4c(string email, string pswd)
		{ _user = new dbdata_utilizador_b4c(); _message = new b4c_message(); _email = email;_pswd = pswd;}
		//
		public bool LoginUtilizador(string email, string pswd)
		{
			// Standard b4c message passing structure
			b4c_message msg = new b4c_message();
			// Pre-flight checks on data
			if (!(stc_util_b4c.IsValidEmail(_email)))
			{ // We can't do this check on SQL server side, so we MUST prevent invalid emails HERE
				_message.msg_res = -1; _message.msg_errnum = -2; _message.msg_errmsg = "Email not valid!"; return false;
			}
			else
			{
				if (string.IsNullOrEmpty(_email)) { _message.msg_res = -1; _message.msg_errnum = -2; _message.msg_errmsg = "Email is empty!"; return false; }
				else
				{
					if (_email.Substring(_email.Length - 13, 13) != "@facebook.com")
					{ // we need pswd if not coming from FB!
						if (string.IsNullOrEmpty(_pswd))
						{ _message.msg_res = -1; _message.msg_errnum = -3; _message.msg_errmsg = "Password is empty!"; return false; }
						else
						{ // Stored password is the MD5 of email + the received md5 hash of the password
							_pswd = security_b4c_md5.StringToMD5(_email+_pswd);
						}
					}
					else
					{ // coming from FB, "make" the password
						string _pswd = security_b4c_md5.StringToMD5(_email);
					}
				}
			}
			// We have a email and a password, so, proceed to try and get a user out of it
			// We can assume user exists because the page MUST have already checked it

			// SQL calls to the stored Procedures
			try
			{
				// Are the Login Credentials right?
				SqlConnection sqlcon = new SqlConnection(b4c_global.ConnectionString);
				SqlCommand sqlcmd = new SqlCommand("LoginUtilizador", sqlcon);
				sqlcmd.CommandType = CommandType.StoredProcedure;
				sqlcmd.Parameters.Add("@email", SqlDbType.VarChar, 128).Value = _email;
				sqlcmd.Parameters.Add("@pswd", SqlDbType.VarChar, 32).Value = _pswd;
				sqlcmd.Parameters.Add("@res", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errnum", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errmsg", SqlDbType.VarChar, 192).Direction = ParameterDirection.Output;
				sqlcon.Open();
				sqlcmd.ExecuteNonQuery();
				_message.msg_res = Convert.ToInt64(sqlcmd.Parameters["@res"].Value);
				_message.msg_errnum = Convert.ToInt64(sqlcmd.Parameters["@sql_errnum"].Value);
				_message.msg_errmsg = (sqlcmd.Parameters["@sql_errmsg"].Value).ToString();
				sqlcon.Close();
				return true;
			}
			catch (Exception e)
			{
				// If we got here, something happend but we don't know exactly WHAT
				_message.msg_res = -1; _message.msg_errnum = -1; _message.msg_errmsg = "Unspecified error has occurred!";
				return false;
			}
		}
		public bool VerificarUtilizadorEmail()
		{
			// Pre-flight checks on data
			if (!(stc_util_b4c.IsValidEmail(_email)))
			{ _message.msg_res = -1; _message.msg_errnum = -2; _message.msg_errmsg = "Email inválido."; return false; }
			else
			{
				if (string.IsNullOrEmpty(_email))
				{ _message.msg_res = -1; _message.msg_errnum = -2; _message.msg_errmsg = "Email vazio."; return false; }
			}
			// SQL calls to the stored Procedures
			try
			{
				// Does user exist?
				SqlConnection sqlcon = new SqlConnection(b4c_global.ConnectionString);
				SqlCommand sqlcmd = new SqlCommand("VerificarUtilizadorEmail", sqlcon);
				sqlcmd.CommandType = CommandType.StoredProcedure;
				sqlcmd.Parameters.Add("@email", SqlDbType.VarChar, 128).Value = _email;
				sqlcmd.Parameters.Add("@res", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errnum", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errmsg", SqlDbType.VarChar, 192).Direction = ParameterDirection.Output;
				sqlcon.Open();
				sqlcmd.ExecuteNonQuery();
				_message.msg_res = Convert.ToInt64(sqlcmd.Parameters["@res"].Value);
				_message.msg_errnum = Convert.ToInt64(sqlcmd.Parameters["@sql_errnum"].Value);
				_message.msg_errmsg = (sqlcmd.Parameters["@sql_errmsg"].Value).ToString();
				sqlcon.Close();
				return true;
			}
			catch (Exception e)
			{
				// If we got here, something happend but we don't know exactly WHAT
				_message.msg_res = -1; _message.msg_errnum = -1; _message.msg_errmsg = "Unspecified error has occurred!";
				return false;
			}
		}
	}
}