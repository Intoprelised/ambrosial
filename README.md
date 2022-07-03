<h3 align="center"><img src="https://user-images.githubusercontent.com/54753631/177060465-cfa6fa0f-727a-4f3e-b86d-45d4b844c4c9.png" alt="Ambrosial"></h3>
<h1 align="center">ambrosial</h1>

Ambrosial is a launcher for Minecraft: Windows 10 Edition modifications.

## Features
- [x] Server stored modifications
- `Ensures you are always up to date by retrieving the latest modifications from the server.`
- [x] Fast & reliable
- `Ambrosial requires very little power & network usage, downloads and injections are almost instant.`
- [x] Download caching
- `Any download made is stored for next usage, minimizing bandwidth and allowing for offline use.`
- [x] Safe & open source
- `Ambrosial is trusted by thousands of users and has the source code available for download.`
- [x] Ease of use
- `Download and launch new modifications in a single click, no extra work needed.`
- [x] Large range of modifications
- `Ambrosial has a wide collection of modifications, your favourites & more will be included.`

## Download & installation
Ambrosial is portable and very easy to install. Simply [click here](https://github.com/disepi/ambrosial/releases) and download the **latest** `Ambrosial.exe` listed at the top. Once you have downloaded the executable, open it and installation is done. Don't get confused with the source code download - you will not need to download it if you do not wish to modify it.

## Troubleshooting
If you have any problem running Ambrosial or any included modification, try these listed fixes:
#### Installing Visual C++ Redistributable
- Some included modifications requires this redist to operate. If you do not already have it installed, it can be found [here](https://aka.ms/vs/17/release/vc_redist.x64.exe).
#### Installing .NET Framework Redistributable
- Ambrosial requires .NET Framework in order to open. The download for it can be found [here](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net472-web-installer).

`If you require any other help, please open an issue.`

## Building from source
### Building the executable
- Ambrosial runs on .NET Framework 4.7.2, you will need to install the SDK for it before proceeding. Visual Studio 2022/2019 can be used for building Ambrosial.
- Once opened in Visual Studio, you will need to install multiple NuGET packages using the manager. The list of required packages are as listed:

  - [x] DiscordRichPresence
  - [x] Costura.Fody
  - [x] Newtonsoft.JSON
  - [x] Guna.UI2.WinForms
- Use the Build Solution option in Visual Studio to compile the executable. It is advised to compile on Release mode.

### Creating client collection for serialization/deserialization
- The developer form has tools to obtain the current encrypted collection string, decrypt string to obtain the raw JSON and encrypt string to encrypt raw JSON. If you know what you are doing, it is simple to edit the collection string. If you wish to change the web endpoint which it collects the string from, look at the `requestEnd` string property in `setupClients()` located inside the `.\Ambrosial\AmbrosialC.cs` file.
