using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace H5ServersideAni.Codes
{
	public class HashingExample
	{
		public string GetHashedText_MD5(string valueTohash)
		{
			byte[] valueAsBytes = ASCIIEncoding.ASCII.GetBytes(valueTohash);

			byte[] valueT = MD5.HashData(valueAsBytes);

			string HashedValueAsString = Convert.ToBase64String(valueT);

			return HashedValueAsString;
		}

	}
}
