using System;
using System.Windows.Forms;

namespace DataVault
{
    public partial class ControlBar : UserControl
    {
        public ControlBar()
        {
            InitializeComponent();
            cbPagination.SelectedIndex = 1;
        }

        public string StatusText
        {
            get => lbPage.Text;
            set => lbPage.Text = value;
        }

        public bool EditButtonEnabled
        {
            get => btnEdit.Enabled;
            set => btnEdit.Enabled = value;
        }

        public bool RemoveButtonEnabled
        {
            get => btnRemove.Enabled;
            set => btnRemove.Enabled = value;
        }

        public bool NextPageButtonEnabled
        {
            get => btnNext.Enabled;
            set => btnNext.Enabled = value;
        }

        public bool PrevPageButtonEnabled
        {
            get => btnPrev.Enabled;
            set => btnPrev.Enabled = value;
        }

        public int PaginationSize => cbPagination.SelectedIndex == cbPagination.Items.Count - 1
            ? -1
            : int.Parse((string) cbPagination.SelectedItem);

        public event EventHandler FilterButtonClick;
        public event EventHandler AddButtonClick;
        public event EventHandler EditButtonClick;
        public event EventHandler RemoveButtonClick;
        public event EventHandler ReloadButtonClick;
        public event EventHandler ExitButtonClick;


        public event EventHandler<PaginationEventArgs> PaginationButtonClick;
        public event EventHandler PaginationSizeChanged;

        private void btnFilters_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnFilters))
                FilterButtonClick?.Invoke(sender, e);
            else if (sender.Equals(btnAdd))
                AddButtonClick?.Invoke(sender, e);
            else if (sender.Equals(btnEdit))
                EditButtonClick?.Invoke(sender, e);
            else if (sender.Equals(btnRemove))
                RemoveButtonClick?.Invoke(sender, e);
            else if (sender.Equals(btnReload))
                ReloadButtonClick?.Invoke(sender, e);
            else if (sender.Equals(btnNext) || sender.Equals(btnPrev))
                PaginationButtonClick?.Invoke(sender, new PaginationEventArgs {IsNextPage = sender.Equals(btnNext)});
            else if (sender.Equals(btnExit))
                ExitButtonClick?.Invoke(sender, e);
        }

        private void cbPagination_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaginationSizeChanged?.Invoke(sender, e);
        }

        public class PaginationEventArgs
        {
            public bool IsNextPage { get; set; }
        }
    }
}