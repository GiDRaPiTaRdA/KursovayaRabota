﻿using KursovayaRabota.Models;
using KursovayaRabota.Models.TeamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;

namespace KursovayaRabota.Converters
{
    public class CanModifyExecutorConverter : IValueConverter
    {
        int i = 0;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new CanModifyWrapper<Executor>((Executor)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return CanModifyWraperManager.UnPackCanModifyWrapper((CanModifyWrapper<Executor>)value);
        }
    }
}
