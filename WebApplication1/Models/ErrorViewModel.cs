namespace WebApplication1.Models
{
    public class ErrorViewModel : IErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public interface IErrorViewModel
    {
        string? RequestId { get; set; }

        bool ShowRequestId { get; }
    }
}
