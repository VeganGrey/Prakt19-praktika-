using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prakt18_praktika_
{
    internal class DetDomContext : DetdomEntities1
    {
        private static DetDomContext context;

        public static DetDomContext GetContext()
        {
            if (context == null)
            {
                context = new DetDomContext();
            }
            return context;
        }
    }
}
