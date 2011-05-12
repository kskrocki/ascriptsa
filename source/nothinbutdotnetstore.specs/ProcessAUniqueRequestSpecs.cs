 using System.Web;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    [Subject(typeof(BasicRequestHandler))]
    public class BasicRequestHandlerSpecs
    {
        public abstract class concern : Observes<IHttpHandler, BasicRequestHandler>
        {
        
        }

        public class when_processing_an_incoming_http_context : concern
        {
            Establish c = () =>
            {
                front_controller = depends.on<IProcessApplicationRequests>();
                request_factory = depends.on<ICreateRequests>();
                the_created_request = fake.an<IContainRequestInformation>(); 

                an_incoming_http_context = ObjectFactory.web.create_http_context();

                request_factory.setup(x => x.create_request_from(an_incoming_http_context)).Return(the_created_request);
            };

            Because b = () =>
                sut.ProcessRequest(an_incoming_http_context);


            It should_delegate_processing_of_a_request_to_the_front_controller = () =>
                front_controller.received(x => x.process(the_created_request));


            static IProcessApplicationRequests front_controller;
            static IContainRequestInformation the_created_request;
            static HttpContext an_incoming_http_context;
            static ICreateRequests request_factory;
        }
    }
}
