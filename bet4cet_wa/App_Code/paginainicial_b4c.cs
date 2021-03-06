﻿/*
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
	public class paginainicial_b4c : IErrorMessage
	{
		//
		private b4c_message _message;
		public long Message_Res { get { return _message.msg_res; } set { _message.msg_res = value; } }
		public long Message_ErrNum { get { return _message.msg_errnum; } set { _message.msg_errnum = value; } }
		public string Message_ErrMsg { get { return _message.msg_errmsg; } set { _message.msg_errmsg = value; } }
		//
		private List<dbdata_paginainicial_b4c> _paginainicial;
		//
		public paginainicial_b4c()
		{
			_message = new b4c_message();
		}
		//
		public void PaginaInicial_Carregar()
		{
			// SQL calls to the stored Procedures
			_paginainicial = new List<dbdata_paginainicial_b4c>();
			try
			{
				// Are the Login Credentials right?
				SqlConnection sqlcon = new SqlConnection(b4c_global.ConnectionString);
				SqlCommand sqlcmd = new SqlCommand("PaginaInicial_Listar", sqlcon);
				sqlcmd.CommandType = CommandType.StoredProcedure;
				sqlcmd.Parameters.Add("@res", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errnum", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errmsg", SqlDbType.VarChar, 192).Direction = ParameterDirection.Output;
				sqlcon.Open();
				SqlDataReader sqldr = sqlcmd.ExecuteReader();
				// sqlcmd.ExecuteNonQuery();
				while (sqldr.Read())
				{
					dbdata_paginainicial_b4c _temppi = new dbdata_paginainicial_b4c();
					_temppi.Ipk = Convert.ToInt64(sqldr["ipk"]);
					_temppi.Gid = Convert.ToInt64(sqldr["gid"]);
					_temppi.PaginaInicial = sqldr["paginainicial"].ToString();
					_paginainicial.Add(_temppi);
				}
				sqlcon.Close();
				Message_Res = Convert.ToInt64(sqlcmd.Parameters["@res"].Value);
				Message_ErrNum = Convert.ToInt64(sqlcmd.Parameters["@sql_errnum"].Value);
				Message_ErrMsg = (sqlcmd.Parameters["@sql_errmsg"].Value).ToString();
			}
			catch (Exception e)
			{
				// If we got here, something happend but we don't know exactly WHAT
				Message_Res = -1; Message_ErrNum = -1; Message_ErrMsg = "Unspecified error has occurred!";
			}
		}
		//
		public List<dbdata_paginainicial_b4c> PaginaInicial_Listar()
		{
			// Shallow copy !!!
			List<dbdata_paginainicial_b4c> _returnlist = new List<dbdata_paginainicial_b4c>(_paginainicial);
			return _returnlist;
		}
		//
		public string PaginaInicial_EncontrarPorGid(long gid)
		{
			dbdata_paginainicial_b4c _temp = _paginainicial.Find(x => x.Gid == gid);
			return _temp.PaginaInicial;
		}
		//
	}
}