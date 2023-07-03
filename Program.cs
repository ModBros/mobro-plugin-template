using System;
using MoBro.Plugin.SDK;
using MoBro.Plugin.Template;

// create and start the plugin to test it locally
var plugin = MoBroPluginBuilder
  .Create<Plugin>()
  .WithSetting("update_frequency", "2")
  .Build();

Console.ReadLine();
