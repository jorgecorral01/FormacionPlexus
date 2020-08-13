﻿using System;
using System.Threading.Tasks;
using Bank.Actions.Dtos;
using MiAPI.Business.Exceptions;

namespace Bank.Actions {

    public class AccountAction {
        public Account CreateAccount(string dni) {
            return new Account{Dni = dni, Balance = 0};
        }

        public async Task<Account> AddAmount(Account account, double amount){
            if (amount <= 0){ throw new AmountException();}
            await Task.Delay(1);
            account.Balance += amount;
            return account;
        }
    }
}
