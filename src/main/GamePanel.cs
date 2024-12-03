using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace main
{
    public class GamePanel : Panel
    {
        public KeyHandle keyHandle;
        private int originalTileSize = 16;
        private int scale = 3;
        public int tileSize;
        public int maxScreenCol = 16;
        public int maxScreenRow = 12;
        public int screenWidth;
        public int screenHeight;

        public int maxWorldCol = 50;
        public int maxWorldRow = 50;
        public int worldWidth;
        public int worldHeight;

        private int FPS = 60;

        // Các tham số liên quan đến người chơi và đối tượng
        public int playerX = 100;
        public int playerY = 100;
        public int playerSpeed = 4;

        private Thread gameThread;
        private int delta = 0;
        private long lastTime = DateTime.Now.Ticks;
        private long currentTime;
        private int drawCount = 0;
        private long timer = 0;

        // Hàm khởi tạo
        public GamePanel()
        {
            tileSize = originalTileSize * scale;
            screenWidth = maxScreenCol * tileSize;
            screenHeight = maxScreenRow * tileSize;
            worldWidth = tileSize * maxWorldCol;
            worldHeight = tileSize * maxWorldRow;

            this.keyHandle = new KeyHandle();

            this.Size = new Size(screenWidth, screenHeight);
            this.BackColor = Color.Black;
            this.DoubleBuffered = true;
        }

        // Khởi động luồng game
        public void StartGameThread()
        {
            gameThread = new Thread(GameLoop);
            gameThread.Start();
        }

        // Vòng lặp game
        private void GameLoop()
{
    // FPS thông qua TimeSpan
    double drawInterval = 1000 / FPS;  // 1 giây chia cho FPS
    long lastUpdateTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    while (gameThread != null)
    {
        currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        delta += (int)(currentTime - lastUpdateTime);
        timer += (currentTime - lastUpdateTime);
        lastUpdateTime = currentTime;

        // Nếu đủ thời gian thì cập nhật và vẽ lại
        if (delta > drawInterval)
        {
            Update();
            Invalidate();  // Redraw screen
            delta = 0;
            drawCount++;
        }

        // Kiểm tra FPS và in ra console
        if (timer > 1000)
        {
            Console.WriteLine($"FPS: {drawCount}");
            drawCount = 0;
            timer = 0;
        }
    }
}


        // Phương thức cập nhật game
        public new void Update()
        {
            if (keyHandle.upPress)
            {
                playerY -= playerSpeed; // Di chuyển lên
            }
            if (keyHandle.downPress)
            {
                playerY += playerSpeed; // Di chuyển xuống
            }
            if (keyHandle.leftPress)
            {
                playerX -= playerSpeed; // Di chuyển trái
            }
            if (keyHandle.rightPress)
            {
                playerX += playerSpeed; // Di chuyển phải
            }
        }

        // Vẽ lên màn hình
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Vẽ các đối tượng (chẳng hạn, người chơi)
            g.FillRectangle(Brushes.Red, playerX, playerY, tileSize, tileSize);

            // Vẽ thêm các đối tượng khác ở đây, nếu cần.
        }
    }
}
