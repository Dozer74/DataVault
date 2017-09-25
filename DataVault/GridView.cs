using System.Windows.Forms;

namespace DataVault
{
    internal class GridView : DataGridView
    {
        public bool BackSort { get; set; }
        public int SortColumnIndex { get; set; }

        public GridView()
        {
            EditMode = DataGridViewEditMode.EditProgrammatically;
            MultiSelect = false;
            RowHeadersVisible = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            var columnIndex = e.ColumnIndex;
            if (columnIndex == SortColumnIndex)
                BackSort = !BackSort;
            else BackSort = false;

            Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                BackSort ? SortOrder.Descending : SortOrder.Ascending;

            SortColumnIndex = columnIndex;

            base.OnColumnHeaderMouseClick(e);
        }

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);

            foreach (DataGridViewColumn column in Columns)
                column.SortMode = DataGridViewColumnSortMode.Programmatic;

            Columns[SortColumnIndex].HeaderCell.SortGlyphDirection =
                BackSort ? SortOrder.Descending : SortOrder.Ascending;
        }
    }
}