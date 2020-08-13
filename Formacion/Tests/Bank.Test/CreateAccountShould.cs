using System;
using Bank.Actions;
using Bank.Actions.Dtos;
using FluentAssertions;
using NUnit.Framework;

namespace Bank.Test {
    public class CreateAccountShould {
        [Test]
        public void when_we_create_account_we_have_an_account_with_zero_balance(){
            var dni = "anyDni";
            var accountAction = new AccountAction();

            var actualAccount = accountAction.CreateAccount(dni);

            actualAccount.Balance.Should().Be(0);
            actualAccount.Dni.Should().Be(dni);

        }


        [TestCase("A1", 10000, 500)]
        [TestCase("A2", 500000,400)]
        public void when_we_add_amount_to_account_we_have_the_sum_with_balance(string dni, Double actualBalance,  double amount) {
            var accountAction = GivenAnAccount(out var newAccount, actualBalance, out var initialBalance, dni);

            var actualAccount = accountAction.AddAmount(newAccount, amount);

            actualAccount.Balance.Should().Be(initialBalance + amount);
            

        }

        private static AccountAction GivenAnAccount(out Account newAccount, double actualBalance, out double initialBalance, string dni){
            var accountAction = CreateAnAccount(out newAccount, dni);
            newAccount.Balance = actualBalance;
            initialBalance = newAccount.Balance;
            return accountAction;
        }

        private static AccountAction CreateAnAccount(out Account newAccount, string dni){
            var accountAction = new AccountAction();
            newAccount = accountAction.CreateAccount(dni);
            return accountAction;
        }
    }
}
