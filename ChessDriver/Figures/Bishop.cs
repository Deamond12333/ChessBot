using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDriver.Figures
{
    public class Bishop:Figure
    {
        public List<int[]> getAllowedSteps(List<Figure> figures, Figure f)
        {
            List<int[]> allowedSteps = new List<int[]>();
            int stepLength = 1;
            bool RD = true, LD = true, RU = true, LU = true, RDE = false, LDE = false, RUE = false, LUE = false;

            while (stepLength <= 8)
            {
                foreach (Figure f1 in figures)
                {
                    if (f1.Equals(f)) continue;
                    //ищем ходы вниз вправо
                    if (RD && f1.Coord[0] == f.Coord[0] + stepLength && f1.Coord[1] == f.Coord[1] + stepLength)
                    {
                        if (f1.IsWhite != f.IsWhite) RDE = true;
                        RD = false;
                    }
                    //ищем ходы вниз влево
                    if (LD && f1.Coord[0] == f.Coord[0] - stepLength && f1.Coord[1] == f.Coord[1] + stepLength)
                    {
                        if (f1.IsWhite != f.IsWhite) LDE = true;
                        LD = false;
                    }
                    //ищем ходы вверх влево
                    if (LU && f1.Coord[0] == f.Coord[0] - stepLength && f1.Coord[1] == f.Coord[1] - stepLength)
                    {
                        if (f1.IsWhite != f.IsWhite) LUE = true;
                        LU = false;
                    }
                    //ищем ходы вверх вправо
                    if (RU && f1.Coord[0] == f.Coord[0] + stepLength && f1.Coord[1] == f.Coord[1] - stepLength)
                    {
                        if (f1.IsWhite != f.IsWhite) RUE = true;
                        RU = false;
                    }
                }
                if ((RDE || RD) && (f.Coord[0] + stepLength < 8 && f.Coord[1] + stepLength < 8))
                {
                    allowedSteps.Add(new int[] { f.Coord[0] + stepLength, f.Coord[1] + stepLength });
                    if (RDE) RDE = false;
                }
                if ((LDE || LD) && (f.Coord[0] - stepLength > -1 && f.Coord[1] + stepLength < 8))
                {
                    allowedSteps.Add(new int[] { f.Coord[0] - stepLength, f.Coord[1] + stepLength });
                    if (LDE) LDE = false;
                }
                if ((RUE || RU) && (f.Coord[0] + stepLength < 8 && f.Coord[1] - stepLength > -1))
                {
                    allowedSteps.Add(new int[] { f.Coord[0] + stepLength, f.Coord[1] - stepLength });
                    if (RUE) RUE = false;
                }
                if ((LUE || LU) && (f.Coord[0] - stepLength > -1 && f.Coord[1] - stepLength > -1))
                {
                    allowedSteps.Add(new int[] { f.Coord[0] - stepLength, f.Coord[1] - stepLength });
                    if (LUE) LUE = false;
                }
                stepLength++;
            }
            return allowedSteps;
        }
    }
}
