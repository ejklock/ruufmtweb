using Quartz;
using Quartz.Impl;

namespace ruservice.Jobs
{
	public class JobScheduler
	{
		public static void Start()
		{
			IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
			scheduler.Start();
			IJobDetail job = JobBuilder.Create<UpdateJob>().WithIdentity("job1", "group1").Build();

			ITrigger trigger = TriggerBuilder.Create()
					.WithIdentity("trigger1", "group1")
					.StartNow()
					.WithSimpleSchedule(x => x
						.WithIntervalInHours(1)
						.RepeatForever())
					.Build();

			scheduler.ScheduleJob(job, trigger);

		}
	}
}