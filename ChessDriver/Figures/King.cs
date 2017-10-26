using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDriver.Figures
{
    public class King:Figure
    {
        public List<int[]> getAllowedSteps(List<Figure> figures, Figure f)
        {
            //обработать рокировку
            List<int[]> allowedSteps = new List<int[]>();
            bool U = true, RU = true, R = true, RD = true, D = true, LD = true, L = true, LU = true;
            bool UE = false, RUE = false, RE = false, RDE = false, DE = false, LDE = false, LE = false, LUE = false;

            foreach (Figure f1 in figures)
            {
                if (f1.Equals(f)) continue;
                //ищем ход вниз вправо
                if (RD && f1.Coord[0] == f.Coord[0] + 1 && f1.Coord[1] == f.Coord[1] + 1)
                {
                    if (f1.IsWhite != f.IsWhite) RDE = true;
                    RD = false;
                }
                //ищем ход вниз влево
                if (LD && f1.Coord[0] == f.Coord[0] - 1 && f1.Coord[1] == f.Coord[1] + 1)
                {
                    if (f1.IsWhite != f.IsWhite) LDE = true;
                    LD = false;
                }
                //ищем ход вверх вправо
                if (RU && f1.Coord[0] == f.Coord[0] + 1 && f1.Coord[1] == f.Coord[1] - 1)
                {
                    if (f1.IsWhite != f.IsWhite) RUE = true;
                    RU = false;
                }
                //ищем ход вверх влево
                if (LU && f1.Coord[0] == f.Coord[0] - 1 && f1.Coord[1] == f.Coord[1] - 1)
                {
                    if (f1.IsWhite != f.IsWhite) LUE = true;
                    LU = false;
                }
                //ищем ход вправо
                if (R && f1.Coord[0] == f.Coord[0] + 1 && f1.Coord[1] == f.Coord[1])
                {
                    if (f1.IsWhite != f.IsWhite) RE = true;
                    R = false;
                }
                //ищем ход влево
                if (L && f1.Coord[0] == f.Coord[0] - 1 && f1.Coord[1] == f.Coord[1])
                {
                    if (f1.IsWhite != f.IsWhite) LE = true;
                    L = false;
                }
                //ищем ход верх
                if (U && f1.Coord[1] == f.Coord[1] - 1 && f1.Coord[0] == f.Coord[0])
                {
                    if (f1.IsWhite != f.IsWhite) UE = true;
                    U = false;
                }
                //ищем ход вниз
                if (D && f1.Coord[1] == f.Coord[1] + 1 && f1.Coord[0] == f.Coord[0])
                {
                    if (f1.IsWhite != f.IsWhite) DE = true;
                    D = false;
                }
            }
            if ((RD || RDE) && (f.Coord[0] + 1 < 8 && f.Coord[1] + 1 < 8))
            {
                allowedSteps.Add(new int[2] { f.Coord[0] + 1, f.Coord[1] + 1 });
                if (RDE) RDE = false;
            }
            if ((LD || LDE) && (f.Coord[0] - 1 > -1 && f.Coord[1] + 1 < 8))
            {
                allowedSteps.Add(new int[2] { f.Coord[0] - 1, f.Coord[1] + 1 });
                if (LDE) LDE = false;
            }
            if ((RU || RUE) && (f.Coord[0] + 1 < 8 && f.Coord[1] - 1 > -1))
            {
                allowedSteps.Add(new int[2] { f.Coord[0] + 1, f.Coord[1] - 1 });
                if (RUE) RUE = false;
            }
            if ((LU || LUE) && (f.Coord[0] - 1 > -1 && f.Coord[1] - 1 > -1))
            {
                allowedSteps.Add(new int[2] { f.Coord[0] - 1, f.Coord[1] - 1 });
                if (LUE) LUE = false;
            }
            if ((R || RE) && f.Coord[0] + 1 < 8)
            {
                allowedSteps.Add(new int[2] { f.Coord[0] + 1, f.Coord[1] });
                if (RE) RE = false;
            }
            if ((L || LE) && f.Coord[0] - 1 > -1)
            {
                allowedSteps.Add(new int[2] { f.Coord[0] - 1, f.Coord[1] });
                if (LE) LE = false;
            }
            if ((U || UE) && f.Coord[1] - 1 > -1)
            {
                allowedSteps.Add(new int[2] { f.Coord[0], f.Coord[1] - 1 });
                if (UE) UE = false;
            }
            if ((D || DE) && f.Coord[1] + 1 < 8)
            {
                allowedSteps.Add(new int[2] { f.Coord[0], f.Coord[1] + 1 });
                if (DE) DE = false;
            }
            return allowedSteps;
        }
    }
}
