using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DFC.UMS.Microservice.Services.Contracts
{
    public interface IViewRenderService
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);

        ActionContext GetActionContext();
    }
}
