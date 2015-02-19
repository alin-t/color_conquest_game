using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGameLib
{
    public interface IVisitingBoard
    {
        bool WasVisited(int x, int y);
        void SetVisited(int x, int y);
        void SetNotVisited(int x, int y);
    }
}
