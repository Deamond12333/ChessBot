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
        public List<int[]> getAllowedSteps(List<Figure> figures, Figure f)
        {
            // НУЖНО ОБРАБОТАТЬ СОБЫТИЕ, КОГДА ПЕШКА ДОХОДИТ ДО РЕСПЫ ПРОТИВНИКА (ЗАМЕНА НА БОЛЕЕ СИЛЬНУЮ ФИГУРУ)
            // НО СКОРЕЙ ВСЕГО ЭТО НЕ ЗДЕСЬ
            // забыл про цвет фигур йопта... вспомнил
            // почему-то чёрные не могут ходить на 2 клетки сначала...
            List<int[]> allowedSteps = new List<int[]>();
            bool /*step1 = true, step2 = true, */isStep = true, isEat = true, ER = false, EL = false;
            int stepLength;

            if (IsWhite) stepLength = -1;
            else stepLength = 1;

            while (isStep)
            {
                foreach (Figure f1 in figures)
                {
                    if (f1.Equals(f)) continue;
                    if (isEat) // обработка сруба
                    {
                        if (f1.Coord[0] == f.Coord[0] + 1 && f1.Coord[1] == f.Coord[1] + stepLength && f1.IsWhite == !f.IsWhite) ER = true;
                        if (f1.Coord[0] == f.Coord[0] - 1 && f1.Coord[1] == f.Coord[1] + stepLength && f1.IsWhite == !f.IsWhite) EL = true;
                    }
                    if (f1.Coord[1] == f.Coord[1] + stepLength)
                    {
                        isStep = false;
                        break;
                    }
                }
                if (ER) allowedSteps.Add(new int[2] { f.Coord[0] + 1, f.Coord[1] + stepLength });
                if (EL) allowedSteps.Add(new int[2] { f.Coord[0] - 1, f.Coord[1] + stepLength });
                isEat = false;
                ER = false;
                EL = false;
                if (isStep && f.Coord[1] + stepLength < 8 && f.Coord[1] + stepLength > -1)
                    allowedSteps.Add(new int[2] { f.Coord[0], f.Coord[1] + stepLength });

                //если пешка еще не ходила
                if (isStep && ((IsWhite && f.Coord[1] == 6) || (!IsWhite && f.Coord[1] == 1)) && Math.Abs(stepLength) < 2)
                {
                    int k = Math.Abs(stepLength) + 1;
                    stepLength = k * stepLength; // другого решения не нашел...
                }
                else isStep = false;
            }
            /* Вариант №1
            if (f.IsWhite)
            {
                // если пешка еще не двигалась с места
                if (f.Coord[1] == 6)
                {
                    //ищем ходы с учётом ходов на 2 клетки
                    foreach (Figure f1 in figures)
                    {
                        if (f1.Equals(f)) continue;
                        if (f1.Coord[1] == f.Coord[1] - 1)
                        {
                            step1 = false;
                            break;
                        }
                        if (f1.Coord[1] == f.Coord[1] - 2)
                        {
                            step2 = false;
                            break;
                        }
                    }
                    if (step1) allowedSteps.Add(new int[2] { f.Coord[0], f.Coord[1] - 1 });
                    if (step2) allowedSteps.Add(new int[2] { f.Coord[0], f.Coord[1] - 2 });
                }
                else
                {
                    //ищем ходы только на 1 клетку
                    foreach (Figure f1 in figures)
                    {
                        if (f1.Equals(f)) continue;
                        if (f1.Coord[1] == f.Coord[1] - 1)
                        {
                            step1 = false;
                            break;
                        }
                    }
                    if (step1) allowedSteps.Add(new int[2] { f.Coord[0], f.Coord[1] - 1 });
                }
            }
            else
            {
                // если пешка еще не двигалась с места
                if (f.Coord[1] == 1)
                {
                    //ищем ходы с учётом ходов на 2 клетки
                    foreach (Figure f1 in figures)
                    {
                        if (f1.Equals(f)) continue;
                        if (f1.Coord[1] == f.Coord[1] + 1)
                        {
                            step1 = false;
                            break;
                        }
                        if (f1.Coord[1] == f.Coord[1] + 2)
                        {
                            step2 = false;
                            break;
                        }
                    }
                    if (step1) allowedSteps.Add(new int[2] { f.Coord[0], f.Coord[1] + 1 });
                    if (step2) allowedSteps.Add(new int[2] { f.Coord[0], f.Coord[1] + 2 });
                }
                else
                {
                    //ищем ходы только на 1 клетку
                    foreach (Figure f1 in figures)
                    {
                        if (f1.Equals(f)) continue;
                        if (f1.Coord[1] == f.Coord[1] + 1)
                        {
                            step1 = false;
                            break;
                        }
                    }
                    if (step1) allowedSteps.Add(new int[2] { f.Coord[0], f.Coord[1] + 1 });
                }
            }*/
            return allowedSteps;
            //дальше нужно просчитать исходы на 4-5 шагов на всех ходах и выявить лучший или рандом из одинаковых
        }
    }
}
