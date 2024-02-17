
namespace ElmTask.Application.Common.Dtos
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; } = true;
        public T Data { get; set; }

    }
}
