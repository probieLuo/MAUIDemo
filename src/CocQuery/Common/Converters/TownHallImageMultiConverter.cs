using System.Globalization;

namespace CocQuery.Common.Converters
{
    public class TownHallImageMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2) return "default_town_hall.webp";

            int townHallLevel = 0;
            int townHallWeaponLevel = 0;
            int.TryParse(values[0] == null ? "" : values[0].ToString(), out townHallLevel);
            int.TryParse(values[1] == null ? "" : values[1].ToString(), out townHallWeaponLevel);
            if (townHallLevel > 0 && townHallWeaponLevel > 0)
            {
                return $"town_hall{townHallLevel}_{townHallWeaponLevel}a.webp";
            }
            else if (townHallLevel > 0 && (townHallWeaponLevel == 0))
            {
                return $"town_hall{townHallLevel}a.webp";
            }
            else
            {
                return "town_hall17_5a.webp";
            }
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
