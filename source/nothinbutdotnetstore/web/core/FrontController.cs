using System;

namespace nothinbutdotnetstore.web.core
{
    public class FrontController : IProcessApplicationRequests
    {
        IFindSpecificRequestHandlers requestHandler;

        public FrontController(IFindSpecificRequestHandlers request_handler)
        {
            requestHandler = request_handler;
        }

        public void process(IContainRequestInformation request)
        {
            requestHandler.get_the_command_that_can_process(request).run(request);
        }

    }
}