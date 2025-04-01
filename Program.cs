var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();  // 1?? Enables MVC

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Configure MVC Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TeacherPage}/{action=List}/{id?}"  // 2?? Sets default controller & action
);

app.Run();


