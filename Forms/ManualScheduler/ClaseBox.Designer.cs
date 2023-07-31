namespace Forms.ManualScheduler
{
    partial class ClaseBox
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.NombreLabel = new System.Windows.Forms.Label();
            this.cantButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(15, 50);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // NombreLabel
            // 
            this.NombreLabel.Font = new System.Drawing.Font("SimSun-ExtB", 7F);
            this.NombreLabel.Location = new System.Drawing.Point(28, 0);
            this.NombreLabel.Margin = new System.Windows.Forms.Padding(0);
            this.NombreLabel.Name = "NombreLabel";
            this.NombreLabel.Size = new System.Drawing.Size(135, 50);
            this.NombreLabel.TabIndex = 1;
            this.NombreLabel.Text = "Materia";
            this.NombreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NombreLabel.Click += new System.EventHandler(this.NombreLabel_Click);
            // 
            // cantButton
            // 
            this.cantButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.cantButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cantButton.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cantButton.Location = new System.Drawing.Point(166, 0);
            this.cantButton.Margin = new System.Windows.Forms.Padding(0);
            this.cantButton.Name = "cantButton";
            this.cantButton.Size = new System.Drawing.Size(34, 50);
            this.cantButton.TabIndex = 2;
            this.cantButton.Text = "XX";
            this.cantButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.cantButton.UseVisualStyleBackColor = true;
            this.cantButton.Click += new System.EventHandler(this.cantButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 3F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(10, 50);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // ClaseBox
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cantButton);
            this.Controls.Add(this.NombreLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "ClaseBox";
            this.Size = new System.Drawing.Size(200, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label NombreLabel;
        private System.Windows.Forms.Button cantButton;
        private System.Windows.Forms.Button button1;
    }
}
