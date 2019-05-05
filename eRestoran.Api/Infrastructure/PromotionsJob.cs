using Quartz;
using System.Threading.Tasks;

namespace eRestoran.Api.Infrastructure
{
    public class PromotionsJob : IJob
    {
        PromotionsService promotionsService = new PromotionsService();
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() => promotionsService.CheckPromotions());
        }
    }
}