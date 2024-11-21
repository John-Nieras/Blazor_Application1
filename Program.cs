using Blazor_Application1.Components;

var builder = WebApplication.CreateBuilder(args); //Instantiate the application using the create builder 

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build(); //Finish the web application

//This part is considered the middleware
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); //This code request the https request

app.UseStaticFiles();
app.UseAntiforgery(); //This is use for the security para hindi makalog in yun iba 

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run(); //The application starts here...
