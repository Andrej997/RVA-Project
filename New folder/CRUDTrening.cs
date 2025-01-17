///////////////////////////////////////////////////////////
//  CRUDTrening.cs
//  Implementation of the Class CRUDTrening
//  Generated by Enterprise Architect
//  Created on:      17-Sep-2020 6:58:25 PM
//  Original author: andrej
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class CRUDTrening {

	public UndoRedo undoRedo;

	public CRUDTrening(){
		undoRedo = new UndoRedo();
	}

	~CRUDTrening(){

	}

	/// 
	/// <param name="adminId"></param>
	/// <param name="service"></param>
	/// <param name="trening"></param>
	public string AddTreningAdmin(int adminId, IDBService service, Trening trening){

		string message = "";
		undoRedo.InsertInUnDoRedoForAdd(adminId, 0, service, trening, out message);
		return message;
		//return service.AddTreningAdmin(adminId, trening);
	}

	/// 
	/// <param name="service"></param>
	public List<Trener> GetTrenere(IDBService service){

		return service.GetTrenere();
	}

	/// 
	/// <param name="osoba"></param>
	/// <param name="trening"></param>
	/// <param name="service"></param>
	public string DeleteTrening(Osoba osoba, Trening trening, IDBService service){

		string message = "";
		undoRedo.InsertInUnDoRedoForDelete(osoba, service, trening, out message);
		return message;
		//return service.DeleteTrening(osoba, trening);
	}

	/// 
	/// <param name="admin"></param>
	/// <param name="service"></param>
	public List<Trening> GetTreninge(Admin admin, IDBService service){

		return service.GetTreninge(admin);
	}

	/// 
	/// <param name="vezbac"></param>
	/// <param name="service"></param>
	public List<Trening> GetTreninge(Vezbac vezbac, IDBService service){

		return service.GetTreninge(vezbac);
	}

	/// 
	/// <param name="vezbacId"></param>
	/// <param name="service"></param>
	/// <param name="trening"></param>
	public string AddTreningVezbac(int vezbacId, IDBService service, Trening trening){

		string message = "";
		undoRedo.InsertInUnDoRedoForAdd(vezbacId, 1, service, trening, out message);
		return message;
		//return service.AddTreningVezbac(vezbacId, trening);
	}

	public string Redo(){

		return undoRedo.Redo();
	}

	public string Undo(){

		return undoRedo.Undo();
	}

}//end CRUDTrening