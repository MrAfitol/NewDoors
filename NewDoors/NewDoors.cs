﻿using PluginAPI.Core.Attributes;
using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace NewDoors
{
    public class NewDoors
    {
        public static NewDoors Instance { get; private set; }

        [PluginConfig("configs/new-doors.yml")]
        public Config Config;

        [PluginPriority(LoadPriority.Highest)]
        [PluginEntryPoint("NewDoors", "1.1.0", "Plugin added new doors.", "MrAfitol")]
        void LoadPlugin()
        {
            Instance = this;
            EventManager.RegisterEvents<EventHandlers>(this);

            var handler = PluginHandler.Get(this);
            handler.SaveConfig(this, nameof(Config));
        }
    }
}
