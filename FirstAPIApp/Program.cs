using FirstAPIApp.DataContext;
using FirstAPIApp.Repositories;
using FirstAPIApp.Services;
using Microsoft.EntityFrameworkCore;

namespace FirstAPIApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ProgrammingClubDataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

            //builder.Services.AddTransient<ProgrammingClubDataContext, ProgrammingClubDataContext>();
            builder.Services.AddTransient<IAnnouncementsRepository, AnnouncementsRepository>();
            builder.Services.AddTransient<IAnnouncementsService, AnnouncementsService>();
            //builder.Services.AddTransient<MembersRepository, MembersRepository>();
            //builder.Services.AddTransient<MembershipsRepository, MembershipsRepository>();
            //builder.Services.AddTransient<MembershipTypesRepository, MembershipTypesRepository>();
            //builder.Services.AddTransient<CodeSnippetsRepository, CodeSnippetsRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}