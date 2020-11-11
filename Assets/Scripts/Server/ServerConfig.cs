
// This class store server config keys and urls.
// class này chứa server config keys and urls
public class ServerConfig
{
    // URL with place to put API method in it.
    // URL với một vị trí để đặt phương thức API vào đó
    public const string SERVER_API_URL_FORMAT = "http://www.mocky.io/v2/{0}";

    // Mocky generates random strings for your endpoints, should name them properly
    // Mocky tạo các chuỗi ngẫu nhiên cho các điểm cuối, nên đặt tên cho hợp lý 
    // Và Mocky tạo random string bất kỳ, không giống nhau.

    public const string API_GET_QUOTE = "5cb15fdf330000ee1557204f";
    public const string API_GET_BLOG_INFO = "5cb28ba13000007b00a78c92";
}
