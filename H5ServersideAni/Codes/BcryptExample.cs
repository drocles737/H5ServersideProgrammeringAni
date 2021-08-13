using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using BCrypt.Net;

namespace H5ServersideAni.Codes
{
	public class BcryptExample
	{
		public string GetEncryptetText(string valueToEncrypt)
		{
			string encryptetText = BCrypt.Net.BCrypt.HashPassword(valueToEncrypt);

			return encryptetText;
		}

		public string GetDecryptedText(string valueofDecrypt, string correctHash)
		{

			string verified = "";

			var decryptedText = BCrypt.Net.BCrypt.Verify(valueofDecrypt, correctHash);

			if(decryptedText == true)
			{
				verified = "sandt";
				return verified;
			}
			else
			{
				verified = "false";
				return verified;
			}
		}
	}
}
