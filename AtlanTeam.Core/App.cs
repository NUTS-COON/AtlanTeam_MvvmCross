using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using AtlanTeam.Core.Services;

namespace AtlanTeam.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //Mvx.RegisterType<IDataService, DataService>();
            //Mvx.RegisterType<IRestAPIService, RestAPIService>();
            //RegisterAppStart<ViewModels.MainViewModel>();
            //Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<ViewModels.MainViewModel>());
            RegisterNavigationServiceAppStart<ViewModels.MainViewModel>();
        }
    }
}
