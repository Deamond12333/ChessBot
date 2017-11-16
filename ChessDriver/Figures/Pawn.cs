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
        private double stepLength = 0;
        public List<Step> getAllowedSteps(List<Figure> figures)
        {
            // обработать момент, когда пешка дошла до конца поля
            List<Step> allowedSteps = new List<Step>();
            bool isStep = true, ER = false, EL = false;
            int endLength, qurLength;
            if (!IsMoved)
            {
                if (Coord[1] == 6)
                {
                    stepLength = -1.0;
                }
                else
                {
                    stepLength = 1.0;
                }
                endLength = 2;
            }
            else
            {
                endLength = 1;
            }
            qurLength = (int)stepLength;
            while (Math.Abs(qurLength) <= endLength)
            {
                foreach (Figure f1 in figures)
                {
                    if (f1.Equals(this)) continue;
                    if (f1.Coord[1] == Coord[1] + qurLength && f1.Coord[0] == Coord[0])
                    {
                        isStep = false;
                        break;
                    }
                }
                if (isStep && Coord[1] + qurLength < 8 && Coord[1] + qurLength >-1)
                {
                    Step step = new Step();
                    step.X = Coord[0];
                    step.Y = Coord[1] + qurLength;
                    step.Parent = this;
                    allowedSteps.Add(step);
                }
                qurLength *= 2;
            }

            foreach (Figure f1 in figures)
            {
                if (f1.Equals(this)) continue;
                if (f1.Coord[1] == Coord[1] + (int)stepLength && f1.Coord[0] == Coord[0] + 1 && f1.IsWhite != IsWhite)
                {
                    ER = true;
                    continue;
                }
                if (f1.Coord[1] == Coord[1] + (int)stepLength && f1.Coord[0] == Coord[0] - 1 && f1.IsWhite != IsWhite)
                {
                    EL = true;
                    continue;
                }
            }
            if (ER)
            {
                Step step = new Step();
                step.X = Coord[0] + 1;
                step.Y = Coord[1] + (int)stepLength;
                step.Parent = this;
                allowedSteps.Add(step);
            }
            if (EL)
            {
                Step step = new Step();
                step.X = Coord[0] - 1;
                step.Y = Coord[1] + (int)stepLength;
                step.Parent = this;
                allowedSteps.Add(step);
            }
            return allowedSteps;
        }
    }
}
