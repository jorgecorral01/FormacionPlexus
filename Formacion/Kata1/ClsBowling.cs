using System.CodeDom;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;

namespace Kata1{
    public class ClsBowling{
        private static int score;
        private static int theThrows;
        private static List<int> theThrowsScores;

        public ClsBowling(){
            score = 0;
            theThrows = 0;
            theThrowsScores = new List<int>();
        }
        public static void Roll(int numberPinsKnocked){
            theThrows += 1;
            if (theThrows % 2 == 0 && theThrowsScores[theThrows-2] == 10) {
                score += numberPinsKnocked;
            }else if (theThrows % 3 == 0 && theThrowsScores[theThrows - 3] == 10){
                score += numberPinsKnocked;
            }

            score += numberPinsKnocked;
            theThrowsScores.Add(numberPinsKnocked);
            
        }

        public static int Score(){
            return score;
        }
    }
}