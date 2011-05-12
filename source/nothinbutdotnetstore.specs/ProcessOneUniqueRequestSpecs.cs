using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;
using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{
  public class ProcessOneUniqueRequestSpecs
  {
    public abstract class concern : Observes<IProcessOneUniqueRequest,
                                      ProcessOneUniqueRequest>
    {
    }

    [Subject(typeof(IProcessOneUniqueRequest))]
    public class when_determining_if_it_can_process_a_request : concern
    {
      public class and_it_can_proces_it : when_determining_if_it_can_process_a_request
      {
        Establish c = () =>
        {
            request = fake.an<IContainRequestInformation>();
            request.IsValid = true;
        };

        Because b = () =>
          result = sut.can_handle(request);

        It should_inform_us_that_it_can_handle = () =>
          result.ShouldBeTrue();

        static IContainRequestInformation request;
        static bool result;
      }

      public class and_it_cannot_process_it : when_determining_if_it_can_process_a_request
      {
        Establish c = () =>
        {
            request = fake.an<IContainRequestInformation>();
            request.IsValid = false;
        };

        Because b = () =>
          result = sut.can_handle(request);

        It should_inform_us_that_it_cannot_handle = () =>
          result.ShouldBeFalse();

        static IContainRequestInformation request;
        static bool result;
      }
    }
  }
}