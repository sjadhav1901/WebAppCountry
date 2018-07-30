using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Country.Repositories;

namespace WebApp.Country.Helpers
{
    public interface IActivityHelper
    {
        void SaveActivity(string name, string description, Guid createdBy);
    }
    public class ActivityHelper : IActivityHelper
    {
        private IRecentActivityRepository _recentActivityRepository;
        public ActivityHelper(IRecentActivityRepository recentActivityRepository)
        {
            _recentActivityRepository = recentActivityRepository;
        }

        public void SaveActivity(string name, string description, Guid createdBy)
        {
            _recentActivityRepository.Save(new Contracts.DataModels.RecentActivity
            {
                Name = name,
                Description = description,
                IsEnabled = true,
                CreatedUtc = DateTime.Now,
                CreatedBy = createdBy
            });
        }
    }
}
