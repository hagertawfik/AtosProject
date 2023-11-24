using Application_Layer.DTO;

namespace Application_Layer.BussinesLogicInterface
{
    public interface IDashboardService
    {
        DashboardNumbersDto GetRequiredNumbers();
    }
}
