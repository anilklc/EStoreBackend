using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities.Identity;
using EStoreBackend.Persistence.Context;
using EStoreBackend.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
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
            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequiredLength = 3;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
            }).AddRoles<AppRole>().AddEntityFrameworkStores<EStoreDbContext>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);
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
            services.AddScoped<IBrandImageReadRepository,BrandImageReadRepository>();
            services.AddScoped<IBrandImageWriteRepository,BrandImageWriteRepository>();
            services.AddScoped<IReviewImageReadRepository, ReviewImageReadRepository>();
            services.AddScoped<IReviewImageWriteRepository, ReviewImageWriteRepository>();
            services.AddScoped<ISliderImageReadRepository, SliderImageReadRepository>();
            services.AddScoped<ISliderImageWriteRepository, SliderImageWriteRepository>();
            services.AddScoped<IAnnouncementReadRepository,AnnouncementReadRepository>();
            services.AddScoped<IAnnouncementWriteRepository,AnnouncementWriteRepository>();
            services.AddScoped<IProductReadRepository,ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteepository>();
            services.AddScoped<IProductImageReadRepository, ProductImageReadRepository>();
            services.AddScoped<IProductImageWriteRepository,ProductImageWriteRepository>();
            services.AddScoped<IStockReadRepository,StockReadRepository>();
            services.AddScoped<IStockWriteRepository, StockWriteRepository>();
        }
    }
}
