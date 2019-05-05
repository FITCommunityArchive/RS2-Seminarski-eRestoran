using Quartz;
using Quartz.Impl;

namespace eRestoran.Api.Infrastructure
{
    public class JobScheduler
    {
        public JobScheduler() { }

        public async void Start()
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            IScheduler sched = await schedFact.GetScheduler();
            await sched.Start();

            IJobDetail job = JobBuilder.Create<PromotionsJob>()
                     .WithIdentity("myJob", "group1")
                     .Build();

            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity("myTrigger", "group1")
              .StartNow()
               .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(6, 0))
                  .Build();

            await sched.ScheduleJob(job, trigger);
        }
    }
}