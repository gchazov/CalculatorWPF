﻿using CalcYouLate.MeasurePages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CalcYouLate.Functionality
{
    public class MeasureList
    {
        
        #region Lists of measures
        public string[] Area
        {
            get { return area; }
            set { }
        }
        public string[] area = {
            "ар",
            "гектар",
            "тауншип",
            "акр",
            "квадратный миллиметр мм²",
            "квадратный сантиметр см²",
            "квадратный дециметр дм²",
            "квадратный метр м²",
            "квадратный километр км²",
            "квадратный дюйм²",
            "квадратный фут²",
            "квадратный ярд²",
            "квадратная миля²",
        };

        public string[] Volume
        {
            get { return volume; }
            set { }
        }
        public string[] volume =
        {
            "кубический миллиметр мм³",
            "кубический сантиметр см³",
            "кубический дециметр (литр) дм³",
            "кубический метр м³",
            "кубический километр км³",
            "кубический дюйм³",
            "кубический фут³",
            "кубический ярд³",
            "кубическая миля³",
            "пинта",
            "кварта",
            "галлон",
            "баррель",
        };

        public string[] Length
        {
            get { return length; }
            set { }
        }
        public string[] length =
        {
            "миллиметр",
            "сантиметр",
            "дециметр",
            "метр",
            "километр",
            "дюйм",
            "фут",
            "ярд",
            "миля",
            "морская миля",
            "лига",
            "вершок",
            "сажень",
            "аршин",
            "верста",
            "астрономическая единица",
            "световой год",
            "парсек",
        };

        public string[] Energy
        {
            get { return energy; }
            set { }
        }
        public string[] energy =
        {
            "калория",
            "килокалория",
            "мегакалория",
            "ватт/секунда",
            "киловатт/час",
            "электрон-вольт",
            "квад",
            "терм",
            "килограмм тротила",
            "джоуль",
            "килоджуоль",
        };

        public string[] Weight
        {
            get { return weight; }
            set { }
        }
        public string[] weight =
        {
            "милиграмм мг",
            "грамм г",
            "килограмм кг",
            "центнер",
            "тонна",
            "стоун",
            "фунт",
            "унция",
            "центнер",
            "гран",
            "карат",
        };

        public string[] Temperature
        {
            get { return temperature; }
            set { }
        }
        public string[] temperature =
        {
            "градус Цельсия",
            "градус Фаренгейта",
            "градус Кельвина",
            "градус Реомюра",
        };

        public string[] Power
        {
            get { return power; }
            set { }
        }
        public string[] power =
        {
            "ватт",
            "киловатт",
            "мегаватт",
            "лошадиная сила",
            "вольт-ампер",
            "фут-фунты/мин",
            "БТЕ/мин",
        };

        public string[] Pressure
        {
            get { return pressure; }
            set { }
        }
        public string[] pressure =
        {
            "бар",
            "паскаль",
            "килопаскаль",
            "миллиметры ртутного столба",
            "фунт/дюйм²",
            "атмосфера",
        };

        public string[] Data
        {
            get { return data; }
            set { }
        }
        public string[] data =
        {
            "бит",
            "байт",
            "килобайт",
            "мегабайт",
            "гигабайт",
            "терабайт",
            "петабайт",
            "эксабайт",
        };

        public string[] Angle
        {
            get { return angle; }
            set { }
        }
        public string[] angle =
        {
            "градус",
            "радиан",
            "минута",
            "секунда",
        };

        public string[] Speed
        {
            get { return speed; }
            set { }
        }
        public string[] speed =
        {
            "метр/сек",
            "метр/мин",
            "метр/час",
            "клометр/сек",
            "клометр/мин",
            "клометр/час",
            "дюйм/сек",
            "фут/мин",
            "фут/час",
            "миль/час",
            "узел",
            "Мах",
        };

        public string[] Time
        {
            get { return time; }
            set { }
        }
        public string[] time =
        {
            "наносекунда",
            "миллисекунда",
            "секунда",
            "минута",
            "час",
            "сутки",
            "неделя",
            "григорианский год",
            "юлианский год",
            "драконический год",
            "век",
        };
        #endregion

        public static Dictionary<string, double> areaToMeters = new Dictionary<string, double>()
        {
            {"ар", 100},
            { "гектар", 1000},
            {"тауншип",  93.2396 },
            { "акр", 4046.86},
            {"квадратный миллиметр мм²", 0.000001},
            {"квадратный сантиметр см²", 0.0001},
            {"квадратный дециметр дм²", 0.01},
            {"квадратный метр м²", 1},
            {"квадратный километр км²", 1000000},
            {"квадратный дюйм²", 0.00064516},
            {"квадратный фут²", 0.09290304},
            {"квадратный ярд²", 0.83612736},
            {"квадратная миля²", 2589988.110336},
        };

        public static Dictionary<string, double> areaFromMeters = new Dictionary<string, double>()
        {
            {"ар", 0.01},
            {"гектар", 0.0001},
            {"тауншип",  0.010725 },
            { "акр", 0.00024710516},
            {"квадратный миллиметр мм²", 1000000},
            {"квадратный сантиметр см²", 10000},
            {"квадратный дециметр дм²", 100},
            {"квадратный метр м²", 1},
            {"квадратный километр км²", 0.000001},
            {"квадратный дюйм²", 1550.0031000062},
            {"квадратный фут²", 10.76391041671},
            {"квадратный ярд²", 1.1959900463},
            {"квадратная миля²", 0.0000003861},
        };

    }
}
