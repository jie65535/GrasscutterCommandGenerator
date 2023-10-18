# Grasscutter Tools

[![GitHub license](https://img.shields.io/github/license/jie65535/GrasscutterCommandGenerator)](https://github.com/jie65535/GrasscutterCommandGenerator/blob/main/LICENSE)
[![GitHub stars](https://img.shields.io/github/stars/jie65535/GrasscutterCommandGenerator)](https://github.com/jie65535/GrasscutterCommandGenerator/stargazers)
[![Github All Releases](https://img.shields.io/github/downloads/jie65535/GrasscutterCommandGenerator/total.svg)](https://github.com/jie65535/GrasscutterCommandGenerator/releases)
[![GitHub release](https://img.shields.io/github/v/release/jie65535/GrasscutterCommandGenerator)](https://github.com/jie65535/GrasscutterCommandGenerator/releases/latest)
[![Build](https://github.com/jie65535/GrasscutterCommandGenerator/actions/workflows/build.yml/badge.svg)](https://github.com/jie65535/GrasscutterCommandGenerator/actions/workflows/build.yml)
[![QQ Group](https://pub.idqqimg.com/wpa/images/group.png)](http://qm.qq.com/cgi-bin/qm/qr?_wv=1027&k=fBizzp6RwJsIY7gFlmd4L-WG0V3aF8X3&authKey=mTjf%2B7jCIZess1HTRi05e5yi%2FHKA1auMwE8%2FJ960PFWk8WMATST654gWPi4OTHTZ&noverify=0&group_code=835489603)

English | [简体中文](README_zh-cn.md) | [繁體中文](README_zh-tw.md) | [Русский](README_ru-RU.md)

## Commands Generator

Please download the latest committed automated build from [Action](https://github.com/jie65535/GrasscutterCommandGenerator/actions/workflows/build.yml), or a release from [Releases](https://github.com/jie65535/GrasscutterCommandGenerator/releases) (may be behind)

Support 简体中文, 繁體中文, English and Русский languages.

> **Warning**: app look may be different rather than on screenshots. It may also contain translation errors and a lack of certain resources. **We're welcome everyone to contribute to their [improvement](/Source/GrasscutterTools/Resources/en-us)**

## Remote command

The server require [gc-opencommand-plugin](https://github.com/jie65535/gc-opencommand-plugin) support

![OpenCommand](Doc/Screenshots/OpenCommand.gif)

> If you cannot connect to the server, please make sure the server address is correct.
>
> It is recommended to configure the server to HTTP mode, as shown in the figure(config.json):
> ![ConfigHttp](Doc/Screenshots/ConfigHttp.png)
> 
> You can visit http://127.0.0.1/status/server with a browser to test whether the service is working properly.
>
> If you are not using port `80`, specify the port number to access in the url: http://127.0.0.1:443

## Update log

### GrasscutterTools-v1.13
![Proxy](Doc/Screenshots-en/22-Proxy.png)

![SceneTag](Doc/Screenshots-en/23-SceneTag.png)

![Weather](Doc/Screenshots-en/24-Weather.png)

![Settings](Doc/Screenshots-en/25-Settings.png)

### GrasscutterTools-v1.11
![HotKey](Doc/Screenshots-en/21-HotKey.png)

Commandline Usages:
```bash
GcTools.exe -help
GcTools.exe -version
GcTools.exe -c "cmd arg"
GcTools.exe -c "cmd1 arg" && GcTools -c "cmd2 arg1 arg2"
GcTools.exe -host http://127.0.0.1:443 -token 123456 -c "cmd1 arg1 arg2 | cmd2 | cmd3 arg"
```

### GrasscutterTools-v1.10
![Cutscene](Doc/Screenshots-en/7-ChangeScene.png)

![Activity Editor](Doc/Screenshots-en/20-ActivityEditor.png)

### GrasscutterTools-v1.9
![Achievement Page](Doc/Screenshots-en/19-AchievementPage.png)

### GrasscutterTools-v1.8
![Task page](Doc/Screenshots-en/18-TaskPage.png)

### GrasscutterTools-v1.7.3
![Gadget](Doc/Screenshots-en/6-SpawnEntity.png)

Added [AttackModifier](https://github.com/NotThorny/AttackModifier), [AttackInfusedWithItem](https://github.com/snoobi-seggs/AttackInfusedWithItem), [SwitchElementTraveller](https://github.com/Penelopeep/SwitchElementTraveller) plugins command generation

![AttackInfusedWithItem Gif](Doc/Screenshots/AttackMod.gif)

### GrasscutterTools-v1.7.2
![Shop Editor](Doc/Screenshots-en/17-ShopEditor.png)

### GrasscutterTools-v1.7.1
 - Gadgets(CHS Only)

### GrasscutterTools-v1.7.0

![Run Commands](Doc/Screenshots/RunMultipleCommands.png)

![Drop Editor](Doc/Screenshots-en/15-DropEditor.png)

![Mail Editor](Doc/Screenshots-en/16-MailEditor.png)

---


## Screenshots

![Logo](Doc/Screenshots/GrasscutterLogo.png)

![Home](Doc/Screenshots-en/0-Home.png)

![Custom Commands Screenshot](Doc/Screenshots-en/1-CustomCommands.png)

![Custom Artifact Screenshot](Doc/Screenshots-en/2-CustomArtifact.png)

![Custom Weapon Screenshort](Doc/Screenshots-en/3-CustomWeapon.png)

![Give Item Screenshort](Doc/Screenshots-en/4-GiveItem.png)

![Give Avatar Screenshort](Doc/Screenshots-en/5-GiveAvatar.png)

![Spawn Entity Screenshort](Doc/Screenshots-en/6-SpawnEntity.png)

![Change Scene Screenshort](Doc/Screenshots-en/7-ChangeScene.png)

![Management](Doc/Screenshots-en/9-Manage.png)

![GachaBannerEditor](Doc/Screenshots-en/10-GachaBannerEditor.png)

![Text Map Browser](Doc/Screenshots-en/11-TextMapBrowser.png)

![Remote Screenshort](Doc/Screenshots-en/12-Remote.png)

![Quest Screenshort](Doc/Screenshots-en/13-Quest.png)
