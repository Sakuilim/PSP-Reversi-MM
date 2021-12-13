using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PSP_Reversi_MM_Winforms.Constants;
using PSP_Reversi_MM_Winforms.Forms;
using PSP_Reversi_MM_Winforms.Logic;
using PSP_Reversi_MM_Winforms.Logic.ColorCheckingLogic;
using PSP_Reversi_MM_Winforms.Logic.DirectionLogic;
using PSP_Reversi_MM_Winforms.Logic.EndGameLogic;
using PSP_Reversi_MM_Winforms.Logic.PieceLogic;
using PSP_Reversi_MM_Winforms.Logic.SystemLogic;
using PSP_Reversi_MM_Winforms.Shared;
using PSP_Reversi_MM_Winforms.Shared.HelperMethods;
using PSP_Reversi_MM_Winforms.Shared.Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger.Information("Application Starting");

            Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IInitiateGameSys, InitiateGameSys>();
                    services.AddSingleton<ISystemInitializer, SystemInitializer>();
                    services.AddTransient<IColorTurningLogic, ColorTurningLogic>();
                    services.AddTransient<ILabelChangingLogic, LabelChangingLogic>();
                    services.AddTransient<IPiecePlacer, PiecePlacer>();
                    services.AddTransient<ILegalMoveChecker, LegalMoveChecker>();
                    services.AddTransient<IDirectionChecker, DirectionChecker>();
                    services.AddTransient<IColorLineChecker, ColorLineChecker>();
                    services.AddTransient<IArrayLineChecker, ArrayLineChecker>();
                    services.AddTransient<IColorTurningInitiator, ColorTurningInitiator>();
                    services.AddTransient<IButtonCreator, ButtonCreator>();
                    services.AddTransient<IPointLogic, PointLogic>();
                    services.AddTransient<IResultChecker,ResultChecker>();
                    services.AddTransient<ITurnLogic, TurnLogic>();
                    services.AddSingleton<IButtonMakingHelper, ButtonMakingHelper>();
                    services.AddScoped<WelcomeWindow>();
                    services.AddScoped<IGameWindow, GameWindow>();
                    services.AddTransient<IColorTurningLogic, ColorTurningLogic>();
                    using ServiceProvider serviceProvider = services.BuildServiceProvider();
                    var welcomeWindow = serviceProvider.GetRequiredService<WelcomeWindow>();
                    Application.Run(welcomeWindow);
                })
                .UseSerilog()
                .Build();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.json.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Local"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}
