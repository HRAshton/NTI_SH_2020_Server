namespace WebApplication4.Models.ResponseModels
{
    public class HouseMessageModel : ModelBase
    {
        public HouseMessageModel(string message)
        {
            Status = Statuses.Error;
            Message = message;
        }
    }
}