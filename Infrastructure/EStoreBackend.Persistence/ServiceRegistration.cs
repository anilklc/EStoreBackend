﻿using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Persistence.Context;
using EStoreBackend.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EStoreDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
            services.AddScoped<IAboutReadRepository,AboutReadRepository>();
            services.AddScoped<IAboutWriteRepository,AboutWriteRepository>();
            services.AddScoped<IBrandReadRepository,BrandReadRepository>();
            services.AddScoped<IBrandWriteRepository,BrandWriteRepository>();
            services.AddScoped<ICategoryReadRepository,CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository,CategoryWriteRepository>();
            services.AddScoped<IFeatureReadRepository,FeatureReadRepository>();
            services.AddScoped<IFeatureWriteRepository,FeatureWriteRepository>();
            services.AddScoped<IFooterReadRepository,FooterReadRepository>();
            services.AddScoped<IFooterWriteRepository,FooterWriteRepository>();
            services.AddScoped<IPolicyReadRepository,PolicyReadRepository>();
            services.AddScoped<IPolicyWriteRepository,PolicyWriteRepository>();
            services.AddScoped<IReviewReadRepository,ReviewReadRepository>();
            services.AddScoped<IReviewWriteRepository,ReviewWriteRepository>();
            services.AddScoped<ISliderReadRepository,SliderReadRepository>();
            services.AddScoped<ISliderWriteRepository,SliderWriteRepository>();
            services.AddScoped<ISocialMediaReadRepository,SocialMediaReadRepository>();
            services.AddScoped<ISocialMediaWriteRepository,SocialMediaWriteRepository>();
        }
    }
}
