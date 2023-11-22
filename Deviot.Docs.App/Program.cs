using Deviot.Docs.App.Interfaces;
using Deviot.Docs.App.Services;
using Radzen;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
              .Enrich.FromLogContext()
              .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();

    builder.Services.AddRadzenComponents();
    builder.Services.AddScoped<DialogService>();

    builder.Services.AddSingleton<ISummaryService, SummaryService>();

    var application = builder.Environment.ApplicationName;

    var serilogLogger = new LoggerConfiguration()
        .Enrich.WithProperty("Application", application)
        .WriteTo.Console(theme: AnsiConsoleTheme.Code)
        .CreateLogger();

    builder.Services.AddLogging(x =>
    {
        x.AddSerilog(logger: serilogLogger, dispose: true);
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    //app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host Terminated Unexpectedly");
}

finally
{
    Log.CloseAndFlush();
}
