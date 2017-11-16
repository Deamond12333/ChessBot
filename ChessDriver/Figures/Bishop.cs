using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDriver.Figures
{
    public class Bishop:Figure
    {
        public List<Step> getAllowedSteps(List<Figure> figures)
        {
            List<Step> allowedSteps = new List<Step>();
            int stepLength = 1;
            bool RD = true, LD = true, RU = true, LU = true, RDE = false, LDE = false, RUE = false, LUE = false;

            while (stepLength <= 8)
            {
                foreach (Figure f1 in figures)
                {
                    if (f1.Equals(this)) continue;
                    //ищем ходы вниз вправо
                    if (RD && f1.Coord[0] == Coord[0] + stepLength && f1.Coord[1] == Coord[1] + stepLength)
                    {
                        if (f1.IsWhite != IsWhite) RDE = true;
                        RD = false;
                        continue;
                    }
                    //ищем ходы вниз влево
                    if (LD && f1.Coord[0] == Coord[0] - stepLength && f1.Coord[1] == Coord[1] + stepLength)
                    {
                        if (f1.IsWhite != IsWhite) LDE = true;
                        LD = false;
                        continue;
                    }
                    //ищем ходы вверх влево
                    if (LU && f1.Coord[0] == Coord[0] - stepLength && f1.Coord[1] == Coord[1] - stepLength)
                    {
                        if (f1.IsWhite != IsWhite) LUE = true;
                        LU = false;
                        continue;
                    }
                    //ищем ходы вверх вправо
                    if (RU && f1.Coord[0] == Coord[0] + stepLength && f1.Coord[1] == Coord[1] - stepLength)
                    {
                        if (f1.IsWhite != IsWhite) RUE = true;
                        RU = false;
                        continue;
                    }
                }
                if ((RDE || RD) && (Coord[0] + stepLength < 8 && Coord[1] + stepLength < 8))
                {
                    Step step = new Step();
                    step.X = Coord[0] + stepLength;
                    step.Y = Coord[1] + stepLength;
                    step.Parent = this;
                    allowedSteps.Add(step);
                    if (RDE) RDE = false;
                }
                if ((LDE || LD) && (Coord[0] - stepLength > -1 && Coord[1] + stepLength < 8))
                {
                    Step step = new Step();
                    step.X = Coord[0] - stepLength;
                    step.Y = Coord[1] + stepLength;
                    step.Parent = this;
                    allowedSteps.Add(step);
                    if (LDE) LDE = false;
                }
                if ((RUE || RU) && (Coord[0] + stepLength < 8 && Coord[1] - stepLength > -1))
                {
                    Step step = new Step();
                    step.X = Coord[0] + stepLength;
                    step.Y = Coord[1] - stepLength;
                    step.Parent = this;
                    allowedSteps.Add(step);
                    if (RUE) RUE = false;
                }
                if ((LUE || LU) && (Coord[0] - stepLength > -1 && Coord[1] - stepLength > -1))
                {
                    Step step = new Step();
                    step.X = Coord[0] - stepLength;
                    step.Y = Coord[1] - stepLength;
                    step.Parent = this;
                    allowedSteps.Add(step);
                    if (LUE) LUE = false;
                }
                stepLength++;
            }
            return allowedSteps;
        }
    }
}
