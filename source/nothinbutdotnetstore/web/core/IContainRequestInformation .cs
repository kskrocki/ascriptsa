using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core
{
    public interface IContainRequestInformation 
    {
        DepartmentItem SelectedDepartment { get; set; }
    }
}