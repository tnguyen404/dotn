namespace dotnet_rpg.Models
{
    public class ServiceResponse<T>
    {
        public T data { get; set; } 
        public string message { get; set; }
        public bool success { get; set; }
    }
}