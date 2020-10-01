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
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

public class DBService : IDBService {
	public Logger logger;


	public DBService(){
		logger = new Logger();
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
			catch (Exception e)
			{
				logger.LogError(e.Message);
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
			catch (Exception e)
			{
				logger.LogError(e.Message);
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
			catch (Exception e)
			{
				logger.LogError(e.Message);
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
			catch (Exception e)
			{
				logger.LogError(e.Message);
				return $"Failed to deleted vezbac [{vezbac.Username}] {vezbac.FullName}";
			}
		}
		return $"Successfully deleted vezbac [{vezbac.Username}] {vezbac.FullName}";
	}

	/// 
	/// <param name="admin"></param>
	public string ChangeAdmin(Admin admin){

		using (CommonContex commonContex = new CommonContex())
		{
			try
			{
				var adm = commonContex.Admin
					.FirstOrDefault(x => x.ID == admin.ID);
				adm.Username = admin.Username;
				adm.FullName = admin.FullName;

				commonContex.Entry(adm)
					.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				commonContex.SaveChanges();
			}
			catch (Exception e)
			{
				logger.LogError(e.Message);
				return $"Failed to update admin [{admin.Username}] {admin.FullName}";
			}
		}
		return $"Successfully update admin [{admin.Username}] {admin.FullName}";
	}

	/// 
	/// <param name="vezbac"></param>
	public string ChangeVezbac(Vezbac vezbac){

		using (CommonContex commonContex = new CommonContex())
		{
			try
			{
				var vez = commonContex.Vezbac
					.FirstOrDefault(x => x.ID == vezbac.ID);
				vez.Username = vezbac.Username;
				vez.FullName = vezbac.FullName;

				commonContex.Entry(vez)
					.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				commonContex.SaveChanges();
			}
			catch (Exception e)
			{
				logger.LogError(e.Message);
				return $"Failed to update vezbac [{vezbac.Username}] {vezbac.FullName}";
			}
		}
		return $"Successfully update vezbac [{vezbac.Username}] {vezbac.FullName}";
	}

	/// 
	/// <param name="adminId"></param>
	/// <param name="trening"></param>
	public string AddTreningAdmin(int adminId, Trening trening){

		using (CommonContex commonContex = new CommonContex())
		{
			try
			{
				Admin admin = null;
				
				admin = commonContex.Admin
					.Where(x => x.ID == adminId)
					.Include(x => x.treninzi)
					.FirstOrDefault();
				
				if (admin == null)
					return $"No admin with id: {adminId}";

				if (admin.treninzi == null)
					admin.treninzi = new List<Trening>();
				admin.treninzi.Add(trening);

				commonContex.Entry(admin)
					.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				commonContex.SaveChanges();
			}
			catch (Exception e)
			{
				logger.LogError(e.Message);
				return $"Failed to add trening to admin ({adminId})";
			}
		}
		return $"Successfully added trening to admin ({adminId})";
	}

	public List<Trener> GetTrenere(){

		List<Trener> list;
		using (CommonContex commonContex = new CommonContex())
		{
			list = commonContex.Trener
				.ToList();
		}
		return list;
	}

	/// 
	/// <param name="osoba"></param>
	/// <param name="trening"></param>
	public string DeleteTrening(Osoba osoba, Trening trening){

		using (CommonContex commonContex = new CommonContex())
		{
			try
			{
				var treningEntity = commonContex.Trening
						.Where(x => x.ID == trening.ID)
						.FirstOrDefault();
				commonContex.Trening.Remove(treningEntity);
				commonContex.SaveChanges();
				//if (osoba.Role == 0)
				//{
				//	Admin admin = null;

				//	admin = commonContex.Admin
				//		.Where(x => x.ID == osoba.ID)
				//		.Include(x => x.treninzi)
				//		.FirstOrDefault();

				//	if (admin == null)
				//		return $"No admin with id: {osoba.ID}";

				//	if (admin.treninzi == null)
				//		return $"Admin with id: {osoba.ID} doesn't have treninge";

				//	admin.treninzi.Remove(trening);

				//	commonContex.Entry(admin)
				//		.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				//	commonContex.Entry(admin.treninzi)
				//		.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

				//	commonContex.SaveChanges();
				//}
				//else
				//{
				//	Vezbac  vezbac = null;

				//	vezbac = commonContex.Vezbac
				//		.Where(x => x.ID == osoba.ID)
				//		.Include(x => x.treninzi)
				//		.FirstOrDefault();

				//	if (vezbac == null)
				//		return $"No vezbac with id: {osoba.ID}";

				//	if (vezbac.treninzi == null)
				//		return $"Vezbac with id: {osoba.ID} doesn't have treninge";

				//	vezbac.treninzi.Remove(trening);

				//	//commonContex.Entry(vezbac.treninzi)
				//	//	.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
				//	//commonContex.Entry(vezbac)
				//	//	.State = Microsoft.EntityFrameworkCore.EntityState.Modified;


				//	commonContex.SaveChanges();
				//}
			}
			catch (Exception e)
			{
				logger.LogError(e.Message);
				if (osoba.Role == 0)
					return $"Failed to remove trening to admin ({osoba.ID})";
				else
					return $"Failed to remove trening to vezbac ({osoba.ID})";
			}
		}
		if (osoba.Role == 0)
			return $"Successfully removed trening to admin ({osoba.ID})";
		else
			return $"Successfully removed trening to vezbac ({osoba.ID})";
	}

	/// 
	/// <param name="osoba"></param>
	public List<Trening> GetTreninge(Osoba osoba){

		using (CommonContex commonContex = new CommonContex())
		{
			try
			{
				if (osoba.Role == 0)
				{
					Admin admin = null;

					admin = commonContex.Admin
						.Where(x => x.ID == osoba.ID)
							.Include(x => x.treninzi)
								.ThenInclude(x => x.Trener)
						.FirstOrDefault();

					if (admin == null)
						return null;

					if (admin.treninzi == null)
						return null;

					return admin.treninzi;
				}
				else
				{
					Vezbac vezbac = null;

					vezbac = commonContex.Vezbac
						.Where(x => x.ID == osoba.ID)
						.Include(x => x.treninzi)
							.ThenInclude(x => x.Trener)
						.FirstOrDefault();

					if (vezbac == null)
						return null;

					if (vezbac.treninzi == null)
						return null;

					return vezbac.treninzi;
				}
			}
			catch (Exception e)
			{
				logger.LogError(e.Message);
				return null;
			}
		}
	}

	/// 
	/// <param name="vezbacId"></param>
	/// <param name="trening"></param>
	public string AddTreningVezbac(int vezbacId, Trening trening){

		using (CommonContex commonContex = new CommonContex())
		{
			try
			{
				Vezbac vezbac = null;

				vezbac = commonContex.Vezbac
					.Where(x => x.ID == vezbacId)
					.Include(x => x.treninzi)
					.FirstOrDefault();

				if (vezbac == null)
					return $"No vezbac with id: {vezbacId}";

				if (vezbac.treninzi == null)
					vezbac.treninzi = new List<Trening>();
				vezbac.treninzi.Add(trening);

				commonContex.Entry(vezbac)
					.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				commonContex.SaveChanges();
			}
			catch (Exception e)
			{
				logger.LogError(e.Message);
				return $"Failed to add trening to vezbac ({vezbacId})";
			}
		}
		return $"Successfully added trening to vezbac ({vezbacId})";
	}

	/// 
	/// <param name="trener"></param>
	public string CreateTrener(Trener trener){

		using (CommonContex commonContex = new CommonContex())
		{
			try
			{
				var ret = commonContex
					.Trener
					.Add(trener);
				commonContex.SaveChanges();
				return "Trener successfully created!";
			}
			catch (Exception e)
			{
				logger.LogError(e.Message);
				return "Faild to create trener!";
			}
		}
	}

	/// 
	/// <param name="trener"></param>
	public string ChangeTrener(Trener trener){

		using (CommonContex commonContex = new CommonContex())
		{
			try
			{
				var tren = commonContex.Trener
					.FirstOrDefault(x => x.ID == trener.ID);

				tren.FullName = trener.FullName;

				commonContex.Entry(tren)
					.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				commonContex.SaveChanges();
			}
			catch (Exception e)
			{
				logger.LogError(e.Message);
				return $"Failed to update vezbac {trener.FullName}";
			}
		}
		return $"Successfully update vezbac {trener.FullName}";
	}

	/// 
	/// <param name="id"></param>
	public string DeleteTrener(int id){

		using (CommonContex commonContex = new CommonContex())
		{
			try
			{
				var treninzi = commonContex.Trening
					.Include(x => x.Trener)
					.Where(x => x.Trener.ID == id)
					.ToList();

				commonContex.Trening.RemoveRange(treninzi);
				commonContex.SaveChanges();

				var tren = commonContex.Trener
					.FirstOrDefault(x => x.ID == id);

				commonContex.Trener.Remove(tren);
				commonContex.SaveChanges();
			}
			catch (Exception e)
			{
				logger.LogError(e.Message);
				return $"Failed to deleted trener";
			}
		}
		return $"Successfully deleted trener";
	}

}//end DBService