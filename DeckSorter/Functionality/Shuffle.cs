using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeckSorter.Models.DBModels;


namespace DeckSorter.Functionality
{
    public static class Shuffle
    {
        //Метод простой перетасовки (работает для массива любого размера)
        public static string[] SimpleShuffle(string[] cards)
        {
            var rand = new Random();
            //Перебираем элементы с 0 до предпоследнего
            for (int i = 0; i < cards.Length-1; i++)
            {
                //Для каждого элемента ищем случайный элемент впереди него, который поставим на его место
                int j = rand.Next(i + 1,cards.Length-1);
                //Переставляем значения cards[j] и cards[i]
                var temp = cards[j];
                cards[j] = cards[i];
                cards[i] = temp;
            }
            return cards;
        }

        //Метод эмуляции ручной перетасовки (работает для массива любого размера)
        public static string[] ManualShuffleEmulation(string[] cards)
        {
            //Создаем пустой итоговый  массив 
            string[] result = new string[cards.Length];  
            //Хранит индекс с конца cards (элемент, начиная с которого карты уже добавлены в result )
            int prevEnd = cards.Length;
            //Текущий индекс в result
            int resultIndex = 0;
            //Пока стартовый индекс для cards не станет < 0
            //pow представляет степень 2. Последовательность GetCurStartIndrex(prevEnd, pow)= {1,3,7,15...}
            for (int pow = 0; GetCurStartIndrex(prevEnd, pow) >= 0; pow++)
            {
                //Получаем индекс, с которого начнем добавлять карты в result
                int curStart = GetCurStartIndrex(prevEnd, pow);
                //Если на следующей итерации чисел для добавления меньше, чем на текущей, то считаем, что мы уже прошли середину и выходим из цикла
                if (GetCurStartIndrex(curStart, pow) < 0) break;
                //Заполняем result картами с cards[curStart] до cards[prevEnd-1]
                for (int j = curStart; j < prevEnd; j++)
                {
                    result[resultIndex] = cards[j];
                    resultIndex++;
                }
                //Смещаем конец в текущий старт
                prevEnd = curStart;
            }
            //Заполняем всем оставшимися картами, если такие имеются
            for (int i = 0; i < prevEnd; i++)
            {
                result[resultIndex] = cards[i];
                resultIndex++;
            }
            return result;

            //Стартовый индекс определяется с конца как разница между всей длиной массива и суммой текущего последнего элемента и 2-ой в некоторой степени 
            int GetCurStartIndrex(int prevEndIndex, int pow)
            {
                return cards.Length - ((cards.Length - prevEndIndex) + (int)Math.Pow(2, pow));
            }

            //Пример работы:
            //cards = { "1", "2", "3", "4", "5", "6", "7", "8" }, prevEnd = 8
            //1 итерация: result = {"8"}, prevEnd = 7
            //2 итерация: result = {"8","6","7"}, prevEnd = 5
            //Выход из цикла т.к. на 3 итерации необходимо поставить вперед числа {"2", "3", "4", "5"}, но для следующей итерации остается только 1 элемент (1<4)
            //Заполняем всем оставшимися значениями до prevEnd
            //3 итерация: result = {"8","6","7", "1", "2", "3", "4", "5"}, prevEnd = 7
            //Доп. примеры в проекте с тестом
        }
    }
}
