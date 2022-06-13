#region

using System.IO;
using API;
using API.ServiceFactory;
using API.Settings;
using Newtonsoft.Json;

#endregion

namespace DuckSoup.Library.Settings
{
    public class SettingsManager : ISettingsManager
    {
        public SettingsManager()
        {
            ServiceFactory.Register<ISettingsManager>(typeof(ISettingsManager), this);

            if (!File.Exists(@"./Settings.json"))
            {
                Settings = new Settings().Init();
                File.WriteAllText(@"./Settings.json",
                    JsonConvert.SerializeObject(Settings, Formatting.Indented));
                Global.Logger.WarnFormat("Settings.json created. Please stop the Proxy and configure the file.");
            }

            // if a config file exists deserialize and initialize it
            Settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(@"./Settings.json"));
        }

        public ISettings Settings { get; private set; }

        public void Dispose()
        {
            Settings = null;
        }
    }
}