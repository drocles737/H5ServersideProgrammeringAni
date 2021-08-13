using H5ServersideAni.Codes;
using H5ServersideAni.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using H5ServersideAni.Areas.Identity.Codes;
using Microsoft.AspNetCore.DataProtection;
using H5ServersideAni.Areas.ToDoList.Code;
//using H5ServersideAni.Areas.ToDoList.Models;

namespace H5ServersideAni.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private readonly Class1 _class1;

		private readonly HashingExample _hashingexample;

		private readonly BcryptExample _BcryptExample;

		private readonly IServiceProvider _serviceprovider;

		private readonly myUserRoleHandler _myUserRoleHandler;

		private readonly IDataProtector _dataProtector;

		private readonly Cryptexample _cryptexample;

		private readonly Sqlqueriess _sqlqueries;

		public HomeController(ILogger<HomeController> logger, Class1 class1, HashingExample hashingexample, BcryptExample bcryptexample, IServiceProvider serviceprovider, myUserRoleHandler myUserrolehandler, IDataProtectionProvider dataProtector, Cryptexample cryptexample, Sqlqueriess sqlqueriess )
		{
			_logger = logger;
			_class1 = class1;
			_hashingexample = hashingexample;
			_BcryptExample = bcryptexample;
			_myUserRoleHandler = myUserrolehandler;
			_serviceprovider = serviceprovider;
			_cryptexample = cryptexample;
			_dataProtector = dataProtector.CreateProtector("H5ServerSideAni.HomeController.SecretKey");
			//H5ServerSideAni.HomeController.SecretKey
			_sqlqueries = sqlqueriess;
		}

		// requirement kommer fra policy 
		[Authorize("RequireAuthenticatedUser")]

		public async Task< IActionResult> Index()
		{
			//bruges til at gøre brugeren til admin
			//await _myUserRoleHandler.CreateRole("andreas.n737@gmail.com", "Admin", _serviceprovider);
			string myText1 = _class1.GetText();
			string myText2 = _class1.GetText();
			string txt = "Hello World";
			string txt2 = "nisse";
			string txt3 = "kartoffel";

			string myencryptedtext = _BcryptExample.GetEncryptetText(txt2);
			string myHashedText = _hashingexample.GetHashedText_MD5(txt);
			// txt2 kan udskrifte til at sandt eller falsk for at teste bcrypt
			string mydecryptedtext = _BcryptExample.GetDecryptedText(txt2, myencryptedtext);
			string myecryptedtext2 = _BcryptExample.GetEncryptetText(txt);

			string myEncryptText = _cryptexample.Encrypt(txt3, _dataProtector);
			string mydecryptText = _cryptexample.Decrypt(myEncryptText, _dataProtector);
			Indexmodels myModel = new Indexmodels() { Text1 = myHashedText, Text2 = myencryptedtext, Text3 = mydecryptedtext, Text4 = myecryptedtext2, Text5 = mydecryptText };
			return View(model: myModel);

			//return View();
		}

		[Authorize( Policy = "RequireAdminUser")]
		public async Task<IActionResult> Privacy()
		{

			//string UserId = await _sqlqueries.GetId("", _serviceprovider);
			string txt = "ID";

			//int UserID = _sqlqueries.GetId;
			//Infomodel myModel = new() { UserName = 1, Titel = "nisse i eventyr land", Beskrivelse = "den kan lide kartoffler" };

			return View();//model: myModel
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
