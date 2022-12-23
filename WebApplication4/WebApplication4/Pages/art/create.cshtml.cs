using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using WebApplication4.Pages.Info_ar;

namespace WebApplication4.Pages.art
{
    public class createModel : PageModel
    {
        public ArticleInfo articleInfo = new ArticleInfo();
        public String errorMessenge = "";  
        public String successMessenge = "";
        public void OnGet()
        {

        }
        public void OnPost() /*����� ������� �����  ����������� ����� �� ������� ������ ���� ����� � ������� ������ ��������*/
        {
            articleInfo.title = Request.Form["title"];
            articleInfo.author = Request.Form["author"];

            if (articleInfo.title.Length == 0 || articleInfo.author.Length == 0)
            {
                errorMessenge = "All the fields are required";
                return;
            }
            try /*����� � ����*/
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=sf;Integrated Security=True";
                using (SqlConnection connection= new SqlConnection(connectionString))
                {
                    connection.Open(); /*��������� ���������*/
                    String sql = "INSERT INTO article" + "(title,author) VALUES" + "(@title,@author);";/* ������� ����� ������*/
                    using (SqlCommand command= new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@title", articleInfo.title); /*�������� ������� ������� �� �������� �� �����*/
                        command.Parameters.AddWithValue("@author", articleInfo.author);
                        command.ExecuteNonQuery();
                    }
                }
            }
            //����������
            catch(Exception ex)
            {
                errorMessenge = ex.Message; /*��������� ����� �� ������ */
                return;
            }

            articleInfo.author = "";
            articleInfo.title = "";

            successMessenge = "�������� ����������";
            Response.Redirect("/art/Index");

        }


    }
}
