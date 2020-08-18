using System;

namespace Kata1.Exceptions{
    public class TrowsException:Exception{
        public readonly string MessageError;

        public TrowsException(string messageError){
            MessageError = messageError;
        }
    }
}