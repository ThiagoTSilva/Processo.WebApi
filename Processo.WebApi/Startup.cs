using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Processo.WebApi.Data;
using Processo.WebApi.Repositories;
using Processo.WebApi.Repositories.Interface;
using Processo.WebApi.Service;
using Processo.WebApi.Service.Interface;

namespace Processo.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
                options.AddPolicy("AllowAll", e =>
                {
                    e.AllowAnyOrigin();
                    e.AllowAnyMethod();
                    e.AllowAnyHeader();
                }));

            services.AddControllers();

            services.AddDbContext<ContextDb>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();

            services.AddTransient<IBeneficiarioService, BeneficiarioService>()
                 .AddTransient<IBeneficiarioRepository, BeneficiarioRepository>()
                 .AddTransient<IBeneficioService, BeneficioService>()
                 .AddTransient<IBeneficioRepository, BeneficioRepository>()
                 .AddTransient<IDocumentoService, DocumentoService>()
                 .AddTransient<IDocumentoRepository, DocumentoRepository>()
                 .AddTransient<IMovimentacaoService, MovimentacaoService>()
                 .AddTransient<IMovimentacaoRepository, MovimentacaoRepository>()
                 .AddTransient<IUsuarioService, UsuarioService>()
                 .AddTransient<IUsuarioRepository, UsuarioRepository>()
                 .AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAll");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
