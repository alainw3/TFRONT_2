namespace TFRONT
{
    partial class Form_Backup
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
            dataGridViewBackUp = new DataGridView();
            colIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            colDescDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            colDatDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataSet1B = new DataSet1();
            buttonSaveBackUp = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBackUp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataSet1B).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewBackUp
            // 
            dataGridViewBackUp.AutoGenerateColumns = false;
            dataGridViewBackUp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBackUp.Columns.AddRange(new DataGridViewColumn[] { colIdDataGridViewTextBoxColumn, colDescDataGridViewTextBoxColumn, colDatDataGridViewTextBoxColumn });
            dataGridViewBackUp.DataMember = "TBACKUP";
            dataGridViewBackUp.DataSource = dataSet1B;
            dataGridViewBackUp.Location = new Point(50, 26);
            dataGridViewBackUp.Name = "dataGridViewBackUp";
            dataGridViewBackUp.Size = new Size(400, 303);
            dataGridViewBackUp.TabIndex = 0;
            // 
            // colIdDataGridViewTextBoxColumn
            // 
            colIdDataGridViewTextBoxColumn.DataPropertyName = "colId";
            colIdDataGridViewTextBoxColumn.HeaderText = "colId";
            colIdDataGridViewTextBoxColumn.Name = "colIdDataGridViewTextBoxColumn";
            // 
            // colDescDataGridViewTextBoxColumn
            // 
            colDescDataGridViewTextBoxColumn.DataPropertyName = "colDesc";
            colDescDataGridViewTextBoxColumn.HeaderText = "colDesc";
            colDescDataGridViewTextBoxColumn.Name = "colDescDataGridViewTextBoxColumn";
            // 
            // colDatDataGridViewTextBoxColumn
            // 
            colDatDataGridViewTextBoxColumn.DataPropertyName = "colDat";
            colDatDataGridViewTextBoxColumn.HeaderText = "colDat";
            colDatDataGridViewTextBoxColumn.Name = "colDatDataGridViewTextBoxColumn";
            // 
            // dataSet1B
            // 
            dataSet1B.DataSetName = "DataSet1";
            dataSet1B.Namespace = "http://tempuri.org/DataSet1.xsd";
            dataSet1B.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonSaveBackUp
            // 
            buttonSaveBackUp.Location = new Point(335, 349);
            buttonSaveBackUp.Name = "buttonSaveBackUp";
            buttonSaveBackUp.Size = new Size(115, 23);
            buttonSaveBackUp.TabIndex = 1;
            buttonSaveBackUp.Text = "Save";
            buttonSaveBackUp.UseVisualStyleBackColor = true;
            buttonSaveBackUp.Click += buttonSaveBackUp_Click;
            // 
            // Form_Backup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 429);
            Controls.Add(buttonSaveBackUp);
            Controls.Add(dataGridViewBackUp);
            Name = "Form_Backup";
            Text = "Form_Backup";
            ((System.ComponentModel.ISupportInitialize)dataGridViewBackUp).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataSet1B).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewBackUp;
        private DataSet1 dataSet1B;
        private DataGridViewTextBoxColumn colIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn colDescDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn colDatDataGridViewTextBoxColumn;
        private Button buttonSaveBackUp;
    }
}