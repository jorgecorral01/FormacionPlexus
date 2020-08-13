using System;
using Bank.Actions;
using FluentAssertions;
using NUnit.Framework;

namespace Bank.Test {
    public class CreateAcountShould {
        [Test]
        public void when_we_create_account_we_have_an_account_with_zero_balance(){
            var dni = "anyDni";
            var acountAction = new AcountAction();

            var actualAccount = acountAction.CreateAccount(dni);

            actualAccount.Balance.Should().Be(0);
            actualAccount.Dni.Should().Be(dni);

        }


        [Test]
        public void when_we_add_amount_to_account_we_have_the_sum_with_balance() {
            var dni = "anyDni";
            var acountAction = new AcountAction();
            var newAccount = acountAction.CreateAccount(dni);
            var initialBalance = newAccount.Balance;
            var amount = 100;
            var actualAccount = acountAction.AddAmount(newAccount, amount);

            actualAccount.Balance.Should().Be(initialBalance + amount);
            

        }

    }
}
