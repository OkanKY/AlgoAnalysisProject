using AlgoAnalysis.SortAlgoritm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoAnalysProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private String aSize;
        private void button1_Click(object sender, EventArgs e)
        {
             aSize = arraySizeText.Text;
             if (aSize != "")
             {
                 enterExecute();
             }
             else
                 execute();
        }
        private void execute()
        {
            String write="";
            StreamWriter dosya = File.CreateText("E:\\output.txt");
            write+="\t           Bubble Sort                                    Quick Sort";
            write+="\t Key Compare        Run Time(msc)                Key Comparision     Run Time(msc)";
            write+="\tAvarage   Std.Dev  Avarage   Std.Dev            Avarage   Std.Dev   Avarage   Std.Dev";
            Sorted bubble_srt = new Sorted(new BubbleSort());
            Sorted quick_srt = new Sorted(new QuickSort());
            for (int j = 1; j <= 10; j++)//dizilerin boyutlarını otomatik ayarlamak için 
            {
                double bstoplamKCompare = 0;
                double bstoplamRTime = 0;
                double qstoplamKCompare = 0;
                double qstoplamRTime = 0;
                int[] bskeycount = new int[10];
                int[] qskeycount = new int[10];
                int[] bsrunTime = new int[10];
                int[] qsrunTime = new int[10];


                for (int k = 0; k < 10; k++)//her dizinin 10 defa yaratılması için
                {
                    Random r = new Random();
                    // int arraySize = int.Parse(aSize);
                    int[] Array0 = new int[j * 1000];
                    int[] Array1 = new int[j * 1000];
                    int[] Array2 = new int[j * 1000];


                    //************* Generate Random Numbers ***************	
                    int res = 0;
                    for (int i = 0; i < j * 1000; i++)
                    {

                        res = r.Next(0, j * 1000);
                        Array0[i] = res;
                        Array1[i] = res;
                        Array2[i] = res;

                    }
                    //************* Execution Time of BubbleSort *********
                    //  Sorted bubble_srt = new Sorted(new BubbleSort());
                    DateTime bsstartTime = DateTime.Now;
                    bskeycount[k] = bubble_srt.sort(Array1, Array1.Length);
                    DateTime bsendTime = DateTime.Now;
                    //  Sorted quick_srt = new Sorted(new QuickSort());
                    DateTime qsstartTime = DateTime.Now;
                    qskeycount[k] = quick_srt.sort(Array2, Array2.Length);
                    DateTime qsendTime = DateTime.Now;

                    bstoplamKCompare += bskeycount[k];
                    bsrunTime[k] = (bsendTime - bsstartTime).Milliseconds;
                    bstoplamRTime += bsrunTime[k];
                    qstoplamKCompare += qskeycount[k];
                    qsrunTime[k] = (qsendTime - qsstartTime).Milliseconds;
                    qstoplamRTime += qsrunTime[k];

                }
                
                write+="\n" + j * 1000 + "\t" + String.Format("{0:0.##}", (double)bstoplamKCompare / 10) + "\t" + String.Format("{0:0.##}", standartSapmaBul(bskeycount, bstoplamKCompare / 10)) + "\t" + String.Format("{0:0.##}", (double)bstoplamRTime / 10) + "\t" + String.Format("{0:0.##}", standartSapmaBul(bsrunTime, bstoplamRTime / 10)) + "\t" + String.Format("{0:0.##}", (double)qstoplamKCompare / 10) + "\t" + String.Format("{0:0.##}", standartSapmaBul(qskeycount, qstoplamKCompare / 10)) + "\t" + String.Format("{0:0.##}", (double)qstoplamRTime / 10) + "\t" + String.Format("{0:0.##}", standartSapmaBul(qsrunTime, qstoplamRTime / 10));
                sortRichText.Text = write;
                dosya.WriteLine(write);

            }
            dosya.Close();
            write = "";
        }
        private void enterExecute()
        {
                StreamWriter dosya = File.CreateText("E:\\output.txt");
                Random r = new Random();
                int arraySize = int.Parse(aSize);
                int[] Array0 = new int[arraySize];
                int[] Array1 = new int[arraySize];
                int[] Array2 = new int[arraySize];
                String write = "";
                //************* Generat Random Numbers ***************	
                int res = 0;
                for (int i = 0; i < arraySize; i++)
                {

                    res = r.Next(0, arraySize);
                    Array0[i] = res;
                    Array1[i] = res;
                    Array2[i] = res;

                }
                //************* Execution Time of BubbleSort *********
                Sorted bubble_srt = new Sorted(new BubbleSort());
                DateTime bsstartTime = DateTime.Now;
                int bskeycount = bubble_srt.sort(Array1, Array1.Length);
                DateTime bsendTime = DateTime.Now;
                sortRichText.Text = "Total elapsed time in execution of method BubbleSort :" + (bsendTime - bsstartTime).TotalMilliseconds + "\n";
                Sorted quick_srt = new Sorted(new QuickSort());
                DateTime qsstartTime = DateTime.Now;
                int qskeycount = quick_srt.sort(Array2, Array2.Length);
                DateTime qsendTime = DateTime.Now;
                sortRichText.Text += "Total elapsed time in execution of QuickSort :" + (qsendTime - qsstartTime).TotalMilliseconds + "\n";
                write = "Algorithm:		BubbleSort		QuickSort\n"
                         + "ArraySize:		" + arraySize + "			" + arraySize + "\n"
                         + "RunningTime(Msn):	" + (bsendTime - bsstartTime).TotalMilliseconds + "			" + (qsendTime - qsstartTime).TotalMilliseconds + "\n"
                         + "No,Key Comparasion:	" + bskeycount + "			" + qskeycount + "\n";
                write = write + "Input		BubbleSort		QuickSort" + "\n";
                for (int i = 0; i < arraySize; i++)
                {
                    write = write + Array0[i] + "\t\t" + Array1[i] + "\t\t\t" + Array2[i] + "\n";
                }
                sortRichText.Text += write;
                dosya.WriteLine(write);
                dosya.Close();
                write = "";

        }
        private double standartSapmaBul(int[] dizi, double ortalama) // Standart Sapma
        {
            double toplam = 0.0;
            for (int i = 0; i < dizi.Length; i++)
                toplam += Math.Pow((dizi[i] - ortalama), 2);
            return Math.Sqrt(toplam / (dizi.Length - 1));
        }
    }
}
