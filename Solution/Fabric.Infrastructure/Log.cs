using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using log4net;
using log4net.Config;

namespace Fabric.Infrastructure {

	/*================================================================================================*/
	[ExcludeFromCodeCoverage]
	public class Log {

		public const string Action = "Action";
		public const string Session = "Session";

		private static readonly ILog LogInstance = LogManager.GetLogger(typeof(Log));
		private static bool Configured = false;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void ConfigureOnce() {
			if ( Configured ) { return; }
			XmlConfigurator.Configure();
			Configured = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string Prefix(string pType) {
			return pType.PadRight(5, ' ')+" | ";
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string Prefix(string pType, Guid pSessId, string pMode) {
			return pType.PadRight(5, ' ')+" | "+pSessId+" | "+pMode.PadRight(7, ' ')+" | ";
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void Info(string pText) {
			pText = Prefix("Info")+pText;
			LogInstance.Info(pText);
			ConsoleOut(pText);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Info(string pText, Exception pException) {
			pText = Prefix("Info")+pText;
			LogInstance.Info(pText, pException);
			ConsoleOut(pText, pException);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Info(Guid pSessId, string pMode, string pText, Exception pException=null) {
			pText = Prefix("Info", pSessId, pMode)+pText;
			LogInstance.Info(pText, pException);
			if ( pException != null ) { ConsoleOut(pText, pException); }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void Debug(string pText) {
			pText = Prefix("Debug")+pText;
			LogInstance.Debug(pText);
			ConsoleOut(pText);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Debug(string pText, Exception pException) {
			pText = Prefix("Debug")+pText;
			LogInstance.Debug(pText, pException);
			ConsoleOut(pText, pException);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Debug(Guid pSessId, string pMode, string pText, Exception pException=null) {
			pText = Prefix("Debug", pSessId, pMode)+pText;
			LogInstance.Debug(pText, pException);
			if ( pException != null ) { ConsoleOut(pText, pException); }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void Error(string pText) {
			pText = Prefix("Error")+pText;
			LogInstance.Error(pText);
			ConsoleOut(pText);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Error(string pText, Exception pException) {
			pText = Prefix("Error")+pText;
			LogInstance.Error(pText, pException);
			ConsoleOut(pText, pException);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Error(Guid pSessId, string pMode, string pText, Exception pException=null) {
			pText = Prefix("Error", pSessId, pMode)+pText;
			LogInstance.Error(pText, pException);
			if ( pException != null ) { ConsoleOut(pText, pException); }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void Fatal(string pText) {
			pText = Prefix("Fatal")+pText;
			LogInstance.Fatal(pText);
			ConsoleOut(pText);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Fatal(string pText, Exception pException) {
			pText = Prefix("Fatal")+pText;
			LogInstance.Fatal(pText, pException);
			ConsoleOut(pText, pException);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Fatal(Guid pSessId, string pMode, string pText, Exception pException=null) {
			pText = Prefix("Fatal", pSessId, pMode)+pText;
			LogInstance.Fatal(pText, pException);
			if ( pException != null ) { ConsoleOut(pText, pException); }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void Warn(string pText) {
			pText = Prefix("Warn")+pText;
			LogInstance.Warn(pText);
			ConsoleOut(pText);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Warn(string pText, Exception pException) {
			pText = Prefix("Warn")+pText;
			LogInstance.Warn(pText, pException);
			ConsoleOut(pText, pException);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Warn(Guid pSessId, string pMode, string pText, Exception pException=null) {
			pText = Prefix("Warn", pSessId, pMode)+pText;
			LogInstance.Warn(pText, pException);
			if ( pException != null ) { ConsoleOut(pText, pException); }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void ConsoleOut(string pText, Exception pException=null) {
			Trace.WriteLine(pText);
			if ( pException != null ) { Trace.WriteLine(pException); }
		}

	}

}