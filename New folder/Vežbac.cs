///////////////////////////////////////////////////////////
//  Ve�bac.cs
//  Implementation of the Class Vezbac
//  Generated by Enterprise Architect
//  Created on:      11-Sep-2020 6:25:09 PM
//  Original author: tanja
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;

public class Vezbac : Osoba {

	public List<Trening> treninzi;

	public Vezbac(){

	}

	~Vezbac(){

	}

	public override string FullName{
		get;
		set;
	}

	[Key]
	public override int ID{
		get;
		set;
	}

	public override string Password{
		get;
		set;
	}

	public override int Role{
		get;
		set;
	}

	public override string ToString(){

		return "";
	}

	public override string Username{
		get;
		set;
	}

}//end Vezbac