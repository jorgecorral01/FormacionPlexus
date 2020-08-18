using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Kata1.Exceptions;

namespace Kata1 {
    public class ClsBowling2 {
        private List<int> theThrowsScores;

        public ClsBowling2() {
            theThrowsScores = new List<int>();
        }
       
        public int Score(){
            int score = 0;
            int frameIndex = 0;
            for(int frame = 0;frame < 10;frame++) {
                if(isSpare(frameIndex)) {
                    score += 10 + theThrowsScores[frameIndex + 2];
                    frameIndex += 2;
                }
                else if(isStrike(frameIndex)) {
                    score += 10 + theThrowsScores[frameIndex + 1] + theThrowsScores[frameIndex + 2];
                    frameIndex++;
                }
                else {
                    score += theThrowsScores[frameIndex] + theThrowsScores[frameIndex + 1];
                    frameIndex += 2;
                }

            }

            return score;
        }

        private bool isSpare(int frameIndex) {
            return theThrowsScores[frameIndex] + theThrowsScores[frameIndex + 1] == 10;
        }

        private bool isStrike(int frameIndex) {
            return theThrowsScores[frameIndex] == 10;
        }

        public void Roll(int[] numberPinsKnocked){
            foreach (var tirada in numberPinsKnocked){
                Roll(tirada);
            }

        }
        public void Roll(int numberPinsKnocked) {
            theThrowsScores.Add(numberPinsKnocked);
        }
    }
}