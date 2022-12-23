using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebApplication4.Pages.Info_ar
{
    public class IndexModel : PageModel
    {

        public List<ArticleInfo> listArticle = new List<ArticleInfo>(); /* ������ ������ ���� ��� � �������*/
        public void OnGet()       /*� ���� ������ �������� ������ � ����*/
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=sf;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); /*��������� ����������*/
                    string sql = "Select * FROM article"; /*������ ��������� ��������� ��� ������ �� ������*/
                    using (SqlCommand command = new SqlCommand(sql, connection)) /*������� sql ������*/
                    {
                        using (SqlDataReader reader = command.ExecuteReader()) 
                        {
                            while (reader.Read())  /*��������� ������ � ���� � ������ � �������*/
                            {
                                ArticleInfo articleInfo = new ArticleInfo();
                                articleInfo.id = " " + reader.GetInt32(0);
                                articleInfo.title = reader.GetString(1);   /*����� ��������������� ������*/
                                articleInfo.author = reader.GetString(2);
                                articleInfo.create_data = reader.GetDateTime(3).ToString();

                                listArticle.Add(articleInfo); /*��������� ���� ������ � ������*/
                            }
                        }
                    }
                }
            }
            catch (Exception ex) /*���������� ���������� ������ �� ������� � ������ ����������*/
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class ArticleInfo
    {
        public string id;
        public string title;
        public string author;
        public string create_data;
    }
}
