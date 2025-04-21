using Microsoft.AspNetCore.Authentication.Cookies;
using Sustainsys.Saml2;
using Sustainsys.Saml2.AspNetCore2;
using Sustainsys.Saml2.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = Saml2Defaults.Scheme; // This is key!
})
.AddCookie()
.AddSaml2(options =>
{
    options.SPOptions.EntityId = new EntityId("https://localhost:5000/Saml/Metadata");

    options.IdentityProviders.Add(
        new IdentityProvider(
            new EntityId("http://www.okta.com/exkodeqq561QrJsD95d7"),
            options.SPOptions)
        {
            LoadMetadata = true,
            MetadataLocation = "https://dev-51454621.okta.com/app/exkodeqq561QrJsD95d7/sso/saml/metadata"
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
}

app.Urls.Add(app.Environment.IsDevelopment() ? $"https://localhost:{port}" : $"http://*:{port}");
app.Urls.Add("https://localhost:5001");
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllers();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
