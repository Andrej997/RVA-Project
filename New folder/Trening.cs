///////////////////////////////////////////////////////////
//  Trening.cs
//  Implementation of the Class Trening
//  Generated by Enterprise Architect
//  Created on:      11-Sep-2020 6:25:09 PM
//  Original author: tanja
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;

public class Trening {

	private DateTime termin;
	private Trener trener;

	public Trening(){

	}

	~Trening(){

	}

	public int ID{
		get;
		set;
	}

	public DateTime Termin{
		get{
			return termin;
		}
		set{
			termin = value;
		}
	}

	public Trener Trener
	{
		get
		{
			return trener;
		}
		set
		{
			trener = value;
		}
	}

}//end Trening