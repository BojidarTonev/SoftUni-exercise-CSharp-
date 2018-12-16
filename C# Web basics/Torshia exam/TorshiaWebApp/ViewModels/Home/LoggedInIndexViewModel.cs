using System.Collections.Generic;
using TorshiaWebApp.ViewModels.Tasks;

namespace TorshiaWebApp.ViewModels.Home
{
    public class LoggedInIndexViewModel
    {
        public IEnumerable<BaseTaskViewModel> YourTasks { get; set; }

        //public IEnumerable<BaseChannelViewModel> SuggestedChannels { get; set; }

        //public IEnumerable<BaseChannelViewModel> SeeOtherChannels { get; set; }
    }
}
