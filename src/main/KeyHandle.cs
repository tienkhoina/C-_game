using System;
using System.Windows.Forms;

public class KeyHandle : Form
{
    public bool upPress, downPress, leftPress, rightPress;

    public KeyHandle()
    {
        // Đảm bảo form nhận sự kiện phím
        this.KeyDown += KeyPressed;
        this.KeyUp += KeyReleased;
    }

    // Xử lý khi một phím được nhấn xuống
    public void KeyPressed(object sender, KeyEventArgs e)
    {
        // Kiểm tra mã phím khi người dùng nhấn
        if (e.KeyCode == Keys.W)
        {
            upPress = true;
            // Console.WriteLine("Đã nhấn W");
        }
        if (e.KeyCode == Keys.S)
        {
            downPress = true;
        }
        if (e.KeyCode == Keys.A)
        {
            leftPress = true;
        }
        if (e.KeyCode == Keys.D)
        {
            rightPress = true;
        }
    }

    // Xử lý khi một phím được nhả ra
    public void KeyReleased(object sender, KeyEventArgs e)
    {
        // Kiểm tra mã phím khi người dùng nhả phím
        if (e.KeyCode == Keys.W)
        {
            upPress = false;
        }
        if (e.KeyCode == Keys.S)
        {
            downPress = false;
        }
        if (e.KeyCode == Keys.A)
        {
            leftPress = false;
        }
        if (e.KeyCode == Keys.D)
        {
            rightPress = false;
        }
    }
}
