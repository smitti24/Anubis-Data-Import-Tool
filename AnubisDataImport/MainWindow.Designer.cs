namespace AnubisDataImport
{
    partial class MainWindow
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.btnSaveToDB = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblTimer = new MaterialSkin.Controls.MaterialLabel();
            this.lblMessage = new MaterialSkin.Controls.MaterialLabel();
            this.lblCount = new MaterialSkin.Controls.MaterialLabel();
            this.lblHeader = new MaterialSkin.Controls.MaterialLabel();
            this.materialProgressBar = new MaterialSkin.Controls.MaterialProgressBar();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(38, 256);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(255, 38);
            this.progressBar.TabIndex = 5;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnSaveToDB
            // 
            this.btnSaveToDB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveToDB.Depth = 0;
            this.btnSaveToDB.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveToDB.Icon = null;
            this.btnSaveToDB.Location = new System.Drawing.Point(38, 115);
            this.btnSaveToDB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveToDB.MouseState = MaterialSkin.MouseState.Hover;
            this.btnSaveToDB.Name = "btnSaveToDB";
            this.btnSaveToDB.Primary = true;
            this.btnSaveToDB.Size = new System.Drawing.Size(255, 46);
            this.btnSaveToDB.TabIndex = 8;
            this.btnSaveToDB.Text = "Start Data Import";
            this.btnSaveToDB.UseCompatibleTextRendering = true;
            this.btnSaveToDB.UseVisualStyleBackColor = true;
            this.btnSaveToDB.Click += new System.EventHandler(this.btnSaveToDB_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Transparent;
            this.lblTimer.Depth = 0;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTimer.Location = new System.Drawing.Point(38, 298);
            this.lblTimer.MouseState = MaterialSkin.MouseState.Hover;
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(97, 25);
            this.lblTimer.TabIndex = 9;
            this.lblTimer.Text = "Completed in";
            this.lblTimer.UseCompatibleTextRendering = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Depth = 0;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMessage.Location = new System.Drawing.Point(38, 220);
            this.lblMessage.MouseState = MaterialSkin.MouseState.Hover;
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(111, 25);
            this.lblMessage.TabIndex = 10;
            this.lblMessage.Text = "Status message";
            this.lblMessage.UseCompatibleTextRendering = true;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCount.Depth = 0;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCount.Location = new System.Drawing.Point(38, 187);
            this.lblCount.MouseState = MaterialSkin.MouseState.Hover;
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(108, 25);
            this.lblCount.TabIndex = 11;
            this.lblCount.Text = "Import counter";
            this.lblCount.UseCompatibleTextRendering = true;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Depth = 0;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHeader.Location = new System.Drawing.Point(38, 86);
            this.lblHeader.MouseState = MaterialSkin.MouseState.Hover;
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(255, 25);
            this.lblHeader.TabIndex = 12;
            this.lblHeader.Text = "Import Steam Games Into Anubis Db";
            this.lblHeader.UseCompatibleTextRendering = true;
            // 
            // materialProgressBar
            // 
            this.materialProgressBar.Depth = 0;
            this.materialProgressBar.Location = new System.Drawing.Point(0, 63);
            this.materialProgressBar.MouseState = MaterialSkin.MouseState.Hover;
            this.materialProgressBar.Name = "materialProgressBar";
            this.materialProgressBar.Size = new System.Drawing.Size(330, 5);
            this.materialProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.materialProgressBar.TabIndex = 13;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 362);
            this.Controls.Add(this.materialProgressBar);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnSaveToDB);
            this.Controls.Add(this.progressBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anubis Data Import Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private MaterialSkin.Controls.MaterialRaisedButton btnSaveToDB;
        private MaterialSkin.Controls.MaterialLabel lblTimer;
        private MaterialSkin.Controls.MaterialLabel lblMessage;
        private MaterialSkin.Controls.MaterialLabel lblCount;
        private MaterialSkin.Controls.MaterialLabel lblHeader;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar;
    }
}

