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
using System.Net;
using System.Text.RegularExpressions;

namespace Intelli_Web_Search
{
    public class SearchUrlResolver
    {
        private String SearchYandex = "https://www.yandex.ru/search/?text={text}";
        private String SearchGoogle = "https://www.google.com/search?q={text}";

        public String GetUrl(String text)
        {
            String SearchLink = SearchGoogle;
            if (hasCyrillicChars(text))
            {
                SearchLink = SearchYandex;
            }
            return SearchLink.Replace("{text}", WebUtility.UrlEncode(text));
        }

        private bool hasCyrillicChars(String text)
        {
            return Regex.IsMatch(text, ".*[А-Яа-я]+.*");
        }
    }
}
