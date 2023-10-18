# Grasscutter Tools

[![GitHub license](https://img.shields.io/github/license/jie65535/GrasscutterCommandGenerator)](https://github.com/jie65535/GrasscutterCommandGenerator/blob/main/LICENSE)
[![GitHub stars](https://img.shields.io/github/stars/jie65535/GrasscutterCommandGenerator)](https://github.com/jie65535/GrasscutterCommandGenerator/stargazers)
[![Github All Releases](https://img.shields.io/github/downloads/jie65535/GrasscutterCommandGenerator/total.svg)](https://github.com/jie65535/GrasscutterCommandGenerator/releases)
[![GitHub release](https://img.shields.io/github/v/release/jie65535/GrasscutterCommandGenerator)](https://github.com/jie65535/GrasscutterCommandGenerator/releases/latest)
[![Build](https://github.com/jie65535/GrasscutterCommandGenerator/actions/workflows/build.yml/badge.svg)](https://github.com/jie65535/GrasscutterCommandGenerator/actions/workflows/build.yml)
[![QQ Group](https://pub.idqqimg.com/wpa/images/group.png)](http://qm.qq.com/cgi-bin/qm/qr?_wv=1027&k=fBizzp6RwJsIY7gFlmd4L-WG0V3aF8X3&authKey=mTjf%2B7jCIZess1HTRi05e5yi%2FHKA1auMwE8%2FJ960PFWk8WMATST654gWPi4OTHTZ&noverify=0&group_code=835489603)

[English](README.md) | [简体中文](README_zh-cn.md) | 繁體中文 | [Русский](README_ru-RU.md) 

## 指令產生工具

請從 [Action](https://github.com/jie65535/GrasscutterCommandGenerator/actions/workflows/build.yml) 中下載最新提交的自動構建版本，或者從 [Releases](https://github.com/jie65535/GrasscutterCommandGenerator/releases) 中下載發布版本（可能落後）

本工具支援 简体中文、繁體中文、English 及 Русский 上述語言。

> **Warning**: 程式中的實際外觀可能會與截圖中的內容不同。其中也可能包含翻譯錯誤及缺乏特定資源。**我們歡迎各位為此工具做出貢獻並[改進](/Source/GrasscutterTools/Resources/zh-tw)**

## 遠端控制

伺服器需要安裝 [gc-opencommand-plugin](https://github.com/jie65535/gc-opencommand-plugin) 插件

![OpenCommand](Doc/Screenshots-tw/OpenCommand.gif)

> 如果你無法連接至伺服器，請確認輸入的伺服器位址是否正確。
>
> 建議將伺服器調整為HTTP模式，如下圖所示(config.json):
> ![ConfigHttp](Doc/Screenshots-tw/ConfigHttp.png)
> 
> 你可藉由任何瀏覽器輸入網址 http://127.0.0.1/status/server 以測試伺服器是否正常運作。
>
> 如果你並非使用`80`端口, 則須在網址後輸入指定端口: http://127.0.0.1:443

## 更新日誌

### GrasscutterTools-v1.13
![Proxy](Doc/Screenshots/22-Proxy.png)

![SceneTag](Doc/Screenshots/23-SceneTag.png)

![Weather](Doc/Screenshots/24-Weather.png)

![Settings](Doc/Screenshots/25-Settings.png)

### GrasscutterTools-v1.11
![HotKey](Doc/Screenshots/21-HotKey.png)

Commandline Usages:
```bash
GcTools.exe -help
GcTools.exe -version
GcTools.exe -c "cmd arg"
GcTools.exe -c "cmd1 arg" && GcTools -c "cmd2 arg1 arg2"
GcTools.exe -host http://127.0.0.1:443 -token 123456 -c "cmd1 arg1 arg2 | cmd2 | cmd3 arg"
```

### GrasscutterTools-v1.10
![Cutscene](Doc/Screenshots-tw/7-ChangeScene.png)

![Activity Editor](Doc/Screenshots-tw/20-ActivityEditor.png)

### GrasscutterTools-v1.9
![Achievement Page](Doc/Screenshots-tw/19-AchievementPage.png)

### GrasscutterTools-v1.8
![Task page](Doc/Screenshots-tw/18-TaskPage.png)

### GrasscutterTools-v1.7.3
![Spawns](Doc/Screenshots-tw/6-SpawnEntity.png)

![AttackMod](Doc/Screenshots-tw/6.1-AttackMod.png)

![AttackInfuse](Doc/Screenshots-tw/6.2-AttackInfuse.png)

新增 [攻擊修改](https://github.com/NotThorny/AttackModifier)、[攻擊注入](https://github.com/snoobi-seggs/AttackInfusedWithItem)、[主角切換元素](https://github.com/Penelopeep/SwitchElementTraveller)等插件指令產生

![AttackInfusedWithItem Gif](Doc/Screenshots-tw/AttackMod.gif)

### GrasscutterTools-v1.7.2
![Shop Editor](Doc/Screenshots-tw/17-ShopEditor.png)

### GrasscutterTools-v1.7.1
 - 新增 Gadgets

### GrasscutterTools-v1.7.0

![Run Commands](Doc/Screenshots-tw/RunMultipleCommands.png)

![Drop Editor](Doc/Screenshots-tw/15-DropEditor.png)

![Mail Editor](Doc/Screenshots-tw/16-MailEditor.png)

---


## 工具截圖

![Logo](Doc/Screenshots-tw/GrasscutterLogo.png)

![Home](Doc/Screenshots-tw/0-Home.png)

![Custom Commands Screenshot](Doc/Screenshots-tw/1-CustomCommands.png)

![Custom Artifact Screenshot](Doc/Screenshots-tw/2-CustomArtifact.png)

![Custom Weapon Screenshort](Doc/Screenshots-tw/3-CustomWeapon.png)

![Give Item Screenshort](Doc/Screenshots-tw/4-GiveItem.png)

![Give Avatar Screenshort](Doc/Screenshots-tw/5-GiveAvatar.png)

![Spawn Entity Screenshort](Doc/Screenshots-tw/6-SpawnEntity.png)

![Change Scene Screenshort](Doc/Screenshots-tw/7-ChangeScene.png)

![Management](Doc/Screenshots-tw/9-Manage.png)

![GachaBannerEditor](Doc/Screenshots-tw/10-GachaBannerEditor.png)

![Text Map Browser](Doc/Screenshots-tw/11-TextMapBrowser.png)

![Remote Screenshort](Doc/Screenshots-tw/12-Remote.png)

![Quest Screenshort](Doc/Screenshots-tw/13-Quest.png)
