using System;
using System.Collections.Generic;
using System.Text;

namespace Reflections_Copy
{
    public class ProjectServices
    {
        private string serviceName = "My service";
        protected DateTime deployInProdDate = new DateTime();
        public int deployDaysCount;
        public string clientName;
        public int jobsCount;

        public ProjectServices()
        {

        }
    }

}
