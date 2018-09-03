namespace triPOSCloud.CSharp
{
    partial class ActivationCodeInput
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
            this.txtActivationCode = new System.Windows.Forms.TextBox();
            this.btnActivationCode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtActivationCode
            // 
            this.txtActivationCode.Location = new System.Drawing.Point(33, 21);
            this.txtActivationCode.Name = "txtActivationCode";
            this.txtActivationCode.Size = new System.Drawing.Size(155, 20);
            this.txtActivationCode.TabIndex = 0;
            // 
            // btnActivationCode
            // 
            this.btnActivationCode.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnActivationCode.Location = new System.Drawing.Point(64, 48);
            this.btnActivationCode.Name = "btnActivationCode";
            this.btnActivationCode.Size = new System.Drawing.Size(75, 23);
            this.btnActivationCode.TabIndex = 1;
            this.btnActivationCode.Text = "Enter Code";
            this.btnActivationCode.UseVisualStyleBackColor = true;
            this.btnActivationCode.Click += new System.EventHandler(this.btnActivationCode_Click);
            // 
            // ActivationCodeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 90);
            this.Controls.Add(this.btnActivationCode);
            this.Controls.Add(this.txtActivationCode);
            this.Name = "ActivationCodeInput";
            this.Text = "ActivationCodeInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtActivationCode;
        private System.Windows.Forms.Button btnActivationCode;
    }
}