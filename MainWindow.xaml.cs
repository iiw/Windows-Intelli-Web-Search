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

using System;
using System.Threading.Tasks;
using System.Windows;

namespace Intelli_Web_Search
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Tray mTray;
        private AppHotkeysManager appHotkeysManager;
        private long DeactivatedTime;

        public MainWindow()
        {
            InitializeComponent();
            mTray = new Tray(this);
            appHotkeysManager = new AppHotkeysManager(this);
            SearchBox.Focus();
        }

        public string GetSearchText()
        {
            return SearchBox.Text;
        }

        public void ClearSearchText()
        {
            SearchBox.Text = "";
        }

        public async void HideWindow()
        {
            ClearSearchText();
            await Task.Delay(50);
            Hide();
        }

        public void ShowWindow()
        {
            Show();
            Activate();
            SearchBox.Focus();
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            DeactivatedTime = GetCurrentTimeUtcMS();
            HideWindow();
        }

        private long GetCurrentTimeUtcMS()
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(DateTime.UtcNow - epoch).TotalMilliseconds;
        }

        public bool IsForeground()
        {
            return GetCurrentTimeUtcMS() < DeactivatedTime + 250;
        }
    }
}
