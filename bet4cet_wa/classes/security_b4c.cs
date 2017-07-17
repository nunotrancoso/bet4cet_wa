/*
* This is a personal academic project. Dear PVS-Studio, please check it.
* PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// Summary description for security_b4c
/// </summary>
namespace b4c_classes
{
	public static class security_b4c_md5
	{
		public static string StringToMD5(string input)
		{
			MD5 md5 = MD5.Create();
			byte[] inputBytes = Encoding.ASCII.GetBytes(input);
			byte[] hash = md5.ComputeHash(inputBytes);
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < hash.Length; i++)
			{ sb.Append(hash[i].ToString("x2")); }
			return sb.ToString();
		}
	}
}