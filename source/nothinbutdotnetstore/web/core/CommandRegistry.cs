using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class CommandRegistry : IFindSpecificRequestHandlers
    {
        IEnumerable<IProcessOneUniqueRequest> handlers;

        public CommandRegistry(IEnumerable<IProcessOneUniqueRequest> handlers)
        {
            this.handlers = handlers;
        }

        public IProcessOneUniqueRequest get_the_command_that_can_process(IContainRequestInformation request)
        {
            return handlers.First(x => x.can_handle(request));
        }
    }
}