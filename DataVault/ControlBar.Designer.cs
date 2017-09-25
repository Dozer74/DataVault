namespace DataVault
{
    partial class ControlBar
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlBar));
            this.lbPage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPagination = new System.Windows.Forms.ComboBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnFilters = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbPage
            // 
            this.lbPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbPage.AutoSize = true;
            this.lbPage.Location = new System.Drawing.Point(384, 11);
            this.lbPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(132, 18);
            this.lbPage.TabIndex = 18;
            this.lbPage.Text = "Страница 1 [20/100]";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(721, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Отображать записи по";
            // 
            // cbPagination
            // 
            this.cbPagination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPagination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPagination.FormattingEnabled = true;
            this.cbPagination.Items.AddRange(new object[] {
            "10",
            "25",
            "50",
            "100",
            "Все"});
            this.cbPagination.Location = new System.Drawing.Point(879, 7);
            this.cbPagination.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbPagination.Name = "cbPagination";
            this.cbPagination.Size = new System.Drawing.Size(67, 26);
            this.cbPagination.TabIndex = 16;
            this.cbPagination.SelectedIndexChanged += new System.EventHandler(this.cbPagination_SelectedIndexChanged);
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReload.ImageKey = "refresh.png";
            this.btnReload.ImageList = this.imageList;
            this.btnReload.Location = new System.Drawing.Point(214, 0);
            this.btnReload.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(40, 40);
            this.btnReload.TabIndex = 11;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnFilters_Click);
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
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.ImageKey = "exit.png";
            this.btnExit.ImageList = this.imageList;
            this.btnExit.Location = new System.Drawing.Point(955, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 40);
            this.btnExit.TabIndex = 12;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnFilters_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext.ImageKey = "right-arrow.png";
            this.btnNext.ImageList = this.imageList;
            this.btnNext.Location = new System.Drawing.Point(335, 0);
            this.btnNext.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 40);
            this.btnNext.TabIndex = 13;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnFilters_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev.ImageKey = "left-arrow.png";
            this.btnPrev.ImageList = this.imageList;
            this.btnPrev.Location = new System.Drawing.Point(285, 0);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(40, 40);
            this.btnPrev.TabIndex = 14;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnFilters_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.ImageKey = "delete.png";
            this.btnRemove.ImageList = this.imageList;
            this.btnRemove.Location = new System.Drawing.Point(164, 0);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(40, 40);
            this.btnRemove.TabIndex = 15;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnFilters_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.ImageKey = "pencil.png";
            this.btnEdit.ImageList = this.imageList;
            this.btnEdit.Location = new System.Drawing.Point(114, 0);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(40, 40);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnFilters_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.ImageKey = "add.png";
            this.btnAdd.ImageList = this.imageList;
            this.btnAdd.Location = new System.Drawing.Point(64, 0);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 40);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnFilters_Click);
            // 
            // btnFilters
            // 
            this.btnFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilters.ImageKey = "filter.png";
            this.btnFilters.ImageList = this.imageList;
            this.btnFilters.Location = new System.Drawing.Point(0, 0);
            this.btnFilters.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnFilters.Name = "btnFilters";
            this.btnFilters.Size = new System.Drawing.Size(40, 40);
            this.btnFilters.TabIndex = 8;
            this.btnFilters.UseVisualStyleBackColor = true;
            this.btnFilters.Click += new System.EventHandler(this.btnFilters_Click);
            // 
            // ControlBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbPage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPagination);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnFilters);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ControlBar";
            this.Size = new System.Drawing.Size(995, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPagination;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnFilters;
        private System.Windows.Forms.ImageList imageList;
    }
}
