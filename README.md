# mobro-plugin-template

![GitHub tag (latest by date)](https://img.shields.io/github/v/tag/ModBros/mobro-plugin-template?label=version)
![GitHub](https://img.shields.io/github/license/ModBros/mobro-plugin-template)
[![MoBro](https://img.shields.io/badge/-MoBro-red.svg)](https://mobro.app)
[![Discord](https://img.shields.io/discord/620204412706750466.svg?color=7389D8&labelColor=6A7EC2&logo=discord&logoColor=ffffff&style=flat-square)](https://discord.com/invite/DSNX4ds)

**Template for MoBro plugins**

This plugin is intended to serve as a template and starting point to developing a plugin
for [MoBro](https://mobro.app).  
It contains the basic setup as well as some example code on how to

- register and update metrics
- define and access the plugin settings
- set up a scheduled task to continuously poll metric values

## Publish

### CLI

The easiest way to publish the plugin is to utilize
the [MoBro Plugin CLI](https://github.com/ModBros/mobro-plugin-cli).  
Just execute from within the project directory:

```
mobro publish .
```

### Script

Alternatively the plugin can be published by running the included [`publish_zip.bat`](./publish.bat) script from within
the project. (Requires 7Zip to be installed)

```
./publish.bat YourPluginName_v1
```

## SDK

The plugin is built using the [MoBro Plugin SDK](https://github.com/ModBros/mobro-plugin-sdk).  
Detailed developer documentation is available at [developer.mobro.app](https://developer.mobro.app).

---

Feel free to visit us on our [Discord](https://discord.com/invite/DSNX4ds) or [Forum](https://www.mod-bros.com/en/forum)
for any questions or in case you run into any issues.
