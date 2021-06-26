using System;
using Newtonsoft.Json;

namespace Oxide.Plugins
{
    [Info("FPS Restart", "RustySpoon", "1.0")]
    [Description("Restarts server when FPS reaches a specific target")]
    public class FPSRestart : CovalencePlugin
    {
        private Timer timerObject;

        #region Configuration

        private static ConfigData config = new ConfigData();

        private class ConfigData
        {
            [JsonProperty(PropertyName = "FPS To Trigger Restart")]
            public float FrameRate = 100;

            [JsonProperty(PropertyName = "How Long The Restart should be")]
            public float RestartTime = 300;
        }

        protected override void LoadConfig()
        {
            base.LoadConfig();

            try
            {
                config = Config.ReadObject<ConfigData>();
                if (config == null)
                {
                    LoadDefaultConfig();
                }
            }
            catch
            {

                LoadDefaultConfig();
                return;
            }

            SaveConfig();
        }

        protected override void LoadDefaultConfig()
        {
            config = new ConfigData();
        }

        protected override void SaveConfig()
        {
            Config.WriteObject(config);
        }

        #endregion

        #region Oxide Hooks

        private void OnServerInitialized()
        {
            timerObject = timer.Every(60, FrameRate);
        }

        private void Unload()
        {
            config = null;
            timerObject.Destroy();
        }

        #endregion

        #region Core

        private void FrameRate()
        {
            if (Performance.report.frameRate > config.FrameRate)
            {
                return;
            }

            server.Broadcast("The Server Has Detected Low FPS That May Cause Lag. A Restart Has Begun, stash yo' loot!");
            LogWarning("The Server Has Detected Low FPS That May Cause Lag. A Restart Has Begun!");
            server.Command("restart " + config.RestartTime);
            timerObject.Destroy();
        }

        #endregion
    }
}