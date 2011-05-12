namespace nothinbutdotnetstore.web.core
{
  public class ProcessOneUniqueRequest : IProcessOneUniqueRequest
  {
    IncomingRequestMeetsCriteria request_criteria;
    IProcessApplicationSpecificBehaviour application_specific_behaviour;

    public ProcessOneUniqueRequest(IncomingRequestMeetsCriteria request_criteria,
                                   IProcessApplicationSpecificBehaviour application_specific_behaviour)
    {
      this.request_criteria = request_criteria;
      this.application_specific_behaviour = application_specific_behaviour;
    }

    public void run(IContainRequestInformation request)
    {
      application_specific_behaviour.run(request);
    }

    public bool can_handle(IContainRequestInformation request)
    {
      return request_criteria(request);
    }
  }
}