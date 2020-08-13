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


        [Test]
        public void when_we_add_amount_to_account_we_have_the_sum_with_balance() {
            var accountAction = GivenAnAccount(out var newAccount, out var initialBalance);
            var amount = 100;

            var actualAccount = accountAction.AddAmount(newAccount, amount);

            actualAccount.Balance.Should().Be(initialBalance + amount);
            

        }

        private static AccountAction GivenAnAccount(out Account newAccount, out double initialBalance){
            var dni = "anyDni";
            var accountAction = CreateAnAccount(out newAccount, dni);
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
