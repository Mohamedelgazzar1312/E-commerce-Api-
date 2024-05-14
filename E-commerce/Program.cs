using Services.Mapper;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Repository.GenericRepo;
using Repository.UserRepo;
using Services.GenericServices;
using Services.UserServices;
using Services.OrderServices;
using Services.OrderDetailsServices;
using Repository.CartRepo;
using Repository.CategoryRepo;
using Repository.OrderDetailsRepo;
using Repository.OrderRepo;
using Repository.ProductRepo;
using Services.ProductServices;
using Services.CategoryServices;
using Services.CartServices;
using Context;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace E_commerce
{
    public class Program
    {
        public static void Main(string[] args)
        {



     
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<E_Context>();

            // Register repositories
          
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IcartRepository, CartRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            // Register other repositories as needed

            // Register services
            builder.Services.AddScoped<IUserService, UserService>();  
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IOrderService, OrderService>();  
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
            //// Register other services as needed

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(op =>
            {
                op.AddProfile(new MapperProfile());
            });

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            builder.Services.AddIdentity<User, IdentityRole>(op => op.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<E_Context>();

            builder.Services.AddAuthentication(op =>
            {
                op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(op =>
            {
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:Key"])),
                    ValidateIssuerSigningKey = true,
                    ValidAudience = builder.Configuration["jwt:audience"],
                    ValidateAudience = true,
                    ValidIssuer = builder.Configuration["jwt:issuer"],
                    ValidateIssuer = true,
                };
            });

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                // Define the OAuth2.0 scheme that's in use (i.e., Implicit, Password, Application and AccessCode)
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }

 
}