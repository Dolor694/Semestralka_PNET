using Gym.Business.Factories;
using Gym.Business.Services.AimOfPLanService;
using Gym.Business.Services.ExerciseService;
using Gym.Business.Services.ExerciseInTrainingService;
using Gym.Business.Services.MuscleService;
using Gym.Business.Services.MuscleGroupService;
using Gym.Business.Services.TrainingService;
using Gym.Business.Services.TrainingPlanService;
using Gym.Business.Services.TrainingTypeService;
using Gym.Business.Services.TrainingTypeSequenceService;
using Gym.Business.Services.UserService;
using Gym.Business.TrainingGenerator;
using Gym.Models._Database.Seed;
using Gym.Models._Repo;
using Gym.Models.AimOfPlanEntity;
using Gym.Models.Data;
using Gym.Models.ExerciseEntity;
using Gym.Models.ExerciseInTrainingEntity;
using Gym.Models.MuscleEntity;
using Gym.Models.MuscleGroupEntity;
using Gym.Models.TrainingEntity;
using Gym.Models.TrainingTypeEntity;
using Gym.Models.TrainingTypeSequenceEntity;
using Gym.Models.TrainingPlanEntity;
using Gym.Models.UserEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<GymDbContext>(options =>
    options.UseSqlite("Data Source=gym.db"));

// Repositories
builder.Services.AddScoped<IAimOfPlanRepository, DatabaseAimOfPlanRepo>();
builder.Services.AddScoped<IExerciseInTrainingRepository, DatabaseExerciseInTrainingRepo>();
builder.Services.AddScoped<IExerciseRepository, DatabaseExerciseRepo>();
builder.Services.AddScoped<IMuscleGroupRepository, DatabaseMuscleGroupRepo>();
builder.Services.AddScoped<IMuscleRepository, DatabaseMuscleRepo>();
builder.Services.AddScoped<ITrainingPlanRepository, DatabaseTrainingPlanRepo>();
builder.Services.AddScoped<ITrainingRepository, DatabaseTrainingRepo>();
builder.Services.AddScoped<ITrainingTypeRepository, DatabaseTrainingTypeRepo>();
builder.Services.AddScoped<ITrainingTypeSequenceRepository, DatabaseTrainingTypeSequenceRepo>();
builder.Services.AddScoped<IUserRepository, DatabaseUserRepo>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(DatabaseRepository<>));

// Services
builder.Services.AddScoped<IAimOfPlanService, AimOfPlanService>();
builder.Services.AddScoped<IExerciseInTrainingService, ExerciseInTrainingService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IMuscleGroupService, MuscleGroupService>();
builder.Services.AddScoped<IMuscleService, MuscleService>();
builder.Services.AddScoped<ITrainingPlanService, TrainingPlanService>();
builder.Services.AddScoped<ITrainingService, TrainingService>();
builder.Services.AddScoped<ITrainingTypeSequenceService, TrainingTypeSequenceService>();
builder.Services.AddScoped<ITrainingTypeService, TrainingTypeService>();
builder.Services.AddScoped<IUserService, UserService>();

// Generators
builder.Services.AddScoped<ITrainingGenerator, TrainingGenerator>();
builder.Services.AddScoped<INextTrainingTypeSequenceResolver, NextTrainingTypeSequenceResolver>();
builder.Services.AddScoped<IExerciseGetter, ExerciseGetter>();
builder.Services.AddScoped<IExerciseSelector, ExerciseSelector>();
builder.Services.AddSingleton<AimOfPlanFactory>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontends", policy =>
    {
        policy.AllowAnyOrigin() // Simplified for production/local evaluation
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Reset + seed at startup (testing)
using (IServiceScope scope = app.Services.CreateScope())
{
    GymDbContext dbContext = scope.ServiceProvider.GetRequiredService<GymDbContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated(); // Ensure the file is created before seeding
    DbSeeder.Seed(dbContext);
}

// Order matters here!
app.UseBlazorFrameworkFiles(); // This requires the above using directive
app.UseStaticFiles();          // Serves the files from wwwroot

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontends");
app.UseAuthorization();
app.MapControllers();

// If no API route matches, serve the Blazor app
app.MapFallbackToFile("index.html");

app.Run();