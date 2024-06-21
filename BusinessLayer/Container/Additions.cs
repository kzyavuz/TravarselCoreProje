using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.AnnonuncementDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Additions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EFAboutDal>();

            services.AddScoped<IAbout2Service, About2Manager>();
            services.AddScoped<IAboutDal2, EFAbout2Dal>();

            services.AddScoped<IFeatureService, FeatureManager>();
            services.AddScoped<IFeatureDal, EFFeatureDal>();

            services.AddScoped<IFeature2Service, Feature2Manager>();
            services.AddScoped<IFeatureDal2, EFFeatureDal2>();

            services.AddScoped<ICommnetService, CommentManager>();
            services.AddScoped<ICommentDal, EFCommentDal>();

            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDal, EFTestimonialDal>();
            
            services.AddScoped<ISubAboutService, SubAboutManager>();
            services.AddScoped<ISubAboutDal, EFSubAboutDal>();

            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EFDestinationDal>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EFAppUserDal>();

            services.AddScoped<IRezervationService, RezervationManager>();
            services.AddScoped<IRezervationDal, EFRezervationDal>();

            services.AddScoped<ICatagoryService, CatagoryManager>();
            services.AddScoped<ICatagoryDal, EFCatagoryDal>();

            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EFGuideDal>();

            services.AddScoped<IExcelService, ExcelManager>();

            services.AddScoped<IPDFRportService, PDFReportManager>();

            services.AddScoped<IContactInfoService, ContactInfoManager>();
            services.AddScoped<IContactInfoDal, EFContactInfoDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EFContactDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EFAnnouncementDal>();


        }

        public static void CustomerValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AnnonuncementAddDTO>, AnnonuncementValidator>();
            services.AddTransient<IValidator<AnnonuncementUpdateDTO>, AnnonuncementUpdateValidator>();
        }
    }
}
