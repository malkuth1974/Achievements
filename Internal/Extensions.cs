/*
Achievements - Brings achievements to Kerbal Space Program.
Copyright (C) 2013-2014 Maik Schreiber

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Achievements {
	internal static class Extensions {
		internal static bool between(this double d, double bound1, double bound2) {
			return ((d >= bound1) && (d <= bound2)) || ((d >= bound2) && (d <= bound1));
		}

		internal static int getValuesCount(this Dictionary<Category, IEnumerable<Achievement>> achievements) {
			int count = 0;
			foreach (IEnumerable<Achievement> categoryAchievements in achievements.Values) {
				count += categoryAchievements.Count();
			}
			return count;
		}

		internal static double south(this double d) {
			return -d;
		}

		internal static double north(this double d) {
			return d;
		}

		internal static double west(this double d) {
			return -d;
		}

		internal static double east(this double d) {
			return d;
		}
	}
}
