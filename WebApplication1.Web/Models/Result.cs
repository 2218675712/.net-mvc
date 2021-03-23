namespace WebApplication1.Web.Models
{
    /// <summary>
    /// 通用返回类
    /// </summary>
    public class Result
    {
        public int code { get; set; } = 200;
        public string type { get; set; } = "success";
        public string message { get; set; } = "";
        public object data { get; set; } = new { };
    }
}