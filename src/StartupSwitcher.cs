/**
 * Copyright © 2019 Victor Buzanov
 * 
 * 
 * This file is part of Intelli Web Search.
 *
 * Intelli Web Search is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Intelli Web Search is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Intelli Web Search.  If not, see <https://www.gnu.org/licenses/>.
 */

using Microsoft.Win32;
using System;
using System.Reflection;


namespace Intelli_Web_Search
{
    public class StartupSwitcher
    {
        private readonly MainWindow mWindow;
        private const string KEY_NAME = "Intelli Web Search";
        public StartupSwitcher(MainWindow window)
        {
            mWindow = window;
        }

        public void Register()
        {
            RegistryKey registryKey = OpenStartupRegistryKey();
            registryKey.SetValue(KEY_NAME, GetExeLocation());
        }

        public void Unregister()
        {
            RegistryKey registryKey = OpenStartupRegistryKey();
            registryKey.DeleteValue(KEY_NAME);
        }

        public bool IsRegistered()
        {
            RegistryKey key = OpenStartupRegistryKey();
            object value = key.GetValue(KEY_NAME);
            if (value == null)
            {
                return false;
            }
            return value.ToString().Equals(GetExeLocation());
        }

        private string GetExeLocation()
        {
            Console.WriteLine("Assembly.GetExecutingAssembly().Location " + Assembly.GetExecutingAssembly().Location);
            return Assembly.GetExecutingAssembly().Location;
        }

        private RegistryKey OpenStartupRegistryKey()
        {
            return Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        }
    }
}
