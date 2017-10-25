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
            // забыл про цвет фигур йопта .... вспомнил
            // забыл про своих...
            List<int[]> allowedSteps = new List<int[]>();
            int stepLength = 1;
            bool RD = true, LD = true, RU = true, LU = true;
            while (RD && LD && RU && LU)
            {
                //ищем ходы вниз вправо
                if (RD)
                {
                    foreach (Figure f1 in figures)
                    {
                        if (f1.Equals(f)) continue;
                        if (f1.Coord[0] == f.Coord[0] + stepLength && f1.Coord[1] == f.Coord[1] + stepLength)
                        {
                            if (f1.IsWhite == f.IsWhite) RD = false;
                            break;
                        }
                    }
                    if (RD && f.Coord[0] + stepLength < 8 && f.Coord[1] + stepLength < 8) //если мы не выходим за границы поля
                    {
                        allowedSteps.Add(new int[2] { f.Coord[0] + stepLength, f.Coord[1] + stepLength });
                        //RD = false;
                    }
                }
                //ищем ходы вниз влево
                if (LD)
                {
                    foreach (Figure f1 in figures)
                    {
                        if (f1.Equals(f)) continue;
                        if (f1.Coord[0] == f.Coord[0] - stepLength && f1.Coord[1] == f.Coord[1] + stepLength)
                        {
                            if (f1.IsWhite == f.IsWhite) LD = false;
                            break;
                        }
                    }
                    if (LD && f.Coord[0] - stepLength > -1 && f.Coord[1] + stepLength < 8) //если мы не выходим за границы поля
                    {
                        allowedSteps.Add(new int[2] { f.Coord[0] - stepLength, f.Coord[1] + stepLength });
                        //LD = false;
                    }
                }
                //ищем ходы вверх вправо
                if (RU)
                {
                    foreach (Figure f1 in figures)
                    {
                        if (f1.Equals(f)) continue;
                        if (f1.Coord[0] == f.Coord[0] + stepLength && f1.Coord[1] == f.Coord[1] - stepLength)
                        {
                            if (f1.IsWhite == f.IsWhite) RU = false;
                            break;
                        }
                    }
                    if (RU && f.Coord[0] + stepLength < 8 && f.Coord[1] - stepLength > -1) //если мы не выходим за границы поля
                    {
                        allowedSteps.Add(new int[2] { f.Coord[0] + stepLength, f.Coord[1] - stepLength });
                        //RU = false;
                    }
                }
                //ищем ходы верх влево
                if (LU)
                {
                    foreach (Figure f1 in figures)
                    {
                        if (f1.Equals(f)) continue;
                        if (f1.Coord[0] == f.Coord[0] - stepLength && f1.Coord[1] == f.Coord[1] - stepLength)
                        {
                            if (f1.IsWhite == f.IsWhite) LU = false;
                            break;
                        }
                    }
                    if (LU && f.Coord[0] - stepLength > -1 && f.Coord[1] - stepLength > -1) //если мы не выходим за границы поля  
                    {
                        allowedSteps.Add(new int[2] { f.Coord[0] - stepLength, f.Coord[1] - stepLength });
                        //LU = false;
                    }
                }
                stepLength++;
            }
            return allowedSteps;
        }
    }
}
