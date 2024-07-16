using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PistolGame.Code.Infrastructure.StateMachine.States;
using PistolGame.Code.Services;
using PistolGame.Code.Services.Factories.BaseFactory;

namespace PistolGame.Code.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetAllStatesTypes() =>
            Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                type.GetInterfaces().Contains(typeof(IExitableState)) && type.IsClass);

        public static IEnumerable<(Type, Type)> GetAllGlobalServiceTypes()
        {
            List<(Type, Type)> services = new List<(Type, Type)>(12);
            IEnumerable<Type> serviceTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.GetInterfaces().Contains(typeof(IGlobalService)) && type.IsClass);

            foreach (Type serviceType in serviceTypes)
            {
                Type instanceType = serviceType;
                Type interfaceType = serviceType.GetInterfaces()
                    .First(type => type != typeof(IGlobalService) && type != typeof(IBaseFactory));
                services.Add((instanceType, interfaceType));
            }

            return services;
        }
    }
}