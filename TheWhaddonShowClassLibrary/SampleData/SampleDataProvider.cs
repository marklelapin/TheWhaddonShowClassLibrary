using MyClassLibrary.LocalServerMethods.Interfaces;
using MyClassLibrary.LocalServerMethods.Models;
using System.Text.Json;

namespace TheWhaddonShowClassLibrary.SampleData
{
	public class SampleDataProvider<T> : ISampleDataProvider<T> where T : ILocalServerModelUpdate, new()
	{

		public List<ServerSyncLog> GetServerSyncLogSampleData()
		{
			string updateType = typeof(T).Name;

			List<ServerSyncLog> output;

			switch (updateType)
			{

				case "PartUpdate":
					output = SamplePartData.ServerSyncLogStartingData;
					break;
				case "ScriptItemUpdate":
					output = SampleScriptItemData.ServerSyncLogStartingData;
					break;
				case "PersonUpdate":
					output = SamplePersonData.ServerSyncLogStartingData;
					break;
				case "TagUpdate":
					output = SampleTagData.ServerSyncLogStartingData;
					break;

				default: throw new NotImplementedException();

			}

			return output;
		}


		public List<T> GetServerStartingSampleData()
		{
			string updateType = typeof(T).Name;

			string jsonOutput;
			List<T> output;

			switch (updateType)
			{

				case "PartUpdate":
					jsonOutput = JsonSerializer.Serialize(SamplePartData.ServerStartingData);
					break;
				case "ScriptItemUpdate":
					jsonOutput = JsonSerializer.Serialize(SampleScriptItemData.ServerStartingData);
					break;
				case "PersonUpdate":
					jsonOutput = JsonSerializer.Serialize(SamplePersonData.ServerStartingData);
					break;
				case "TagUpdate":
					jsonOutput = JsonSerializer.Serialize(SampleTagData.ServerStartingData);
					break;

				default: throw new NotImplementedException();

			}

			output = JsonSerializer.Deserialize<List<T>>(jsonOutput) ?? new List<T>();

			return output;
		}



		public List<T> GetLocalStartingSampleData()
		{
			string updateType = typeof(T).Name;

			string jsonOutput;
			List<T> output;

			switch (updateType)
			{

				case "PartUpdate":
					jsonOutput = JsonSerializer.Serialize(SamplePartData.LocalStartingData);
					break;
				case "ScriptItemUpdate":
					jsonOutput = JsonSerializer.Serialize(SampleScriptItemData.LocalStartingData);
					break;
				case "PersonUpdate":
					jsonOutput = JsonSerializer.Serialize(SamplePersonData.LocalStartingData);
					break;
				case "TagUpdate":
					jsonOutput = JsonSerializer.Serialize(SampleTagData.LocalStartingData);
					break;

				default: throw new NotImplementedException();

			}

			output = JsonSerializer.Deserialize<List<T>>(jsonOutput) ?? new List<T>();

			return output;
		}



	}
}
