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


using System.Windows.Controls;
using ThinkGeo.MapSuite.Layers;

namespace ThinkGeo.MapSuite.GisEditor
{
    //public class LoadFromLibraryMenuItemViewModel : LayerListMenuItem
    internal partial class LayerListMenuItemHelper
    {
        public static MenuItem GetLoadFromLibraryMenuItem()
        {
            var command = new ObservedCommand(LoadFromLibrary, () => true);
            return GetMenuItem("Load from Library...", "/GisEditorInfrastructure;component/Images/load_from_library.png", command);
        }

        private static void LoadFromLibrary()
        {
            if (GisEditor.LayerListManager.SelectedLayerListItem == null) return;
            StyleLibraryWindow library = new StyleLibraryWindow();
            if (library.ShowDialog().GetValueOrDefault())
            {
                FeatureLayer currentFeatureLayer = GisEditor.LayerListManager.SelectedLayerListItem.ConcreteObject as FeatureLayer;
                if (currentFeatureLayer != null)
                {
                    ZoomLevelHelper.ApplyStyle(library.Result.CompositeStyle, currentFeatureLayer, library.Result.FromZoomLevelIndex, library.Result.ToZoomLevelIndex);
                }
            }
        }
    }
}