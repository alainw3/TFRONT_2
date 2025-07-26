namespace TFRONT
{
    partial class CV
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
            components = new System.ComponentModel.Container();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            dataSet21 = new DataSet2();
            comboBox1 = new ComboBox();
            tJOBTITLEBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataSet21).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tJOBTITLEBindingSource).BeginInit();
            SuspendLayout();
            // 
            // reportViewer1
            // 
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer1";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(880, 624);
            reportViewer1.TabIndex = 0;
            // 
            // dataSet21
            // 
            dataSet21.DataSetName = "DataSet2";
            dataSet21.Namespace = "http://tempuri.org/DataSet2.xsd";
            dataSet21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox1
            // 
            comboBox1.DataSource = tJOBTITLEBindingSource;
            comboBox1.DisplayMember = "colJobTitle";
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(922, 17);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            comboBox1.ValueMember = "colId";
            // 
            // tJOBTITLEBindingSource
            // 
            tJOBTITLEBindingSource.DataMember = "TJOBTITLE";
            tJOBTITLEBindingSource.DataSource = dataSet21;
            // 
            // CV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 642);
            Controls.Add(comboBox1);
            Controls.Add(reportViewer1);
            Name = "CV";
            Text = "CV";
            Load += CV_Load;
            ((System.ComponentModel.ISupportInitialize)dataSet21).EndInit();
            ((System.ComponentModel.ISupportInitialize)tJOBTITLEBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet2 dataSet21;
        private ComboBox comboBox1;
        private BindingSource tJOBTITLEBindingSource;
    }
}