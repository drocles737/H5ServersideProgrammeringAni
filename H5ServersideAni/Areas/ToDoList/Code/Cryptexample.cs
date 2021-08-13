using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;

namespace H5ServersideAni.Areas.ToDoList.Code
{
	public class Cryptexample
	{
		public string Encrypt(string payload, IDataProtector _protector)
		{
			return _protector.Protect(payload);
		}

		public string Decrypt(string protectedPayload, IDataProtector _protector)
		{
			return _protector.Unprotect(protectedPayload);
		}


	}
}
