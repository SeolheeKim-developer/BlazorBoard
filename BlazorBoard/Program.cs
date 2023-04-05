using BlazorBoard.Areas.Identity;
using BlazorBoard.Areas.Identity.Models;
using BlazorBoard.Areas.Identity.Services;
using BlazorBoard.Data;
using BlazorBoard.Models.Candidates;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();


//Add new DbContext
//builder.Services.AddDbContext<CandidateAppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContextFactory<CandidateAppDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options => { options.DetailedErrors = true; });
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
builder.Services.AddSingleton<WeatherForecastService>();

//add for email
builder.Services.AddTransient<IEmailSender, EmailSender>();

var app = builder.Build();

//when it is development, add seed data (Update-Database) 
if (app.Environment.IsDevelopment())
{
    await CheckCandidateDbMigrated(app.Services);
    CandidateSeedData(app); 
    CandidateDbInitializer.Initialize(app);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");



app.Run();

#region CandidateSeedData: initial data(seed data) in Candidates tables
//initial data(seed data) in Candidates tables
static void CandidateSeedData(WebApplication app)
{
    using (var serviceScope = app.Services.CreateScope())
    {
        var services = serviceScope.ServiceProvider;
        var candidateDbContext = services.GetRequiredService<CandidateAppDbContext>();

        if (!candidateDbContext.Candidates.Any())
        {
            candidateDbContext.Candidates.Add(
                new Candidate { FirstName = "Seolhee", LastName = "Kim", IsEnrollment = false });
            candidateDbContext.Candidates.Add(
                new Candidate { FirstName = "Teri", LastName = "Campigotto", IsEnrollment = false });

            candidateDbContext.SaveChanges();
        }
    }
}
#endregion

#region CheckCandidateDbMigrated
//Database Migration
async Task CheckCandidateDbMigrated(IServiceProvider services)
{
    using var scope = services.CreateScope();
    using var candidateContext = scope.ServiceProvider.GetService<CandidateAppDbContext>();
    if (candidateContext is not null)
    {
        await candidateContext.Database.MigrateAsync();
    }

} 
#endregion