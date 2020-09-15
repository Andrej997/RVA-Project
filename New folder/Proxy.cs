///////////////////////////////////////////////////////////
//  Proxy.cs
//  Implementation of the Class Proxy
//  Generated by Enterprise Architect
//  Created on:      11-Sep-2020 10:34:44 PM
//  Original author: andrej
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Proxy : IDBService {

	private DBService realService;

	~Proxy(){

	}

	public Proxy(){

	}

	public void LogAccess(string message)
	{
		Console.WriteLine($"[{DateTime.Now}] -- {message}");
		// TO DO: loguj u fajl
	}

	/// 
	/// <param name="dbService"></param>
	public Proxy(DBService dbService){
		realService = dbService;
	}

	/// 
	/// <param name="loginUser"></param>
	public Admin FindAdmin(LoginUser loginUser){

		var admin = realService.FindAdmin(loginUser);
		if (admin != null)
		{
			LogAccess($"Admin [{admin.Username}] logged in!");
		}

		return admin;
	}

	/// 
	/// <param name="loginUser"></param>
	public Vezbac FindVezbac(LoginUser loginUser){

		var vezbac = realService.FindVezbac(loginUser);
		if (vezbac != null)
		{
			LogAccess($"Vezbac [{vezbac.Username}] logged in!");
		}

		return vezbac;
	}

	/// 
	/// <param name="osoba"></param>
	public void LogOut(string username)
	{

		LogAccess($"{username} logged out!");
	}

	/// 
	/// <param name="admin"></param>
	public string AddAdmin(Admin admin){

		var message = realService.AddAdmin(admin);
		LogAccess($"{DateTime.Now} {message}");
		return message;
	}

	/// 
	/// <param name="vezbac"></param>
	public string AddVezbav(Vezbac vezbac){

		var message = realService.AddVezbav(vezbac);
		LogAccess($"{DateTime.Now} {message}");
		return message;
	}

	public List<Admin> GetAllAdmins(){

		var list = realService.GetAllAdmins();
		LogAccess($"Got {list.Count} admins from database");
		return list;
	}

	public List<Vezbac> GetAllVezbace(){

		var list = realService.GetAllVezbace();
		LogAccess($"Got {list.Count} vezbace from database");
		return list;
	}

}//end Proxy