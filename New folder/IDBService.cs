///////////////////////////////////////////////////////////
//  IDBService.cs
//  Implementation of the Interface IDBService
//  Generated by Enterprise Architect
//  Created on:      12-Sep-2020 6:28:48 PM
//  Original author: andrej
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public interface IDBService                  {

	/// 
	/// <param name="loginUser"></param>
	Admin FindAdmin(LoginUser loginUser);

	/// 
	/// <param name="loginUser"></param>
	Vezbac FindVezbac(LoginUser loginUser);

	/// 
	/// <param name="osoba"></param>
	void LogOut(string username);

	/// 
	/// <param name="admin"></param>
	string AddAdmin(Admin admin);

	/// 
	/// <param name="vezbac"></param>
	string AddVezbav(Vezbac vezbac);

	List<Admin> GetAllAdmins();

	List<Vezbac> GetAllVezbace();

	/// 
	/// <param name="admin"></param>
	string DeleteAdmin(Admin admin);

	/// 
	/// <param name="vezbac"></param>
	string DeleteVezbac(Vezbac vezbac);

	/// 
	/// <param name="admin"></param>
	string ChangeAdmin(Admin admin);

	/// 
	/// <param name="vezbac"></param>
	string ChangeVezbac(Vezbac vezbac);

	/// 
	/// <param name="adminId"></param>
	/// <param name="trening"></param>
	string AddTreningAdmin(int adminId, Trening trening);

	List<Trener> GetTrenere();

	/// 
	/// <param name="osoba"></param>
	/// <param name="trening"></param>
	string DeleteTrening(Osoba osoba, Trening trening);

	/// 
	/// <param name="osoba"></param>
	List<Trening> GetTreninge(Osoba osoba);

	/// 
	/// <param name="vezbacId"></param>
	/// <param name="trening"></param>
	string AddTreningVezbac(int vezbacId, Trening trening);

	/// 
	/// <param name="trener"></param>
	string CreateTrener(Trener trener);

	/// 
	/// <param name="trener"></param>
	string ChangeTrener(Trener trener);

	/// 
	/// <param name="id"></param>
	string DeleteTrener(int id);

	/// 
	/// <param name="osoba"></param>
	string ChangeUser(object osoba);
}//end IDBService