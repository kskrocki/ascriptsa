namespace nothinbutdotnetstore.web.core
{
    public class FrontController : IProcessApplicationRequests
    {
        IFindSpecificRequestHandlers command_registry;

        public FrontController(IFindSpecificRequestHandlers command_registry)
        {
            this.command_registry = command_registry;
        }

        public void process(IContainRequestInformation request)
        {
            command_registry.get_the_command_that_can_process(request).run(request);
        }
    }
}