using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe
{
    public class ChangementCaseEventArgs : EventArgs
    {
        Direction direction;

        public ChangementCaseEventArgs(Direction d)
        {
            direction = d;
        }
    }
}
