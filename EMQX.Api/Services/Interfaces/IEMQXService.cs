using EMQX.Api.Models;
using EMQX.Api.Models.Responses;

namespace EMQX.Api.Services.Interfaces
{
    public interface IEMQXService
    {
        Task<EMQXResponse> ConnectAsync(MessageRequest request);
    }
}