#undef SCOPED
#undef SINGLETON

using System.Net;
using Microsoft.AspNetCore.Rewrite;
using ServiceLifetimes.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services with different lifetimes using preprocessor directives.
#if TRANSIENT
builder.Services.AddTransient<IWelcomeService, WelcomeService>();
#elif SCOPED
builder.Services.AddScoped<IWelcomeService, WelcomeService>();
#elif SINGLETON
builder.Services.AddSingleton<IWelcomeService, WelcomeService>();
#else
throw new InvalidOperationException("Set at least one service-lifetime using the preprocessor directives.");
#endif

var app = builder.Build();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/favicon.ico")
    {
        context.Response.StatusCode = (int)HttpStatusCode.NoContent;
        return;
    }

    await next();
});

app.Use(async (context, next) =>
{
    await next(); // Call the next delegate/middleware in the pipeline
    Console.WriteLine($"{context.Request.Method} {context.Request.Path} {context.Response.StatusCode}");
});

app.MapGet("/", (IWelcomeService welcomeService1, IWelcomeService welcomeService2) =>
{
    var message1 = welcomeService1.GetWelcomeMessage();
    var message2 = welcomeService2.GetWelcomeMessage();
    return $"{message1}\n{message2}";
});

app.UseRewriter(new RewriteOptions().AddRedirect("history", "about"));

app.MapGet("/about", () => "This site was created on 2025.");

app.Run();