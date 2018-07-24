using System;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DeejayEntertainment.UnarmedDuallingClub.Configuration
{
	public static class ConfigurationManager
	{
		public static GameBalanceConstants GameBalanceConfiguration { get; }

		public static ControllerConfiguration FirstPlayerConfiguration { get; private set; }
		public static ControllerConfiguration SecondPlayerConfiguration { get; private set; }

		static ConfigurationManager()
		{
			GameBalanceConfiguration = LoadGameBalanceConfiguration();
			LoadControllerConfigurations();
		}

		public static GameBalanceConstants LoadGameBalanceConfiguration()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(GameBalanceConstants));
			using (XmlReader reader = XmlReader.Create(Path.Combine(Environment.CurrentDirectory, System.Configuration.ConfigurationManager.AppSettings["configuration"])))
			{
				return (GameBalanceConstants)serializer.Deserialize(reader);
			}
		}

		public static void LoadControllerConfigurations()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(ControllerConfiguration));
			using (XmlReader reader = XmlReader.Create(Path.Combine(Environment.CurrentDirectory, System.Configuration.ConfigurationManager.AppSettings["firstControllerConfiguration"])))
			{
				FirstPlayerConfiguration = (ControllerConfiguration)serializer.Deserialize(reader);
			}

			using (XmlReader reader = XmlReader.Create(Path.Combine(Environment.CurrentDirectory, System.Configuration.ConfigurationManager.AppSettings["secondControllerConfiguration"])))
			{
				SecondPlayerConfiguration = (ControllerConfiguration)serializer.Deserialize(reader);
			}
		}

		public static void SaveControllerConfigurations()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(ControllerConfiguration));
			FileStream file = File.Create(Path.Combine(Environment.CurrentDirectory, System.Configuration.ConfigurationManager.AppSettings["firstControllerConfiguration"]));
			serializer.Serialize(file, FirstPlayerConfiguration);
			file = File.Create(Path.Combine(Environment.CurrentDirectory, System.Configuration.ConfigurationManager.AppSettings["secondControllerConfiguration"]));
			serializer.Serialize(file, SecondPlayerConfiguration);
		}
	}
}
