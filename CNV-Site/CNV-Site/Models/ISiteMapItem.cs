using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNV_Site.Models
{
       public interface ISiteMapItem
        {
             string Url { get; }
             DateTime? LastModified { get; }
             ChangeFrequency? ChangeFrequency { get; }
             float? Priority { get; }

            
        }

}
