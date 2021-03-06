﻿using System;
using System.Reflection;
using KaiHelper.Activator;
using KaiHelper.Tracker;
using LeagueSharp;
using LeagueSharp.Common;

namespace KaiHelper
{
    internal class Program
    {
        public static Menu MainMenu;

        private static void Main(string[] args)
        {
            MainMenu = new Menu("【無為汉化】kaigan多功能", "KaiHelp", true);
            Menu ActivatorMenu = MainMenu.AddSubMenu(new Menu("活化剂", "Activator"));
            new AutoPot(ActivatorMenu);
            Menu Tracker = MainMenu.AddSubMenu(new Menu("跟踪器", "Tracker"));
            new SkillBar(Tracker);
            new GankDetector(Tracker);
            new WayPoint(Tracker);
            new WardDetector(Tracker);
            new HealthTurret(Tracker);
            Menu Timer = MainMenu.AddSubMenu(new Menu("计时器", "Timer"));
            new JungleTimer(Timer);
            Menu Range = MainMenu.AddSubMenu(new Menu("范围", "Range"));
            new Vision(Range);
            MainMenu.AddToMainMenu();
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            bool hasUpdate = Helper.HasNewVersion(Assembly.GetExecutingAssembly().GetName().Name);
            Game.PrintChat(
                "-------------------------------------------------------------------------------------------");
            if (hasUpdate)
            {
                Game.PrintChat(
                    "<font color = \"#ff002b\">A new version of KaiHelper is available. Please check for updates!</font>");
            }
            Game.PrintChat("<font color = \"#00FF2B\">KaiHelper</font> by <font color = \"#FD00FF\">kaigan</font>");
            Game.PrintChat(
                "<font color = \"#0092FF\">Feel free to donate via Paypal to:</font> <font color = \"#F0FF00\">ntanphat2406@gmail.com</font>");
            Game.PrintChat("KaiHelper - Loaded!");
            Game.PrintChat(
                "-------------------------------------------------------------------------------------------");
        }
    }
}