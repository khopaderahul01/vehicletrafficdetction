namespace VideoCaptureDemo
{
    partial class Form3
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbSourceDest = new System.Windows.Forms.ComboBox();
            this.mtsDataSet = new VideoCaptureDemo.mtsDataSet();
            this.mtsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mtsDataSet1 = new VideoCaptureDemo.mtsDataSet1();
            this.sourceDestinationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sourceDestinationsTableAdapter = new VideoCaptureDemo.mtsDataSet1TableAdapters.SourceDestinationsTableAdapter();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mtsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtsDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtsDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceDestinationsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(89, 97);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(280, 54);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "Play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Capture From Camera",
            "Capture From File"});
            this.comboBox1.Location = new System.Drawing.Point(8, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.shapeContainer1);
            this.groupBox5.Controls.Add(this.pictureBox3);
            this.groupBox5.Location = new System.Drawing.Point(81, 170);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 0, 4, 8);
            this.groupBox5.Size = new System.Drawing.Size(296, 210);
            this.groupBox5.TabIndex = 56;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detection Preview";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(4, 13);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2});
            this.shapeContainer1.Size = new System.Drawing.Size(288, 189);
            this.shapeContainer1.TabIndex = 1;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BorderColor = System.Drawing.Color.DarkRed;
            this.rectangleShape2.Location = new System.Drawing.Point(220, -1);
            this.rectangleShape2.Name = "rectangleShape1";
            this.rectangleShape2.Size = new System.Drawing.Size(4, 176);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::VideoCaptureDemo.Properties.Resources.blank;
            this.pictureBox3.Location = new System.Drawing.Point(8, 23);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(262, 173);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(413, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 30);
            this.label1.TabIndex = 57;
            this.label1.Text = "Total Vehicle Count: 0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbSourceDest);
            this.groupBox2.Location = new System.Drawing.Point(97, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 58);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Source Destination";
            // 
            // cmbSourceDest
            // 
            this.cmbSourceDest.DataSource = this.sourceDestinationsBindingSource;
            this.cmbSourceDest.FormattingEnabled = true;
            this.cmbSourceDest.Location = new System.Drawing.Point(16, 19);
            this.cmbSourceDest.Name = "cmbSourceDest";
            this.cmbSourceDest.Size = new System.Drawing.Size(238, 21);
            this.cmbSourceDest.TabIndex = 0;
            this.cmbSourceDest.Text = "System.Data.DataViewManagerListItemTypeDescriptor";
            // 
            // mtsDataSet
            // 
            this.mtsDataSet.DataSetName = "mtsDataSet";
            this.mtsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mtsDataSetBindingSource
            // 
            this.mtsDataSetBindingSource.DataSource = this.mtsDataSet;
            this.mtsDataSetBindingSource.Position = 0;
            // 
            // mtsDataSet1
            // 
            this.mtsDataSet1.DataSetName = "mtsDataSet1";
            this.mtsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sourceDestinationsBindingSource
            // 
            this.sourceDestinationsBindingSource.DataMember = "SourceDestinations";
            this.sourceDestinationsBindingSource.DataSource = this.mtsDataSet1;
            // 
            // sourceDestinationsTableAdapter
            // 
            this.sourceDestinationsTableAdapter.ClearBeforeFill = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 405);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mtsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtsDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtsDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceDestinationsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbSourceDest;
        private System.Windows.Forms.BindingSource mtsDataSetBindingSource;
        private mtsDataSet mtsDataSet;
        private mtsDataSet1 mtsDataSet1;
        private System.Windows.Forms.BindingSource sourceDestinationsBindingSource;
        private mtsDataSet1TableAdapters.SourceDestinationsTableAdapter sourceDestinationsTableAdapter;
    }
}