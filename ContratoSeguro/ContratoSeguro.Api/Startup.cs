
using ContratoSeguro.Dominio.Handlers.Command.Usuario;
using ContratoSeguro.Dominio.Repositories;
using ContratoSeguro.Infra.Data.Context;
using ContratoSeguro.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro_Api
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
            services.AddRazorPages();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                //Correção do erro object cycle
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                //Remover propriedades nulas
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });
            
            services.AddDbContext<ContratoSeguroContext>(o => o.UseSqlServer("Data Source= DESKTOP-HQAU92S\\SQLEXPRESS;Initial Catalog=ContratoSeguro;user id=sa; password=sa132"));
            //services.AddDbContext<ContratoSeguroContext>(o => o.UseSqlServer("Data Source= .\\SQLEXPRESS;Initial Catalog=ContratoSeguro;user id=sa; password=sa132"));

            //JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "contratoseguro",
                        ValidAudience = "contratoseguro",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaContratoSeguroApi"))
                    };
                });


            #region Injeção Dependência Usuario Recrutado
            services.AddTransient<IUsuarioRecrutadoRepository, UsuarioRecrutadoRepository>();
            services.AddTransient<CriarContaRecrutadoCommandHandler, CriarContaRecrutadoCommandHandler>();
            services.AddTransient<EsqueciMinhaSenhaCommandHandler, EsqueciMinhaSenhaCommandHandler>();
            services.AddTransient<LogarHandler, LogarHandler>();


            #endregion

            #region Injeção Dependência Usuario Funcionario
            services.AddTransient<IUsuarioFuncionarioRepository, UsuarioFuncionarioRepository>();
            services.AddTransient<CriarContaFuncionarioCommandHandler, CriarContaFuncionarioCommandHandler>();


            #endregion

            //SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Contrato Seguro", Version = "V1" });
            });

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(o => o.SwaggerEndpoint("/swagger/v1/swagger.json", "Api ContratoSeguro V1"));
            }

            /*app.UseHttpsRedirection();*/

            app.UseRouting();

            app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
