using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDriver.Figures;

namespace ChessDriver
{
    public class Step
    {
        public int X, Y;
        public Figure Parent;
        public double Weight;

        public void doStep(List<Figure> figures)
        {
            Parent.Coord[0] = X;
            Parent.Coord[1] = Y;
            Parent.IsMoved = true;
            foreach(Figure f in figures)
            {
                if (f.Equals(Parent) == true) continue;
                if (f.Coord[0] != X || f.Coord[1] != Y) continue;
                if (f.IsEaten) continue;
                f.IsEaten = true;
                f.Coord[0] = 9;
                f.Coord[1] = 11;
                break;
            }
        }
    }
}
