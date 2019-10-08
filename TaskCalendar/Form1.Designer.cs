namespace TaskCalendar
{
    partial class Form1
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
            this.lblAssigner = new System.Windows.Forms.Label();
            this.txtContext = new System.Windows.Forms.TextBox();
            this.lblKind = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.lblTime = new System.Windows.Forms.Label();
            this.numTime = new System.Windows.Forms.NumericUpDown();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblList = new System.Windows.Forms.Label();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnRemoveTask = new System.Windows.Forms.Button();
            this.btnClearFields = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAssigner
            // 
            this.lblAssigner.AutoSize = true;
            this.lblAssigner.Location = new System.Drawing.Point(12, 15);
            this.lblAssigner.Name = "lblAssigner";
            this.lblAssigner.Size = new System.Drawing.Size(59, 17);
            this.lblAssigner.TabIndex = 0;
            this.lblAssigner.Text = "Context:";
            // 
            // txtContext
            // 
            this.txtContext.Location = new System.Drawing.Point(77, 12);
            this.txtContext.Name = "txtContext";
            this.txtContext.Size = new System.Drawing.Size(100, 22);
            this.txtContext.TabIndex = 1;
            this.txtContext.Click += new System.EventHandler(this.txtContext_Enter);
            this.txtContext.TextChanged += new System.EventHandler(this.txtContext_TextChanged);
            this.txtContext.Enter += new System.EventHandler(this.txtContext_Enter);
            // 
            // lblKind
            // 
            this.lblKind.AutoSize = true;
            this.lblKind.Location = new System.Drawing.Point(183, 15);
            this.lblKind.Name = "lblKind";
            this.lblKind.Size = new System.Drawing.Size(44, 17);
            this.lblKind.TabIndex = 2;
            this.lblKind.Text = "Type:";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(233, 12);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(100, 22);
            this.txtType.TabIndex = 3;
            this.txtType.Click += new System.EventHandler(this.txtType_Enter);
            this.txtType.Enter += new System.EventHandler(this.txtType_Enter);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(339, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(70, 17);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Due date:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(415, 10);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(250, 22);
            this.dateTimePicker.TabIndex = 5;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(671, 15);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(43, 17);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "Time:";
            // 
            // numTime
            // 
            this.numTime.Location = new System.Drawing.Point(720, 13);
            this.numTime.Maximum = new decimal(new int[] {
            2359,
            0,
            0,
            0});
            this.numTime.Name = "numTime";
            this.numTime.Size = new System.Drawing.Size(75, 22);
            this.numTime.TabIndex = 7;
            this.numTime.Value = new decimal(new int[] {
            2359,
            0,
            0,
            0});
            this.numTime.Click += new System.EventHandler(this.numTime_Enter);
            this.numTime.Enter += new System.EventHandler(this.numTime_Enter);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(801, 15);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(54, 17);
            this.lblLocation.TabIndex = 8;
            this.lblLocation.Text = "Where:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(861, 12);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(100, 22);
            this.txtLocation.TabIndex = 9;
            this.txtLocation.Click += new System.EventHandler(this.txtLocation_Enter);
            this.txtLocation.Enter += new System.EventHandler(this.txtLocation_Enter);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(967, 15);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(49, 17);
            this.lblNotes.TabIndex = 10;
            this.lblNotes.Text = "Notes:";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(1022, 12);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(200, 22);
            this.txtNote.TabIndex = 11;
            this.txtNote.Enter += new System.EventHandler(this.txtNote_Enter);
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblList.Location = new System.Drawing.Point(12, 100);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(72, 25);
            this.lblList.TabIndex = 14;
            this.lblList.Text = "Tasks:";
            // 
            // btnAddTask
            // 
            this.btnAddTask.AutoSize = true;
            this.btnAddTask.Location = new System.Drawing.Point(12, 48);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(113, 27);
            this.btnAddTask.TabIndex = 12;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnRemoveTask
            // 
            this.btnRemoveTask.AutoSize = true;
            this.btnRemoveTask.Location = new System.Drawing.Point(90, 102);
            this.btnRemoveTask.Name = "btnRemoveTask";
            this.btnRemoveTask.Size = new System.Drawing.Size(140, 27);
            this.btnRemoveTask.TabIndex = 15;
            this.btnRemoveTask.Text = "Remove Task";
            this.btnRemoveTask.UseVisualStyleBackColor = true;
            this.btnRemoveTask.Click += new System.EventHandler(this.btnRemoveTask_Click);
            // 
            // btnClearFields
            // 
            this.btnClearFields.AutoSize = true;
            this.btnClearFields.Location = new System.Drawing.Point(1022, 48);
            this.btnClearFields.Name = "btnClearFields";
            this.btnClearFields.Size = new System.Drawing.Size(92, 27);
            this.btnClearFields.TabIndex = 13;
            this.btnClearFields.Text = "Clear Fields";
            this.btnClearFields.UseVisualStyleBackColor = true;
            this.btnClearFields.Click += new System.EventHandler(this.btnClearFields_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnAddTask;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1234, 423);
            this.Controls.Add(this.btnClearFields);
            this.Controls.Add(this.btnRemoveTask);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.lblList);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.numTime);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblKind);
            this.Controls.Add(this.txtContext);
            this.Controls.Add(this.lblAssigner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Calendar";
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAssigner;
        private System.Windows.Forms.TextBox txtContext;
        private System.Windows.Forms.Label lblKind;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.NumericUpDown numTime;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnRemoveTask;
        private System.Windows.Forms.Button btnClearFields;
    }
}

