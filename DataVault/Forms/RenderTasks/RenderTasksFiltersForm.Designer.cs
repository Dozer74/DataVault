namespace DataVault.Forms.RenderTasks
{
    partial class RenderTaskFilterForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.priceFrom = new System.Windows.Forms.TextBox();
            this.priceTo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.startDateFrom = new System.Windows.Forms.DateTimePicker();
            this.startDateTo = new System.Windows.Forms.DateTimePicker();
            this.renderTimeTo = new System.Windows.Forms.TextBox();
            this.renderTimeFrom = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.project = new System.Windows.Forms.ComboBox();
            this.software = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbProjectEnabled = new System.Windows.Forms.CheckBox();
            this.cbSoftwareEnabled = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOk.Location = new System.Drawing.Point(152, 244);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 27);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Применить";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Location = new System.Drawing.Point(272, 244);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 27);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnIgnore
            // 
            this.btnIgnore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIgnore.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnIgnore.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnIgnore.Location = new System.Drawing.Point(13, 244);
            this.btnIgnore.Margin = new System.Windows.Forms.Padding(4);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(81, 27);
            this.btnIgnore.TabIndex = 0;
            this.btnIgnore.Text = "Сбросить";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new System.EventHandler(this.btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(120, 6);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(252, 26);
            this.name.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "from";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "to";
            // 
            // priceFrom
            // 
            this.priceFrom.Location = new System.Drawing.Point(161, 38);
            this.priceFrom.Name = "priceFrom";
            this.priceFrom.Size = new System.Drawing.Size(89, 26);
            this.priceFrom.TabIndex = 6;
            this.priceFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.balanceFrom_KeyPress);
            // 
            // priceTo
            // 
            this.priceTo.Location = new System.Drawing.Point(283, 38);
            this.priceTo.Name = "priceTo";
            this.priceTo.Size = new System.Drawing.Size(89, 26);
            this.priceTo.TabIndex = 6;
            this.priceTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.balanceFrom_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(130, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "to";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(117, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "from";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 108);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "StartDate";
            // 
            // startDateFrom
            // 
            this.startDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateFrom.Location = new System.Drawing.Point(161, 102);
            this.startDateFrom.Name = "startDateFrom";
            this.startDateFrom.ShowCheckBox = true;
            this.startDateFrom.Size = new System.Drawing.Size(116, 26);
            this.startDateFrom.TabIndex = 12;
            // 
            // startDateTo
            // 
            this.startDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateTo.Location = new System.Drawing.Point(161, 134);
            this.startDateTo.Name = "startDateTo";
            this.startDateTo.ShowCheckBox = true;
            this.startDateTo.Size = new System.Drawing.Size(116, 26);
            this.startDateTo.TabIndex = 13;
            // 
            // renderTimeTo
            // 
            this.renderTimeTo.Location = new System.Drawing.Point(283, 70);
            this.renderTimeTo.Name = "renderTimeTo";
            this.renderTimeTo.Size = new System.Drawing.Size(89, 26);
            this.renderTimeTo.TabIndex = 17;
            // 
            // renderTimeFrom
            // 
            this.renderTimeFrom.Location = new System.Drawing.Point(161, 70);
            this.renderTimeFrom.Name = "renderTimeFrom";
            this.renderTimeFrom.Size = new System.Drawing.Size(89, 26);
            this.renderTimeFrom.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(256, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 18);
            this.label9.TabIndex = 16;
            this.label9.Text = "to";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(117, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 18);
            this.label10.TabIndex = 15;
            this.label10.Text = "from";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 73);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 18);
            this.label11.TabIndex = 14;
            this.label11.Text = "RenderTime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 169);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Project";
            // 
            // project
            // 
            this.project.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.project.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.project.FormattingEnabled = true;
            this.project.Location = new System.Drawing.Point(141, 166);
            this.project.Name = "project";
            this.project.Size = new System.Drawing.Size(231, 26);
            this.project.TabIndex = 20;
            // 
            // software
            // 
            this.software.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.software.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.software.FormattingEnabled = true;
            this.software.Location = new System.Drawing.Point(141, 198);
            this.software.Name = "software";
            this.software.Size = new System.Drawing.Size(231, 26);
            this.software.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 201);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 18);
            this.label12.TabIndex = 21;
            this.label12.Text = "Software";
            // 
            // cbProjectEnabled
            // 
            this.cbProjectEnabled.AutoSize = true;
            this.cbProjectEnabled.Location = new System.Drawing.Point(120, 172);
            this.cbProjectEnabled.Name = "cbProjectEnabled";
            this.cbProjectEnabled.Size = new System.Drawing.Size(15, 14);
            this.cbProjectEnabled.TabIndex = 23;
            this.cbProjectEnabled.UseVisualStyleBackColor = true;
            this.cbProjectEnabled.CheckedChanged += new System.EventHandler(this.cbSoftwareEnabled_CheckedChanged);
            // 
            // cbSoftwareEnabled
            // 
            this.cbSoftwareEnabled.AutoSize = true;
            this.cbSoftwareEnabled.Location = new System.Drawing.Point(120, 204);
            this.cbSoftwareEnabled.Name = "cbSoftwareEnabled";
            this.cbSoftwareEnabled.Size = new System.Drawing.Size(15, 14);
            this.cbSoftwareEnabled.TabIndex = 24;
            this.cbSoftwareEnabled.UseVisualStyleBackColor = true;
            this.cbSoftwareEnabled.CheckedChanged += new System.EventHandler(this.cbSoftwareEnabled_CheckedChanged);
            // 
            // RenderTaskFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 283);
            this.Controls.Add(this.cbSoftwareEnabled);
            this.Controls.Add(this.cbProjectEnabled);
            this.Controls.Add(this.software);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.project);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.renderTimeTo);
            this.Controls.Add(this.renderTimeFrom);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.startDateTo);
            this.Controls.Add(this.startDateFrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.priceTo);
            this.Controls.Add(this.priceFrom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "RenderTaskFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox priceFrom;
        private System.Windows.Forms.TextBox priceTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker startDateFrom;
        private System.Windows.Forms.DateTimePicker startDateTo;
        private System.Windows.Forms.TextBox renderTimeTo;
        private System.Windows.Forms.TextBox renderTimeFrom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox project;
        private System.Windows.Forms.ComboBox software;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cbProjectEnabled;
        private System.Windows.Forms.CheckBox cbSoftwareEnabled;
    }
}