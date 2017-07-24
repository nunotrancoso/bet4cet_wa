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

/// <summary>
/// Summary description for SendMail
/// </summary>
namespace b4c_classes
{
	static public class b4c_SendMail
	{
		private static string mailhost;
		private static int mailhostport;
		public static readonly string mailhostuser;
		private static string mailhostpass;
		private static bool mailhostssl;

		static b4c_SendMail()
		{
			// Na versão final é para substituir por dados lidos de
			// System.Configuration.ConfigurationManager.AppSettings["key"].ToString()
			mailhost = "smtp.sapo.pt";
			mailhostport = 587;
			mailhostuser = "njte2017@sapo.pt";
			mailhostpass = "cet23psw12_";
			mailhostssl = true;
			/*
			string hostname = System.Configuration.ConfigurationManager.AppSettings["mailhost"].ToString();
			int hostport = int.Parse(System.Configuration.ConfigurationManager.AppSettings["mailhostport"].ToString());
			string username = System.Configuration.ConfigurationManager.AppSettings["mailhostuser"].ToString();
			string password = System.Configuration.ConfigurationManager.AppSettings["mailhostpass"].ToString();
			bool sslen;
			if (System.Configuration.ConfigurationManager.AppSettings["mailhostssl"].ToString() == "1")
			{ sslen = true; } else { sslen = false;	}
			*/
		}
		static public bool SendMailPub(string[] mailtolist, string subject, string body)
		{
			
			//Envia emails para duas contas, num form a serio um deles seria o proprio user
			return SendMailSMTP(mailhostuser, mailtolist, subject, body, mailhost, mailhostport, mailhostuser, mailhostpass, mailhostssl);
		}
		static private bool SendMailSMTP(string mailfrom, string[] mailto, string mailsubject, string mailbody, string hostname, int hostport, string username, string password, bool SSLEnable)
		{
			MailMessage m = new MailMessage();
			// if (m == null) { return false; }
			SmtpClient sc = new SmtpClient();
			// if (sc == null) { return false; }
			//
			if ((mailfrom == null) || (mailfrom == "")) { return false; }
			m.From = new MailAddress(mailfrom);
			if (mailto.Length < 1) { return false; }
			for (int c = 0; c < mailto.Length; c++)
			{
				m.To.Add(new MailAddress(mailto[c]));
			}
			if ((mailsubject == null) || (mailsubject == "")) { return false; }
			m.Subject = mailsubject;
			if ((mailbody == null) || (mailbody == "")) { return false; }
			m.Body = mailbody;
			if ((hostname == null) || (hostname == "")) { return false; }
			sc.Host = hostname;
			if (hostport < 0) { return false; }
			sc.Port = hostport;
			if ((username == null) || (username == "")) { return false; }
			if ((password == null) || (password == "")) { return false; }
			sc.Credentials = new System.Net.NetworkCredential(username, password);
			sc.EnableSsl = SSLEnable;
			//
			try
			{ sc.Send(m); return true; }
			catch (Exception ex)
			{
				Debug.WriteLine("Exception thrown in SendMailSMTP : " + ex.ToString());
				return false;
			}
		}
	}
}
