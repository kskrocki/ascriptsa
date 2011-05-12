using System;

namespace nothinbutdotnetstore.web.core.stubs
{
  public class StubMissingRequestHandler
  {
    public static MissingHandlerFactory create()
    {
      return () => { throw new NotImplementedException(); };
    }
  }
}