using System.Text.Json;
using System.Text.RegularExpressions;
using System.Net;
using Microsoft.Extensions.FileProviders;

// Serve the real portal templates with explicitly shared preview data. The
// original Web Forms application and its database are not started by this host.
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var templates = Path.Combine(AppContext.BaseDirectory, "Templates");
var publicFiles = Path.Combine(AppContext.BaseDirectory, "wwwroot");
app.UseStaticFiles(new StaticFileOptions { FileProvider = new PhysicalFileProvider(publicFiles) });

string Render(string kind = "home")
{
    using var fixture = JsonDocument.Parse(File.ReadAllText(Path.Combine(templates, "portal-fixture.json")));
    // Default JSON escaping prevents embedded content from closing a script tag.
    var payload = JsonSerializer.Serialize(fixture.RootElement);
    var body = File.ReadAllText(Path.Combine(templates, "PortalHome.ascx"));
    if (kind == "news")
    {
        var source = File.ReadAllText(Path.Combine(templates, "ShowNews.aspx"));
        body = Regex.Match(source, "<asp:Content ID=\"Content2\"[^>]*>(.*?)</asp:Content>", RegexOptions.Singleline).Groups[1].Value;
        var sample = fixture.RootElement.GetProperty("news")[0];
        var fields = new Dictionary<string, string> {
            ["lblNewsTitle"] = sample.GetProperty("title").GetString()!,
            ["lblNewsDate"] = "نمونهٔ خبر برای بررسی طراحی",
            ["lblNewsSummary"] = sample.GetProperty("summary").GetString()!,
            ["lblNewsContent"] = "این متن نمونه فقط برای بررسی قالب صفحهٔ خبر است. اطلاعات واقعی خبر از پایگاه دادهٔ سامانه خوانده می‌شود."
        };
        foreach (var field in fields)
            body = Regex.Replace(body, "(?<open><(?<tag>\\w+)\\b[^>]*\\bid=\"" + field.Key + "\"[^>]*>).*?(?<close></\\k<tag>>)",
                m => m.Groups["open"].Value + WebUtility.HtmlEncode(field.Value) + m.Groups["close"].Value, RegexOptions.Singleline);
        body = Regex.Replace(body, "<img\\b[^>]*\\bid=\"lblNewsLargeImage\"[^>]*>", "<img src=\"/UploadFiles/slider/01/01.jpg\" alt=\"تصویر نمونه خبر\" />");
        body = Regex.Replace(body, @"<uc\w+:[^>]+/>", "");
        body = Regex.Replace(body, @"<%=Set\w+Url\(\)%>", "/fixture/news-action");
    }
    else if (kind == "currency")
    {
        var source = File.ReadAllText(Path.Combine(templates, "Currency.aspx"));
        body = Regex.Match(source, "<asp:Content ID=\"RateBody\"[^>]*>(.*?)</asp:Content>", RegexOptions.Singleline).Groups[1].Value;
    }
    else if (kind != "home")
        body = "<section class=\"portal-status-page\"><h1>پیش‌نمایش طراحی اروند</h1><p>داده‌ها آزمایشی هستند. مسیرها و عملیات واقعی در سامانهٔ اصلی با پایگاه داده اجرا می‌شوند.</p><a href=\"/\">صفحهٔ نخست</a></section>";
    var page = File.ReadAllText(Path.Combine(templates, "PortalShell.master"));
    page = Regex.Replace(page, "<asp:ContentPlaceHolder ID=\"PortalHead\"[^>]+/>", "");
    page = Regex.Replace(page, "<asp:ContentPlaceHolder ID=\"PortalNavigation\"[^>]*>(.*?)</asp:ContentPlaceHolder>", "$1", RegexOptions.Singleline);
    page = Regex.Replace(page, "<asp:ContentPlaceHolder ID=\"PortalMain\"[^>]+/>", _ => "<div class=\"portal-content portal-auto-content\">" + body + "</div>");
    page = Regex.Replace(page, @"<asp:Literal\b[^>]+/>", _ => payload);
    page = page.Replace("<%= IsPortalHome.ToString().ToLowerInvariant() %>", kind == "home" ? "true" : "false");
    page = Regex.Replace(page, @"<%@.*?%>", "", RegexOptions.Singleline);
    page = Regex.Replace(page, "<%(?:=|#) ResolveUrl\\(\"~/(.*?)\"\\) %>", "/$1");
    page = page.Replace("href=\"~/", "href=\"/").Replace("src=\"~/", "src=\"/").Replace(" runat=\"server\"", "");
    if (page.Contains("<%") || page.Contains("<asp:"))
        throw new InvalidOperationException("The portal template contains unsupported server markup.");
    return page;
}

app.MapGet("/", () => Results.Content(Render(), "text/html; charset=utf-8"));
app.MapGet("/index.html", () => Results.Content(Render(), "text/html; charset=utf-8"));
app.MapGet("/news.html", () => Results.Content(Render("news"), "text/html; charset=utf-8"));
app.MapGet("/currency.html", () => Results.Content(Render("currency"), "text/html; charset=utf-8"));
app.MapGet("/api/Service/PortalRates/fa/0", () => Results.Json(new { available = false, items = Array.Empty<object>() }));
app.MapGet("/fixture/{**path}", () => Results.Content(Render("fixture"), "text/html; charset=utf-8"));
app.Run();
