# Snow-Flash-Tool

## About
* A tool to flash, unlock bootloader, and more on Android
* Status: Working
* Maintainer: SnowTalking <snowtalking13@gmail.com>

## Requirements
* Windows, Linux or Mac 64-bit. Won't work on M1s
* An Android phone

## Support
* [GitHub Issues](https://github.com/SnowTalking/Snow-Flash-Tool/issues)
* [Telegram Discussion Thread](https://t.me/snowflashtooldiscussion)
* [Telegram Tread](https://t.me/snowflashtool)

# Notes
* Mac users will need to build themselves
* This has not been tested on a Mac. We don't have a Mac.
* This project won't work with .NET 5.0 because the person who ported this to Linux is too lazy to refactor it.
* We packaged binaries to a .deb ourselves. If you build on Linux, (and maybe MacOS), it will NOT give a deb package

## Build Requirements
### Windows
* Install VS 2019 and Windows Build Tools 2019 with .NET Core Development Pack
### Linux
* Install the dotnet-sdk-3.1 package from Microsoft's Repositories
### Mac
* Install .NET SDK 3.1 from Microsoft's Website

## Build Instructions
* Fufill the Build Requirements (Above)
* `cd` into the directory of the `.sln` file.
* Run `dotnet build`
* Output is in `./Snow-Flash-Tool/bin/Debug/netcoreapp3.1/`

## Screenshots
![image](https://user-images.githubusercontent.com/71605881/118374704-9f24c200-b58b-11eb-8a56-20c3cfbd4ed7.png)

## Downloads
* [Android File Host](https://androidfilehost.com/?w=files&flid=325135)
* [GitHub Releases](https://github.com/SnowTalking/Snow-Flash-Tool/releases)
