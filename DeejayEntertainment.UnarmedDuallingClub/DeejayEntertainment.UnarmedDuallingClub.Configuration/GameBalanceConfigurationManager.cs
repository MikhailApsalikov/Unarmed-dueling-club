using System;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using DeejayEntertainment.UnarmedDuallingClub.Configuration;

namespace DeejayEntertainment.UnarmedDuallingClub.GameCore.Configuration
{
	public class GameBalanceConfigurationManager
	{
		public GameBalanceConstants GetConfiguration()
		{
			XmlSerializer ser = new XmlSerializer(typeof(GameBalanceConstants));
			//FileStream file = File.Create(Path.Combine(Environment.CurrentDirectory, "Configuration.xml"));
			//ser.Serialize(file, new GameBalanceConstants());
			using (XmlReader reader = XmlReader.Create(Path.Combine(Environment.CurrentDirectory, ConfigurationManager.AppSettings["configuration"])))
			{
				return (GameBalanceConstants)ser.Deserialize(reader);
			}
		}
	}
}
