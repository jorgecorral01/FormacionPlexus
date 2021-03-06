﻿using System;
using Kata1.interfaces;

namespace Kata1{
    public class ClsSeason{
        private iClock Clock{ get; }

        public ClsSeason(iClock clock){
            Clock = clock;
        }

        public string GetSeason(){
            var date = Clock.Now();
            DateTime startSpring = Convert.ToDateTime("21/03/" + date.Year);
            DateTime finishSpring = Convert.ToDateTime("20/06/" + date.Year);
            DateTime startSummer = Convert.ToDateTime("21/06/" + date.Year);
            DateTime finishSummer = Convert.ToDateTime("21/09/" + date.Year);
            DateTime startAutumn = Convert.ToDateTime("22/09/" + date.Year);
            DateTime finishAutumn = Convert.ToDateTime("20/12/" + date.Year);

            if((date >= startSpring) && (date <= finishSpring)) {
                return "Spring";
            }
            if((date >= startSummer) && (date <= finishSummer)) {
                return "Summer";
            }
            if((date >= startAutumn) && (date <= finishAutumn)) {
                return "Autumn";
            }
            return "Winter";
        }
    }
}