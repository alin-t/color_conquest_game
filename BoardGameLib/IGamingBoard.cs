using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGameLib
{
    public interface IGamingBoard
    {
        int PickNextColor();
        void MoveNext(int color);
        bool IsGameOver();
        void SetColor(int x, int y, int color);
        int GetColor(int x, int y);

        int GetSize();
        int GetColorsNumber();
    }
}
