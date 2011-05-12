namespace nothinbutdotnetstore.web.core
{
  public interface IProcessApplicationSpecificBehaviour 
  {
    void run(IContainRequestInformation request);
  }
}