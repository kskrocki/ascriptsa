using developwithpassion.specifications.extensions;
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
      Establish c = () =>
      {
        request = fake.an<IContainRequestInformation>();
        the_result_returned_by_the_specification = true;
        depends.on<IncomingRequestMeetsCriteria>(x =>
        {
          specification_was_leveraged = true;
          return true;
        });
      };

      Because b = () =>
        result = sut.can_handle(request);

      It should_make_its_determination_by_using_its_request_specification =
        () =>
        {
          specification_was_leveraged.ShouldBeTrue();
          result.ShouldEqual(the_result_returned_by_the_specification);
        };

      static IContainRequestInformation request;
      static bool result;
      static bool the_result_returned_by_the_specification;
      static bool specification_was_leveraged;
    }

    public class when_running_a_request : concern
    {
      Establish c = () =>
      {
        application_behaviour = depends.on<IProcessApplicationSpecificBehaviour>();
        request = fake.an<IContainRequestInformation>();
      };

      Because b = () =>
        sut.run(request);

      It should_run_the_application_specific_behaviour =
        () => { application_behaviour.received(x => x.run(request)); };

      static IContainRequestInformation request;
      static IProcessApplicationSpecificBehaviour application_behaviour;
    }
  }
}