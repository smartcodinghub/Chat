using Chat.Server.Infraestructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Server
{
    public class Startup
    {
        /// <summary>
        /// Dependency Injection configuration
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSignalR();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/Account/Login";
                opt.LogoutPath = "/Account/Logout";
            });
        }

        /// <summary>
        /// Server Pipeline
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseSignalR(routes => routes.MapHub<ChatHub>(ChatHub.Path));

            app.UseMvc(routes => routes.MapRoute("default", "{Controller=Users}/{Action=Index}"));
        }
    }
}
