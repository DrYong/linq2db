﻿using System;
using System.Collections.Specialized;
using System.Data;
using System.Reflection;

namespace LinqToDB.DataProvider.Firebird
{
	using Data;

	public class FirebirdFactory: IDataProviderFactory
	{
		static readonly FirebirdDataProvider _firebirdDataProvider = new FirebirdDataProvider();

		static FirebirdFactory()
		{
			DataConnection.AddDataProvider(_firebirdDataProvider);
		}

		IDataProvider IDataProviderFactory.GetDataProvider(NameValueCollection attributes)
		{
			return _firebirdDataProvider;
		}

		public static IDataProvider GetDataProvider()
		{
			return _firebirdDataProvider;
		}

		public static void ResolveFirebird(string path)
		{
			new AssemblyResolver(path, "FirebirdSql.Data.FirebirdClient");
		}

		public static void ResolveFirebird(Assembly assembly)
		{
			new AssemblyResolver(assembly, "FirebirdSql.Data.FirebirdClient");
		}

		#region CreateDataConnection

		public static DataConnection CreateDataConnection(string connectionString)
		{
			return new DataConnection(_firebirdDataProvider, connectionString);
		}

		public static DataConnection CreateDataConnection(IDbConnection connection)
		{
			return new DataConnection(_firebirdDataProvider, connection);
		}

		public static DataConnection CreateDataConnection(IDbTransaction transaction)
		{
			return new DataConnection(_firebirdDataProvider, transaction);
		}

		#endregion
	}
}
