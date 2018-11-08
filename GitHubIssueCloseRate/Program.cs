using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using GitHubIssueCloseRate.Services;
using GitHubIssueCloseRate.Interfaces;
using GitHubIssueCloseRate.Entities;
using GitHubIssueCloseRate.Data;

namespace GitHubIssueCloseRate {

    internal class Program {

        private static void Main(string[] args)
        {
            // https://developer.github.com/v3/
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IGitHubIssueService, GitHubIssueService>()
                .AddScoped<IGitHubIssueRepository, GitHubIssuesRepository>()
                .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            logger.LogDebug("Starting application");

            //do the actual work here
            var gitHubIssueService = serviceProvider.GetService<IGitHubIssueService>();
            gitHubIssueService.Report().Wait();

            logger.LogDebug("All done!");
            Console.ReadLine();
        }
    }
}