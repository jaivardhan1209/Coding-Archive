using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codepractice.Custom
{
    public class Test
    {
        /// <summary>
        /// Gets or sets the nam.
        /// </summary>
        [CustomJai("jai")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        public DateTime? StartDate { get; set; }
    }
}
