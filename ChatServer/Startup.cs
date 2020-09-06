using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Subscriptions;
using HotChocolate.AspNetCore.Voyager;
using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ChatServer.Graphql;
using HotChocolate.AspNetCore.Playground;
using Autofac;
using Autofac.Configuration;
using ChatServer.Infrastructure.InMemory.DI;
using System;
using Autofac.Extensions.DependencyInjection;
using ChatServer.Application.DI;

namespace ChatServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            var builder = new ContainerBuilder();
            builder.RegisterModule(new RepositoriesModule());
            builder.RegisterModule(new ApplicationModule());

            services.AddControllers();
            services.AddInMemorySubscriptionProvider();

            services.AddGraphQL(sp => SchemaBuilder.New()
                .AddServices(sp)

                .AddAuthorizeDirectiveType()
                
                .AddQueryType<QueryType>()
                .AddMutationType<MutationType>()
                .AddSubscriptionType<SubscriptionType>()
                .AddType<MessageType>()
                .Create());

            builder.Populate(services);
            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ConfigurationModule(Configuration));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app
                .UseWebSockets()
                .UseGraphQL("/graphql")
                .UsePlayground(new PlaygroundOptions { QueryPath = "/graphql", Path = "/playground" })
                .UseVoyager(new VoyagerOptions { QueryPath = "/graphql", Path = "/voyager" });
        }
    }
}
