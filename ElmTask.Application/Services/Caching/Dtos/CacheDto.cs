namespace ElmTask.Application.Services.Caching.Dtos
{
    public class CacheDto<T> where T : class
    {
        public List<T> Entities { get; set; }
        public DateTime ExripyDate { get; set; }
    }
}
