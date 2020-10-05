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
	
	public Logger logger;
	~Proxy(){

	}

	public Proxy(){
	}

	public void LogAccess(string message)
	{
		if (logger == null)
		{
			logger = new Logger();
		}
		var text = $"[{DateTime.Now}] - {message}";
		//Console.WriteLine(text);
		logger.LogInTxt(text);
		logger.LogInfo(text);
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
			LogAccess($"(ID={admin.ID},Role={admin.Role}) - Admin [{admin.Username}] logged in!");
		}

		return admin;
	}

	/// 
	/// <param name="loginUser"></param>
	public Vezbac FindVezbac(LoginUser loginUser){

		var vezbac = realService.FindVezbac(loginUser);
		if (vezbac != null)
		{
			LogAccess($"(ID={vezbac.ID},Role={vezbac.Role}) - Vezbac [{vezbac.Username}] logged in!");
		}

		return vezbac;
	}

	/// 
	/// <param name="osoba"></param>
	public void LogOut(string username) {

		LogAccess($"{username} logged out!");
	}

	/// 
	/// <param name="admin"></param>
	public string AddAdmin(Admin admin){

		var message = realService.AddAdmin(admin);
		LogAccess($"{message}");
		return message;
	}

	/// 
	/// <param name="vezbac"></param>
	public string AddVezbav(Vezbac vezbac){

		var message = realService.AddVezbav(vezbac);
		LogAccess($"{message}");
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

	/// 
	/// <param name="admin"></param>
	public string DeleteAdmin(Admin admin){

		var message = realService.DeleteAdmin(admin);
		LogAccess($"{message}");
		return message;
	}

	/// 
	/// <param name="vezbac"></param>
	public string DeleteVezbac(Vezbac vezbac){

		var message = realService.DeleteVezbac(vezbac);
		LogAccess($"{message}");
		return message;
	}

	/// 
	/// <param name="admin"></param>
	public string ChangeAdmin(Admin admin){

		var message = realService.ChangeAdmin(admin);
		LogAccess($"{message}");
		return message;
	}

	/// 
	/// <param name="vezbac"></param>
	public string ChangeVezbac(Vezbac vezbac){

		var message = realService.ChangeVezbac(vezbac);
		LogAccess($"{message}");
		return message;
	}

	/// 
	/// <param name="adminId"></param>
	/// <param name="trening"></param>
	public string AddTreningAdmin(int adminId, Trening trening){

		var message = realService.AddTreningAdmin(adminId, trening);
		LogAccess($"(ID={adminId},Role=0) - {message}");
		return message;
	}

	public List<Trener> GetTrenere(){

		var list = realService.GetTrenere();
		LogAccess($"Got {list.Count} trenera from database");
		return list;
	}

	/// 
	/// <param name="osoba"></param>
	/// <param name="trening"></param>
	public string DeleteTrening(Osoba osoba, Trening trening){

		var message = realService.DeleteTrening(osoba, trening);
		LogAccess($"(ID={osoba.ID},Role={osoba.Role}) - {message}");
		return message;
	}

	/// 
	/// <param name="osoba"></param>
	public List<Trening> GetTreninge(Osoba osoba){

		var list = realService.GetTreninge(osoba);
		if (list == null)
			LogAccess($"Internal server error for user {osoba.ID}");
		else
			LogAccess($"Got {list.Count} treninge for user {osoba.ID} from database");
		return list;
	}

	/// 
	/// <param name="vezbacId"></param>
	/// <param name="trening"></param>
	public string AddTreningVezbac(int vezbacId, Trening trening){

		var message = realService.AddTreningVezbac(vezbacId, trening);
		LogAccess($"(ID={vezbacId},Role=1) - {message}");
		return message;
	}

	/// 
	/// <param name="trener"></param>
	public string CreateTrener(Trener trener){

		var message = realService.CreateTrener(trener);
		LogAccess($"{message}");
		return message;
	}

	/// 
	/// <param name="trener"></param>
	public string ChangeTrener(Trener trener){

		var message = realService.ChangeTrener(trener);
		LogAccess($"{message}");
		return message;
	}

	/// 
	/// <param name="id"></param>
	public string DeleteTrener(int id){

		var message = realService.DeleteTrener(id);
		LogAccess($"{message}");
		return message;
	}

	/// 
	/// <param name="osoba"></param>
	public string ChangeUser(object osoba){

		var message = realService.ChangeUser(osoba);
		if (message is String)
			LogAccess($"{message}");
		return message;
	}

}//end Proxy