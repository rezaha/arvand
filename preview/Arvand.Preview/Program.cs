using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileProviders;

// Serve the real portal templates with explicitly shared preview data. The
// original Web Forms application and its database are not started by this host.
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var templates = Path.Combine(AppContext.BaseDirectory, "Templates");
var publicFiles = Path.Combine(AppContext.BaseDirectory, "wwwroot");
app.UseStaticFiles(new StaticFileOptions { FileProvider = new PhysicalFileProvider(publicFiles) });

string Render()
{
    using var fixture = JsonDocument.Parse(File.ReadAllText(Path.Combine(templates, "portal-fixture.json")));
    // Default JSON escaping prevents embedded content from closing a script tag.
    var payload = JsonSerializer.Serialize(fixture.RootElement);
    var body = File.ReadAllText(Path.Combine(templates, "PortalHome.ascx"));
    body = Regex.Replace(body, @"<asp:Literal\b[^>]+/>", _ => payload);
    var page = File.ReadAllText(Path.Combine(templates, "Portal.master"));
    page = Regex.Replace(page, "<asp:ContentPlaceHolder ID=\"head\"[^>]+/>", "");
    page = Regex.Replace(page, "<asp:ContentPlaceHolder ID=\"ContentPlaceHolder1\"[^>]+/>", _ => body);
    page = Regex.Replace(page, @"<%@.*?%>", "", RegexOptions.Singleline);
    page = Regex.Replace(page, "<%= ResolveUrl\\(\"~/(.*?)\"\\) %>", "/$1");
    page = page.Replace("href=\"~/", "href=\"/").Replace(" runat=\"server\"", "");
    if (page.Contains("<%") || page.Contains("<asp:"))
        throw new InvalidOperationException("The portal template contains unsupported server markup.");
    return page;
}

app.MapGet("/", () => Results.Content(Render(), "text/html; charset=utf-8"));
app.MapGet("/index.html", () => Results.Content(Render(), "text/html; charset=utf-8"));
app.MapGet("/fixture/{**path}", () => Results.Content("""
    <!doctype html><html lang="fa" dir="rtl"><meta charset="utf-8">
    <title>پیش‌نمایش طراحی اروند</title>
    <body style="font-family:Tahoma;max-width:640px;margin:60px auto;padding:20px;line-height:2">
    <h1>این صفحه پیش‌نمایش طراحی است</h1>
    <p>داده‌ها آزمایشی هستند. برای ورود به سامانه‌ها، جستجوی واقعی و دریافت اسناد باید سامانهٔ اصلی با پایگاه داده اجرا شود.</p>
    <a href="/">بازگشت به صفحهٔ نخست</a></body></html>
    """, "text/html; charset=utf-8"));
app.Run();
