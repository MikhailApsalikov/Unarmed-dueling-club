using System;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using DeejayEntertainment.UnarmedDuallingClub.Configuration;

namespace DeejayEntertainment.UnarmedDuallingClub.GameCore.Configuration
{
	public static class GameBalanceConfigurationManager
	{
		public static GameBalanceConstants Configuration { get; } = LoadConfiguration();

		public static GameBalanceConstants LoadConfiguration()
		{
			XmlSerializer ser = new XmlSerializer(typeof(GameBalanceConstants));
			using (XmlReader reader = XmlReader.Create(Path.Combine(Environment.CurrentDirectory, ConfigurationManager.AppSettings["configuration"])))
			{
				return (GameBalanceConstants)ser.Deserialize(reader);
			}
		}
	}
}
