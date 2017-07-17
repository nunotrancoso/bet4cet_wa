/*
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
	public enum b4c_lang : int { pt_pt, en_us };
	public enum b4c_text : int { username, password, login, register, resetpass }
	public static class b4c_intl
	{
		public static readonly string[,] site_trans;
		static b4c_intl()
		{
			int langs = Enum.GetNames(typeof(b4c_lang)).Length;
			int texts = Enum.GetNames(typeof(b4c_text)).Length;
			site_trans = new string[langs, texts];
			// Username
			site_trans[(int)b4c_lang.pt_pt, (int)b4c_text.login] = "Username (email)";
			site_trans[(int)b4c_lang.en_us, (int)b4c_text.login] = "Utilizador (email)";
			// Password
			site_trans[(int)b4c_lang.pt_pt, (int)b4c_text.login] = "Password";
			site_trans[(int)b4c_lang.en_us, (int)b4c_text.login] = "Password";
			// Login
			site_trans[(int)b4c_lang.pt_pt, (int)b4c_text.login] = "Login";
			site_trans[(int)b4c_lang.en_us, (int)b4c_text.login] = "Login";
			// Login
			site_trans[(int)b4c_lang.pt_pt, (int)b4c_text.login] = "Login";
			site_trans[(int)b4c_lang.en_us, (int)b4c_text.login] = "Login";
			// Register
			site_trans[(int)b4c_lang.pt_pt, (int)b4c_text.register] = "Registar";
			site_trans[(int)b4c_lang.en_us, (int)b4c_text.register] = "Register";
		}
	}
}