using System.Threading.Tasks;
using API.Event;
using Quartz;

namespace DuckSoup.Library.Event;

public class EventJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        using var eEvent = context.JobDetail.JobDataMap["event"] as IEvent;
        if (eEvent == null) return;

        await Task.Run(() => { eEvent.SetEventState(EventStateEnum.Starting); });
    }
}