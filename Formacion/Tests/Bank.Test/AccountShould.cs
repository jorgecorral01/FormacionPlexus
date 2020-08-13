using System;
using System.Threading.Tasks;
using Bank.Actions;
using Bank.Actions.Dtos;
using FluentAssertions;
using MiAPI.Business.Exceptions;
using NUnit.Framework;

namespace Bank.Test {
    public class AccountShould {

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
        public async Task when_we_add_amount_to_account_we_have_the_sum_with_balance(string dni, Double actualBalance,  double amount) {
            var accountAction = GivenAnAccount(out var newAccount, actualBalance, out var initialBalance, dni);

            var actualAccount = await accountAction.AddAmount(newAccount, amount);

            actualAccount.Balance.Should().Be(initialBalance + amount);
            

        }

        [Test]
        public void when_we_add_negative_amount_we_have_a_amount_exception(){
            var accountAction = GivenAnAccount(out var newAccount, 4000, out var initialBalance, "1r");
            var amount = -1100;
            
            Func<Task> action = async () => await accountAction.AddAmount(newAccount, amount);

            action.Should().ThrowExactly<AmountException>().Which.MessageError.Should().Be("The amount must be greater than zero");

        }

        [TestCase(1100.111D)]
        [TestCase(1100.1111D)]
        public void when_we_add_amount_without_two_decimals_we_have_a_amount_exception(double amount) {
            var accountAction = GivenAnAccount(out var newAccount, 4000, out var initialBalance, "1r");
            

            Func<Task> action = async () => await accountAction.AddAmount(newAccount, amount);

            action.Should().ThrowExactly<AmountException>().Which.MessageError.Should().Be("The amount must be have two decimals");

        }

        [Test]
        public void when_we_add_amount_greater_than_6000_we_have_a_amount_exception() {
            var accountAction = GivenAnAccount(out var newAccount, 4000, out var initialBalance, "1r");
            double amount = 6000.1D;

            Func<Task> action = async () => await accountAction.AddAmount(newAccount, amount);

            action.Should().ThrowExactly<AmountException>().Which.MessageError.Should().Be("The amount mustn't greater than 6000€");

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
