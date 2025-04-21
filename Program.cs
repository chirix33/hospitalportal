using Microsoft.AspNetCore.Authentication.Cookies;
using Sustainsys.Saml2;
using Sustainsys.Saml2.AspNetCore2;
using Sustainsys.Saml2.Metadata;

var builder = WebApplication.CreateBuilder(args);
var samlSection = builder.Configuration.GetSection("Saml");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.Secure = CookieSecurePolicy.Always;
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = Saml2Defaults.Scheme;
})
.AddCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
})
.AddSaml2(options =>
{
    options.SPOptions.EntityId = new EntityId(samlSection["EntityId"]);

    options.IdentityProviders.Add(
        new IdentityProvider(
            new EntityId("http://www.okta.com/exkodeqq561QrJsD95d7"),
            options.SPOptions)
        {
            LoadMetadata = true,
            MetadataLocation = samlSection["Metadata"]
        });

    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});
builder.Services.AddAuthorization();
builder.Services.AddControllers();
var app = builder.Build();
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); 
} else
{
    app.UseHttpsRedirection();
    app.Urls.Add("https://localhost:5001");
}

app.Urls.Add(app.Environment.IsDevelopment() ? $"https://localhost:{port}" : $"http://*:{port}");
app.UseRouting();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllers();
app.MapRazorPages()
   .WithStaticAssets();
app.Run();
