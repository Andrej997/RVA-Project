///////////////////////////////////////////////////////////
//  LoginUser.cs
//  Implementation of the Class LoginUser
//  Generated by Enterprise Architect
//  Created on:      11-Sep-2020 6:25:09 PM
//  Original author: andrej
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class LoginUser {

	private string password;
	private string username;

	public LoginUser(){

	}

	~LoginUser(){

	}

	/// 
	/// <param name="username"></param>
	/// <param name="password"></param>
	public LoginUser(string username, string password){
		this.Username = username;
		this.Password = password;
	}

	public string Password{
		get{
			return password;
		}
		set{
			password = value;
		}
	}

	public string Username{
		get{
			return username;
		}
		set{
			username = value;
		}
	}

}//end LoginUser