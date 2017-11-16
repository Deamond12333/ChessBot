using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDriver.Figures
{
    public class King:Figure
    {
        public List<Step> getAllowedSteps(List<Figure> figures)
        {
            //обработать рокировку
            List<Step> allowedSteps = new List<Step>();
            bool U = true, RU = true, R = true, RD = true, D = true, LD = true, L = true, LU = true;
            bool UE = false, RUE = false, RE = false, RDE = false, DE = false, LDE = false, LE = false, LUE = false;

            foreach (Figure f1 in figures)
            {
                if (f1.Equals(this)) continue;
                //ищем ход вниз вправо
                if (RD && f1.Coord[0] == Coord[0] + 1 && f1.Coord[1] == Coord[1] + 1)
                {
                    if (f1.IsWhite != IsWhite) RDE = true;
                    RD = false;
                    continue;
                }
                //ищем ход вниз влево
                if (LD && f1.Coord[0] == Coord[0] - 1 && f1.Coord[1] == Coord[1] + 1)
                {
                    if (f1.IsWhite != IsWhite) LDE = true;
                    LD = false;
                    continue;
                }
                //ищем ход вверх вправо
                if (RU && f1.Coord[0] == Coord[0] + 1 && f1.Coord[1] == Coord[1] - 1)
                {
                    if (f1.IsWhite != IsWhite) RUE = true;
                    RU = false;
                    continue;
                }
                //ищем ход вверх влево
                if (LU && f1.Coord[0] == Coord[0] - 1 && f1.Coord[1] == Coord[1] - 1)
                {
                    if (f1.IsWhite != IsWhite) LUE = true;
                    LU = false;
                    continue;
                }
                //ищем ход вправо
                if (R && f1.Coord[0] == Coord[0] + 1 && f1.Coord[1] == Coord[1])
                {
                    if (f1.IsWhite != IsWhite) RE = true;
                    R = false;
                    continue;
                }
                //ищем ход влево
                if (L && f1.Coord[0] == Coord[0] - 1 && f1.Coord[1] == Coord[1])
                {
                    if (f1.IsWhite != IsWhite) LE = true;
                    L = false;
                    continue;
                }
                //ищем ход верх
                if (U && f1.Coord[1] == Coord[1] - 1 && f1.Coord[0] == Coord[0])
                {
                    if (f1.IsWhite != IsWhite) UE = true;
                    U = false;
                    continue;
                }
                //ищем ход вниз
                if (D && f1.Coord[1] == Coord[1] + 1 && f1.Coord[0] == Coord[0])
                {
                    if (f1.IsWhite != IsWhite) DE = true;
                    D = false;
                    continue;
                }
            }
            if ((RD || RDE) && (Coord[0] + 1 < 8 && Coord[1] + 1 < 8))
            {
                Step step = new Step();
                step.X = Coord[0] + 1;
                step.Y = Coord[1] + 1;
                step.Parent = this;
                allowedSteps.Add(step);
                if (RDE) RDE = false;
            }
            if ((LD || LDE) && (Coord[0] - 1 > -1 && Coord[1] + 1 < 8))
            {
                Step step = new Step();
                step.X = Coord[0] - 1;
                step.Y = Coord[1] + 1;
                step.Parent = this;
                allowedSteps.Add(step);
                if (LDE) LDE = false;
            }
            if ((RU || RUE) && (Coord[0] + 1 < 8 && Coord[1] - 1 > -1))
            {
                Step step = new Step();
                step.X = Coord[0] + 1;
                step.Y = Coord[1] - 1;
                step.Parent = this;
                allowedSteps.Add(step);
                if (RUE) RUE = false;
            }
            if ((LU || LUE) && (Coord[0] - 1 > -1 && Coord[1] - 1 > -1))
            {
                Step step = new Step();
                step.X = Coord[0] - 1;
                step.Y = Coord[1] - 1;
                step.Parent = this;
                allowedSteps.Add(step);
                if (LUE) LUE = false;
            }
            if ((R || RE) && Coord[0] + 1 < 8)
            {
                Step step = new Step();
                step.X = Coord[0] + 1;
                step.Y = Coord[1];
                step.Parent = this;
                allowedSteps.Add(step);
                if (RE) RE = false;
            }
            if ((L || LE) && Coord[0] - 1 > -1)
            {
                Step step = new Step();
                step.X = Coord[0] - 1;
                step.Y = Coord[1];
                step.Parent = this;
                allowedSteps.Add(step);
                if (LE) LE = false;
            }
            if ((U || UE) && Coord[1] - 1 > -1)
            {
                Step step = new Step();
                step.X = Coord[0];
                step.Y = Coord[1] - 1;
                step.Parent = this;
                allowedSteps.Add(step);
                if (UE) UE = false;
            }
            if ((D || DE) && Coord[1] + 1 < 8)
            {
                Step step = new Step();
                step.X = Coord[0];
                step.Y = Coord[1] + 1;
                step.Parent = this;
                allowedSteps.Add(step);
                if (DE) DE = false;
            }
            return allowedSteps;
        }
    }
}
