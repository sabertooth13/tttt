namespace StarWarApi
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
            this.label1 = new System.Windows.Forms.Label();
            this.textMGLT = new System.Windows.Forms.TextBox();
            this.Calc = new System.Windows.Forms.Button();
            this.ResultGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ResultGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter The Distance";
            // 
            // textMGLT
            // 
            this.textMGLT.Location = new System.Drawing.Point(193, 31);
            this.textMGLT.Name = "textMGLT";
            this.textMGLT.Size = new System.Drawing.Size(144, 20);
            this.textMGLT.TabIndex = 1;
            // 
            // Calc
            // 
            this.Calc.Location = new System.Drawing.Point(363, 27);
            this.Calc.Name = "Calc";
            this.Calc.Size = new System.Drawing.Size(75, 23);
            this.Calc.TabIndex = 2;
            this.Calc.Text = "Calc";
            this.Calc.UseVisualStyleBackColor = true;
            this.Calc.Click += new System.EventHandler(this.button1_Click);
            // 
            // ResultGridView
            // 
            this.ResultGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ResultGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ResultGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultGridView.Location = new System.Drawing.Point(65, 78);
            this.ResultGridView.Name = "ResultGridView";
            this.ResultGridView.Size = new System.Drawing.Size(545, 407);
            this.ResultGridView.TabIndex = 3;
            this.ResultGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultGridView_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 497);
            this.Controls.Add(this.ResultGridView);
            this.Controls.Add(this.Calc);
            this.Controls.Add(this.textMGLT);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ResultGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textMGLT;
        private System.Windows.Forms.Button Calc;
        private System.Windows.Forms.DataGridView ResultGridView;
    }
}

