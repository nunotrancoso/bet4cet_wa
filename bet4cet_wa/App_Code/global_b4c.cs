﻿/*
* This is a personal academic project. Dear PVS-Studio, please check it.
* PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

/// <summary>
/// Summary description for global_b4c
/// </summary>
namespace b4c_classes
{
	public static class b4c_global
	{
		public static readonly string site_name = "Bet 4 Cet";
		public static readonly string site_version = "0";
		public static readonly string site_revision = "1";
		public static readonly string site_title = site_name + " " + site_version + "." + site_revision;
		public static readonly string ConnectionString = "Data Source=mssql6.gear.host;Initial Catalog=bet4cet;User id=bet4cet;Password=An6ZhWCK_-Uq;";
	}
	public class b4c_message
	{
		public long msg_res;
		public long msg_errnum;
		public string msg_errmsg;
	}
}

