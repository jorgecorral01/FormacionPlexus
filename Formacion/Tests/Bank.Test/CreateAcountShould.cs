using System;
using Bank.Actions;
using FluentAssertions;
using NUnit.Framework;

namespace Bank.Test {
    public class CreateAcountShould {
        [Test]
        public void when_we_create_account_we_have_an_account_with_zero_money(){
            var dni = "anyDni";
            var createAcountAction = new CreateAcountAction();

            var actualAccount = createAcountAction.CreateAccount(dni);

            actualAccount.Balance.Should().Be(0);
            actualAccount.Dni.Should().Be(dni);

        }
    }
}
