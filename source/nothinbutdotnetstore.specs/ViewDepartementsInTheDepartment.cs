 using System;
 using System.Collections.Generic;
 using developwithpassion.specifications.rhinomocks;
 using Machine.Specifications;
 using developwithpassion.specifications.moq;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.application;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.core;
 using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{   
    public class ViewDepartementsInTheDepartment
    {
        public abstract class concern : Observes<IProcessApplicationSpecificBehaviour,
                                            ViewDepartmentsInTheDepartment>
        {
        
        }

        [Subject(typeof(ViewDepartmentsInTheDepartment))]
        public class when_run : concern
        {
              Establish c = () =>
              {
                request = fake.an<IContainRequestInformation>();
                DepartmentItem testdepartment = new DepartmentItem();

                department_repository = depends.on<IFindDepartments>();
                the_departments_list = new List<DepartmentItem> {new DepartmentItem()};
                report_engine = depends.on<IDisplayReportModels>();

                request.setup(x => x.SelectedDepartment).Return(testdepartment);
                department_repository.setup(x => x.get_departments_in_the_department(request.SelectedDepartment)).Return(the_departments_list);
              };

              Because b = () =>
                sut.run(request);


              It should_display_the_departments_in_the_department =
                () =>
                  report_engine.received(x => x.display(the_departments_list));


              static IContainRequestInformation request;
              static IFindDepartments department_repository;
              static IDisplayReportModels report_engine;
              static IEnumerable<DepartmentItem> the_departments_list;
            }                
        }

    public class ViewDepartmentsInTheDepartment: IProcessApplicationSpecificBehaviour
    {
        public void run(IContainRequestInformation request)
        {
            throw new NotImplementedException();
        }
    }
}
}
