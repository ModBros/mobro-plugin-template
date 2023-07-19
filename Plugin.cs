using System;
using System.Runtime.InteropServices;
using MoBro.Plugin.SDK;
using MoBro.Plugin.SDK.Builders;
using MoBro.Plugin.SDK.Enums;
using MoBro.Plugin.SDK.Services;

namespace MoBro.Plugin.Template;

public class Plugin : IMoBroPlugin
{
  private readonly IMoBroService _mobro;
  private readonly IMoBroScheduler _scheduler;
  private readonly IMoBroSettings _settings;

  private readonly Random _random;

  public Plugin(IMoBroService mobro, IMoBroScheduler scheduler, IMoBroSettings settings)
  {
    // inject all needed services via the constructor
    _mobro = mobro; // allows the plugin to interact with MoBro 
    _scheduler = scheduler; // scheduler for recurring tasks such as updating metrics
    _settings = settings; // used to retrieve the settings values

    _random = new Random(); // just to generate some metric values
  }

  public void Init()
  {
    // Init() will be automatically called once upon initialization of the plugin
    // There is also an asynchronous implementation available: InitAsync()

    // create and register all metrics
    CreateAndRegisterMetrics();

    // set the value for the static metrics
    SetStaticMetricValues();

    // get the value of the setting for the update frequency
    var updateFrequencySetting = _settings.GetValue<int>("update_frequency");

    // schedule a recurring task to update the dynamic metrics
    _scheduler.Interval(UpdateDynamicMetrics, TimeSpan.FromSeconds(updateFrequencySetting), TimeSpan.FromSeconds(5));
  }

  private void CreateAndRegisterMetrics()
  {
    // dynamic number metric (e.g. CPU temperature, load, etc..)
    var cpuUsage = MoBroItem
      .CreateMetric()
      .WithId("cpu_usage")
      .WithLabel("CPU usage")
      .OfType(CoreMetricType.Usage)
      .OfCategory(CoreCategory.Cpu)
      .OfNoGroup()
      .Build();

    var memoryInUse = MoBroItem
      .CreateMetric()
      .WithId("ram_in_use")
      .WithLabel("Memory in use")
      .OfType(CoreMetricType.Data)
      .OfCategory(CoreCategory.Ram)
      .OfNoGroup()
      .Build();

    // static text metric (e.g. CPU name, operating system)
    var osName = MoBroItem
      .CreateMetric()
      .WithId("os_name")
      .WithLabel("Operating system")
      .OfType(CoreMetricType.Text)
      .OfCategory(CoreCategory.System)
      .OfNoGroup()
      .AsStaticValue()
      .Build();

    _mobro.Register(cpuUsage);
    _mobro.Register(memoryInUse);
    _mobro.Register(osName);
  }

  private void SetStaticMetricValues()
  {
    // since this value won't change over time, it's sufficient to set it once
    _mobro.UpdateMetricValue("os_name", RuntimeInformation.OSDescription);
  }

  private void UpdateDynamicMetrics()
  {
    // update the changing dynamic metrics
    // normally we would retrieve the new value first by e.g. reading a sensor or calling an external API
    _mobro.UpdateMetricValue("cpu_usage", _random.NextDouble() * 100);
    _mobro.UpdateMetricValue("ram_in_use", _random.NextDouble() * 1_000_000_000);
  }

  public void Dispose()
  {
  }
}