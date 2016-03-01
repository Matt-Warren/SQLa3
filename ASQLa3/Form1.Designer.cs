namespace ASQLa3
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtFromTable = new System.Windows.Forms.TextBox();
            this.txtToTable = new System.Windows.Forms.TextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnFromDatabase = new System.Windows.Forms.Button();
            this.btnToDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Table";
            // 
            // txtFromTable
            // 
            this.txtFromTable.Location = new System.Drawing.Point(15, 124);
            this.txtFromTable.Name = "txtFromTable";
            this.txtFromTable.Size = new System.Drawing.Size(100, 20);
            this.txtFromTable.TabIndex = 11;
            // 
            // txtToTable
            // 
            this.txtToTable.Location = new System.Drawing.Point(142, 124);
            this.txtToTable.Name = "txtToTable";
            this.txtToTable.Size = new System.Drawing.Size(100, 20);
            this.txtToTable.TabIndex = 19;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(15, 165);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(227, 32);
            this.btnTransfer.TabIndex = 24;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransferClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Table";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "From";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(136, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Destination";
            // 
            // btnFromDatabase
            // 
            this.btnFromDatabase.Location = new System.Drawing.Point(12, 25);
            this.btnFromDatabase.Name = "btnFromDatabase";
            this.btnFromDatabase.Size = new System.Drawing.Size(100, 76);
            this.btnFromDatabase.TabIndex = 31;
            this.btnFromDatabase.Text = "Get Connection String";
            this.btnFromDatabase.UseVisualStyleBackColor = true;
            this.btnFromDatabase.Click += new System.EventHandler(this.btnFromDatabase_Click);
            // 
            // btnToDatabase
            // 
            this.btnToDatabase.Location = new System.Drawing.Point(139, 25);
            this.btnToDatabase.Name = "btnToDatabase";
            this.btnToDatabase.Size = new System.Drawing.Size(100, 76);
            this.btnToDatabase.TabIndex = 33;
            this.btnToDatabase.Text = "Get Connection String";
            this.btnToDatabase.UseVisualStyleBackColor = true;
            this.btnToDatabase.Click += new System.EventHandler(this.btnToDatabase_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 209);
            this.Controls.Add(this.btnToDatabase);
            this.Controls.Add(this.btnFromDatabase);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.txtToTable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFromTable);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFromTable;
        private System.Windows.Forms.TextBox txtToTable;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnFromDatabase;
        private System.Windows.Forms.Button btnToDatabase;
    }
}

