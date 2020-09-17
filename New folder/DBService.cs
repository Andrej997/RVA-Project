///////////////////////////////////////////////////////////
//  DBService.cs
//  Implementation of the Class DBService
//  Generated by Enterprise Architect
//  Created on:      12-Sep-2020 6:28:45 PM
//  Original author: andrej
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Common;
using System.Linq;

public class DBService : IDBService {

	public DBService(){

	}

	~DBService(){

	}

	/// 
	/// <param name="loginUser"></param>
	public Admin FindAdmin(LoginUser loginUser){

		Admin logged = null;
		using (CommonContex commonContex = new CommonContex())
		{
			logged = commonContex.Admin
				.Where(x => x.Username == loginUser.Username && x.Password == loginUser.Password)
				.FirstOrDefault();
		}
		return logged;
	}

	/// 
	/// <param name="loginUser"></param>
	public Vezbac FindVezbac(LoginUser loginUser){
		
		Vezbac logged = null;
		using (CommonContex commonContex = new CommonContex())
		{
			logged = commonContex.Vezbac
				 .Where(x => x.Username == loginUser.Username && x.Password == loginUser.Password)
				 .FirstOrDefault();
		}
		return logged;
	}

	/// 
	/// <param name="osoba"></param>
	public void LogOut(string username)
	{

	}

	/// 
	/// <param name="admin"></param>
	public string AddAdmin(Admin admin){

		using (CommonContex commonContex = new CommonContex())
		{
			try
			{
				var ret = commonContex
					.Admin
					.Add(admin);
				commonContex.SaveChanges();
				return "Admin successfully created!";
			}
			catch (Exception)
			{
				return "Faild to create admin!";
			}
		}
	}

	/// 
	/// <param name="vezbac"></param>
	public string AddVezbav(Vezbac vezbac){

		using (CommonContex commonContex = new CommonContex())
		{
			try
			{
				var ret = commonContex
					.Vezbac
					.Add(vezbac);
				commonContex.SaveChanges();
				return "Vezbac successfully created!";
			}
			catch (Exception)
			{
				return "Faild to create vezbac!";
			}
		}
	}

	public List<Admin> GetAllAdmins(){

		List<Admin> list;
		using (CommonContex commonContex = new CommonContex())
		{
			list = commonContex.Admin
				.ToList();
		}
		return list;
	}

	public List<Vezbac> GetAllVezbace(){

		List<Vezbac> list;
		using (CommonContex commonContex = new CommonContex())
		{
			list = commonContex.Vezbac
				.ToList();
		}
		return list;
	}

	/// 
	/// <param name="admin"></param>
	public string DeleteAdmin(Admin admin){

		using (CommonContex commonContex = new CommonContex())
		{
			try
			{
				commonContex.Admin.Remove(admin);
				commonContex.SaveChanges();
			}
			catch
			{
				return $"Failed to deleted admin [{admin.Username}] {admin.FullName}";
			}
		}
		return $"Successfully deleted admin [{admin.Username}] {admin.FullName}";
	}

	/// 
	/// <param name="vezbac"></param>
	public string DeleteVezbac(Vezbac vezbac){

		using (CommonContex commonContex = new CommonContex())
		{
			try
			{
				commonContex.Vezbac.Remove(vezbac);
				commonContex.SaveChanges();
			}
			catch
			{
				return $"Failed to deleted vezbac [{vezbac.Username}] {vezbac.FullName}";
			}
		}
		return $"Successfully deleted vezbac [{vezbac.Username}] {vezbac.FullName}";
	}

}//end DBService