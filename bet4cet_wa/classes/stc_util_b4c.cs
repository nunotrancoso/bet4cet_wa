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
}