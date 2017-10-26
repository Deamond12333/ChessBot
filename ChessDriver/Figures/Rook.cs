using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDriver.Figures
{
    public class Rook:Figure
    {
        public List<int[]> getAllowedSteps(List<Figure> figures, Figure f)
        {
            List<int[]> allowedSteps = new List<int[]>();
            int stepLength = 1;
            bool R = true, D = true, U = true, L = true, RE = false, DE = false, UE = false, LE = false;
            while (stepLength <= 8)
            {
                foreach (Figure f1 in figures)
                {
                    if (f1.Equals(f)) continue;
                    //ищем ходы вправо
                    if (R && f1.Coord[0] == f.Coord[0] + stepLength && f1.Coord[1] == f.Coord[1])
                    {
                        if (f1.IsWhite != f.IsWhite) RE = true;
                        R = false;
                    }
                    //ищем ходы вниз
                    if (D && f1.Coord[0] == f.Coord[0] && f1.Coord[1] == f.Coord[1] + stepLength)
                    {
                        if (f1.IsWhite != f.IsWhite) DE = true;
                        D = false;
                    }
                    //ищем ходы вверх
                    if (U && f1.Coord[0] == f.Coord[0] && f1.Coord[1] == f.Coord[1] - stepLength)
                    {
                        if (f1.IsWhite != f.IsWhite) UE = true;
                        U = false;
                    }
                    //ищем ходы влево
                    if (L && f1.Coord[0] == f.Coord[0] - stepLength && f1.Coord[1] == f.Coord[1])
                    {
                        if (f1.IsWhite != f.IsWhite) LE = true;
                        L = false;
                    }
                }
                if ((RE || R) && f.Coord[0] + stepLength < 8)
                {
                    allowedSteps.Add(new int[] { f.Coord[0] + stepLength, f.Coord[1] });
                    if (RE) RE = false;
                }
                if ((DE || D) && f.Coord[1] + stepLength < 8)
                {
                    allowedSteps.Add(new int[] { f.Coord[0], f.Coord[1] + stepLength });
                    if (DE) DE = false;
                }
                if ((UE || U) && f.Coord[1] - stepLength > -1)
                {
                    allowedSteps.Add(new int[] { f.Coord[0], f.Coord[1] - stepLength });
                    if (UE) UE = false;
                }
                if ((LE || L) && f.Coord[0] - stepLength > -1)
                {
                    allowedSteps.Add(new int[] { f.Coord[0] - stepLength, f.Coord[1]});
                    if (LE) LE = false;
                }
                stepLength++;
            }
            return allowedSteps;
        }
    }
}
