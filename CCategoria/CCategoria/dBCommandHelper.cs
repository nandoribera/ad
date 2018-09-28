using System;
using System.Data;
namespace CCategoria
{
    public class dBCommandHelper
    {
		public static void AddParemeter(IDbCommand dbCommand, string parameterName, object value){
			IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
			dbDataParameter.ParameterName = parameterName;
			dbDataParameter.Value = value;
			dbCommand.Parameters.Add(dbDataParameter);
		}
    }
}
