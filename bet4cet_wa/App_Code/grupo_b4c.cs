/*
* This is a personal academic project. Dear PVS-Studio, please check it.
* PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

namespace bet4cet_wa
{
	public class grupos_b4c : IErrorMessage
	{
		//
		private b4c_message _message;
		public long Message_Res { get { return _message.msg_res; } set { _message.msg_res = value; } }
		public long Message_ErrNum { get { return _message.msg_errnum; } set { _message.msg_errnum = value; } }
		public string Message_ErrMsg { get { return _message.msg_errmsg; } set { _message.msg_errmsg = value; } }
		//
		public grupos_b4c()
		{
			_message = new b4c_message();
		}
		public List<dbdata_grupo_b4c> ListarGrupos()
		{
			//
			List<dbdata_grupo_b4c> _temp = new List<dbdata_grupo_b4c>();
			try
			{
				// SQL calls to the stored Procedures
				SqlConnection sqlcon = new SqlConnection(b4c_global.ConnectionString);
				SqlCommand sqlcmd = new SqlCommand("Grupo_Listar", sqlcon);
				sqlcmd.CommandType = CommandType.StoredProcedure;
				sqlcmd.Parameters.Add("@res", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errnum", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errmsg", SqlDbType.VarChar, 192).Direction = ParameterDirection.Output;
				sqlcon.Open();
				SqlDataReader sqldr = sqlcmd.ExecuteReader();
				// sqlcmd.ExecuteNonQuery();
				while (sqldr.Read())
				{
					/* [ipk],[idgrupo],[nome],[datacriacao],[idadmin],[activo] */
					dbdata_grupo_b4c _tempru = new dbdata_grupo_b4c();
					_tempru.Ipk = Convert.ToInt64(sqldr["ipk"]);
					_tempru.IdGrupo = Convert.ToInt64(sqldr["idgrupo"]);
					_tempru.NomeGrupo = sqldr["nome"].ToString();
					_tempru.DataCriacao = Convert.ToDateTime(sqldr["datacriacao"]);
					_tempru.IdAdmin = Convert.ToInt64(sqldr["idadmin"]);
					_tempru.Activo = Convert.ToInt32(sqldr["activo"]);
					_temp.Add(_tempru);
				}
				sqlcon.Close();
				Message_Res = Convert.ToInt64(sqlcmd.Parameters["@res"].Value);
				Message_ErrNum = Convert.ToInt64(sqlcmd.Parameters["@sql_errnum"].Value);
				Message_ErrMsg = (sqlcmd.Parameters["@sql_errmsg"].Value).ToString();
			}
			catch (Exception e)
			{
				// Output the Exception
				Debug.WriteLine("Listar Grupos : Exception " + e.Message);
				// If we got here, something happend but we don't know exactly WHAT
				Message_Res = -1; Message_ErrNum = -1; Message_ErrMsg = "Unspecified error has occurred!"; _temp = null;
			}
			return _temp;
		}
	}
}