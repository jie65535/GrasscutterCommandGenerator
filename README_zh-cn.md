# Grasscutter Tools

[![GitHub license](https://img.shields.io/github/license/jie65535/GrasscutterCommandGenerator)](https://github.com/jie65535/GrasscutterCommandGenerator/blob/main/LICENSE)
[![GitHub stars](https://img.shields.io/github/stars/jie65535/GrasscutterCommandGenerator)](https://github.com/jie65535/GrasscutterCommandGenerator/stargazers)
[![Github All Releases](https://img.shields.io/github/downloads/jie65535/GrasscutterCommandGenerator/total.svg)](https://github.com/jie65535/GrasscutterCommandGenerator/releases)
[![GitHub release](https://img.shields.io/github/v/release/jie65535/GrasscutterCommandGenerator)](https://github.com/jie65535/GrasscutterCommandGenerator/releases/latest)
[![Build](https://github.com/jie65535/GrasscutterCommandGenerator/actions/workflows/build.yml/badge.svg)](https://github.com/jie65535/GrasscutterCommandGenerator/actions/workflows/build.yml)
[![QQ Group](https://pub.idqqimg.com/wpa/images/group.png)](http://qm.qq.com/cgi-bin/qm/qr?_wv=1027&k=fBizzp6RwJsIY7gFlmd4L-WG0V3aF8X3&authKey=mTjf%2B7jCIZess1HTRi05e5yi%2FHKA1auMwE8%2FJ960PFWk8WMATST654gWPi4OTHTZ&noverify=0&group_code=835489603)

[English](README.md) | 简体中文 | [繁體中文](README_zh-tw.md) | [Русский](README_ru-RU.md)

## Commands Generator

请从 [Action](https://github.com/jie65535/GrasscutterCommandGenerator/actions/workflows/build.yml) 中下载最新提交的自动构建版本，或者从 [Releases](https://github.com/jie65535/GrasscutterCommandGenerator/releases) 中下载发布版本（可能落后）

本工具支持 简体中文, 繁體中文, English 与 Русский 语言。

> **Warning**: 应用程序的外观可能与截图上的不同。它也可能包含翻译错误和缺乏某些资源。**我们欢迎各位为此工具做出贡献并<a href="./Source/GrasscutterTools/Resources/zh-cn">改进</a> : )**

## 远程执行

服务端需要 [gc-opencommand-plugin](https://github.com/jie65535/gc-opencommand-plugin) 插件支持

![OpenCommand](Doc/Screenshots/OpenCommand.gif)

> 如果你无法连接到服务器，请确认填写的服务器地址是否正确。
> 
> 建议配置服务器为HTTP模式，如图所示(config.json)：
> ![ConfigHttp](Doc/Screenshots/ConfigHttp.png)
> 
> 你可以用浏览器访问 http://127.0.0.1/status/server 来测试服务是否正常工作。
> 
> 如果使用的不是`80`端口，则要在url中指定访问的端口号：http://127.0.0.1:443


## 更新概要

### GrasscutterTools-v1.13
![Proxy](Doc/Screenshots/22-Proxy.png)

![SceneTag](Doc/Screenshots/23-SceneTag.png)

![Weather](Doc/Screenshots/24-Weather.png)

![Settings](Doc/Screenshots/25-Settings.png)

### GrasscutterTools-v1.11
![HotKey](Doc/Screenshots/21-HotKey.png)

命令行用法:
```bash
GcTools.exe -help
GcTools.exe -version
GcTools.exe -c "cmd arg"
GcTools.exe -c "cmd1 arg" && GcTools -c "cmd2 arg1 arg2"
GcTools.exe -host http://127.0.0.1:443 -token 123456 -c "cmd1 arg1 arg2 | cmd2 | cmd3 arg"
```

### GrasscutterTools-v1.10
![Cutscene](Doc/Screenshots/7-ChangeScene.png)

![Activity Editor](Doc/Screenshots/20-ActivityEditor.png)

### GrasscutterTools-v1.9
![Achievement Page](Doc/Screenshots/19-AchievementPage.png)

### GrasscutterTools-v1.8
![Task page](Doc/Screenshots/18-TaskPage.png)

### GrasscutterTools-v1.7.3
![Spawns](Doc/Screenshots/6-SpawnEntity.png)

![AttackMod](Doc/Screenshots/6.1-AttackMod.png)

![AttackInfuse](Doc/Screenshots/6.2-AttackInfuse.png)

新增[攻击修改](https://github.com/NotThorny/AttackModifier)、[攻击注入](https://github.com/snoobi-seggs/AttackInfusedWithItem)、[切换元素](https://github.com/Penelopeep/SwitchElementTraveller)等插件命令生成

![AttackInfusedWithItem Gif](Doc/Screenshots/AttackMod.gif)

### GrasscutterTools-v1.7.2
![Shop Editor](Doc/Screenshots/17-ShopEditor.png)

### GrasscutterTools-v1.7.1
 - 增加了 Gadgets

### GrasscutterTools-v1.7.0

![Run Commands](Doc/Screenshots/RunMultipleCommands.png)

![Drop Editor](Doc/Screenshots/15-DropEditor.png)

![Mail Editor](Doc/Screenshots/16-MailEditor.png)

---

## 软件截图

![Logo](Doc/Screenshots/GrasscutterLogo.png)

![Home](Doc/Screenshots/0-Home.png)

![Custom Commands Screenshot](Doc/Screenshots/1-CustomCommands.png)

![Custom Artifact Screenshot](Doc/Screenshots/2-CustomArtifact.png)

![Custom Weapon Screenshort](Doc/Screenshots/3-CustomWeapon.png)

![Give Item Screenshort](Doc/Screenshots/4-GiveItem.png)

![Give Avatar Screenshort](Doc/Screenshots/5-GiveAvatar.png)

![Spawn Entity Screenshort](Doc/Screenshots/6-SpawnEntity.png)

![Change Scene Screenshort](Doc/Screenshots/7-ChangeScene.png)

![Management](Doc/Screenshots/9-Manage.png)

![GachaBannerEditor](Doc/Screenshots/10-GachaBannerEditor.png)

![Text Map Browser](Doc/Screenshots/11-TextMapBrowser.png)

![Remote Screenshort](Doc/Screenshots/12-Remote.png)

![Quest Screenshort](Doc/Screenshots/13-Quest.png)
