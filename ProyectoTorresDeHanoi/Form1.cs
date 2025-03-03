using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;


namespace ProyectoTorresDeHanoi
{
    public partial class Form1 : Form
    {
        TimeSpan time;//Representa un intervalo de tiempo
        PictureBox[] discos;//Arreglo de discos
        Pila<PictureBox> TorreA, TorreB, TorreC;
        Pila<PictureBox> PrimerTorre, SegundoTorre;//pilas auxiliares 
        const int Yinicial = 408, AlturaDisco = 20, LongitudBarra = 9, subidaDisco = 210;
        int cantDiscos;
        int MovimientosRealizados = 1;
        SoundPlayer melodia;
        NumericUpDown Level;
   

        // Variables para el drag and drop, mover discos con mouse
        private bool isDragging = false;
        private PictureBox draggedDisk = null;
        private Pila<PictureBox> sourceTower = null;
        private Point dragOffset;


        // Componentes para el diseño
        private Panel panelControles;
        private Panel panelInformacion;

        public Form1()
        {
            InitializeComponent();

            // Configuración inicial de la forma
            this.BackColor = Color.FromArgb(240, 240, 245);
            this.Text = "Juego Torres de Hanoi";
            this.Size = new Size(800, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        

            // Crear y configurar los paneles
            ConfigurarPaneles();

            // Mover los controles existentes a los paneles
            ReorganizarControles();

            // Rediseñar los discos
            discos = new PictureBox[] { pic1, pic2, pic3, pic4, pic5, pic6, pic7, pic8 };
            // Estilo para los discos
            for (int i = 0; i < discos.Length; i++)
            {
                StyleDisk(discos[i], i);
            }
            ConfigureDiskDragDrop(); //Evento mover disco con mouse

            //capturando las posiciones de las torres que estan en Form
            int x1 = Torre1.Location.X;
            int x2 = Torre2.Location.X;
            int x3 = Torre3.Location.X;

            //pilas
            Torre1.Tag = TorreA = new Pila<PictureBox>(x1);
            Torre2.Tag = TorreB = new Pila<PictureBox>(x2);
            Torre3.Tag = TorreC = new Pila<PictureBox>(x3);
        }

        // ===============Métodos para reconfigurar los componentes del formulario======================
        private void ConfigurarPaneles()
        {
            // Panel para los controles (botones)
            panelControles = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(230, 230, 235),
                Padding = new Padding(10)
            };
            this.Controls.Add(panelControles);

            // Panel para la información ( movimientos)
            panelInformacion = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 80,
                BackColor = Color.FromArgb(230, 230, 235),
                Padding = new Padding(10)
            };
            this.Controls.Add(panelInformacion);
        }

        private void ReorganizarControles()
        {
            // Reconfigurar botones 
            ReconfigurarBoton(btnIniciar, "Jugar", 20, 26);
            ReconfigurarBoton(btnRendirse, "Rendirse", 470, 26);
            ReconfigurarBoton(btnSolucion, "Solución",600 , 26);

            // Mover y reconfigurar el control de nivel
            Level = new NumericUpDown();
            Level.Location = new Point(200, 30);
            Level.Size = new Size(60, 45);
            Level.BackColor = Color.White;
            Level.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            Level.Minimum = 3; //Establece el número inicial
            panelControles.Controls.Add(Level);

            // Añadir etiqueta para el nivel
            Label lblNivel = new Label()
            {
                Text = "Nivel:",
                Location = new Point(157, 33),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.FromArgb(60, 60, 60),
                BorderStyle = BorderStyle.None
            };
            panelControles.Controls.Add(lblNivel);

            // Reconfigurar las etiquetas de información
            ReconfigurarLabel(lblMoveCount, "Número mín de movimientos: 0", 20, 40);
            ReconfigurarLabel(lblTusMovimientos, "Tus movimientos: 0", 350, 40);

            // Mover las torres al panel de juego
            ReconfigurarTorre(Torre1, 140);
            ReconfigurarTorre(Torre2, 380);
            ReconfigurarTorre(Torre3, 620);
        }

        private void ReconfigurarBoton(Button btn, string texto, int x, int y)
        {
            btn.Text = texto;
            btn.Location = new Point(x, y);
            btn.Size = new Size(100, 40);
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.FromArgb(70, 130, 180);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            panelControles.Controls.Add(btn);
        }

        private void ReconfigurarLabel(Label lbl, string texto, int x, int y)
        {
            lbl.Text = texto;
            lbl.Location = new Point(x, y);
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lbl.BackColor = Color.Transparent;
            lbl.BorderStyle = BorderStyle.None;
            panelInformacion.Controls.Add(lbl);
        }

