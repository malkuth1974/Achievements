/*
Achievements - Brings achievements to Kerbal Space Program.
Copyright (C) 2013-2014 Maik Schreiber && Danny Moffre

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
using UnityEngine;

namespace Achievements
{
    internal class ReputationFactory : AchievementFactory
    {
        public IEnumerable<Achievement> getAchievements()
        {
            return new Achievement[] {
				new ReputationAllocations("Fame And Glory","Achieve at least 400 points in reputation","reputation.fame.400",400f,false),
                new ReputationAllocations("God Among Kerbals","Achieve at Least 800 points in reputation","reputation.fame.800",800f,false),
                new ReputationAllocations("The Devil Wears Prada","Achieve below -400 in reputation","reputation.fame.-400",-400f,true)
			};
        }

        public Category getCategory()
        {
            return Category.REPUTATION;
        }
    }
    internal class ReputationAllocations : AchievementBase
    {
        private string title;
        private string text;
        private string key;
        private float repAmount;
        private bool negCheck;

        internal ReputationAllocations(string title, string text, string key, float fundsAmount,bool negCheck)
        {
            this.title = title;
            this.text = text;
            this.key = key;
            this.repAmount = fundsAmount;
            this.negCheck = negCheck;
        }

        public override bool check(Vessel vessel)
        {
            if (Reputation.Instance.reputation >= repAmount && !negCheck)
            {
                return true;
            }
            else if (Reputation.Instance.reputation <= repAmount && negCheck)
            {
                return true;
            }
            else
                return false;
        }

        public override string getTitle()
        {
            return title;
        }
        public override string getText()
        {
            return text;
        }
        public override string getKey()
        {
            return key;
        }
    }
}
