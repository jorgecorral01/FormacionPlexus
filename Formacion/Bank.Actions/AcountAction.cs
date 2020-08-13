using System;
using Bank.Actions.Dtos;

namespace Bank.Actions {

    public class CreateAcountAction {
        public Account CreateAccount(string dni) {
            return new Account{Dni = dni, Balance = 0};
        }
    }
}
