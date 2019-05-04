using eRestoran.Data.DAL;
using Quartz;
using Quartz.Impl;
using System;
using System.Linq;
using System.Threading.Tasks;

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

    public class PromotionsJob : IJob
    {
        private MyContext db = new MyContext();

        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() => CheckPromotions());
        }

        private void CheckPromotions()
        {
            var startingPromotionsPica = db.Promocije.Where(x => x.ProizvodId.HasValue && x.DatumOd.Day == DateTime.Now.Day
                                                       && x.DatumOd.Month == DateTime.Now.Month && x.DatumOd.Year == DateTime.Now.Year);
            var startingPromotionsJela = db.Promocije.Where(x => x.JeloId.HasValue && x.DatumOd.Day == DateTime.Now.Day
                                                       && x.DatumOd.Month == DateTime.Now.Month && x.DatumOd.Year == DateTime.Now.Year);
            var endingPromotionsPica = db.Promocije.Where(x => x.ProizvodId.HasValue && x.DatumDo.Day == DateTime.Now.Day
                                                       && x.DatumDo.Month == DateTime.Now.Month && x.DatumDo.Year == DateTime.Now.Year);
            var endingPromotionsJela = db.Promocije.Where(x => x.JeloId.HasValue && x.DatumDo.Day == DateTime.Now.Day
                                                       && x.DatumDo.Month == DateTime.Now.Month && x.DatumDo.Year == DateTime.Now.Year);

            startingPromotionsPica.ToList().ForEach(x =>
            {
                x.StaraCijena = x.Proizvod.Cijena;
                x.Proizvod.Cijena = x.PromotivnaCijena;
            });

            startingPromotionsJela.ToList().ForEach(x =>
            {
                x.StaraCijena = x.Jelo.Cijena;
                x.Jelo.Cijena = x.PromotivnaCijena;
            });

            endingPromotionsPica.ToList().ForEach(x =>
            {
                x.Proizvod.Cijena = x.StaraCijena;
            });

            endingPromotionsJela.ToList().ForEach(x =>
            {
                x.Jelo.Cijena = x.StaraCijena;
            });

            db.SaveChanges();

            return;
        }
    }
}