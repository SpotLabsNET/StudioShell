/*
   Copyright (c) 2011 Code Owls LLC, All Rights Reserved.

   Licensed under the Microsoft Reciprocal License (Ms-RL) (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.opensource.org/licenses/ms-rl

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/


using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CodeOwls.StudioShell.DataPaneControls
{
    public partial class DataChartControl : UserControl
    {
        public DataChartControl()
        {
            InitializeComponent();
        }

        public void SetDataSource(IEnumerable data, string chartType, string xAxisProperty)
        {
            chart1.Series.Clear();

            SeriesChartType type = Adapt(chartType);
            if (String.IsNullOrEmpty(xAxisProperty))
            {
                chart1.DataBindTable(data);
            }
            else
            {
                chart1.DataBindTable(data,xAxisProperty);
            }

            chart1.Series.ToList().ForEach( s=> s.ChartType = type);
        }

        private SeriesChartType Adapt(string chartType)
        {
            Dictionary<string, SeriesChartType> map = new Dictionary<string, SeriesChartType>
                                                          {
                                                              {"line", SeriesChartType.Line},
                                                              {"bar", SeriesChartType.Bar},
                                                              {"column", SeriesChartType.Column},
                                                              {"pie", SeriesChartType.Pie},
                                                              {"point", SeriesChartType.Point},
                                                              {"area", SeriesChartType.Area},
                                                              {"spline", SeriesChartType.Spline},
                                                          };

            var name = chartType.ToLowerInvariant();
            if( map.ContainsKey( name ) )
            {
                return map[name];
            }
            return SeriesChartType.Bar;
        }
    }
}
