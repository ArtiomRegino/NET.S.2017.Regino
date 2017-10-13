using System.Data.Entity;
using DAL.Concrete;
using DAL.Concrete.Repositories;
using DAL.Interface.Interfaces;
using BLL.Interfaces.Interfaces;
using BLL.Servicies;
using Ninject;
using Ninject.Web.Common;
using ORM;

namespace DependencyResolver
{
    /// <summary>
    /// Service class for DI and IoC implemetnation
    /// </summary>
    public static class DependencyResolver
    {
        /// <summary>
        /// The method for Kernel configuration
        /// </summary>
        /// <param name="kernel">this IKernel parameter</param>
        public static void ConfigurateResolver(this IKernel kernel)
        {
            Configure(kernel);
        }

        private static void Configure(IKernel kernel)
        {
            //https://github.com/ninject/Ninject.Web.Common/wiki/InRequestScope
            //The main reason for using InRequestScope() is to make sure that a single instance of an object is shared by all objects created via the Ninject kernel for that HTTP request (e.g. to share an object that is expensive to create).
            kernel.Bind<DbContext>().To<SocialNetworkContext>().InSingletonScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();

            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();

            kernel.Bind<IProfileService>().To<ProfileService>();
            kernel.Bind<IProfileRepository>().To<ProfileRepository>();

            kernel.Bind<IFriendshipService>().To<FriendshipService>();
            kernel.Bind<IFriendshipRepository>().To<FriendshipRepository>();

            kernel.Bind<IMessageService>().To<MessageService>();
            kernel.Bind<IMessageRepository>().To<MessageRepository>();

            kernel.Bind<IPhotoService>().To<PhotoService>();
            kernel.Bind<IPhotoRepository>().To<PhotoRepository>();

        }
    }
}
