using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Modelo.Comun
{
	public static class HashHelpers
	{
		public static string MD5(string word)
		{
			MD5 md5 = MD5CryptoServiceProvider.Create();
			ASCIIEncoding encoding = new ASCIIEncoding();
			byte[] stream = null;
			StringBuilder sb = new StringBuilder();
			stream = md5.ComputeHash(encoding.GetBytes(word));
			for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
			return sb.ToString();
		}
		public static string Token()
		{
			long i = 1;
			foreach (byte b in Guid.NewGuid().ToByteArray()) i *= ((int)b + 1);
			return MD5(string.Format("{0:x}", i - DateTime.Now.Ticks));
		}
		public static string Base64Encode(string word)
		{
			byte[] byt = System.Text.Encoding.UTF8.GetBytes(word);
			return Convert.ToBase64String(byt);
		}
		public static string Base64Decode(string word)
		{
			byte[] b = Convert.FromBase64String(word);
			return System.Text.Encoding.UTF8.GetString(b);
		}
		public static string SHA1(string str)
		{
			SHA1 sha1 = SHA1Managed.Create();
			ASCIIEncoding encoding = new ASCIIEncoding();
			byte[] stream = null;
			StringBuilder sb = new StringBuilder();
			stream = sha1.ComputeHash(encoding.GetBytes(str));
			for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
			return sb.ToString();
		}
		public static string SHA256(string str)
		{
			SHA256 sha256 = SHA256Managed.Create();
			ASCIIEncoding encoding = new ASCIIEncoding();
			byte[] stream = null;
			StringBuilder sb = new StringBuilder();
			stream = sha256.ComputeHash(encoding.GetBytes(str));
			for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
			return sb.ToString();
		}
		public static string SHA384(string str)
		{
			SHA384 sha384 = SHA384Managed.Create();
			ASCIIEncoding encoding = new ASCIIEncoding();
			byte[] stream = null;
			StringBuilder sb = new StringBuilder();
			stream = sha384.ComputeHash(encoding.GetBytes(str));
			for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
			return sb.ToString();
		}
		public static string SHA512(string str)
		{
			SHA512 sha512 = SHA512Managed.Create();
			ASCIIEncoding encoding = new ASCIIEncoding();
			byte[] stream = null;
			StringBuilder sb = new StringBuilder();
			stream = sha512.ComputeHash(encoding.GetBytes(str));
			for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
			return sb.ToString();
		}
		public static string Encrypt(string clearText)
		{
			string EncryptionKey = "MAKV2SPBNI99212";

			byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
			Aes encryptor = Aes.Create();
			Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 73, 118, 97, 110, 32, 77, 101, 100, 118, 101, 100, 101, 118 });
			encryptor.Key = pdb.GetBytes(32);
			encryptor.IV = pdb.GetBytes(16);
			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write);
			cs.Write(clearBytes, 0, clearBytes.Length);
			cs.Close();
			clearText = Convert.ToBase64String(ms.ToArray());
			return clearText;
		}
		public static string Decrypt(string cipherText)
		{
			string EncryptionKey = "MAKV2SPBNI99212";
			cipherText = cipherText.Replace(" ", "+");
			byte[] cipherBytes = Convert.FromBase64String(cipherText);
			Aes encryptor = Aes.Create();
			Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[]
			{73,118,97,110,32,77,101,100,118,101,100,101,118});
			encryptor.Key = pdb.GetBytes(32);
			encryptor.IV = pdb.GetBytes(16);
			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write);
			cs.Write(cipherBytes, 0, cipherBytes.Length);
			cs.Close();

			cipherText = Encoding.Unicode.GetString(ms.ToArray());
			return cipherText;
		}
	}
}
