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
            // НУЖНО ОБРАБОТАТЬ СОБЫТИЕ СРУБА
            List<int[]> allowedSteps = new List<int[]>();
            int stepLength = 1;
            bool isStep = true, RD = true, LD = true, RU = true, LU = true;
            while (!RD && !LD && !RU && !LU)
            {
                //ищем ходы вниз вправо
                if (RD)
                {
                    foreach (Figure f1 in figures)
                    {
                        if (f1.Equals(f)) continue;
                        if (f1.Coord[0] == f.Coord[0] + stepLength && f1.Coord[1] == f.Coord[1] + stepLength)
                        {
                            isStep = false;
                            break;
                        }
                    }
                    if (isStep && f.Coord[0] + stepLength < 8 && f.Coord[1] + stepLength < 8) //если мы не выходим за границы поля
                        allowedSteps.Add(new int[2] { f.Coord[0] + stepLength, f.Coord[1] + stepLength });
                    else RD = false;
                }
                //ищем ходы вниз влево
                if (LD)
                {
                    foreach (Figure f1 in figures)
                    {
                        if (f1.Equals(f)) continue;
                        if (f1.Coord[0] == f.Coord[0] - stepLength && f1.Coord[1] == f.Coord[1] + stepLength)
                        {
                            isStep = false;
                            break;
                        }
                    }
                    if (isStep && f.Coord[0] - stepLength > -1 && f.Coord[1] + stepLength < 8) //если мы не выходим за границы поля
                        allowedSteps.Add(new int[2] { f.Coord[0] - stepLength, f.Coord[1] + stepLength });
                    else LD = false;
                }
                //ищем ходы вверх вправо
                if (RU)
                {
                    foreach (Figure f1 in figures)
                    {
                        if (f1.Equals(f)) continue;
                        if (f1.Coord[0] == f.Coord[0] + stepLength && f1.Coord[1] == f.Coord[1] - stepLength)
                        {
                            isStep = false;
                            break;
                        }
                    }
                    if (isStep && f.Coord[0] + stepLength < 8 && f.Coord[1] - stepLength > -1) //если мы не выходим за границы поля
                        allowedSteps.Add(new int[2] { f.Coord[0] + stepLength, f.Coord[1] - stepLength });
                    else RU = false;
                }
                //ищем ходы верх влево
                if (LU)
                {
                    foreach (Figure f1 in figures)
                    {
                        if (f1.Equals(f)) continue;
                        if (f1.Coord[0] == f.Coord[0] - stepLength && f1.Coord[1] == f.Coord[1] - stepLength)
                        {
                            isStep = false;
                            break;
                        }
                    }
                    if (isStep && f.Coord[0] - stepLength > -1 && f.Coord[1] - stepLength > -1) //если мы не выходим за границы поля
                        allowedSteps.Add(new int[2] { f.Coord[0] - stepLength, f.Coord[1] - stepLength });
                    else LU = false;
                }
                stepLength++;
            }
            return allowedSteps;
        }
    }
}
