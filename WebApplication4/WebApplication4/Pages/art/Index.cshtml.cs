using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebApplication4.Pages.Info_ar
{
    public class IndexModel : PageModel
    {

        public List<ArticleInfo> listArticle = new List<ArticleInfo>(); /* список статей спис инф о статьях*/
        public void OnGet()       /*в этом методе получаем доступ к базе*/
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=sf;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); /*открываем соединение*/
                    string sql = "Select * FROM article"; /*запрос позволяет прочитать все строки из статьи*/
                    using (SqlCommand command = new SqlCommand(sql, connection)) /*команда sql запрос*/
                    {
                        using (SqlDataReader reader = command.ExecuteReader()) 
                        {
                            while (reader.Read())  /*считываем данные и сохр в информ о статьях*/
                            {
                                ArticleInfo articleInfo = new ArticleInfo();
                                articleInfo.id = " " + reader.GetInt32(0);
                                articleInfo.title = reader.GetString(1);   /*также преобразовываем строки*/
                                articleInfo.author = reader.GetString(2);
                                articleInfo.create_data = reader.GetDateTime(3).ToString();

                                listArticle.Add(articleInfo); /*добавляем этот объект в список*/
                            }
                        }
                    }
                }
            }
            catch (Exception ex) /*инструкция показывает ошибку на консоли в случае исключения*/
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
