namespace DataVault.Forms.RenderTasks
{
    partial class AddEditRenderTaskForm
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
            this.taskPrice = new System.Windows.Forms.TextBox();
            this.taskDesc = new System.Windows.Forms.TextBox();
            this.taskName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.taskStartDate = new System.Windows.Forms.DateTimePicker();
            this.taskRenderTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.taskSoftware = new System.Windows.Forms.ComboBox();
            this.taskProject = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // taskPrice
            // 
            this.taskPrice.Location = new System.Drawing.Point(96, 134);
            this.taskPrice.Name = "taskPrice";
            this.taskPrice.Size = new System.Drawing.Size(112, 26);
            this.taskPrice.TabIndex = 3;
            this.taskPrice.Validating += new System.ComponentModel.CancelEventHandler(this.fields_Validating);
            // 
            // taskDesc
            // 
            this.taskDesc.Location = new System.Drawing.Point(96, 198);
            this.taskDesc.Multiline = true;
            this.taskDesc.Name = "taskDesc";
            this.taskDesc.Size = new System.Drawing.Size(221, 91);
            this.taskDesc.TabIndex = 2;
            this.taskDesc.Validating += new System.ComponentModel.CancelEventHandler(this.fields_Validating);
            // 
            // taskName
            // 
            this.taskName.Location = new System.Drawing.Point(96, 6);
            this.taskName.Name = "taskName";
            this.taskName.Size = new System.Drawing.Size(222, 26);
            this.taskName.TabIndex = 1;
            this.taskName.Validating += new System.ComponentModel.CancelEventHandler(this.fields_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 201);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Name";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Location = new System.Drawing.Point(216, 296);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 27);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOk.Location = new System.Drawing.Point(96, 296);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 27);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Добавить";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "$";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 44);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "StartDate";
            // 
            // taskStartDate
            // 
            this.taskStartDate.Location = new System.Drawing.Point(96, 38);
            this.taskStartDate.Name = "taskStartDate";
            this.taskStartDate.Size = new System.Drawing.Size(221, 26);
            this.taskStartDate.TabIndex = 18;
            this.taskStartDate.Value = new System.DateTime(2017, 9, 29, 0, 0, 0, 0);
            this.taskStartDate.Validating += new System.ComponentModel.CancelEventHandler(this.fields_Validating);
            // 
            // taskRenderTime
            // 
            this.taskRenderTime.Location = new System.Drawing.Point(96, 166);
            this.taskRenderTime.Name = "taskRenderTime";
            this.taskRenderTime.Size = new System.Drawing.Size(112, 26);
            this.taskRenderTime.TabIndex = 19;
            this.taskRenderTime.Validating += new System.ComponentModel.CancelEventHandler(this.fields_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 168);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 18);
            this.label6.TabIndex = 20;
            this.label6.Text = "RenderTime";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(233, 169);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 18);
            this.label7.TabIndex = 21;
            this.label7.Text = "hours";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 73);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 18);
            this.label9.TabIndex = 23;
            this.label9.Text = "Software";
            // 
            // taskSoftware
            // 
            this.taskSoftware.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.taskSoftware.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.taskSoftware.FormattingEnabled = true;
            this.taskSoftware.Location = new System.Drawing.Point(96, 70);
            this.taskSoftware.Name = "taskSoftware";
            this.taskSoftware.Size = new System.Drawing.Size(221, 26);
            this.taskSoftware.TabIndex = 24;
            this.taskSoftware.Validating += new System.ComponentModel.CancelEventHandler(this.fields_Validating);
            // 
            // taskProject
            // 
            this.taskProject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.taskProject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.taskProject.FormattingEnabled = true;
            this.taskProject.Location = new System.Drawing.Point(96, 102);
            this.taskProject.Name = "taskProject";
            this.taskProject.Size = new System.Drawing.Size(221, 26);
            this.taskProject.TabIndex = 26;
            this.taskProject.Validating += new System.ComponentModel.CancelEventHandler(this.fields_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 105);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 18);
            this.label8.TabIndex = 25;
            this.label8.Text = "Project";
            // 
            // AddEditRenderTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 332);
            this.Controls.Add(this.taskProject);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.taskSoftware);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.taskRenderTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.taskStartDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.taskPrice);
            this.Controls.Add(this.taskDesc);
            this.Controls.Add(this.taskName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddEditRenderTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание задачи";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox taskPrice;
        private System.Windows.Forms.TextBox taskDesc;
        private System.Windows.Forms.TextBox taskName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DateTimePicker taskStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox taskRenderTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox taskProject;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox taskSoftware;
        private System.Windows.Forms.Label label9;
    }
}