using Microsoft.IdentityModel.Tokens;

namespace TestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors();

            builder.Services.AddAuthentication("token")
              .AddJwtBearer("token", options =>
              {
                  //options.Authority = "what goes here?";
                  options.TokenValidationParameters.ValidateAudience = false;

                  //options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
              });

            //builder.Services.AddAuthentication("Bearer")
            //    .AddJwtBearer("Bearer", options =>
            //    {
            //        //options.Authority = "what goes here?";

            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateAudience = false
            //        };
            //    });

            //builder.Services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("ApiScope", policy =>
            //    {
            //        //policy.RequireAuthenticatedUser();
            //        policy.RequireClaim("scope", "openid {clientID} offline_access access_as_application");
            //    });
            //});

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.WithExposedHeaders("WWW-Authenticate");
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            //app.MapControllers()
            //    .RequireAuthorization("ApiScope");
            app.Run();
        }
    }
}