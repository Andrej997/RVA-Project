///////////////////////////////////////////////////////////
//  DeleteTrening.cs
//  Implementation of the Class DeleteTrening
//  Generated by Enterprise Architect
//  Created on:      23-Sep-2020 7:59:02 PM
//  Original author: andrej
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class DeleteTrening : ICommandUR {

	public Trening trening;

	public DeleteTrening()
	{
		
	}

	~DeleteTrening(){

	}

	/// 
	/// <param name="trening"></param>
	public DeleteTrening(Trening trening){
		this.trening = trening;
	}

	public string ExecuteA(int id, IDBService service)
	{
		throw new NotImplementedException();
	}

	public string UnExecuteA(Osoba osoba, IDBService service)
	{
		throw new NotImplementedException();
	}

	/// 
	/// <param name="id"></param>
	/// <param name="service"></param>
	public string ExecuteV(int id, IDBService service){

		return "";
	}

	/// 
	/// <param name="osoba"></param>
	/// <param name="service"></param>
	public string UnExecuteV(Osoba osoba, IDBService service){

		return "";
	}
}//end DeleteTrening