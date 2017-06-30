/*
* Licensed to the Apache Software Foundation (ASF) under one
* or more contributor license agreements.  See the NOTICE file
* distributed with this work for additional information
* regarding copyright ownership.  The ASF licenses this file
* to you under the Apache License, Version 2.0 (the
* "License"); you may not use this file except in compliance
* with the License.  You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/


using System;
using System.Reflection;
using System.Windows.Data;

namespace ThinkGeo.MapSuite.GisEditor
{
    [Serializable]
    [Obfuscation]
    internal class DatumTypeToStringConverter : IValueConverter
    {
        private static string noSelect = GisEditor.LanguageManager.GetStringResource("ProjectionConfigurationCommonProjectionsPleaseSelect");

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is DatumType)
            {
                return Convert((DatumType)value);
            }
            else return ConvertBack(value.ToString());
        }

        private static string Convert(DatumType datumType)
        {
            if (datumType != DatumType.None)
            {
                return datumType.ToString();
            }
            else
            {
                return noSelect;
            }
        }

        private static DatumType ConvertBack(string datumTypeName)
        {
            DatumType result = DatumType.None;
            if (Enum.TryParse<DatumType>(datumTypeName, out result))
            {
                return result;
            }
            else return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}