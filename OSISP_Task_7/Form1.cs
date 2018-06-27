using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Разработать программу, не допускающую запуск своего второго экземпляра.
namespace OSISP_Task_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 3000;

            timer.Tick += new EventHandler(Tick);
            timer.Enabled = true;
            timer.Start();

            string ProductNameText = "Имя продукта: " + Application.ProductName + "\n";
            string ProcessNameText = "Имя процесса: " + Process.GetCurrentProcess().ProcessName + "\n";

            this.labelProductName.Text += ProductNameText + ProcessNameText;
        }      

        private void Tick(object Sender, EventArgs e)
        {
            var FindProcess = Process.GetProcessesByName(Application.ProductName);
            if (FindProcess.Length > 1)
            {
                for (int i = 1; i < FindProcess.Length; i++)
                {
                    Process pr = FindProcess[i];
                    pr.CloseMainWindow();
                }
            }
        }
    }
}
