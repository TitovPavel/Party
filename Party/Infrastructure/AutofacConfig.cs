using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Party;
using Party.BL;
using Party.DAL;
using System.Web.Mvc;

public class AutofacConfig
{
    public static void ConfigureContainer()
    {
        // получаем экземпляр контейнера
        var builder = new ContainerBuilder();

        // регистрируем контроллер в текущей сборке
        builder.RegisterControllers(typeof(MvcApplication).Assembly);

        // регистрируем споставление типов
        builder.RegisterType<ParticipantsRepository>().As<IParticipantsRepository>();
        builder.RegisterType<ParticipantsService>().As<IParticipantsService>();

        // создаем новый контейнер с теми зависимостями, которые определены выше
        var container = builder.Build();

        // установка сопоставителя зависимостей
        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }
}