
// Blog Info is data model for server response to GetBlogInfo.
// Blog Info là mô hình dữ liệu cho phản hồi của máy chủ đối với GetBlogInfo

[System.Serializable]
public class BlogInfoData
{
    public string blogAddress;
    public string bloggerName;
    public int bloggerAge;
}
