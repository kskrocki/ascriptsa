 using developwithpassion.specifications.rhinomocks;
 using Machine.Specifications;
 using developwithpassion.specifications.extensions;
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
        public class when_processing_one_unique_request : concern
        {
            Establish c = () =>
            {
                request = fake.an<IContainRequestInformation>();
            };

            Because b = () =>
                result = sut.ProcessOneUniqueRequest.can_handle(request);

            It should_inform_us_that_it_can_handle = () =>
                result.Equals(true);


            static IContainRequestInformation request;
            static bool result;
        }
    }
}
