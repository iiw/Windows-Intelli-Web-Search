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

using Hardcodet.Wpf.TaskbarNotification;
using Intelli_Web_Search.TrayMenuItems;
using System.Windows;
using System.Windows.Controls;

namespace Intelli_Web_Search
{
    class Tray
    {
        private readonly MainWindow mWindow;
        private readonly TaskbarIcon tray;

        public Tray(MainWindow window)
        {
            mWindow = window;
            tray = new TaskbarIcon();
            tray.Icon = Properties.Resources.TrayIcon;
            tray.ToolTipText = "Intelli Web Search";
            tray.TrayLeftMouseDown += new RoutedEventHandler(HandleTrayLeftMouseButton);
            tray.ContextMenu = new ContextMenu();
            tray.ContextMenu.Items.Add(new StartupMenuItem(mWindow));
            tray.ContextMenu.Items.Add(new ExitMenuItem(mWindow));
        }

        private void HandleTrayLeftMouseButton(object sender, RoutedEventArgs args)
        {
            if (mWindow.IsForeground())
            {
                mWindow.HideWindow();
                return;
            }
            mWindow.ShowWindow();
        }
    }
}
