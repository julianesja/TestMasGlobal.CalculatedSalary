namespace TestMasGlobal.CalculatedSalary.Configurations
{
    using AutoMapper;
    using TestMasGlobal.CalculatedSalary.Domain.Interfaces.Dto;
    using TestMasGlobal.CalculatedSalary.Model;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<LoginViewModel, LoginDto>();
        }
    }
}
