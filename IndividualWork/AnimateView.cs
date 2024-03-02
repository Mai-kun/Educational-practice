using System.Threading;
using System.Windows.Forms;

namespace TowersWindows
{
    class AnimateView
    {
        public static Panel view;
        public void MoveUp(PictureBox Disk, int newY)
        {
            while(Disk.Location.Y > newY)
            {
                Disk.Location = new System.Drawing.Point(Disk.Location.X, Disk.Location.Y - 10);
                view.Refresh();
                Thread.Sleep(10);
            }
        }
        public void MoveDown(PictureBox Disk, int newY)
        {
            while (Disk.Location.Y < newY)
            {
                Disk.Location = new System.Drawing.Point(Disk.Location.X, Disk.Location.Y + 10);
                view.Refresh();
                Thread.Sleep(10);
            }
        }
        public void MoveRight(PictureBox Disk, int newX)
        {
            while (Disk.Location.X < newX)
            {
                Disk.Location = new System.Drawing.Point(Disk.Location.X + 10, Disk.Location.Y);
                view.Refresh();
                Thread.Sleep(10);
            }

        }
        public void MoveLeft(PictureBox Disk, int newX)
        {
            while (Disk.Location.X > newX)
            {
                Disk.Location = new System.Drawing.Point(Disk.Location.X - 10, Disk.Location.Y);
                view.Refresh();
                Thread.Sleep(10);
            }
        }
    }
}
