using Microsoft.AspNetCore.Builder;
using AppProduct;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("AppProduct.Web.csproj"); 
await builder.RunAbpModuleAsync<AppProductWebTestModule>(applicationName: "AppProduct.Web");

public partial class Program
{
}
