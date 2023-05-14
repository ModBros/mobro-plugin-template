using MoBro.Plugin.SDK.Testing;

// create and start the plugin to test it locally
var plugin = MoBroPluginBuilder
  .Create<Plugin.Template.Plugin>()
  .WithSetting("update_frequency", "2")
  .Build();

Console.ReadLine();
