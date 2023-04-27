# No Man's Sky Legacy Version Installer
![nms_legacy_installer_screenshot](https://user-images.githubusercontent.com/21266513/234724944-f7d49817-db78-405c-a3d5-8692f911a2d8.png)

No Man's Sky Legacy Version Installer is a fan-made application designed to facilitate the installation of older versions of the game No Man's Sky. This application is intended for use by individuals who wish to experience older versions of the game who have purchased the game on Steam and is not affiliated with the game's developers or publishers.

The project is made in support of our community at [No Man's Sky Retro](https://nomansskyretro.com).

## Disclaimer

- This application does not contain any game data, and only serves as a tool to download the game from Steam. The user must have a valid, purchased copy of the game and provide their own Steam account details to use this application.

- The removal of DRM measures in the application is done solely for the purpose of allowing the older version of the game to function and is not intended to encourage or support piracy. The creators of the application do not condone or support piracy, and users are reminded that it is illegal to distribute or use pirated software.

- The use of this application is at the user's own risk, and the creators of the application cannot be held responsible for any damages that may result from its use. This includes, but is not limited to, any damage to the user's computer, loss of data, or legal repercussions.

## Usage

To use the No Man's Sky Legacy Version Installer, follow these steps:

1. Download the application from the [Releases](https://github.com/qjimbo/NMSLegacyVersionInstaller/releases)  page.
2. Choose the versions of the game you wish to install.
3. Launch the application and provide your Steam account details.
4. Wait for the download and installation process to complete.
5. Launch No Man's Sky using the provided shortcuts.

## Third-party Tools Used
The installer uses the third-party tool [DepotDownloader](https://github.com/SteamRE/DepotDownloader) to download the game from Steam, followed by the [Goldburg Emulator Project](https://gitlab.com/Mr_Goldberg/goldberg_emulator)'s steam_api64.dll and [Steamless](https://github.com/atom0s/Steamless) to allow the game to run properly.

Additionally the [ConsoleControl](https://github.com/dwmkerr/consolecontrol) and [Costura.Fody](https://github.com/Fody/Costura) libraries are used to handle command line input and output and consolidate the application into a single executable file.

## Contributing

The project is written in C# .NET 4.6.

If you encounter any issues while using the No Man's Sky Legacy Version Installer or have suggestions for improvement, please [open an issue](https://github.com/qjimbo/NMSLegacyVersionInstaller/issues) on the GitHub repository. Pull requests are also welcome.

## License

The No Man's Sky Legacy Version Installer is released under the [MIT License](https://github.com/qjimbo/NMSLegacyVersionInstaller/LICENSE).
