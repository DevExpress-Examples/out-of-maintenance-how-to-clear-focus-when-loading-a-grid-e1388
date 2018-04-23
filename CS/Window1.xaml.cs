#region usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using DevExpress.Wpf.Grid;
#endregion

namespace ClearFocusedRow {
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();

            #region Initialize the grid.
            IList<TestData> list = new BindingList<TestData>();
            for (int i = 0; i < 10; i++) {
                list.Add(new TestData() {
                    Text = String.Format("Row{0}", i),
                    Number = i
                });
            }

            grid.DataSource = list;
            #endregion

            grid.Loaded += grid_Loaded;
        }

        void grid_Loaded(object sender, RoutedEventArgs e) {
            TableView view = grid.View as TableView;
            view.FocusedRowHandle = GridControl.InvalidRowHandle;
        }
    }

    #region Test class to populate the grid.
    public class TestData {
        public int Number { get; set; }
        public string Text { get; set; }
    }
    #endregion
}
