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
            //builder.Services.AddTransient<IMembersRepository, MembersRepository>();
            //builder.Services.AddTransient<IMembersService, MembersService>();
            //builder.Services.AddTransient<IMembershipsRepository, MembershipsRepository>();
            //builder.Services.AddTransient<IMembershipsService, MembershipsService>();
            builder.Services.AddTransient<IMembershipTypesRepository, MembershipTypesRepository>();
            builder.Services.AddTransient<IMembershipTypesService, MembershipTypesService>();
            //builder.Services.AddTransient<ICodeSnippetsRepository, CodeSnippetsRepository>();
            //builder.Services.AddTransient<ICodeSnippetsService, CodeSnippetsService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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