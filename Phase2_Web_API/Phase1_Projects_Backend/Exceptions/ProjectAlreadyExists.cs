using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phase1_Projects_Backend.Exceptions
{
    public class ProjectAlreadyExists:ApplicationException
    {
        public ProjectAlreadyExists()
        {

        }
        public ProjectAlreadyExists(string message):base(message)
        {

        }
    }
}
