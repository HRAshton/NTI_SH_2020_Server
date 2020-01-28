namespace WebApplication4.Models.ResponseModels
{
    public class ErrorResponseModel : ModelBase
    {
        public ErrorResponseModel(string errorMessage)
        {
            Status = Statuses.Error;
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; set; }
    }
}