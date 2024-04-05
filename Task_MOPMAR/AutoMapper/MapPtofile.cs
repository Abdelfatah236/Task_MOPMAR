namespace Chatgpt.AutoMapper
{
    public class MapPtofile:Profile
    {
        public MapPtofile()
        {
            MapEmp();
        }
        private void MapEmp()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        }
    }
}
