using System.Threading.Tasks;
using API.Event;
using Quartz;

namespace DuckSoup.Library.Event;

public class EventJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var eEvent = context.JobDetail.JobDataMap["event"] as IEvent; // using disposes at the end
        if (eEvent == null) return;

        await Task.Run(() => { eEvent.SetEventState(EventStateEnum.Starting); });
    }
}