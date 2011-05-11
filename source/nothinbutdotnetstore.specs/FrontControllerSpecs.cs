 using Machine.Specifications;
 using developwithpassion.specifications.moq;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.core;
 using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{   
    public class FrontControllerSpecs
    {
        public abstract class concern : Observes<IProcessApplicationRequests,
                                            FrontController>
        {
        
        }

        [Subject(typeof(FrontController))]
        public class when_processing_an_request : concern
        {
            Establish c = () =>
            {
                command_registry = depends.on<IFindSpecificRequestHandlers>();

                request = fake.an<IContainRequestInformation>();
                command_that_can_process_the_request = fake.an<IProcessOneUniqueRequest>();

                command_registry.setup(x => x.get_the_command_that_can_process(request)).Return(command_that_can_process_the_request);
            };

            Because b = () =>
                sut.process(request);

            It should_delegate_the_processing_to_the_command_that_can_run_the_request = () =>
                command_that_can_process_the_request.received(x => x.run(request));

            static IProcessOneUniqueRequest command_that_can_process_the_request;
            static IContainRequestInformation request;
            static IFindSpecificRequestHandlers command_registry;
        }
    }
}
