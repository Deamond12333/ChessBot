using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ChessDriver.Figures
{
    public class Pawn:Figure
    {
        public List<int[]> getAllowedSteps(List<Figure> figures, Figure f)
        {
            // обработать момент, когда пешка дошла до конца поля
            List<int[]> allowedSteps = new List<int[]>();
            bool isStep = true, ER = false, EL = false;
            double stepLength;

            if (IsWhite)
            {
                if (f.Coord[1] == 6) stepLength = -2;
                else stepLength = -1;
            }
            else
            {
                if (f.Coord[1] == 1) stepLength = 2;
                else stepLength = 1;
            }

            while (stepLength >= 1 || stepLength <= -1)
            {
                foreach (Figure f1 in figures)
                {
                    if (f1.Equals(f)) continue;
                    if (f1.Coord[1] == f.Coord[1] + stepLength && f1.Coord[0] == f.Coord[0])
                    {
                        isStep = false;
                        break;
                    }
                }
                if (isStep) allowedSteps.Add(new int[2] { f.Coord[0], f.Coord[1] + (int)stepLength });
                stepLength /= 2;
            }
            stepLength *= 2;
            foreach (Figure f1 in figures)
            {
                if (f1.Equals(f)) continue;
                if (f1.Coord[1] == f.Coord[1] + stepLength && f1.Coord[0] == f.Coord[0] + 1 && f1.IsWhite != f.IsWhite)
                {
                    ER = true;
                }
                if (f1.Coord[1] == f.Coord[1] + stepLength && f1.Coord[0] == f.Coord[0] - 1 && f1.IsWhite != f.IsWhite)
                {
                    EL = true;
                }
            }
            if (ER) allowedSteps.Add(new int[2] { f.Coord[0] + 1, f.Coord[1] + (int)stepLength });
            if (EL) allowedSteps.Add(new int[2] { f.Coord[0] - 1, f.Coord[1] + (int)stepLength });
            return allowedSteps;
        }
    }
}
