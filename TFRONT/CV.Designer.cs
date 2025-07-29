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
            comboBoxTJobTitle = new ComboBox();
            tJOBTITLEBindingSource = new BindingSource(components);
            dataSet23 = new DataSet2();
            ((System.ComponentModel.ISupportInitialize)tJOBTITLEBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataSet23).BeginInit();
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
            // comboBoxTJobTitle
            // 
            comboBoxTJobTitle.DataSource = tJOBTITLEBindingSource;
            comboBoxTJobTitle.DisplayMember = "colJobTitle";
            comboBoxTJobTitle.FormattingEnabled = true;
            comboBoxTJobTitle.Location = new Point(922, 17);
            comboBoxTJobTitle.Name = "comboBoxTJobTitle";
            comboBoxTJobTitle.Size = new Size(121, 23);
            comboBoxTJobTitle.TabIndex = 1;
            comboBoxTJobTitle.ValueMember = "colId";
            comboBoxTJobTitle.SelectedIndexChanged += comboBoxTJobTitle_SelectedIndexChanged;
            // 
            // tJOBTITLEBindingSource
            // 
            tJOBTITLEBindingSource.DataMember = "TJOBTITLE";
            tJOBTITLEBindingSource.DataSource = dataSet23;
            // 
            // dataSet23
            // 
            dataSet23.DataSetName = "DataSet2";
            dataSet23.Namespace = "http://tempuri.org/DataSet2.xsd";
            dataSet23.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 642);
            Controls.Add(comboBoxTJobTitle);
            Controls.Add(reportViewer1);
            DataBindings.Add(new Binding("Tag", tJOBTITLEBindingSource, "colJobTitle", true));
            DataBindings.Add(new Binding("DataContext", tJOBTITLEBindingSource, "colId", true));
            Name = "CV";
            Text = "CV";
            Load += CV_Load;
            ((System.ComponentModel.ISupportInitialize)tJOBTITLEBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataSet23).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
       

        private ComboBox comboBoxTJobTitle;

        private DataSet2 dataSet23;
        private BindingSource tJOBTITLEBindingSource;
    }
}