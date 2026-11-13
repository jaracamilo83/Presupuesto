using Presupuestos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepositorioTiposCuenta, RepositorioTiposCuenta>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IRepositorioCuenta, RepositorioCuenta>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzg0Njc4NDAwIiwiaWF0IjoiMTc1MzE0ODA1OCIsImFjY291bnRfaWQiOiIwMTk4MmZjM2E4OGI3OTdjOTQxMTlkYWZiOTE1ZTUzYSIsImN1c3RvbWVyX2lkIjoiY3RtXzAxazBxdzh0cmp4eXljODM2cjNndzZjcDU4Iiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.rc_N-AIh9vYUevTOVqlV0-o8ckAZ_JEBFoFqeisaJe_JWVJmckG_D5WiJ4u5ewyXx5KOE0k7anZDHFevITM0qFQQgNenwPC7JP4KaeSGqS98RP_x7Q13f3lDrKjAjP7DS9HytTkVxFE6rYPaEKpxS9yK3l2rXu1wCIZUnIv2iirEp1YXiuNHg821oZ0Ml6PCnSge4j2TJhY-3BACQm1dNymGTJUZ4zxp0J3rKPILjKKdPCsr-lG4e1-tKIt9wu-wlHCUPkomSj8R5CQeTYty9QbQQUGRSYB0iey_850FlLbBKpMBn9XewIzydMFU2LcbzuCIS9vA_MZvw0qPxGGpSA";
    cfg.CreateMap<Cuenta,CrearCuentaViewModel>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
