
namespace Pascual.Christian.SPLabII
{
    partial class FRMListadoTickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMListadoTickets));
            this.RTBoxTickets = new System.Windows.Forms.RichTextBox();
            this.LblTicket = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RTBoxTickets
            // 
            this.RTBoxTickets.Location = new System.Drawing.Point(31, 42);
            this.RTBoxTickets.Name = "RTBoxTickets";
            this.RTBoxTickets.ReadOnly = true;
            this.RTBoxTickets.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.RTBoxTickets.Size = new System.Drawing.Size(468, 396);
            this.RTBoxTickets.TabIndex = 0;
            this.RTBoxTickets.Text = "";
            // 
            // LblTicket
            // 
            this.LblTicket.AutoSize = true;
            this.LblTicket.BackColor = System.Drawing.Color.LightYellow;
            this.LblTicket.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblTicket.ForeColor = System.Drawing.Color.Black;
            this.LblTicket.Location = new System.Drawing.Point(31, 9);
            this.LblTicket.Name = "LblTicket";
            this.LblTicket.Size = new System.Drawing.Size(88, 30);
            this.LblTicket.TabIndex = 1;
            this.LblTicket.Text = "Tickets";
            // 
            // FRMListadoTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(524, 450);
            this.Controls.Add(this.LblTicket);
            this.Controls.Add(this.RTBoxTickets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FRMListadoTickets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListadoTickets";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTBoxTickets;
        private System.Windows.Forms.Label LblTicket;
    }
}