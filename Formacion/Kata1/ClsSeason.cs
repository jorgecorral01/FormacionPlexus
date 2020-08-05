using System;

namespace Kata1{
    public class ClsSeason{
        public string GetSeason( DateTime date){
            DateTime inicioVerano = Convert.ToDateTime("21/06/" + date.Year);
            DateTime finVerano = Convert.ToDateTime("21/09/" + date.Year);

            if((date >= inicioVerano) && (date <= finVerano)) {
                return "Summer";
            }
            
            return null;
        }
    }
}