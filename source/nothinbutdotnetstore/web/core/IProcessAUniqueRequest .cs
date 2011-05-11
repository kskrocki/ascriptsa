namespace nothinbutdotnetstore.web.core
{
    public interface IProcessOneUniqueRequest 
    {
        void run(IContainRequestInformation request);
        bool can_handle(IContainRequestInformation request);
    }
}