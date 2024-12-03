using System;
using System.Windows.Forms;

namespace main
{
    public class MainForm : Form
    {
        private GamePanel gamePanel;

        public MainForm()
        {
            // Khởi tạo GamePanel
            gamePanel = new GamePanel();
            this.Controls.Add(gamePanel);
            gamePanel.StartGameThread(); // Bắt đầu luồng game

            // Đặt kích thước và tiêu đề cửa sổ
            this.Size = new System.Drawing.Size(gamePanel.screenWidth, gamePanel.screenHeight);
            this.Text = "Game";

            // Đảm bảo Form nhận sự kiện phím
            this.KeyPreview = true;
            this.KeyDown += (sender, e) => gamePanel.keyHandle.KeyPressed(sender, e);
            this.KeyUp += (sender, e) => gamePanel.keyHandle.KeyReleased(sender, e);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
