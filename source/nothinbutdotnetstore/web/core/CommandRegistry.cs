using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class CommandRegistry : IFindSpecificRequestHandlers
    {
      IEnumerable<IProcessOneUniqueRequest> handlers;

      public CommandRegistry():this(new StubSetOfCommands(),
        StubMissingRequestHandler.create())
      {
      }

      MissingHandlerFactory missing_handler_factory;

        public CommandRegistry(IEnumerable<IProcessOneUniqueRequest> handlers,
                               MissingHandlerFactory missing_handler_factory)
        {
            this.handlers = handlers;
            this.missing_handler_factory = missing_handler_factory;
        }

        public IProcessOneUniqueRequest get_the_command_that_can_process(IContainRequestInformation request)
        {
            return handlers.FirstOrDefault(x => x.can_handle(request)) ?? missing_handler_factory();
        }
    }
}