using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using MyParty;
using MyParty.BL;
using MyParty.DAL;
using System.Web.Mvc;

namespace MyParty.Infrastructure
{
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
            builder.RegisterType<PartyRepository>().As<IPartyRepository>();
            builder.RegisterType<PartyService>().As<IPartyService>();
            builder.RegisterType<LastViewedParties>().As<ILastViewedParties>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}