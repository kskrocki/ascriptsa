using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(ViewTheMainDepartmentsInTheStore))]
  public class ViewTheMainDepartmentsInTheStoreSpecs
  {
    public abstract class concern : Observes<IProcessApplicationSpecificBehaviour,
                                      ViewTheMainDepartmentsInTheStore>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestInformation>();

          list_of_main_depts = depends.on<IListOfMainDepts>();
          displayer = depends.on<IDisplayData>();
      };

      Because b = () =>
        sut.run(request);


      It should_find_the_main_depts_for_the_store = () => list_of_main_depts.received(x => x.Load()) ;       

                                        /* find the main depts
                                         * display the main depts
                                         * provide access to the list of main depts
                                         * return a list of main depts
                                         * prepare a list of main depts and forward to a view of the list
                                         */

      It should_display_the_main_depts_for_the_store = () => /* "for_the_store" repeating ourselves? */
      {
          displayer.received(x => x.Display(list_of_main_depts));
      }; 

      static IContainRequestInformation request;
        static IListOfMainDepts list_of_main_depts;
        static IDisplayData displayer;
    }
  }

    public interface IDisplayData
    {
        void Display(IListOfMainDepts list_of_main_depts);
    }

    public interface IListOfMainDepts
    {
        void Load();
    }
}