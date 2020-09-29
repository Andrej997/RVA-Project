///////////////////////////////////////////////////////////
//  Logger.cs
//  Implementation of the Class Logger
//  Generated by Enterprise Architect
//  Created on:      27-Sep-2020 4:52:31 PM
//  Original author: andrej
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Logger {
	private log4net.ILog log;


	public Logger(){
		log4net.Config.BasicConfigurator.Configure();
		log = log4net.LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod()
			.DeclaringType
			);
	}

	~Logger(){

	}

	/// 
	/// <param name="message"></param>
	public void LogInTxt(string message){

		using (StreamWriter w = File.AppendText("log.txt"))
		{
			w.WriteLine(message);
		}
	}

	/// 
	/// <param name="error"></param>
	public void LogError(string error){
		log.Error(error);
	}

	/// 
	/// <param name="message"></param>
	public void LogInfo(string message){
		log.Info(message);
	}

}//end Logger