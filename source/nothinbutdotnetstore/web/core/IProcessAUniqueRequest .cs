namespace nothinbutdotnetstore.web.core
{
    public interface IProcessOneUniqueRequest  : IProcessApplicationSpecificBehaviour
    {
        bool can_handle(IContainRequestInformation request);
    }
}