namespace Injector.Helpers;

public class Constant
{
    public static string AuthProgramCs
    {
        get
        {
            return
                "builder.Services.AddAuthentication(options =>\r\n" +
                "{\r\n" +
                " options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;\r\n" +
                " options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;\r\n" +
                " options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;\r\n" +
                "}).AddCookie(options =>\r\n{\r\n options.LoginPath = \"/Login\";\r\n" +
                "    options.LogoutPath = \"/Logout\";\r\n" +
                "    options.ExpireTimeSpan = TimeSpan.FromDays(30);\r\n" +
                "});\r\n";
        }
    }

    public static string DbContextProgramCs
    {
        get
        {
            return
                "builder.Services.AddDbContext<ApplicationDbContext>(options =>\r\n" +
                " options.UseSqlServer(builder.Configuration.GetConnectionString(\"DefaultConnection\"))\r\n" +
                ");";
        }
    }

    public static string ConnectionString
    {
        get
        {
            return
                "," +
                "\"ConnectionStrings\": {\r\n" +
                "        \"DefaultConnection\": \"Server=.; Database=Your_Db_Name; TrustServerCertificate=true; Trusted_Connection=true\"\r\n" +
                "    }";
        }
    }
}
