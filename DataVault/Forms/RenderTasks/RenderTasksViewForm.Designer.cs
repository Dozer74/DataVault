using DataVault.Forms.Users;

namespace DataVault.Forms.RenderTasks
{
    partial class RenderTasksViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserViewForm));
            this.dataGrid = new DataVault.GridView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.controlBar = new DataVault.ControlBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.BackSort = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGrid.Location = new System.Drawing.Point(16, 17);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(911, 493);
            this.dataGrid.SortColumnIndex = 0;
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellDoubleClick);
            this.dataGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGrid_ColumnHeaderMouseClick);
            this.dataGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGrid_DataBindingComplete);
            this.dataGrid.SelectionChanged += new System.EventHandler(this.dataGrid_SelectionChanged);
            this.dataGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGrid_KeyDown);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "add.png");
            this.imageList.Images.SetKeyName(1, "delete.png");
            this.imageList.Images.SetKeyName(2, "filter.png");
            this.imageList.Images.SetKeyName(3, "left-arrow.png");
            this.imageList.Images.SetKeyName(4, "pencil.png");
            this.imageList.Images.SetKeyName(5, "refresh.png");
            this.imageList.Images.SetKeyName(6, "right-arrow.png");
            this.imageList.Images.SetKeyName(7, "exit.png");
            // 
            // controlBar
            // 
            this.controlBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlBar.EditButtonEnabled = true;
            this.controlBar.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.controlBar.Location = new System.Drawing.Point(13, 517);
            this.controlBar.Margin = new System.Windows.Forms.Padding(4);
            this.controlBar.Name = "controlBar";
            this.controlBar.NextPageButtonEnabled = true;
            this.controlBar.PrevPageButtonEnabled = true;
            this.controlBar.RemoveButtonEnabled = true;
            this.controlBar.Size = new System.Drawing.Size(914, 40);
            this.controlBar.StatusText = "Страница 1 [20/100]";
            this.controlBar.TabIndex = 8;
            // 
            // UserViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 570);
            this.Controls.Add(this.controlBar);
            this.Controls.Add(this.dataGrid);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(832, 251);
            this.Name = "UserViewForm";
            this.Text = "UserViewForm";
            this.Load += new System.EventHandler(this.UserViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GridView dataGrid;
        private System.Windows.Forms.ImageList imageList;
        private ControlBar controlBar;
    }
}