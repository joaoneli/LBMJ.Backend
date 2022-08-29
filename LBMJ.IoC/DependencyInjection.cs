using LBMJ.Bll;
using LBMJ.Bll.Infra;
using LBMJ.Dal.Infra;
using LBMJ.Dal.Infra.Base;
using LBMJ.Dal.MySql;
using LBMJ.Dal.MySql.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LBMJ.IoC
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<IBaseDal>(s =>
                new BaseDal(configuration.GetConnectionString("MySqlConnectionString")));

            service.AddScoped<IUserBll, UserBll>();
            service.AddScoped<IUserDal, UserDal>();

            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
