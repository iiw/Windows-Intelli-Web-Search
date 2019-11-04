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

using System.Windows;
using System.Windows.Controls;

namespace Intelli_Web_Search.TrayMenuItems
{
    class StartupMenuItem : MenuItem
    {
        private MainWindow mWindow;
        private readonly StartupSwitcher startupSwitcher;
        private bool isInitialized;
        public StartupMenuItem(MainWindow window)
        {
            isInitialized = false;
            Header = "Launch with Windows";
            mWindow = window;
            IsCheckable = true;
            startupSwitcher = new StartupSwitcher(mWindow);
            IsChecked = startupSwitcher.IsRegistered();
            isInitialized = true;
        }

        protected override void OnChecked(RoutedEventArgs e)
        {
            base.OnChecked(e);
            if (isInitialized)
            {
                startupSwitcher.Register();
            }
        }

        protected override void OnUnchecked(RoutedEventArgs e)
        {
            base.OnUnchecked(e);
            if (isInitialized)
            {
                startupSwitcher.Unregister();
            }
        }
    }
}
