using System;
using Bank.Actions.Dtos;

namespace Bank.Actions {

    public class AccountAction {
        public Account CreateAccount(string dni) {
            return new Account{Dni = dni, Balance = 0};
        }

        public Account AddAmount(Account account, double amount){
            account.Balance += amount;
            return account;
        }
    }
}
