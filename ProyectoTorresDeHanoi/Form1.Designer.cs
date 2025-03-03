namespace ProyectoTorresDeHanoi
{
    partial class Form1
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

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelA = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.labelC = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.tmrCounTime = new System.Windows.Forms.Timer(this.components);
            this.lblMoveCount = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnRendirse = new System.Windows.Forms.Button();
            this.btnSolucion = new System.Windows.Forms.Button();
            this.pic7 = new System.Windows.Forms.PictureBox();
            this.pic6 = new System.Windows.Forms.PictureBox();
            this.pic5 = new System.Windows.Forms.PictureBox();
            this.pic4 = new System.Windows.Forms.PictureBox();
            this.pic3 = new System.Windows.Forms.PictureBox();
            this.pic8 = new System.Windows.Forms.PictureBox();
            this.Torre1 = new System.Windows.Forms.PictureBox();
            this.Torre2 = new System.Windows.Forms.PictureBox();
            this.Torre3 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.lblTusMovimientos = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Torre1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Torre2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Torre3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Location = new System.Drawing.Point(141, 485);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(14, 13);
            this.labelA.TabIndex = 3;
            this.labelA.Text = "A";
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(382, 485);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(14, 13);
            this.labelB.TabIndex = 4;
            this.labelB.Text = "B";
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Location = new System.Drawing.Point(628, 485);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(14, 13);
            this.labelC.TabIndex = 5;
            this.labelC.Text = "C";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.White;
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTime.Location = new System.Drawing.Point(385, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(92, 15);
            this.lblTime.TabIndex = 15;
            this.lblTime.Text = "Tiempo: 00:00:00";
            // 
            // tmrCounTime
            // 
            this.tmrCounTime.Interval = 1000;
            this.tmrCounTime.Tick += new System.EventHandler(this.Time_Tick);
            // 
            // lblMoveCount
            // 
            this.lblMoveCount.AutoSize = true;
            this.lblMoveCount.BackColor = System.Drawing.Color.White;
            this.lblMoveCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMoveCount.Location = new System.Drawing.Point(362, 45);
            this.lblMoveCount.Name = "lblMoveCount";
            this.lblMoveCount.Size = new System.Drawing.Size(164, 15);
            this.lblMoveCount.TabIndex = 16;
            this.lblMoveCount.Text = " Numero minino de movimientos: ";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(362, 126);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 19;
            this.btnIniciar.Text = "Play";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnRendirse
            // 
            this.btnRendirse.Enabled = false;
            this.btnRendirse.Location = new System.Drawing.Point(443, 126);
            this.btnRendirse.Name = "btnRendirse";
            this.btnRendirse.Size = new System.Drawing.Size(75, 23);
            this.btnRendirse.TabIndex = 20;
            this.btnRendirse.Text = "Rendirse";
            this.btnRendirse.UseVisualStyleBackColor = true;
            this.btnRendirse.Click += new System.EventHandler(this.btnRendirse_Click_1);
            // 
            // btnSolucion
            // 
            this.btnSolucion.Location = new System.Drawing.Point(524, 126);
            this.btnSolucion.Name = "btnSolucion";
            this.btnSolucion.Size = new System.Drawing.Size(97, 23);
            this.btnSolucion.TabIndex = 21;
            this.btnSolucion.Text = "Solucion";
            this.btnSolucion.UseVisualStyleBackColor = true;
            this.btnSolucion.Click += new System.EventHandler(this.btnSolucion_Click_1);
            // 
            // pic7
            // 
            this.pic7.BackColor = System.Drawing.Color.White;
            this.pic7.Image = global::ProyectoTorresDeHanoi.Properties.Resources._7;
            this.pic7.Location = new System.Drawing.Point(550, 414);
            this.pic7.Name = "pic7";
            this.pic7.Size = new System.Drawing.Size(214, 20);
            this.pic7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic7.TabIndex = 13;
            this.pic7.TabStop = false;
            this.pic7.Tag = "7";
  
            // 
            // pic6
            // 
            this.pic6.BackColor = System.Drawing.Color.White;
            this.pic6.Image = global::ProyectoTorresDeHanoi.Properties.Resources._6;
            this.pic6.Location = new System.Drawing.Point(550, 382);
            this.pic6.Name = "pic6";
            this.pic6.Size = new System.Drawing.Size(214, 20);
            this.pic6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic6.TabIndex = 12;
            this.pic6.TabStop = false;
            this.pic6.Tag = "6";
         
            // 
            // pic5
            // 
            this.pic5.BackColor = System.Drawing.Color.White;
            this.pic5.Image = global::ProyectoTorresDeHanoi.Properties.Resources._5;
            this.pic5.Location = new System.Drawing.Point(550, 356);
            this.pic5.Name = "pic5";
            this.pic5.Size = new System.Drawing.Size(214, 20);
            this.pic5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic5.TabIndex = 11;
            this.pic5.TabStop = false;
            this.pic5.Tag = "5";
           
            // 
            // pic4
            // 
            this.pic4.BackColor = System.Drawing.Color.White;
            this.pic4.Image = global::ProyectoTorresDeHanoi.Properties.Resources._4;
            this.pic4.Location = new System.Drawing.Point(550, 330);
            this.pic4.Name = "pic4";
            this.pic4.Size = new System.Drawing.Size(214, 20);
            this.pic4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic4.TabIndex = 10;
            this.pic4.TabStop = false;
            this.pic4.Tag = "4";
         
            // 
            // pic3
            // 
            this.pic3.BackColor = System.Drawing.Color.White;
            this.pic3.Image = global::ProyectoTorresDeHanoi.Properties.Resources._3;
            this.pic3.Location = new System.Drawing.Point(550, 304);
            this.pic3.Name = "pic3";
            this.pic3.Size = new System.Drawing.Size(214, 20);
            this.pic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic3.TabIndex = 9;
            this.pic3.TabStop = false;
            this.pic3.Tag = "3";
          
            // 
            // pic8
            // 
            this.pic8.BackColor = System.Drawing.Color.White;
            this.pic8.Image = global::ProyectoTorresDeHanoi.Properties.Resources._8;
            this.pic8.Location = new System.Drawing.Point(550, 434);
            this.pic8.Name = "pic8";
            this.pic8.Size = new System.Drawing.Size(214, 20);
            this.pic8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic8.TabIndex = 7;
            this.pic8.TabStop = false;
            this.pic8.Tag = "8";
        
            // 
            // Torre1
            // 
            this.Torre1.BackColor = System.Drawing.Color.Transparent;
            this.Torre1.Image = ((System.Drawing.Image)(resources.GetObject("Torre1.Image")));
            this.Torre1.Location = new System.Drawing.Point(55, 234);
            this.Torre1.Name = "Torre1";
            this.Torre1.Size = new System.Drawing.Size(236, 242);
            this.Torre1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Torre1.TabIndex = 2;
            this.Torre1.TabStop = false;
         
            // 
            // Torre2
            // 
            this.Torre2.Image = ((System.Drawing.Image)(resources.GetObject("Torre2.Image")));
            this.Torre2.Location = new System.Drawing.Point(297, 234);
            this.Torre2.Name = "Torre2";
            this.Torre2.Size = new System.Drawing.Size(236, 242);
            this.Torre2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Torre2.TabIndex = 1;
            this.Torre2.TabStop = false;
          
            // 
            // Torre3
            // 
            this.Torre3.Image = ((System.Drawing.Image)(resources.GetObject("Torre3.Image")));
            this.Torre3.Location = new System.Drawing.Point(539, 234);
            this.Torre3.Name = "Torre3";
            this.Torre3.Size = new System.Drawing.Size(236, 242);
            this.Torre3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Torre3.TabIndex = 0;
            this.Torre3.TabStop = false;
    
            // 
            // pic2
            // 
            this.pic2.BackColor = System.Drawing.Color.White;
            this.pic2.Image = global::ProyectoTorresDeHanoi.Properties.Resources._2;
            this.pic2.Location = new System.Drawing.Point(304, 434);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(214, 20);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic2.TabIndex = 22;
            this.pic2.TabStop = false;
            this.pic2.Tag = "2";
        
            // 
            // pic1
            // 
            this.pic1.BackColor = System.Drawing.Color.White;
            this.pic1.Image = global::ProyectoTorresDeHanoi.Properties.Resources._1;
            this.pic1.Location = new System.Drawing.Point(67, 434);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(214, 20);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic1.TabIndex = 23;
            this.pic1.TabStop = false;
            this.pic1.Tag = "1";
         
            // 
            // lblTusMovimientos
            // 
            this.lblTusMovimientos.AutoSize = true;
            this.lblTusMovimientos.BackColor = System.Drawing.Color.White;
            this.lblTusMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTusMovimientos.Location = new System.Drawing.Point(362, 72);
            this.lblTusMovimientos.Name = "lblTusMovimientos";
            this.lblTusMovimientos.Size = new System.Drawing.Size(94, 15);
            this.lblTusMovimientos.TabIndex = 24;
            this.lblTusMovimientos.Text = "Tus movimientos: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(880, 507);
            this.Controls.Add(this.lblTusMovimientos);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.btnSolucion);
            this.Controls.Add(this.btnRendirse);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.lblMoveCount);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.pic7);
            this.Controls.Add(this.pic6);
            this.Controls.Add(this.pic5);
            this.Controls.Add(this.pic4);
            this.Controls.Add(this.pic3);
            this.Controls.Add(this.pic8);
            this.Controls.Add(this.labelC);
            this.Controls.Add(this.labelB);
            this.Controls.Add(this.labelA);
            this.Controls.Add(this.Torre1);
            this.Controls.Add(this.Torre2);
            this.Controls.Add(this.Torre3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "TORRES DE HANOI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Torre1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Torre2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Torre3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox Torre3;
        private System.Windows.Forms.PictureBox Torre2;
        private System.Windows.Forms.PictureBox Torre1;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.PictureBox pic8;
        private System.Windows.Forms.PictureBox pic3;
        private System.Windows.Forms.PictureBox pic4;
        private System.Windows.Forms.PictureBox pic5;
        private System.Windows.Forms.PictureBox pic6;
        private System.Windows.Forms.PictureBox pic7;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer tmrCounTime;
        private System.Windows.Forms.Label lblMoveCount;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnRendirse;
        private System.Windows.Forms.Button btnSolucion;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.Label lblTusMovimientos;
        private System.Windows.Forms.Timer timer1;
    }
}

