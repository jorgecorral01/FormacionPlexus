using System;

namespace MiAPI.Business.Exceptions{
    public class AmountException :Exception{
        public readonly string MessageError;

        public AmountException(string messageError){
            MessageError = messageError;
        }
    }
}