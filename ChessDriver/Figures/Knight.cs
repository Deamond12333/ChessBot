using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDriver.Figures
{
    public class Knight:Figure
    {
        public List<int[]> getAllowedSteps(List<Figure> figures, Figure f)
        {
            List<int[]> allowedSteps = new List<int[]>();
            bool UL = true, RU = true, UR = true, RD = true, DL = true, LD = true, DR = true, LU = true;
            bool ULE = false, RUE = false, URE = false, RDE = false, DLE = false, LDE = false, DRE = false, LUE = false;

            foreach (Figure f1 in figures)
            {
                if (f1.Equals(f)) continue;
                //ищем ход вниз вправо
                if (f1.Coord[0] == f.Coord[0] + 1 && f1.Coord[1] == f.Coord[1] + 2)
                {
                    if (f1.IsWhite != f.IsWhite) DRE = true;
                    DR = false;
                }
                //ищем ход вниз влево
                if (f1.Coord[0] == f.Coord[0] - 1 && f1.Coord[1] == f.Coord[1] + 2)
                {
                    if (f1.IsWhite != f.IsWhite) DLE = true;
                    DL = false;
                }
                //ищем ход вверх вправо
                if (f1.Coord[0] == f.Coord[0] + 1 && f1.Coord[1] == f.Coord[1] - 2)
                {
                    if (f1.IsWhite != f.IsWhite) URE = true;
                    UR = false;
                }
                //ищем ход вверх влево
                if (f1.Coord[0] == f.Coord[0] - 1 && f1.Coord[1] == f.Coord[1] - 2)
                {
                    if (f1.IsWhite != f.IsWhite) ULE = true;
                    UL = false;
                }
                //ищем ход вправо вниз
                if (f1.Coord[0] == f.Coord[0] + 2 && f1.Coord[1] == f.Coord[1] + 1)
                {
                    if (f1.IsWhite != f.IsWhite) RDE = true;
                    RD = false;
                }
                //ищем ход вправо вверх
                if (f1.Coord[0] == f.Coord[0] + 2 && f1.Coord[1] == f.Coord[1] - 1)
                {
                    if (f1.IsWhite != f.IsWhite) RUE = true;
                    RU = false;
                }
                //ищем ход влево вниз
                if (f1.Coord[1] == f.Coord[0] - 2 && f1.Coord[0] == f.Coord[1] + 1)
                {
                    if (f1.IsWhite != f.IsWhite) LDE = true;
                    LD = false;
                }
                //ищем ход влево вверх
                if (f1.Coord[1] == f.Coord[1] - 1 && f1.Coord[0] == f.Coord[1] - 1)
                {
                    if (f1.IsWhite != f.IsWhite) LUE = true;
                    LU = false;
                }
            }
            if ((DR || DRE) && (f.Coord[0] + 1 < 8 && f.Coord[1] + 2 < 8))
            {
                allowedSteps.Add(new int[2] { f.Coord[0] + 1, f.Coord[1] + 2 });
            }
            if ((DL || DLE) && (f.Coord[0] - 1 > -1 && f.Coord[1] + 2 < 8))
            {
                allowedSteps.Add(new int[2] { f.Coord[0] - 1, f.Coord[1] + 2 });
            }
            if ((UR || URE) && (f.Coord[0] + 1 < 8 && f.Coord[1] - 2 > -1))
            {
                allowedSteps.Add(new int[2] { f.Coord[0] + 1, f.Coord[1] - 2 });
            }
            if ((UL || ULE) && (f.Coord[0] - 1 > -1 && f.Coord[1] - 2 > -1))
            {
                allowedSteps.Add(new int[2] { f.Coord[0] - 1, f.Coord[1] - 2 });
            }
            if ((RD || RDE) && f.Coord[0] + 2 < 8 && f.Coord[1] + 1 < 8)
            {
                allowedSteps.Add(new int[2] { f.Coord[0] + 2, f.Coord[1] + 1 });
            }
            if ((RU || RUE) && f.Coord[0] + 2 < 8 && f.Coord[1] - 1 > -1)
            {
                allowedSteps.Add(new int[2] { f.Coord[0] + 2, f.Coord[1] - 1 });
            }
            if ((LD || LDE) && f.Coord[0] - 2 > -1 && f.Coord[1] + 1 < 8)
            {
                allowedSteps.Add(new int[2] { f.Coord[0] - 2, f.Coord[1] + 1 });
            }
            if ((LU || LUE) && f.Coord[0] - 2 > -1 && f.Coord[1] - 1 > -1)
            {
                allowedSteps.Add(new int[2] { f.Coord[0] - 2, f.Coord[1] - 1 });
            }
            return allowedSteps;
        }
    }
}
