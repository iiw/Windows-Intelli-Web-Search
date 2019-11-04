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

using NHotkey;
using NHotkey.Wpf;
using System;
using System.Windows.Input;

namespace Intelli_Web_Search
{
    class AppHotkeysManager
    {
        private readonly MainWindow mWindow;
        private readonly SearchActions searchActions;

        public AppHotkeysManager(MainWindow window)
        {
            mWindow = window;
            mWindow.PreviewKeyDown += new KeyEventHandler(HandleKeys);
            HotkeyManager.Current.AddOrReplace("Increment", Key.F2, ModifierKeys.None, new EventHandler<HotkeyEventArgs>(HandleGlobalHotkeys));
            searchActions = new SearchActions();
        }
        private void HandleKeys(object sender, KeyEventArgs args)
        {
            if (args.Key == Key.Escape)
            {
                mWindow.HideWindow();
            }

            if (args.Key == Key.Enter)
            {
                searchActions.DoSearch(mWindow.GetSearchText());
                mWindow.HideWindow();
            }
        }

        private void HandleGlobalHotkeys(object sender, HotkeyEventArgs args)
        {
            if (mWindow.IsActive)
            {
                mWindow.HideWindow();
            }
            else
            {
                mWindow.ShowWindow();
            }
        }
    }
}
