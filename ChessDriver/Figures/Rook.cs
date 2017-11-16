using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDriver.Figures
{
    public class Rook:Figure
    {
        public List<Step> getAllowedSteps(List<Figure> figures)
        {
            List<Step> allowedSteps = new List<Step>();
            int stepLength = 1;
            bool R = true, D = true, U = true, L = true, RE = false, DE = false, UE = false, LE = false;
            while (stepLength <= 8)
            {
                foreach (Figure f1 in figures)
                {
                    if (f1.Equals(this)) continue;
                    //ищем ходы вправо
                    if (R && f1.Coord[0] == Coord[0] + stepLength && f1.Coord[1] == Coord[1])
                    {
                        if (f1.IsWhite != IsWhite) RE = true;
                        R = false;
                        continue;
                    }
                    //ищем ходы вниз
                    if (D && f1.Coord[0] == Coord[0] && f1.Coord[1] == Coord[1] + stepLength)
                    {
                        if (f1.IsWhite != IsWhite) DE = true;
                        D = false;
                        continue;
                    }
                    //ищем ходы вверх
                    if (U && f1.Coord[0] == Coord[0] && f1.Coord[1] == Coord[1] - stepLength)
                    {
                        if (f1.IsWhite != IsWhite) UE = true;
                        U = false;
                        continue;
                    }
                    //ищем ходы влево
                    if (L && f1.Coord[0] == Coord[0] - stepLength && f1.Coord[1] == Coord[1])
                    {
                        if (f1.IsWhite != IsWhite) LE = true;
                        L = false;
                        continue;
                    }
                }
                if ((RE || R) && Coord[0] + stepLength < 8)
                {
                    Step step = new Step();
                    step.X = Coord[0] + stepLength;
                    step.Y = Coord[1];
                    step.Parent = this;
                    allowedSteps.Add(step);
                    if (RE) RE = false;
                }
                if ((DE || D) && Coord[1] + stepLength < 8)
                {
                    Step step = new Step();
                    step.X = Coord[0];
                    step.Y = Coord[1] + stepLength;
                    step.Parent = this;
                    allowedSteps.Add(step);
                    if (DE) DE = false;
                }
                if ((UE || U) && Coord[1] - stepLength > -1)
                {
                    Step step = new Step();
                    step.X = Coord[0];
                    step.Y = Coord[1] - stepLength;
                    step.Parent = this;
                    allowedSteps.Add(step);
                    if (UE) UE = false;
                }
                if ((LE || L) && Coord[0] - stepLength > -1)
                {
                    Step step = new Step();
                    step.X = Coord[0] - stepLength;
                    step.Y = Coord[1];
                    step.Parent = this;
                    allowedSteps.Add(step);
                    if (LE) LE = false;
                }
                stepLength++;
            }
            return allowedSteps;
        }
    }
}
