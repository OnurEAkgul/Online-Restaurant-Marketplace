
using Business.Interfaces;
using Business.Managers;
using Business.Services;
using Core.Entities.Domains;
using DataAccess.EntityFramework;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Dijital_carsi.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();




// Configure JWT settings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddScoped<UserManager<IdentityUser>>();
//CartItem
builder.Services.AddScoped<InterfaceCartItemDAL, CartItemDAL>();
builder.Services.AddScoped<InterfaceCartItemService>(serviceProvider =>
{
    var cartItemDAL = serviceProvider.GetRequiredService<InterfaceCartItemDAL>();

    // Use a factory method to asynchronously create an instance of InterfaceCartItemService
    Func<Task<InterfaceShoppingCartService>> shoppingCartServiceFactory = async () =>
    {
        // Resolve InterfaceShoppingCartService from the service provider
        var shoppingCartService = serviceProvider.GetRequiredService<InterfaceShoppingCartService>();
        return shoppingCartService;
    };

    // Instantiate CartItemManager with dependencies
    return new CartItemManager(cartItemDAL, shoppingCartServiceFactory);
});

//builder.Services.AddScoped<InterfaceCartItemService, CartItemManager>();

//Ticket
builder.Services.AddScoped<InterfaceTicketDAL, TicketDAL>();
builder.Services.AddScoped<InterfaceTicketService, TicketManager>();

//Category
builder.Services.AddScoped<InterfaceCategoryDAL, CategoryDAL>();
builder.Services.AddScoped<InterfaceCategoryService, CategoryManager>();


// ShoppingCart
builder.Services.AddScoped<InterfaceShoppingCartDAL, ShoppingCartDAL>();
// Register InterfaceShoppingCartService with a factory method
builder.Services.AddScoped<InterfaceShoppingCartService>(serviceProvider =>
{
    var shoppingCartDAL = serviceProvider.GetRequiredService<InterfaceShoppingCartDAL>();
    var cartItemDAL = serviceProvider.GetRequiredService<InterfaceCartItemDAL>();

    // Use a factory method to asynchronously create an instance of InterfaceCartItemService
    Func<Task<InterfaceCartItemService>> cartItemServiceFactory = async () =>
    {
        // Resolve InterfaceCartItemService from the service provider
        var cartItemService = serviceProvider.GetRequiredService<InterfaceCartItemService>();
        return await Task.FromResult(cartItemService);
    };

    // Instantiate ShoppingCartManager with dependencies
    return new ShoppingCartManager(shoppingCartDAL, cartItemDAL, cartItemServiceFactory);
});

//OrderItem
builder.Services.AddScoped<InterfaceOrderItemDAL, OrderItemDAL>();
builder.Services.AddScoped<InterfaceOrderItemService, OrderItemManager>();

//Order
builder.Services.AddScoped<InterfaceOrderDAL, OrderDAL>();
builder.Services.AddScoped<InterfaceOrderService, OrderManager>();

//Product
builder.Services.AddScoped<InterfaceProductDAL, ProductDAL>();
builder.Services.AddScoped<InterfaceProductService, ProductManager>();

//Shop
builder.Services.AddScoped<InterfaceShopDAL, ShopDAL>();
builder.Services.AddScoped<InterfaceShopService, ShopManager>();

//User
builder.Services.AddScoped<InterfaceUserService, UserManager>();

//Token
builder.Services.AddScoped<InterfaceTokenService, TokenManager>();


//NormalUser
builder.Services.AddScoped<InterfaceNormalUserDAL, NormalUserDAL>();

//ShopOwner
builder.Services.AddScoped<InterfaceShopOwnerDAL, ShopOwnerDAL>();
builder.Services.AddScoped<IUserStore<ShopOwner>, UserStore<ShopOwner, IdentityRole, ApplicationDbContext, string>>();

//SupportUser
builder.Services.AddScoped<InterfaceSupportUserDAL, SupportUserDAL>();
builder.Services.AddScoped<IUserStore<SupportUser>, UserStore<SupportUser, IdentityRole, ApplicationDbContext, string>>();



builder.Services.Configure<IdentityOptions>(options =>
{
    // Şifre gereksinimlerini yapılandır
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 5;
    options.Password.RequiredUniqueChars = 0;
});

builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token received from Login method \n\n Name: Authorization\n\n In: Header",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey =
            new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS ayarları
app.UseCors(Options =>
{
    Options.AllowAnyHeader();
    Options.AllowAnyOrigin();
    Options.AllowAnyMethod();
});


app.UseAuthorization();

app.MapControllers();

app.Run();
