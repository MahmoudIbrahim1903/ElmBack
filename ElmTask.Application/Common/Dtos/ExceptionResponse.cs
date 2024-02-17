

namespace ElmTask.Application.Common.Dtos
{
    public class ExceptionResponse
    {
        public bool IsSuccess { get; set; } = true;
        public string[] Errors { get; set; }
    }
}
