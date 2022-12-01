
namespace Pascual.Christian.SPLabII
{
    partial class FRMCartuchera
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMCartuchera));
            this.BTAgregarUtil = new System.Windows.Forms.Button();
            this.BTSerializarXML = new System.Windows.Forms.Button();
            this.BTSerializarJson = new System.Windows.Forms.Button();
            this.DGVUtiles = new System.Windows.Forms.DataGridView();
            this.DVGCartucheras = new System.Windows.Forms.DataGridView();
            this.BTDeserializarXML = new System.Windows.Forms.Button();
            this.BTDeserializarJson = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.BTVerTickets = new System.Windows.Forms.Button();
            this.BORRARTODO = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.BTFibron = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUtiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DVGCartucheras)).BeginInit();
            this.SuspendLayout();
            // 
            // BTAgregarUtil
            // 
            this.BTAgregarUtil.BackColor = System.Drawing.Color.Gold;
            this.BTAgregarUtil.FlatAppearance.BorderSize = 2;
            this.BTAgregarUtil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.BTAgregarUtil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAgregarUtil.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTAgregarUtil.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BTAgregarUtil.Location = new System.Drawing.Point(23, 12);
            this.BTAgregarUtil.Name = "BTAgregarUtil";
            this.BTAgregarUtil.Size = new System.Drawing.Size(111, 60);
            this.BTAgregarUtil.TabIndex = 0;
            this.BTAgregarUtil.Text = "Agregar util";
            this.BTAgregarUtil.UseVisualStyleBackColor = false;
            this.BTAgregarUtil.Click += new System.EventHandler(this.BTAgregarUtil_Click);
            // 
            // BTSerializarXML
            // 
            this.BTSerializarXML.BackColor = System.Drawing.Color.Gold;
            this.BTSerializarXML.FlatAppearance.BorderSize = 2;
            this.BTSerializarXML.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.BTSerializarXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTSerializarXML.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTSerializarXML.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BTSerializarXML.Location = new System.Drawing.Point(155, 78);
            this.BTSerializarXML.Name = "BTSerializarXML";
            this.BTSerializarXML.Size = new System.Drawing.Size(111, 60);
            this.BTSerializarXML.TabIndex = 1;
            this.BTSerializarXML.Text = "Serializar lapiz XML";
            this.BTSerializarXML.UseVisualStyleBackColor = false;
            this.BTSerializarXML.Click += new System.EventHandler(this.BTSerializarXML_Click);
            // 
            // BTSerializarJson
            // 
            this.BTSerializarJson.BackColor = System.Drawing.Color.Gold;
            this.BTSerializarJson.FlatAppearance.BorderSize = 2;
            this.BTSerializarJson.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.BTSerializarJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTSerializarJson.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTSerializarJson.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BTSerializarJson.Location = new System.Drawing.Point(23, 78);
            this.BTSerializarJson.Name = "BTSerializarJson";
            this.BTSerializarJson.Size = new System.Drawing.Size(111, 60);
            this.BTSerializarJson.TabIndex = 2;
            this.BTSerializarJson.Text = "Serializar lapiz JSON";
            this.BTSerializarJson.UseVisualStyleBackColor = false;
            this.BTSerializarJson.Click += new System.EventHandler(this.BTSerializarJson_Click);
            // 
            // DGVUtiles
            // 
            this.DGVUtiles.AllowUserToAddRows = false;
            this.DGVUtiles.AllowUserToDeleteRows = false;
            this.DGVUtiles.AllowUserToResizeColumns = false;
            this.DGVUtiles.AllowUserToResizeRows = false;
            this.DGVUtiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVUtiles.Location = new System.Drawing.Point(289, 12);
            this.DGVUtiles.Name = "DGVUtiles";
            this.DGVUtiles.ReadOnly = true;
            this.DGVUtiles.RowTemplate.Height = 25;
            this.DGVUtiles.Size = new System.Drawing.Size(537, 235);
            this.DGVUtiles.TabIndex = 3;
            // 
            // DVGCartucheras
            // 
            this.DVGCartucheras.AllowUserToAddRows = false;
            this.DVGCartucheras.AllowUserToDeleteRows = false;
            this.DVGCartucheras.AllowUserToResizeColumns = false;
            this.DVGCartucheras.AllowUserToResizeRows = false;
            this.DVGCartucheras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DVGCartucheras.Location = new System.Drawing.Point(392, 253);
            this.DVGCartucheras.Name = "DVGCartucheras";
            this.DVGCartucheras.ReadOnly = true;
            this.DVGCartucheras.RowTemplate.Height = 25;
            this.DVGCartucheras.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DVGCartucheras.Size = new System.Drawing.Size(434, 137);
            this.DVGCartucheras.TabIndex = 4;
            this.DVGCartucheras.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DVGCartucheras_MouseClick);
            // 
            // BTDeserializarXML
            // 
            this.BTDeserializarXML.BackColor = System.Drawing.Color.Gold;
            this.BTDeserializarXML.FlatAppearance.BorderSize = 2;
            this.BTDeserializarXML.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.BTDeserializarXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTDeserializarXML.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTDeserializarXML.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BTDeserializarXML.Location = new System.Drawing.Point(155, 144);
            this.BTDeserializarXML.Name = "BTDeserializarXML";
            this.BTDeserializarXML.Size = new System.Drawing.Size(111, 60);
            this.BTDeserializarXML.TabIndex = 5;
            this.BTDeserializarXML.Text = "Deserializar lapiz XML";
            this.BTDeserializarXML.UseVisualStyleBackColor = false;
            this.BTDeserializarXML.Click += new System.EventHandler(this.BTDeserializarXML_Click);
            // 
            // BTDeserializarJson
            // 
            this.BTDeserializarJson.BackColor = System.Drawing.Color.Gold;
            this.BTDeserializarJson.FlatAppearance.BorderSize = 2;
            this.BTDeserializarJson.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.BTDeserializarJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTDeserializarJson.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTDeserializarJson.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BTDeserializarJson.Location = new System.Drawing.Point(23, 144);
            this.BTDeserializarJson.Name = "BTDeserializarJson";
            this.BTDeserializarJson.Size = new System.Drawing.Size(111, 60);
            this.BTDeserializarJson.TabIndex = 6;
            this.BTDeserializarJson.Text = "Deserializar lapiz JSON";
            this.BTDeserializarJson.UseVisualStyleBackColor = false;
            this.BTDeserializarJson.Click += new System.EventHandler(this.BTDeserializarJson_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Gold;
            this.button7.FlatAppearance.BorderSize = 2;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button7.Location = new System.Drawing.Point(23, 330);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(111, 60);
            this.button7.TabIndex = 8;
            this.button7.Text = "Salir";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // BTVerTickets
            // 
            this.BTVerTickets.BackColor = System.Drawing.Color.Gold;
            this.BTVerTickets.FlatAppearance.BorderSize = 2;
            this.BTVerTickets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.BTVerTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTVerTickets.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTVerTickets.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BTVerTickets.Location = new System.Drawing.Point(155, 12);
            this.BTVerTickets.Name = "BTVerTickets";
            this.BTVerTickets.Size = new System.Drawing.Size(111, 60);
            this.BTVerTickets.TabIndex = 9;
            this.BTVerTickets.Text = "Ver tickets";
            this.BTVerTickets.UseVisualStyleBackColor = false;
            this.BTVerTickets.Click += new System.EventHandler(this.BTVerTickets_Click);
            // 
            // BORRARTODO
            // 
            this.BORRARTODO.BackColor = System.Drawing.Color.IndianRed;
            this.BORRARTODO.FlatAppearance.BorderSize = 2;
            this.BORRARTODO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.BORRARTODO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BORRARTODO.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BORRARTODO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BORRARTODO.Location = new System.Drawing.Point(289, 253);
            this.BORRARTODO.Name = "BORRARTODO";
            this.BORRARTODO.Size = new System.Drawing.Size(97, 76);
            this.BORRARTODO.TabIndex = 11;
            this.BORRARTODO.Text = "Borrar Base de datos";
            this.BORRARTODO.UseVisualStyleBackColor = false;
            this.BORRARTODO.Click += new System.EventHandler(this.BORRARTODO_Click);
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 5000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // BTFibron
            // 
            this.BTFibron.BackColor = System.Drawing.Color.Chartreuse;
            this.BTFibron.FlatAppearance.BorderSize = 2;
            this.BTFibron.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.BTFibron.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTFibron.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTFibron.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BTFibron.Location = new System.Drawing.Point(155, 210);
            this.BTFibron.Name = "BTFibron";
            this.BTFibron.Size = new System.Drawing.Size(111, 60);
            this.BTFibron.TabIndex = 12;
            this.BTFibron.Text = "Fibron";
            this.BTFibron.UseVisualStyleBackColor = false;
            this.BTFibron.Click += new System.EventHandler(this.BTFibron_Click);
            // 
            // FRMCartuchera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(851, 402);
            this.Controls.Add(this.BTFibron);
            this.Controls.Add(this.BORRARTODO);
            this.Controls.Add(this.BTVerTickets);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.BTDeserializarJson);
            this.Controls.Add(this.BTDeserializarXML);
            this.Controls.Add(this.DVGCartucheras);
            this.Controls.Add(this.DGVUtiles);
            this.Controls.Add(this.BTSerializarJson);
            this.Controls.Add(this.BTSerializarXML);
            this.Controls.Add(this.BTAgregarUtil);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMCartuchera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cartuchera";
            ((System.ComponentModel.ISupportInitialize)(this.DGVUtiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DVGCartucheras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTAgregarUtil;
        private System.Windows.Forms.Button BTSerializarXML;
        private System.Windows.Forms.Button BTSerializarJson;
        private System.Windows.Forms.DataGridView DGVUtiles;
        private System.Windows.Forms.DataGridView DVGCartucheras;
        private System.Windows.Forms.Button BTDeserializarXML;
        private System.Windows.Forms.Button BTDeserializarJson;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button BTVerTickets;
        private System.Windows.Forms.Button BORRARTODO;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Button BTFibron;
    }
}

