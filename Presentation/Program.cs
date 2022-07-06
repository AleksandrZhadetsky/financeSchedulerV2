using DAL.DbContext;
using Domain.DTOs;
using Domain.Responses;
using Domain.Responses.Identity;
using Domain.Entities.User;
using Handlers.Admin.Identity.Registration;
using Handlers.CategoriesProcessing.Create;
using Handlers.CategoriesProcessing.Delete;
using Handlers.CategoriesProcessing.Get;
using Handlers.CategoriesProcessing.Update;
using Handlers.PurchasesProcessing.Create;
using Handlers.PurchasesProcessing.Delete;
using Handlers.PurchasesProcessing.Get;
using Handlers.PurchasesProcessing.Update;
using Handlers.Security;
using Handlers.User.Identity.Login;
using Handlers.User.Identity.Registration;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.Categories;
using Services.Purchases;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddControllers();

builder.Services.AddDbContext<AuthDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConnectionString")
    )
);

builder.Services.AddIdentity<AppUser, IdentityRole>(
        options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequiredLength = 5;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
        }
    )
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }
)
    .AddJwtBearer(
        options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = false, // true,
                ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                ValidAudience = builder.Configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
            };
        }
    );

builder.Services.AddScoped<TokenGenerator>();
builder.Services.AddScoped<ICategoryProcessingService, CategoryProcessingService>();
builder.Services.AddScoped<IPurchaseProcessingService, PurchaseProcessingService>();
builder.Services.AddTransient<IRequestHandler<RegistrationCommand, IdentityResponse>, RegistrationHandler>();
builder.Services.AddTransient<IRequestHandler<AdminRegistrationCommand, IdentityResponse>, AdminRegistrationHandler>();
builder.Services.AddTransient<IRequestHandler<LoginQuery, IdentityResponse>, LoginHandler>();

builder.Services.AddTransient<IRequestHandler<CreateCategoryCommand, CommandResponse<CategoryDTO>>, CreateCategoryCommandHandler>();
builder.Services.AddTransient<IRequestHandler<GetCategoryQuery, CommandResponse<CategoryDTO>>, GetCategoryCommandHandler>();
builder.Services.AddTransient<IRequestHandler<GetCategoriesQuery, CommandResponse<IEnumerable<CategoryDTO>>>, GetCategoriesCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateCategoryCommand, CommandResponse<CategoryDTO>>, UpdateCategoryCommandHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteCategoryCommand, CommandResponse<CategoryDTO>>, DeleteCategoryCommandHandler>();

builder.Services.AddTransient<IRequestHandler<CreatePurchaseCommand, CommandResponse<PurchaseDTO>>, CreatePurchaseCommandHandler>();
builder.Services.AddTransient<IRequestHandler<GetPurchaseQuery, CommandResponse<PurchaseDTO>>, GetPurchaseCommandHandler>();
builder.Services.AddTransient<IRequestHandler<GetPurchasesQuery, CommandResponse<IEnumerable<PurchaseDTO>>>, GetPurchasesCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UpdatePurchaseCommand, CommandResponse<PurchaseDTO>>, UpdatePurchaseCommandHandler>();
builder.Services.AddTransient<IRequestHandler<DeletePurchaseCommand, CommandResponse<PurchaseDTO>>, DeletePurchaseCommandHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();
//app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller}/{action=Index}/{id?}");
//});

app.MapControllers();

app.Run();
