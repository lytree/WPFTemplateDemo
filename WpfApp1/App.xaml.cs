using System.IO;
using System.Runtime;
using System;
using System.Windows;
using HandyControl.Properties.Langs;
using HandyControl.Themes;
using HandyControl.Tools.Extension;
using HandyControl.Tools;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Threading;
using WPFTemplate.Data;
using WPFTemplate.Tools.Helper;
using System.Diagnostics.CodeAnalysis;

namespace WPFTemplate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
#pragma warning disable IDE0052
        [SuppressMessage("ReSharper", "NotAccessedField.Local")]
        private static Mutex AppMutex;
#pragma warning restore IDE0052
        public App()
        {
            var cachePath = $"{AppDomain.CurrentDomain.BaseDirectory}Cache";
            if (!Directory.Exists(cachePath))
            {
                Directory.CreateDirectory(cachePath);
            }
            ProfileOptimization.SetProfileRoot(cachePath);
            ProfileOptimization.StartProfile("Profile");
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            AppMutex = new Mutex(true, "HandyControlDemo", out var createdNew);

            if (!createdNew)
            {
                var current = Process.GetCurrentProcess();

                foreach (var process in Process.GetProcessesByName(current.ProcessName))
                {
                    if (process.Id != current.Id)
                    {
                        Win32Helper.SetForegroundWindow(process.MainWindowHandle);
                        break;
                    }
                }
                Shutdown();
            }
            else
            {
                var splashScreen = new SplashScreen("Resources/Img/Cover.png");
                splashScreen.Show(true);

                base.OnStartup(e);

                ApplicationHelper.IsSingleInstance();

                ShutdownMode = ShutdownMode.OnMainWindowClose;
                GlobalData.Init();

                if (GlobalData.Config.Theme != ApplicationTheme.Light)
                {
                    UpdateSkin(GlobalData.Config.Theme);
                }

                ConfigHelper.Instance.SetWindowDefaultStyle();
                ConfigHelper.Instance.SetNavigationWindowDefaultStyle();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            GlobalData.Save();
        }

        internal void UpdateSkin(ApplicationTheme theme)
        {
            ThemeManager.Current.ApplicationTheme = theme;

            var demoResources = new ResourceDictionary
            {
                Source = ApplicationHelper.GetAbsoluteUri("WPFTemplate",
                    $"/Resources/Themes/Basic/Colors/{theme.ToString()}.xaml")
            };

            Resources.MergedDictionaries[0].MergedDictionaries.InsertOrReplace(1, demoResources);
        }
    }
}
