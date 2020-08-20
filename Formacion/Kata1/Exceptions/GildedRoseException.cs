using System;

namespace Kata1.Exceptions{
    public class GildedRoseException : Exception{
        public string MessageError{ get; }


        public GildedRoseException(string messageError){
            MessageError = messageError;
        }

    }
}