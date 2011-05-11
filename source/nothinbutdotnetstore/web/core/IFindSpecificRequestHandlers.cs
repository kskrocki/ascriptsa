namespace nothinbutdotnetstore.web.core
{
    public interface IFindSpecificRequestHandlers
    {
        IProcessOneUniqueRequest get_the_command_that_can_process(IContainRequestInformation request);
    }
}