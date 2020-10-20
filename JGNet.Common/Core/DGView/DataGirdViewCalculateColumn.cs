using System;
using System.Collections.Generic;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common.Core
{
    public class DataGirdViewCalculateColumn
    {
        public DataGridViewColumn Column { get; set; }

        public DataGirdViewCalculateType CalculateType { get; set; }
        public DataGirdViewCalculateColumn() { }
        public DataGirdViewCalculateColumn(DataGridViewColumn column, DataGirdViewCalculateType calculateType) {
            this.Column = column;
            this.CalculateType = calculateType;
        }
        public DataGirdViewCalculateColumn(String columnDataPropertyName, DataGirdViewCalculateType calculateType)
        {
            this.Column = new DataGridViewColumn();
            this.Column.DataPropertyName = columnDataPropertyName;
            this.CalculateType = calculateType;
        }
    }
}
