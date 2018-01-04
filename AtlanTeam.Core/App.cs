using AtlanTeam.Core.Repository;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

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

            Mvx.LazyConstructAndRegisterSingleton<ISQLiteRepository, SQLiteRepository>();
            RegisterNavigationServiceAppStart<ViewModels.MainViewModel>();
        }
    }
}
