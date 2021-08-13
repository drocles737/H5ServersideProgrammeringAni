using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace H5ServersideAni.Areas.Identity.Codes
{
	public class myUserRoleHandler
	{
		public async Task CreateRole(string id, string user, string role, IServiceProvider _serviceProvider)
		{
			var RoleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var UserManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

			await RoleManager.CreateAsync(new IdentityRole(role));

			IdentityResult roleResult;
			var userRoleCheck = await RoleManager.RoleExistsAsync(role);

			if (!userRoleCheck)
			{
				roleResult = await RoleManager.CreateAsync(new IdentityRole(role));
			}

			//IdentityUser identityUser = await UserManager.FindByEmailAsync(user);

			IdentityUser identityUser = await UserManager.FindByIdAsync(user);
			await UserManager.AddToRoleAsync(identityUser, role);

			
		}
	}
}
