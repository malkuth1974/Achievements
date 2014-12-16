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
using UnityEngine;
using Contracts;

namespace Achievements
{
    internal class ContractsFactory : AchievementFactory
    {
        public IEnumerable<Achievement> getAchievements()
        {
            return new Achievement[] {
                new ContractAllocations("Starting Your Adventure","Complete 1 Contract","Complete.Contracts.1",1),
                new ContractAllocations("Contract Enthusiast","Complete 20 Contracts","Complete.Contracts.20",20),
                new ContractAllocations("Grind Machine","Complete 100 Contracts","Complete.Contracts.100",100)
            };
        }

        public Category getCategory()
        {
            return Category.CONTRACTS;
        }
    }
    internal class ContractAllocations : AchievementBase
    {
        private string title;
        private string text;
        private string key;
        private int ContractAmounts;

        internal ContractAllocations(string title, string text, string key, int contractsAmount)
        {
            this.title = title;
            this.text = text;
            this.key = key;
            this.ContractAmounts = contractsAmount;           
        }

        public override bool check(Vessel vessel)
        {
            if (HighLogic.CurrentGame.Mode == Game.Modes.CAREER)
            {
                if (ContractSystem.Instance.ContractsFinished.Count >= ContractAmounts)
                {
                    return true;
                }
                else
                    return false;
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
