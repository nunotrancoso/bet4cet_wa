/*
* This is a personal academic project. Dear PVS-Studio, please check it.
* PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for util_b4c
/// </summary>
namespace b4c_classes
{
	public class stc_util_b4c
	{
		stc_util_b4c()
		{
			// static contructor
		}
		public static string GetPageName(System.Web.UI.Page page)
		{
			return Path.GetFileName(page.Server.MapPath(page.AppRelativeVirtualPath));
		}
		public static void AddToWebLog(List<string> weblog,string tolog)
		{
			weblog.Add(DateTime.Now.ToString() + " : " + tolog + "<br/>");
		}
		public static string WriteWebLog(List<string> weblog)
		{
			string tolog = "";
			if ((weblog!=null)&&(weblog.Count > 0)) { foreach (string s in weblog) { tolog += s; } }
			return tolog;
 		}
		public static bool IsValidEmail(string email)
		{
			try { var addr = new System.Net.Mail.MailAddress(email); return addr.Address == email; }
			catch { return false; }
		}
	}
}