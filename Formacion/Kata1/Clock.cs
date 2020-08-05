using System;
using Kata1.interfaces;

namespace Kata1{
    public class Clock : iClock{
        public DateTime Now(){
            return DateTime.Now; 
        }
    }
}