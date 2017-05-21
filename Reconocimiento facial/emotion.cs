using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Data.OleDb;
//using System.Speech.Synthesis;
using System.Media;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices;



namespace Reconocimiento_facial
{

    public partial class emotion : Form
    {
        public emotion()
        {
            InitializeComponent();
        }
        public DateTime date { get; }
        private void emotion_Load(object sender, EventArgs e)
        {
            Console.WriteLine(date +  ":: Emotion API 1.0 Initiated");

            button1.Text = "Getpics";

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = (Application.StartupPath + "/face_analysis/" + Convert.ToString(listBox1.SelectedItem));
        }

        private void getPics()
        {
            Console.WriteLine("getPics is Activated");
            int picsnum=2;
            while(true)
            {
                if (File.Exists(Application.StartupPath + "/face_analysis/" + picsnum + ".png"))
                { listBox1.Items.Add(picsnum + ".png");
                    Console.WriteLine(date + ":: File {0}.png found", picsnum);
                    picsnum++;
                   
                }
                else
                {
                    Console.WriteLine("============================");
                    Console.WriteLine("Total {0} Pics Found",picsnum-2);
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getPics();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();
       
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;

            Console.WriteLine("Mouse Down event");
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
                Console.WriteLine("Mouse Down event" + Cursor.Position);
            }
        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
