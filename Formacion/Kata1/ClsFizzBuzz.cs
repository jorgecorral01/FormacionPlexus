using System;

namespace Kata1{
    public class ClsFizzBuzz{
        public string EsDivisiblePor(int number){
            if(number % 3 == 0 && number % 5 == 0) {
                return "fizzbuzz";
            }
            if (number % 3 == 0){
                return "fizz";
            }
            if(number % 5 == 0) {
                return "buzz";
            }
            return number.ToString(); 
        }
    }
}