using Bearstrength.Models;
using System.Collections.Generic;

namespace Bearstrength.Data
{
    public interface IBearstrengthRepository
    {
        void AddActivity(Activity activity);
        IEnumerable<Activity> GetActivitiesByCategory(Category category);
        IEnumerable<Activity> GetAllActivities();
        IEnumerable<Category> GetAllCategories();
        bool SaveAll();
    }
}