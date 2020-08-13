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
    }
}
