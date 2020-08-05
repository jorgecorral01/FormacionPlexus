using System;

namespace Kata1{
    public class ClsSeason{
        public string GetSeason( DateTime date){
            DateTime startSpring = Convert.ToDateTime("21/03/" + date.Year);
            DateTime finishSpring = Convert.ToDateTime("20/06/" + date.Year);
            DateTime startSummer = Convert.ToDateTime("21/06/" + date.Year);
            DateTime finishSummer = Convert.ToDateTime("21/09/" + date.Year);

            if((date >= startSpring) && (date <= finishSpring)) {
                return "Spring";
            }
            if((date >= startSummer) && (date <= finishSummer)) {
                return "Summer";
            }
            return null;
        }
    }
}