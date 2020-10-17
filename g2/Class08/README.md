# Logging and Connecting API to other services 🚁

## Logging 🔶

Logging is an integral part of any application. It is the process where we write code that will document a record with some important data when something is executed in the application. Usually, logging is added in important methods that are worth noting that were executed as well as errors so that when something breaks, a developer can open the text file and read what happened. Visual Studio is a great tool for monitoring our code and tracking bugs and errors, but when we deploy our application on some server such as a test server or a production server we do not have the luxury to open Visual Studio and debug. This is where log files come handy and help us detect problems on the spot.

### Log messages 🔹

When logging we create and save messages to a file. logging is usually done in a text file but it can be done in any format the developer sees fit. Sometimes logging is done even in a database. But log messages are very different one from another depending on what happened in the code. That is why there are different types of log messages that represent the nature of the message. When using our logger these messages can be categorized with our system, but when working with libraries the messages are usually categorized by a convention called Severity Level Directive by their severity:

- Error - An error or exception happened
- Warning - Nothing is broken but there are some suspicious activities
- Info - Information that something happened
- Debug - Some extra data for easier debugging

### Logging Libraries 🔹

Logging can be done without libraries by creating methods that write in a text file. But if there is a need for extra features and automation libraries are a better option. There are a lot of different logging libraries and all of them have some features that make them unique and easy to log information on our application. Most of them can give automatic information about the inner works of the application, add timestamps automatically, read and write automatically as well as give preset Directives for severity. Some of the more famous ones for .NET applications are:

- Log4net
- NLog
- SeriLog

### SeriLog 🔹

All custom loggers need to be configured before they can be used. These configurations are usually trivial and very easy for a basic setup. After they are configured they can be used without the box ready methods that log and document things in our application. SeriLog documents a lot of stuff on its own without even writing any log such as starting the application, methods called, timestamps, endpoints hit, responses, SQL queries executed, and so on. The other logs we can write very easily with the **Log** class. The logging is done by stating the severity status first. This way every log is categorized. This library also has the option to log whole objects so in the logs we can see an object instead of just what type it is.

#### Install and Configure SeriLog ( program.cs )

**Nuget packages:**

- Serilog
- Serilog.AspNetCore ( v 2.1.1 )
- Serilog.Sinks.RollingFile

```csharp asp
public class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.Information()
            .WriteTo.RollingFile(
                $@"{AppDomain.CurrentDomain.BaseDirectory}Logs\Notes_LOG_{DateTime.UtcNow.Date:dd-MM-yyyy}.txt",
                LogEventLevel.Information,
                "{NewLine}{Timestamp:HH:mm:ss} [{Level}] ({CorrelationToken}) {Message}{NewLine}{Exception}")
            .CreateLogger();
        CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseSerilog()
            .UseStartup<Startup>();
}
```

#### Using SeriLog

```csharp asp
// This will log an Information type log
Log.Information("USER {username} has registered on the map", Username);
// This will log an Error type log
Log.Error("USER Error for {userId}.{name}: {message}", UserId, Name, Message);
// This will log an Error type log but the user object will be presented with all data
Log.Error("USER Error for {@user}: {message}", User, Message);
```

## Extra Materials 📘

- [SeriLog Writing Logs](https://github.com/serilog/serilog/wiki/Writing-Log-Events)
- [SeriLog Configuration Documentation](https://github.com/serilog/serilog/wiki/Configuration-Basics)
- [Logging in .NET Best Practices](https://michaelscodingspot.com/logging-in-dotnet/)
- [Regex 101](https://regex101.com/)
