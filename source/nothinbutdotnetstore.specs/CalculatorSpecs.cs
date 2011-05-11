using System;
using System.Data;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Threading;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{
    public class CalculatorSpecs
    {
        public abstract class concern : Observes<Calculator>
        {
        }

        public class MyPrincipal : IPrincipal
        {
            bool result;

            public MyPrincipal(bool result)
            {
                this.result = result;
            }

            public bool IsInRole(string role)
            {
                return result;
            }

            public IIdentity Identity
            {
                get { return new GenericIdentity("sdfsd");}
            }
        }

        public class when_shutting_down_the_calculator_and_they_are_in_the_correct_security_group : concern
        {
            Establish c = () =>
            {
                current_principal = new MyPrincipal(true);

                spec.change(() => Thread.CurrentPrincipal).to(current_principal);
            };

            Because b = () =>
                sut.shut_down();

            It should_turn_off = () => { };

            static IPrincipal current_principal;
        }
        public class when_shutting_down_the_calculator_and_they_not_in_the_correct_security_group : concern
        {
            Establish c = () =>
            {
                current_principal = new MyPrincipal(false);

                spec.change(() => Thread.CurrentPrincipal).to(current_principal);
            };

            Because b = () =>
                spec.catch_exception(() =>sut.shut_down());

            It should_turn_off = () =>
            {
                spec.exception_thrown.ShouldBeAn<SecurityException>();
            };

            static IPrincipal current_principal;
        }

        public class when_attempting_to_add_a_negative_number : concern
        {
            Because b = () =>
                spec.catch_exception(() => sut.add(-2, 3));

            It should_throw_an_argument_exception = () =>
                spec.exception_thrown.ShouldBeAn<ArgumentException>();
        }

        public class when_adding_two_positive_numbers : concern
        {
            Establish c = () =>
            {
                connection = depends.on<IDbConnection>();
                command = fake.an<IDbCommand>();

                connection.setup(x => x.CreateCommand()).Return(command);
            };

            Because b = () =>
                result = sut.add(2, 3);

            It should_return_the_sum = () =>
                result.ShouldEqual(5);

            It should_open_a_connection_to_the_database = () =>
                connection.received(x => x.Open());

            It should_run_a_command = () =>
                command.received(x => x.ExecuteNonQuery());


            static IDbConnection connection;
            static int result;
            static IDbCommand command;
        }
    }

    public class Calculator
    {
        IDbConnection connection;

        public Calculator(IDbConnection connection, int number, int number2)
        {
            this.connection = connection;
        }

        public int add(int first_number, int second_number)
        {
            enusure_no_negatives(first_number, second_number);
            connection.Open();
            connection.CreateCommand().ExecuteNonQuery();
            return first_number + second_number;
        }

        void enusure_no_negatives(params int[] numbers)
        {
            if (numbers.Any(x => x < 0)) throw new ArgumentException();
        }

        public void shut_down()
        {
            if (Thread.CurrentPrincipal.IsInRole("blah")) return;
            throw new SecurityException();
        }
    }
}