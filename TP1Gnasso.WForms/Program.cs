using Microsoft.Extensions.DependencyInjection;
using TP1Gnasso.IoC;


namespace TP1Gnasso.WForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            var services = new ServiceCollection();

            services.AddApplicationServices();

            var formularios = typeof(Program).Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Form)) && !t.IsAbstract).ToList();
            foreach (var frm in formularios)
            {
                services.AddTransient(frm);
            }

            var provider = services.BuildServiceProvider();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(provider.GetRequiredService<frmLogin>());
        }
    }
}