using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingLecture
{
    public class JohnHasDoneSomethingBadException :Exception
    {
        public JohnHasDoneSomethingBadException (string message) :base(message)
        {

        }
    }
}
