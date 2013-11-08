using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using log4net;
using log4net.Config;

namespace Fabric.New.Infrastructure {
	
	/*================================================================================================*/
	[ExcludeFromCodeCoverage]
	public abstract class Logger {

		private enum Level {
			Info,
			Debug,
			Warn,
			Error,
			Fatal,
		};

		private static bool Configured = false;
		private static IDictionary<Level, Action<ILog, string, Exception>> LevelMap;

		private readonly ILog vLog;
		private readonly string vClassName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void ConfigureOnce() {
			if ( Configured ) { return; }
			Configured = true;

			XmlConfigurator.Configure();

			LevelMap = new Dictionary<Level, Action<ILog, string, Exception>>();
			LevelMap.Add(Level.Info, (l,t,e) => l.Info(t,e));
			LevelMap.Add(Level.Debug, (l, t, e) => l.Debug(t, e));
			LevelMap.Add(Level.Warn, (l, t, e) => l.Warn(t, e));
			LevelMap.Add(Level.Error, (l,t,e) => l.Error(t,e));
			LevelMap.Add(Level.Fatal, (l,t,e) => l.Fatal(t,e));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected Logger(Type pType) {
			vLog = LogManager.GetLogger(pType);
			vClassName = pType.Name;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Info(string pText) {
			Output(Level.Info, pText);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Info(string pText, Exception pException) {
			Output(Level.Info, pText, pException);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Info(string pSessId, string pMode, string pText, Exception pException=null) {
			Output(Level.Info, pText, pException, pSessId, pMode);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Debug(string pText) {
			Output(Level.Debug, pText);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Debug(string pText, Exception pException) {
			Output(Level.Debug, pText, pException);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Debug(string pSessId, string pMode, string pText, Exception pException=null) {
			Output(Level.Debug, pText, pException, pSessId, pMode);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Warn(string pText) {
			Output(Level.Warn, pText);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Warn(string pText, Exception pException) {
			Output(Level.Warn, pText, pException);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Warn(string pSessId, string pMode, string pText, Exception pException=null) {
			Output(Level.Warn, pText, pException, pSessId, pMode);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Error(string pText) {
			Output(Level.Error, pText);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Error(string pText, Exception pException) {
			Output(Level.Error, pText, pException);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Error(string pSessId, string pMode, string pText, Exception pException=null) {
			Output(Level.Error, pText, pException, pSessId, pMode);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Fatal(string pText) {
			Output(Level.Fatal, pText);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Fatal(string pText, Exception pException) {
			Output(Level.Fatal, pText, pException);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Fatal(string pSessId, string pMode, string pText, Exception pException=null) {
			Output(Level.Fatal, pText, pException, pSessId, pMode);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string Prefix(string pType, string pSessId=null, string pMode=null) {
			return pType.PadRight(5, ' ')+
				(pSessId == null ? "" : " | "+pSessId)+
				(pMode == null ? "" : " | "+pMode.PadRight(7, ' '))+
				" | "+vClassName+" | ";
		}

		/*--------------------------------------------------------------------------------------------*/
		private void Output(Level pLevel, string pText, Exception pEx=null,
															string pSessId=null, string pMode=null) {
			pText = Prefix("Info", pSessId, pMode)+pText;
			ConsoleOut(pText);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void ConsoleOut(string pText, Exception pException=null) {
			Trace.WriteLine(pText);
			if ( pException != null ) { Trace.WriteLine(pException); }
		}

	}


	/*================================================================================================*/
	[ExcludeFromCodeCoverage]
	public class Logger<T> : Logger {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected Logger() : base(typeof(T)) { }

		/*--------------------------------------------------------------------------------------------*/
		public static Logger<T> Build() {
			return new Logger<T>();
		}

	}

}