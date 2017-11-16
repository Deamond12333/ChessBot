using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDriver.Figures
{
    public class Knight:Figure
    {
        public List<Step> getAllowedSteps(List<Figure> figures)
        {
            List<Step> allowedSteps = new List<Step>();
            bool UL = true, RU = true, UR = true, RD = true, DL = true, LD = true, DR = true, LU = true;
            bool ULE = false, RUE = false, URE = false, RDE = false, DLE = false, LDE = false, DRE = false, LUE = false;

            foreach (Figure f1 in figures)
            {
                if (f1.Equals(this)) continue;
                //ищем ход вниз вправо
                if (f1.Coord[0] == Coord[0] + 1 && f1.Coord[1] == Coord[1] + 2)
                {
                    if (f1.IsWhite != IsWhite) DRE = true;
                    DR = false;
                    continue;
                }
                //ищем ход вниз влево
                if (f1.Coord[0] == Coord[0] - 1 && f1.Coord[1] == Coord[1] + 2)
                {
                    if (f1.IsWhite != IsWhite) DLE = true;
                    DL = false;
                    continue;
                }
                //ищем ход вверх вправо
                if (f1.Coord[0] == Coord[0] + 1 && f1.Coord[1] == Coord[1] - 2)
                {
                    if (f1.IsWhite != IsWhite) URE = true;
                    UR = false;
                    continue;
                }
                //ищем ход вверх влево
                if (f1.Coord[0] == Coord[0] - 1 && f1.Coord[1] == Coord[1] - 2)
                {
                    if (f1.IsWhite != IsWhite) ULE = true;
                    UL = false;
                    continue;
                }
                //ищем ход вправо вниз
                if (f1.Coord[0] == Coord[0] + 2 && f1.Coord[1] == Coord[1] + 1)
                {
                    if (f1.IsWhite != IsWhite) RDE = true;
                    RD = false;
                    continue;
                }
                //ищем ход вправо вверх
                if (f1.Coord[0] == Coord[0] + 2 && f1.Coord[1] == Coord[1] - 1)
                {
                    if (f1.IsWhite != IsWhite) RUE = true;
                    RU = false;
                    continue;
                }
                //ищем ход влево вниз
                if (f1.Coord[1] == Coord[0] - 2 && f1.Coord[0] == Coord[1] + 1)
                {
                    if (f1.IsWhite != IsWhite) LDE = true;
                    LD = false;
                    continue;
                }
                //ищем ход влево вверх
                if (f1.Coord[1] == Coord[1] - 1 && f1.Coord[0] == Coord[1] - 1)
                {
                    if (f1.IsWhite != IsWhite) LUE = true;
                    LU = false;
                    continue;
                }
            }
            if ((DR || DRE) && (Coord[0] + 1 < 8 && Coord[1] + 2 < 8))
            {
                Step step = new Step();
                step.X = Coord[0] + 1;
                step.Y = Coord[1] + 2;
                step.Parent = this;
                allowedSteps.Add(step);
            }
            if ((DL || DLE) && (Coord[0] - 1 > -1 && Coord[1] + 2 < 8))
            {
                Step step = new Step();
                step.X = Coord[0] - 1;
                step.Y = Coord[1] + 2;
                step.Parent = this;
                allowedSteps.Add(step);
            }
            if ((UR || URE) && (Coord[0] + 1 < 8 && Coord[1] - 2 > -1))
            {
                Step step = new Step();
                step.X = Coord[0] + 1;
                step.Y = Coord[1] - 2;
                step.Parent = this;
                allowedSteps.Add(step);
            }
            if ((UL || ULE) && (Coord[0] - 1 > -1 && Coord[1] - 2 > -1))
            {
                Step step = new Step();
                step.X = Coord[0] - 1;
                step.Y = Coord[1] - 2;
                step.Parent = this;
                allowedSteps.Add(step);
            }
            if ((RD || RDE) && Coord[0] + 2 < 8 && Coord[1] + 1 < 8)
            {
                Step step = new Step();
                step.X = Coord[0] + 2;
                step.Y = Coord[1] + 1;
                step.Parent = this;
                allowedSteps.Add(step);
            }
            if ((RU || RUE) && Coord[0] + 2 < 8 && Coord[1] - 1 > -1)
            {
                Step step = new Step();
                step.X = Coord[0] + 2;
                step.Y = Coord[1] - 1;
                step.Parent = this;
                allowedSteps.Add(step);
            }
            if ((LD || LDE) && Coord[0] - 2 > -1 && Coord[1] + 1 < 8)
            {
                Step step = new Step();
                step.X = Coord[0] - 2;
                step.Y = Coord[1] + 1;
                step.Parent = this;
                allowedSteps.Add(step);
            }
            if ((LU || LUE) && Coord[0] - 2 > -1 && Coord[1] - 1 > -1)
            {
                Step step = new Step();
                step.X = Coord[0] - 2;
                step.Y = Coord[1] - 1;
                step.Parent = this;
                allowedSteps.Add(step);
            }
            return allowedSteps;
        }
    }
}
