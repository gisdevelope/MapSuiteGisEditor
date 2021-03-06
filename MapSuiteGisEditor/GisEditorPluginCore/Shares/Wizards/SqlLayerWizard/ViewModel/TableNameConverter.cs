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
using System.Globalization;
using System.Windows.Data;

namespace ThinkGeo.MapSuite.GisEditor.Plugins
{
    public class TableNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string name = string.Empty;
            MsSqlTableDataRepositoryItem item = value as MsSqlTableDataRepositoryItem;
            PostgreTableDataRepositoryItem postgreItem = value as PostgreTableDataRepositoryItem;
            PostgreViewDataRepositoryItem postgreViewItem = value as PostgreViewDataRepositoryItem;
            if (item != null)
            {
                string database = item.DatabaseName;
                name = string.Format(CultureInfo.InvariantCulture, "{0}: {1}.{2}", database, item.SchemaName, item.Name);
            }
            else if (postgreItem != null)
            {
                string database = postgreItem.DatabaseName;
                string schema = postgreItem.SchemaName;
                name = string.Format(CultureInfo.InvariantCulture, "{0}: {1}.{2}", database, schema, postgreItem.Name);
            }
            else if (postgreViewItem != null)
            {
                string database = postgreItem.DatabaseName;
                string schema = postgreItem.SchemaName;
                name = string.Format(CultureInfo.InvariantCulture, "{0}: {1}.{2}", database, schema, postgreItem.Name);
            }

            return name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}