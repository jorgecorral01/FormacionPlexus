using System.CodeDom;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Kata1.Exceptions;

namespace Kata1 {
    public class ClsBowling {
        private static int score;
        private static int theThrows;
        private static List<int> theThrowsScores;

        public ClsBowling() {
            score = 0;
            theThrows = 0;
            theThrowsScores = new List<int>();
        }
        public static async Task<int> Roll(int numberPinsKnocked) {
            await Task.Delay(1);
            theThrows += 1;
            if(theThrows == 11 && (!IsSpare() && !IsStrike())) {
                throw new TrowsException("Only ten throws");
            }

            if(theThrows >= 2 && IsStrike() || theThrows >= 3 && IsStrike()) {
                score += numberPinsKnocked;
            }
            if(theThrows >= 3 && IsSpare()) {
                score += numberPinsKnocked;
            }
            
            score += numberPinsKnocked;
            theThrowsScores.Add(numberPinsKnocked);
            return 0;
        }

        private static bool IsSpare() {
            return (theThrowsScores[theThrows - 2] + theThrowsScores[theThrows - 3] == 10 || theThrowsScores[theThrows - 3] == 10);
        }

        private static bool IsStrike() {
            return (theThrowsScores[theThrows - 2] == 10) || (theThrows >= 3 && theThrowsScores[theThrows - 3] == 10);
        }

        public static int Score() {
            return score;
        }
    }
}