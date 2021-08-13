using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using H5ServersideAni.Models;
using System.Data;
using Microsoft.Extensions.DependencyInjection;
//using H5ServersideAni.Areas.ToDoList.Models;

namespace H5ServersideAni.Codes
{

	public class Sqlqueriess
	{
	

		SqlConnection con = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=H5ServersideAni;Trusted_Connection=True;MultipleActiveResultSets=true");
		//Infomodel info = new();

		public async Task GetId(string UserID, IServiceProvider _serviceProvider)
		{
			var UserManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
			IdentityUser identityuser = await UserManager.FindByIdAsync(UserID);

			//int id = Convert.ToInt32(identityuser);

			//await UserManager.

			//return UserID;

		}
		public void Insertdata()
		{
			//SqlCommand cmd = new SqlCommand(null, con);
			//cmd.CommandType = CommandType.StoredProcedure;

			//// skal finde userid først
			//string StrCurrentUserId;

			//con.Open();
			//cmd.CommandText = "INSERT INTO info(UserID, Title, Beskrivelse) VALUES(@UserID, @Title, @Beskrivlese)";
			//cmd.Parameters.AddWithValue("@UserID", info.UserName);
			//cmd.Parameters.AddWithValue("@Title", info.Titel);
			//cmd.Parameters.AddWithValue("@Beskrivelse", info.Beskrivelse);
			//cmd.ExecuteNonQuery();
			//con.Close();
		}

		public void displaydata()
		{
			//SqlCommand cmd = new SqlCommand(null, con);
			//cmd.CommandType = CommandType.StoredProcedure;

			//string strCurrentId;

			//con.Open();
			//cmd.CommandText = "Select from where info (UserID, Title, Beskrivelse) values(@UserID, @Title, @Beskrivlese";
			//cmd.Parameters.AddWithValue("@UserID", info.UserName);
			//cmd.Parameters.AddWithValue("@Title", info.Titel);
			//cmd.Parameters.AddWithValue("@Beskrivelse", info.Beskrivelse);
			//cmd.ExecuteNonQuery();
			//con.Close();

		}
	}
}
