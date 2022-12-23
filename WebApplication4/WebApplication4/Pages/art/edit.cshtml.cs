using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Linq.Expressions;
using WebApplication4.Pages.Info_ar;

namespace WebApplication4.Pages.art
{
    public class editModel : PageModel
    {
        public ArticleInfo articleInfo = new ArticleInfo();
        public String errorMessenge = "";
        public String successMessenge = "";

        public void OnGet()
        {
            String id = Request.Query["id"];

            try
            {

                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=sf;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM article WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                articleInfo.id = "" + reader.GetInt32(0);
                                articleInfo.title = reader.GetString(1);
                                articleInfo.author = reader.GetString(2);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessenge = ex.Message;
            }
        }

        public void OnPost()
        {
            articleInfo.id = Request.Form["id"];
            articleInfo.title = Request.Form["title"];
            articleInfo.author = Request.Form["author"];

            if (articleInfo.title.Length == 0 || articleInfo.author.Length == 0)
            {
                errorMessenge = "Заполнено некорректно";
                return;
            }

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=sf;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE article" + " SET title=@title, author=@author " + "WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@title", articleInfo.title);
                        command.Parameters.AddWithValue("@author", articleInfo.author);
                        command.Parameters.AddWithValue("@id", articleInfo.id);
                        
                        command.ExecuteNonQuery();  //возвр кол во кол во строк обраб командой
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessenge = ex.Message;
                return;
            }
            Response.Redirect("/art/Index");
        }
    }
}
