namespace triPOSCloud.CSharp
{
    partial class triPOSCloud
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
            this.btnPairLane = new System.Windows.Forms.Button();
            this.btnCreditTransaction = new System.Windows.Forms.Button();
            this.btnGiftTransaction = new System.Windows.Forms.Button();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.btnDeleteLane = new System.Windows.Forms.Button();
            this.btnGetLanes = new System.Windows.Forms.Button();
            this.btnGiftActivate = new System.Windows.Forms.Button();
            this.btnGiftBalance = new System.Windows.Forms.Button();
            this.btnGiftReload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPairLane
            // 
            this.btnPairLane.Location = new System.Drawing.Point(346, 13);
            this.btnPairLane.Name = "btnPairLane";
            this.btnPairLane.Size = new System.Drawing.Size(101, 23);
            this.btnPairLane.TabIndex = 0;
            this.btnPairLane.Text = "Pair Lane";
            this.btnPairLane.UseVisualStyleBackColor = true;
            this.btnPairLane.Click += new System.EventHandler(this.btnPairLane_Click);
            // 
            // btnCreditTransaction
            // 
            this.btnCreditTransaction.Location = new System.Drawing.Point(346, 100);
            this.btnCreditTransaction.Name = "btnCreditTransaction";
            this.btnCreditTransaction.Size = new System.Drawing.Size(101, 23);
            this.btnCreditTransaction.TabIndex = 1;
            this.btnCreditTransaction.Text = "Credit Transaction";
            this.btnCreditTransaction.UseVisualStyleBackColor = true;
            this.btnCreditTransaction.Click += new System.EventHandler(this.btnCreditTransaction_Click);
            // 
            // btnGiftTransaction
            // 
            this.btnGiftTransaction.Location = new System.Drawing.Point(346, 129);
            this.btnGiftTransaction.Name = "btnGiftTransaction";
            this.btnGiftTransaction.Size = new System.Drawing.Size(101, 23);
            this.btnGiftTransaction.TabIndex = 2;
            this.btnGiftTransaction.Text = "Gift Transaction";
            this.btnGiftTransaction.UseVisualStyleBackColor = true;
            this.btnGiftTransaction.Click += new System.EventHandler(this.btnGiftTransaction_Click);
            // 
            // txtRequest
            // 
            this.txtRequest.Location = new System.Drawing.Point(13, 13);
            this.txtRequest.Multiline = true;
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRequest.Size = new System.Drawing.Size(327, 197);
            this.txtRequest.TabIndex = 3;
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(12, 226);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResponse.Size = new System.Drawing.Size(327, 197);
            this.txtResponse.TabIndex = 4;
            // 
            // btnDeleteLane
            // 
            this.btnDeleteLane.Location = new System.Drawing.Point(346, 42);
            this.btnDeleteLane.Name = "btnDeleteLane";
            this.btnDeleteLane.Size = new System.Drawing.Size(101, 23);
            this.btnDeleteLane.TabIndex = 5;
            this.btnDeleteLane.Text = "Delete Lane";
            this.btnDeleteLane.UseVisualStyleBackColor = true;
            this.btnDeleteLane.Click += new System.EventHandler(this.btnDeleteLane_Click);
            // 
            // btnGetLanes
            // 
            this.btnGetLanes.Location = new System.Drawing.Point(346, 71);
            this.btnGetLanes.Name = "btnGetLanes";
            this.btnGetLanes.Size = new System.Drawing.Size(101, 23);
            this.btnGetLanes.TabIndex = 6;
            this.btnGetLanes.Text = "Get Lanes";
            this.btnGetLanes.UseVisualStyleBackColor = true;
            this.btnGetLanes.Click += new System.EventHandler(this.btnGetLanes_Click);
            // 
            // btnGiftActivate
            // 
            this.btnGiftActivate.Location = new System.Drawing.Point(346, 158);
            this.btnGiftActivate.Name = "btnGiftActivate";
            this.btnGiftActivate.Size = new System.Drawing.Size(101, 23);
            this.btnGiftActivate.TabIndex = 7;
            this.btnGiftActivate.Text = "Gift Activate";
            this.btnGiftActivate.UseVisualStyleBackColor = true;
            this.btnGiftActivate.Click += new System.EventHandler(this.btnGiftActivate_Click);
            // 
            // btnGiftBalance
            // 
            this.btnGiftBalance.Location = new System.Drawing.Point(346, 187);
            this.btnGiftBalance.Name = "btnGiftBalance";
            this.btnGiftBalance.Size = new System.Drawing.Size(101, 23);
            this.btnGiftBalance.TabIndex = 8;
            this.btnGiftBalance.Text = "Gift Balance";
            this.btnGiftBalance.UseVisualStyleBackColor = true;
            this.btnGiftBalance.Click += new System.EventHandler(this.btnGiftBalance_Click);
            // 
            // btnGiftReload
            // 
            this.btnGiftReload.Location = new System.Drawing.Point(345, 216);
            this.btnGiftReload.Name = "btnGiftReload";
            this.btnGiftReload.Size = new System.Drawing.Size(101, 23);
            this.btnGiftReload.TabIndex = 9;
            this.btnGiftReload.Text = "Gift Reload";
            this.btnGiftReload.UseVisualStyleBackColor = true;
            this.btnGiftReload.Click += new System.EventHandler(this.btnGiftReload_Click);
            // 
            // triPOSCloud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 481);
            this.Controls.Add(this.btnGiftReload);
            this.Controls.Add(this.btnGiftBalance);
            this.Controls.Add(this.btnGiftActivate);
            this.Controls.Add(this.btnGetLanes);
            this.Controls.Add(this.btnDeleteLane);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.txtRequest);
            this.Controls.Add(this.btnGiftTransaction);
            this.Controls.Add(this.btnCreditTransaction);
            this.Controls.Add(this.btnPairLane);
            this.Name = "triPOSCloud";
            this.Text = "triPOSCloud.CSharp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPairLane;
        private System.Windows.Forms.Button btnCreditTransaction;
        private System.Windows.Forms.Button btnGiftTransaction;
        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Button btnDeleteLane;
        private System.Windows.Forms.Button btnGetLanes;
        private System.Windows.Forms.Button btnGiftActivate;
        private System.Windows.Forms.Button btnGiftBalance;
        private System.Windows.Forms.Button btnGiftReload;
    }
}

