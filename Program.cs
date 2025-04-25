using MoBro.Plugin.SDK;
using MoBro.Plugin.Template;
using Serilog.Events;

// create and start the plugin to test it locally
using var plugin = MoBroPluginBuilder
  .Create<Plugin>()
  .WithSetting("update_frequency", "2")
  .WithLogLevel(LogEventLevel.Verbose)
  .Build();

// prevent the program from exiting immediately
Console.ReadLine();