        private void ReconfigurarTorre(PictureBox torre, int x)
        {
            //Label del temporizador
            lblTime.Text = "Tiempo: 00:00:00";
            lblTime.Location = new Point(10, 110);
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblTime.BorderStyle = BorderStyle.None;
            lblTime.BackColor = Color.Transparent;

            // Ajustar la base de la torre
            torre.Size = new Size(20, 200);
            torre.BackColor = Color.FromArgb(139, 69, 19); // Marrón para simular madera
            torre.Location = new Point(x, 230);
            this.Controls.Add(torre);

            // Añadir una base para la torre
            PictureBox base_torre = new PictureBox
            {
                Size = new Size(100, 18),
                BackColor = Color.FromArgb(160, 82, 45),
                Location = new Point(x - 40, 427),
            };
            this.Controls.Add(base_torre);
            base_torre.SendToBack();
        }

        // Método para estilizar discos
        void StyleDisk(PictureBox disk, int index)
        {
            // Colores para los discos (degradado del más pequeño al más grande)
            Color[] diskColors = {
                Color.FromArgb(255, 102, 102), // Rojo
                Color.FromArgb(255, 178, 102), // Naranja
                Color.FromArgb(255, 255, 102), // Amarillo
                Color.FromArgb(178, 255, 102), // Verde claro
                Color.FromArgb(102, 255, 102), // Verde
                Color.FromArgb(102, 255, 178), // Turquesa
                Color.FromArgb(102, 178, 255), // Azul claro
                Color.FromArgb(102, 102, 255)  // Azul
            };

            disk.BackColor = diskColors[index];
            disk.Size = new Size(40 + (index * 20), 20);
            disk.Tag = index;

            // Añade un borde y sombra al disco
            disk.Paint += (s, e) => {
                var diskPic = s as PictureBox;
                using (var brush = new LinearGradientBrush(
                    diskPic.ClientRectangle,
                    Color.FromArgb(Math.Min(diskColors[index].R + 20, 255), Math.Min(diskColors[index].G + 20, 255), Math.Min(diskColors[index].B + 20, 255)),
                    Color.FromArgb((int)(diskColors[index].R * 0.8), (int)(diskColors[index].G * 0.8), (int)(diskColors[index].B * 0.8)),
                    90F))
                using (var pen = new Pen(Color.FromArgb(100, 100, 100), 1))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.FillRectangle(brush, 0, 0, diskPic.Width, diskPic.Height);
                    e.Graphics.DrawRectangle(pen, 0, 0, diskPic.Width - 1, diskPic.Height - 1);
                }
            };
        }

       //============================ Eventos de los BOTONES ===========================================
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            inicializarJuego(true);
        }

        private void btnRendirse_Click_1(object sender, EventArgs e)
        {
            tmrCounTime.Stop();
            Level.Enabled = true;
            btnRendirse.Enabled = false;
            btnIniciar.Text = "Jugar";
        }

        private void btnSolucion_Click_1(object sender, EventArgs e)
        {
            tmrCounTime.Stop();
            lblTime.Text = string.Format("Tiempo: 00:00:00");
            Recursividad(cantDiscos, TorreA, TorreB, TorreC);
            melodia.Stop();
            MessageBox.Show("Juego finalizado");
            inicializarJuego(false);
        }

        //=========================== Métodos del Juego =================================== 
        public void inicializarJuego(bool isPlaying) {
            cantDiscos = (int)Level.Value; //Obtiene el valor del NumericUpDown
            tmrCounTime.Stop(); //Detiene el temporizador

            foreach (PictureBox item in discos) item.Visible = false; //Oculta los discos

            time = new TimeSpan(0); //Inicializa el tiempo
            lblTime.Text = "Tiempo: 00:00:00";
            int minMov = (int)Math.Pow(2, cantDiscos) - 1; //Calcula el número mínimo de movimientos
            lblMoveCount.Text = "Número min de movimientos: " + minMov.ToString();

            //TORRES de form
            Torre1.BorderStyle = Torre2.BorderStyle = Torre3.BorderStyle = BorderStyle.None;
            PrimerTorre = SegundoTorre = null;
            TorreA.Clear();
            TorreB.Clear();
            TorreC.Clear();

            //INICIALIZAR
            Level.Enabled = false;
            btnRendirse.Enabled = true;
            btnSolucion.Enabled = true;
            btnIniciar.Text = "Jugar";

            int y = Yinicial;

            // Indica como debe ir colocandose los anillos
            for (int i = (int)Level.Value - 1; i >= 0; --i, y -= AlturaDisco)
            {
                int centroTorre = Torre1.Location.X + (Torre1.Width / 2);  // Calcula el centro de la torre
                int x = centroTorre - (discos[i].Width / 2);           // Calcula la posición X para centrar el disco

                discos[i].Location = new Point(x, y);
                discos[i].Visible = true;
                TorreA.Push(discos[i]);
            }

            melodia = new SoundPlayer(Properties.Resources.RandyBush);
            melodia.Play();
            tmrCounTime.Enabled = isPlaying; //Inicia el temporizador
        }
      

        public void Recursividad(int n, Pila<PictureBox> TorreA, Pila<PictureBox> TorreB, Pila<PictureBox> TorreC)
        {
            if (n == 1)
            {
                Llamada(TorreA, TorreC);
            }
            else
            {

                Recursividad(n - 1, TorreA, TorreC, TorreB);
                Llamada(TorreA, TorreC);
                Recursividad(n - 1, TorreB, TorreA, TorreC);
            }
        }

        public void Llamada(Pila<PictureBox> anterior, Pila<PictureBox> destino)
        {
            try
            {
                PictureBox seleccionado = anterior.Pop();
                int xOriginal = seleccionado.Location.X; // Guardamos la posición X original

                //sube disco 
                int bass = seleccionado.Location.Y;
                while (bass > subidaDisco)
                {
                    seleccionado.Location = new Point(xOriginal, bass); // Usamos la X original
                    this.Refresh();
                    bass -= 20;
                    Thread.Sleep(300);
                }

                //mueve lado a lado los discos
                int lado1 = xOriginal; // Comenzamos desde la X original
                int lado2 = destino.X; // Obtenemos la X de la torre destino

                if (lado1 < lado2) // Si la torre destino está a la derecha
                {
                    while (lado1 + 20 < lado2) // Mientras no llegue al centro de la torre destino
                    {
                        seleccionado.Location = new Point(lado1, subidaDisco);
                        this.Refresh();
                        lado1 += 20;
                        Thread.Sleep(300);
                    }
                }
                else // Si la torre destino está a la izquierda
                {
                    while (lado1 > lado2 + 20) // Mientras no llegue al centro de la torre destino
                    {
                        seleccionado.Location = new Point(lado1, subidaDisco);
                        this.Refresh();
                        lado1 -= 20;
                        Thread.Sleep(300);
                    }
                }

                // Calculamos el centro para posicionar el disco centrado
                int centroTorre = destino.X + (Torre1.Width / 2);
                int xCentrado = centroTorre - (seleccionado.Width / 2);

                //asienta los discos
                int sup = subidaDisco;
                while (sup < Yinicial - (AlturaDisco * destino.Count - 1)) // Mientras no llegue al nivel de la torre destino
                {
                    seleccionado.Location = new Point(xCentrado, sup);
                    this.Refresh();
                    sup += 20;
                    Thread.Sleep(300);
                }

                seleccionado.Location = new Point(xCentrado, Yinicial - (AlturaDisco * destino.Count - 1));
                destino.Push(seleccionado);
                this.Refresh();
                Thread.Sleep(300);
            }
            catch (Exception e) { }
        }

        private void Time_Tick(object sender, EventArgs e)// Clase TimeSpan
        {
            time = time.Add(new TimeSpan(0, 0, 1));
            lblTime.Text = string.Format("Tiempo: {0:00}:{1:00}:{2:00}", time.Hours, time.Minutes, time.Seconds);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pic1.Visible = false;
            pic2.Visible = false;
            pic3.Visible = false;
            pic4.Visible = false;
            pic5.Visible = false;
            pic6.Visible = false;
            pic7.Visible = false;
            pic8.Visible = false;
            btnSolucion.Enabled = false;
        }

        //================= Movimiento de discos con el mouse ==========================
        private void ConfigureDiskDragDrop() //Evento mover disco con mouse
        {
            foreach (PictureBox disk in discos) //Recorre los discos
            {
                disk.MouseDown += Disk_MouseDown;
                disk.MouseMove += Disk_MouseMove;
                disk.MouseUp += Disk_MouseUp;
            }
        }

        private void Disk_MouseDown(object sender, MouseEventArgs e) //Evento mover disco con mouse
        {
            if (Level.Enabled) return; // No permitir drag si el juego no ha comenzado

            PictureBox disk = sender as PictureBox; //Obtiene el disco seleccionado

            // Verificar si el disco está en la parte superior de alguna torre
            Pila<PictureBox> tower = null;
            if (TorreA.Count > 0 && TorreA.Peek() == disk)
                tower = TorreA;
            else if (TorreB.Count > 0 && TorreB.Peek() == disk)
                tower = TorreB;
            else if (TorreC.Count > 0 && TorreC.Peek() == disk)
                tower = TorreC;

            // Solo permitir arrastrar si es el disco superior
            if (tower != null)
            {
                isDragging = true;
                draggedDisk = disk;
                sourceTower = tower;
                dragOffset = new Point(e.X, e.Y);

                // Traer el disco al frente
                disk.BringToFront();
            }
        }

        private void Disk_MouseMove(object sender, MouseEventArgs e) //Evento mover disco con mouse
        {
            if (isDragging && draggedDisk != null)
            {
                // Calcular nueva posición
                int newX = draggedDisk.Left + e.X - dragOffset.X;
                int newY = draggedDisk.Top + e.Y - dragOffset.Y;

                // Mover el disco
                draggedDisk.Location = new Point(newX, newY);
            }
        }

        private void Disk_MouseUp(object sender, MouseEventArgs e) //Evento mover disco con mouse
        {
            if (isDragging && draggedDisk != null)
            {
                // Detectar a qué torre está más cercano
                Pila<PictureBox> targetTower = GetNearestTower(draggedDisk);

                if (targetTower != null && IsValidMove(sourceTower, targetTower)) // Si el movimiento es válido
                {
                    // Calcular posición centrada en la torre de destino
                    MoveToTower(draggedDisk, sourceTower, targetTower);
                    MovimientosRealizados++;
                    lblTusMovimientos.Text = "Tus movimientos: " + MovimientosRealizados.ToString();

                    // Verificar si se ha completado el juego
                    if (TorreC.Count == Level.Value)
                    {
                        melodia.Stop();
                        btnRendirse.PerformClick();
                        tmrCounTime.Stop();
                        MessageBox.Show("¡Felicidades por tu éxito!", "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    ReturnDiskToSource(); 
                }

                // Resetear variables
                isDragging = false;
                draggedDisk = null;
                sourceTower = null;
            }
        }

        private Pila<PictureBox> GetNearestTower(PictureBox disk) //Obtener la torre más cercana
        {
            // Obtener el centro del disco
            int diskCenterX = disk.Left + disk.Width / 2;

            // Calcular distancias a cada torre
            int distA = Math.Abs(diskCenterX - (Torre1.Location.X + Torre1.Width / 2));
            int distB = Math.Abs(diskCenterX - (Torre2.Location.X + Torre2.Width / 2));
            int distC = Math.Abs(diskCenterX - (Torre3.Location.X + Torre3.Width / 2));

            // Distancia máxima para "magnetismo" 
            const int MAX_MAGNETISM_DISTANCE = 100;

            // Encontrar la torre más cercana dentro del rango de magnetismo
            if (distA < distB && distA < distC && distA < MAX_MAGNETISM_DISTANCE)
                return TorreA;
            else if (distB < distA && distB < distC && distB < MAX_MAGNETISM_DISTANCE)
                return TorreB;
            else if (distC < distA && distC < distB && distC < MAX_MAGNETISM_DISTANCE)
                return TorreC;

            return null;
        }

        private bool IsValidMove(Pila<PictureBox> source, Pila<PictureBox> target) //Validar movimiento
        {
            // No permitir movimientos a la misma torre
            if (source == target)
                return false;

            // Si la torre destino está vacía, el movimiento es válido
            if (target.Count == 0)
                return true;

            // Verificar si el disco de origen es más pequeño que el de destino
            PictureBox sourceDisk = source.Peek();
            PictureBox targetDisk = target.Peek();

            return int.Parse(sourceDisk.Tag.ToString()) < int.Parse(targetDisk.Tag.ToString());
        }

        private void MoveToTower(PictureBox disk, Pila<PictureBox> source, Pila<PictureBox> target) //Mover disco a torre
        { 
            source.Pop(); // Quitar el disco de la torre origen

            // Calcular la posición centrada
            int centroTorre = target == TorreA ? Torre1.Location.X + Torre1.Width / 2 : 
                              target == TorreB ? Torre2.Location.X + Torre2.Width / 2 :
                                               Torre3.Location.X + Torre3.Width / 2;

            int x = centroTorre - (disk.Width / 2);
            int y = Yinicial - (AlturaDisco * target.Count);

            // Animar el movimiento
            AnimateDiskToPosition(disk, x, y);

            // Añadir a la torre destino
            target.Push(disk);
        }

        private void ReturnDiskToSource() //Retornar disco a la torre de origen
        {
            if (sourceTower != null && draggedDisk != null)
            {
                // Calcular la posición original
                int centroTorre = sourceTower == TorreA ? Torre1.Location.X + Torre1.Width / 2 :
                                  sourceTower == TorreB ? Torre2.Location.X + Torre2.Width / 2 :
                                                       Torre3.Location.X + Torre3.Width / 2;

                int x = centroTorre - (draggedDisk.Width / 2);
                int y = Yinicial - (AlturaDisco * (sourceTower.Count - 1));

                // Animar el retorno
                AnimateDiskToPosition(draggedDisk, x, y);
            }
        }

        private void AnimateDiskToPosition(PictureBox disk, int targetX, int targetY) //Animar disco a posición
        {
            // Implementa una animación.
            disk.Location = new Point(targetX, targetY);
        }

    }
}