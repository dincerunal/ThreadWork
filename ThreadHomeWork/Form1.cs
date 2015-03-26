using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace ThreadHomeWork
{
    public partial class Form1 : Form
    {
        Stopwatch zaman = new Stopwatch();

        long sayi;
        long threadSayisi;
        Thread[] th;
        int bolme;
        long[] sonuc;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        

        
        
        private void topla(object ilkbas)
        {
            long araToplam = 0;
            for (long i =Convert.ToInt64(ilkbas)+1; i <= (Convert.ToInt64(ilkbas) + bolme); i++)
            {
                araToplam = araToplam + i;
 
            }
            sonuc[Convert.ToInt64(ilkbas) / bolme] = araToplam;


        }
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            zaman.Reset();
            sayi=100000000;
            threadSayisi = long.Parse(textBoxThread.Text);
            th = new Thread[threadSayisi];
            
            bolme=Convert.ToInt32(sayi/threadSayisi);
            sonuc = new long[threadSayisi];



            zaman.Start();
            for (int i = 0; i < threadSayisi; i++)
            {
                long bas = i * bolme;
                th[i] = new Thread(new ParameterizedThreadStart(topla));
                th[i].Start(bas);
            }



            
            
            

           
            
            long top=0;
            for (int i = 0; i <threadSayisi ; i++)
            {
                th[i].Join();           //İşini bitirmeyen thread varsa beklanir....
                top = top + sonuc[i];
 
            }
            zaman.Stop();
            

            labelTop.Text = top.ToString();
            labelTime.Text = zaman.Elapsed.ToString();
          
           
        }
    }
}
