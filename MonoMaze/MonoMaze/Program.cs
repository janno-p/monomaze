using System;
using System.Windows.Forms;

namespace MonoMaze
{
    public static class Program
    {
        public static void Main()
        {
            try
            {
                using (var game = new Game())
                    game.Run();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Unexpected error occured!");
            }
        }
    }
}