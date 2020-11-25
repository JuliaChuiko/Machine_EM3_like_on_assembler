using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KURSOVAYA_ju
{
    public partial class Form1 : Form
    {
        public int count = 0;
        string[] list = new string[100];
        List<Em3> em3 = new List<Em3>();
        List<Em3> em1 = new List<Em3>();
        public Form1()
        {
            InitializeComponent();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            count += 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            textBox1.AutoSize = false;
            textBox1.Size = new System.Drawing.Size(300, 80);
            int newFontSize = 12;

            FontStyle style = (FontStyle.Regular); //жирный, курсив, подчеркнутый
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, (float)newFontSize, style);
            textBox1.Font= new Font(richTextBox1.Font.FontFamily, (float)newFontSize, style);
            listBox2.Font = new Font(richTextBox1.Font.FontFamily, (float)newFontSize, style);

            

            int i = 0;
            string adress;

            while (i < 100)
            {
                adress = "00" + i;
                //listBox1.Items.Add(adress);
                if (i > 9) { adress = "0" + i; }
                if (i > 99) { adress = "" + i; }
                em3.Insert(i, new Em3() { ADR = adress, KOP = "00", REG1 = "000", REG2 = "000", REG3 = "000" });
                richTextBox1.AppendText(em3[i].ADR + " | ");
                richTextBox1.AppendText(em3[i].KOP + " | ");
                richTextBox1.AppendText(em3[i].REG1 + " | ");
                richTextBox1.AppendText(em3[i].REG2 + " | ");
                richTextBox1.AppendText(em3[i].REG3);
                //richTextBox1.AppendText(em3[i].ADR + " | " + em3[i].KOP + " | " + em3[i].REG1 + " | " + em3[i].REG2 + " | " + em3[i].REG3);
                richTextBox1.AppendText("\n");
                list[i] = em3[i].ADR + " | " + em3[i].KOP + " | " + em3[i].REG1 + " | " + em3[i].REG2 + " | " + em3[i].REG3;
                i += 1;

            }



        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button2.Enabled = true;
            richTextBox1.Clear();
            listBox2.Items.Clear();


            int i = 0;
            string adress;
            while (i < 100)
            {
                adress = "00" + i;
                if (i > 9) { adress = "0" + i; }
                if (i > 99) { adress = "" + i; }
                em3.Add(new Em3() { ADR = adress, KOP = "00", REG1 = "000", REG2 = "000", REG3 = "000" });
                richTextBox1.AppendText(em3[i].ADR + " | ");
                richTextBox1.AppendText(em3[i].KOP + " | ");
                richTextBox1.AppendText(em3[i].REG1 + " | ");
                richTextBox1.AppendText(em3[i].REG2 + " | ");
                richTextBox1.AppendText(em3[i].REG3);
                richTextBox1.AppendText("\n");

                i += 1;

            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           // button2.Enabled = false;
            //string[] ju = textBox1.Text.Split(' ');
            //listBox2.Items.Add(Convert.ToInt32(ju[0])+3);
            string aaa = "000";
            int y = aaa.Length;
            int pos = aaa.LastIndexOf('-');
            
            if (pos != -1) { aaa = aaa.Substring(0, pos); }
            listBox2.Items.Add(aaa);
            listBox2.Items.Add(pos);

            string[] q = new string[5];
            string text = richTextBox1.Text;
            string[] list = new string[100];
            string[] s = text.Split('\n');

            for (int i = 0; i <100; i++)
            {
                string[] em = s[i].Split('|');

                em1.Insert(i, new Em3() { ADR = em[0], KOP = em[1], REG1 = em[2], REG2 = em[3], REG3 = em[4] });
                list[i] = em1[i].ADR + " | " + em1[i].KOP + " | " + em1[i].REG1 + " | " + em1[i].REG2 + " | " + em1[i].REG3;

            }
           Deistvuem(list);

        }
        
        void Deistvuem(string[] em3)
        {
            listBox2.Items.Clear();
            int z = 0;
            int p = 0;
            int w = 0;
            string[] ju = textBox1.Text.Split(' ');
            while (z<em3.Length)
            { 
                string[] em = em3[z].Split('|');               
                int s = Convert.ToInt32(em[1]);
               
                switch (s)
                {

                    case 19:
                        string[] em22 = em3[z - 1].Split('|');
                        int riss = 0;
                        int b22 = Convert.ToInt32(em22[2]);
                        for (int j = 0; j < 100; j++)
                        {
                            string[] em1 = em3[j].Split('|');
                            int k = Convert.ToInt32(em1[0]);
                            if (k ==b22)
                            {
                                int pos = em1[4].LastIndexOf('-');

                                if (pos != -1)
                                {
                                    em1[4] = em1[4].Substring(0, pos);
                                    riss = riss - Convert.ToInt32(em1[4]);
                                    break;
                                }
                                else
                                {
                                    riss = Convert.ToInt32(em1[4]);
                                    break;
                                }

                            }
                        }
                        if (riss > 0)
                        {

                            z = Convert.ToInt32(em[3]) - 1;
                            break;
                        }
                        else if(riss==0)
                        {
                            z = Convert.ToInt32(em[2]) - 1;
                            break;
                        }
                        else if(riss<0)
                        {
                            z = Convert.ToInt32(em[4]) - 1;
                            break;
                        }
                        break;
                    case 9:
                        int h=0;
                        int m=0;
                        for (int j = 0; j < 100; j++)
                        {
                            string[] em1 = em3[j].Split('|');
                            int k = Convert.ToInt32(em1[1]);
                            if (k == 31)
                            {
                                h = 1;
                                m = j;
                                break;
                            }
                        }
                        int u = Convert.ToInt32(em[3]);
                        if (h==0 || u<m)
                        {                            
                            z = u - 1;
                          
                        }
                        else
                        {
                            listBox2.Items.Add("В команде 09 ошибка");
                        }
                        break;
                    case 15:

                        if (Convert.ToInt32(em[2]) < 100 && Convert.ToInt32(em[3]) < 100 && Convert.ToInt32(em[4]) < 100)
                        {
                            int result = 0;
                            int res1 = 0;
                            int res2 = 0;

                            int z1 = Convert.ToInt32(em[3]);
                            int z2 = Convert.ToInt32(em[4]);
                            for (int i = 0; i < 100; i++)
                            {
                                string[] em1 = em3[i].Split('|');
                                int k = Convert.ToInt32(em1[0]);
                                if (k == z1)
                                {
                                    int pos = em1[4].LastIndexOf('-');

                                    if (pos != -1)
                                    {
                                        em1[4] = em1[4].Substring(0, pos);
                                        res1 = res1 - Convert.ToInt32(em1[4]);
                                    }
                                    else { res1 = Convert.ToInt32(em1[4]); }
                                }
                                if (k == z2)
                                {
                                    int pos = em1[4].LastIndexOf('-');

                                    if (pos != -1)
                                    {
                                        em1[4] = em1[4].Substring(0, pos);
                                        res2 = -Convert.ToInt32(em1[4]);
                                    }
                                    else { res2 = Convert.ToInt32(em1[4]); }
                                }
                            }

                            result = res1 % res2;

                            int r = Convert.ToInt32(em[2]);
                            for (int j = 0; j < 100; j++)
                            {
                                string[] em1 = em3[j].Split('|');
                                int k = Convert.ToInt32(em1[0]);
                                if (k == r)
                                {

                                    int gg = Math.Abs(result);
                                    if (result < 10 && result >= 0) { em1[4] = "  00" + Convert.ToString(result); }
                                    else if (result < 100 && result >= 0) { em1[4] = "  0" + Convert.ToString(result); }
                                    else if (result < 1000 && result >= 0) { em1[4] = "  " + Convert.ToString(result); }
                                    else if (result < 10 && result < 0) { em1[4] = "  00" + Convert.ToString(gg) + "-"; }
                                    else if (result < 100 && result < 0) { em1[4] = "  0" + Convert.ToString(gg) + "-"; }
                                    else if (result < 1000 && result < 0) { em1[4] = "  " + Convert.ToString(gg) + "-"; }
                                    //else { listBox2.Items.Add("Введенное число превышает норму"); return; }
                                    string q = string.Join("|", em1);
                                    em3[j] = q;
                                    break;
                                }

                            }
                            break;
                        }

                        else
                        {
                            listBox2.Items.Add("Введенные данные некорректны"); return;
                        }
                    case 16:
                      if(Convert.ToInt32(em[3])>1 && Convert.ToInt32(em[4]) == 0 && Convert.ToInt32(em[3]) <=ju.Length)
                        {
                            int resultat=0;
                            int kk = Convert.ToInt32(em[2]);
                            for (int j = 0; j < 100; j++)
                            {
                                string[] em1 = em3[j].Split('|');
                                int k1 = Convert.ToInt32(em1[0]);
                                if (resultat < Convert.ToInt32(em[3]))
                                {
                                    int a1 = Convert.ToInt32(ju[resultat]);
                                    if (k1==kk)
                                    {
                                        int W2 = Math.Abs(a1);
                                        if (a1 < 10 && a1 >= 0) { em1[4] = "  00" + a1; }
                                        else if (a1 < 100 && a1 >= 0) { em1[4] = "  0" + a1; }
                                        else if (a1 < 1000 && a1 >= 0) { em1[4] = "  " + a1; }
                                        else if (a1 < 10 && a1 < 0) { em1[4] = "  00" + W2 + "-"; }
                                        else if (a1 < 100 && a1 < 0) { em1[4] = "  0" + W2 + "-"; }
                                        else if (a1 < 1000 && a1 < 0) { em1[4] = "  " + W2 + "-"; }
                                        else { listBox2.Items.Add("Введенное число превышает норму"); return; }
                                        string q = string.Join("|", em1);
                                        em3[j] = q;
                                        resultat += 1;
                                        kk += 1;
                                        w += 1;
                                    }
                                }
                                
                                

                            }
                            break;
                        }
                        else if (Convert.ToInt32(em[3]) == 1 && Convert.ToInt32(em[4]) == 0)
                        {
                            if (w < ju.Length)
                            {
                               
                                int a1 = Convert.ToInt32(ju[w]);
                                //listBox2.Items.Add(a1);
                                int g = Convert.ToInt32(em[2]);

                               
                               for (int j = 0; j < 100; j++)
                               {
                                   string[] em1 = em3[j].Split('|');
                                   int k = Convert.ToInt32(em1[0]);
                                   if (k == g)
                                   {
                                       int a2=Math.Abs(a1);
                                       if (a1 < 10 && a1>=0) { em1[4] = "  00" + a1; }
                                       else if (a1 < 100 && a1 >= 0) { em1[4] = "  0" + a1; }
                                       else if (a1 < 1000 && a1 >= 0) { em1[4] = "  " + a1; }
                                       else if (a1 < 10 && a1 < 0) { em1[4] = "  00" + a2+"-"; }
                                       else if (a1 < 100 && a1 < 0) { em1[4] = "  0" + a2 + "-";  }
                                       else if (a1 < 1000 && a1 < 0) { em1[4] = "  " + a2 + "-";  }
                                       else { listBox2.Items.Add("Введенное число превышает норму");return; }
                                       string q = string.Join("|", em1);
                                       em3[j] = q;
                                       break;
                                   }

                               }
                                w += 1;
                            }
                            break;
                        }
                        else
                        {
                            listBox2.Items.Add("В команде 16 ошибка"); return;
                           
                        }
                    case 17:
                        if (Convert.ToInt32(em[3]) == 1)
                        {
                            int ress=0;
                            int y = Convert.ToInt32(em[2]);
                            for (int j = 0; j < 100; j++)
                            {
                                string[] em1 = em3[j].Split('|');
                                int k = Convert.ToInt32(em1[0]);
                                if (k == y)
                                {
                                    int pos = em1[4].LastIndexOf('-');

                                    if (pos != -1)
                                    {
                                        em1[4] = em1[4].Substring(0, pos);
                                        ress= ress - Convert.ToInt32(em1[4]);
                                    }
                                    else { ress = Convert.ToInt32(em1[4]); }
                                                                   
                                    break;
                                }

                            }
                            listBox2.Items.Add(ress);
                            break;
                        }
                        else
                        {
                            listBox2.Items.Add("В команде 17 ошибка"); return;
                        }


                    case 31:
                        
                        richTextBox1.Clear();
                        foreach (string l in em3)
                        {
                            richTextBox1.AppendText(l + "\n");

                        }
                        return ;
                        
                    case 0:
                        if (em[2] != "000" || em[4]!= "000")
                        {
                            int z1 = Convert.ToInt32(em[2]);
                            int r = Convert.ToInt32(em[4]);
                            int res=0;
                            for (int j = 0; j < 100; j++)
                            {
                                string[] em1 = em3[j].Split('|');
                                int k = Convert.ToInt32(em1[0]);
                                if (k == r)
                                {
                                    res = Convert.ToInt32(em1[4]);
                                }
                            }
                            for (int j = 0; j < 100; j++)
                            {
                                string[] em1 = em3[j].Split('|');
                                int k = Convert.ToInt32(em1[0]);
                                if (k == z1)
                                {

                                    if (res < 10) { em1[4] = "  00" + res; }
                                    else if (res < 100) { em1[4] = "  0" + res; }
                                    else if (res < 1000) { em1[4] = "  " + res; }
                                    //else { listBox2.Items.Add("Введенное число превышает норму"); return; }
                                    string q = string.Join("|", em1);
                                    em3[j] = q;
                                    break;
                                }

                            }
                        }
                        richTextBox1.Clear();
                        foreach (string l in em3)
                        {
                            richTextBox1.AppendText(l + "\n");

                        }
                        break;
                    case 11:
                        if (Convert.ToInt32(em[2]) < 100 && Convert.ToInt32(em[3]) < 100 && Convert.ToInt32(em[4]) < 100)
                        {
                            int result = 0;
                            int res1 = 0;
                            int res2 = 0;
                            int flag = 0;
                            int min, max;
                            int z1 = Convert.ToInt32(em[3]);
                            int z2 = Convert.ToInt32(em[4]);
                            if (z1 > z2) { max = z1; min = z2; }
                            else { max = z2; min = z1; }
                            for (int i = 0; i < 100; i++)
                            {
                                string[] em1 = em3[i].Split('|');
                                int k = Convert.ToInt32(em1[0]);
                                if (k == max)
                                {
                                    if (flag == 1 || (Convert.ToInt32(em1[1]) == 0 && Convert.ToInt32(em1[2]) == 0 && Convert.ToInt32(em1[3]) != 0 && Convert.ToInt32(em1[4]) == 0))
                                    {
                                        flag = 1;
                                        res1 = Convert.ToInt32(em1[3]);
                                    }
                                    else
                                    {
                                        int pos = em1[4].LastIndexOf('-');

                                        if (pos != -1)
                                        {
                                            em1[4] = em1[4].Substring(0, pos);
                                            res1 = res1 - Convert.ToInt32(em1[4]);
                                        }
                                        else { res1 = Convert.ToInt32(em1[4]); }
                                    }

                                }
                            }
                            for (int i = 0; i < 100; i++)
                            {
                                string[] em1 = em3[i].Split('|');
                                int k = Convert.ToInt32(em1[0]);
                                if (k == min)
                                {
                                    if (flag==1 || (Convert.ToInt32(em1[1]) == 0 && Convert.ToInt32(em1[2]) == 0 && Convert.ToInt32(em1[3]) != 0 && Convert.ToInt32(em1[4]) == 0))
                                    {
                                        res2 = Convert.ToInt32(em1[3]);
                                        flag = 1;
                                    }
                                    else
                                    {
                                    int pos = em1[4].LastIndexOf('-');
                                    
                                    if (pos != -1)
                                    {
                                        em1[4] = em1[4].Substring(0, pos);
                                        res2 = - Convert.ToInt32(em1[4]);
                                    }
                                    else { res2 = Convert.ToInt32(em1[4]); }
                                    }
                                    
                                }
                            }
                            
                            result = res1 + res2;

                            int r = Convert.ToInt32(em[2]);
                            for (int j = 0; j < 100; j++)
                            {
                                string[] em1 = em3[j].Split('|');
                                int k = Convert.ToInt32(em1[0]);
                                if (k == r)
                                {
                                    if (flag == 1)
                                    {
                                        int gg = Math.Abs(result);
                                        if (result < 10 && result >= 0) { em1[3] = "  00" + Convert.ToString(result)+"  "; }
                                        else if (result < 100 && result >= 0) { em1[3] = "  0" + Convert.ToString(result) + "  "; }
                                        else if (result < 1000 && result >= 0) { em1[3] = "  " + Convert.ToString(result) + "  "; }
                                        else if (result < 10000 && result >= 0) { em1[3] = "" + Convert.ToString(result) + "  "; }
                                        else if (result < 10 && result < 0) { em1[3] = "  00" + Convert.ToString(gg) + "-" + "  "; }
                                        else if (result < 100 && result < 0) { em1[3] = "  0" + Convert.ToString(gg) + "-" + "  "; }
                                        else if (result < 1000 && result < 0) { em1[3] = "  " + Convert.ToString(gg) + "-" + "  "; }
                                        else if (result < 10000 && result < 0) { em1[3] = "" + Convert.ToString(gg) + "  "; }
                                        // else { listBox2.Items.Add("Введенное число превышает норму"); return; }
                                        string q = string.Join("|", em1);
                                        em3[j] = q;
                                        break;
                                    }
                                    else
                                    {
                                    int gg = Math.Abs(result);
                                    if (result < 10 && result >= 0) { em1[4] = "  00" + Convert.ToString(result); }
                                    else if (result < 100 && result >= 0) { em1[4] = "  0" + Convert.ToString(result); }
                                    else if (result < 1000 && result >= 0) { em1[4] = "  " + Convert.ToString(result); }
                                    else if (result < 10000 && result >= 0) { em1[4] = "" + Convert.ToString(result) + "  "; }
                                    else if (result < 10 && result < 0) { em1[4] = "  00" + Convert.ToString(gg)+"-"; }
                                    else if (result < 100 && result < 0) { em1[4] = "  0" + Convert.ToString(gg) + "-"; }
                                    else if (result < 1000 && result < 0) { em1[4] = "  " + Convert.ToString(gg) + "-"; }
                                    else if (result < 10000 && result <0) { em1[4] = "" + Convert.ToString(gg) + "  "; }
                                    // else { listBox2.Items.Add("Введенное число превышает норму"); return; }
                                    string q = string.Join("|", em1);
                                    em3[j] = q;
                                    break;
                                    }
                                    
                                }

                            }
                            break;
                        }
                        else
                        {
                            listBox2.Items.Add("Введенные данные некорректны"); return;
                        }

                    case 12:

                        if (Convert.ToInt32(em[2]) < 100 && Convert.ToInt32(em[3]) < 100 && Convert.ToInt32(em[4]) < 100)
                        {
                            int result = 0;
                            int res1 = 0;
                            int res2 = 0;

                            int z1 = Convert.ToInt32(em[3]);
                            int z2 = Convert.ToInt32(em[4]);
                            for (int i = 0; i < 100; i++)
                            {
                                string[] em1 = em3[i].Split('|');
                                int k = Convert.ToInt32(em1[0]);
                                if (k == z1)
                                {
                                    int pos = em1[4].LastIndexOf('-');

                                    if (pos != -1)
                                    {
                                        em1[4] = em1[4].Substring(0, pos);
                                        res1 = res1 - Convert.ToInt32(em1[4]);
                                    }
                                    else { res1 = Convert.ToInt32(em1[4]); }
                                }
                                if (k == z2)
                                {
                                    int pos = em1[4].LastIndexOf('-');

                                    if (pos != -1)
                                    {
                                        em1[4] = em1[4].Substring(0, pos);
                                        res2 = -Convert.ToInt32(em1[4]);
                                    }
                                    else { res2 = Convert.ToInt32(em1[4]); }
                                }
                            }

                            result = res1 - res2;

                            int r = Convert.ToInt32(em[2]);
                            for (int j = 0; j < 100; j++)
                            {
                                string[] em1 = em3[j].Split('|');
                                int k = Convert.ToInt32(em1[0]);
                                if (k == r)
                                {

                                    int gg = Math.Abs(result);
                                    if (result < 10 && result >= 0) { em1[4] = "  00" + Convert.ToString(result)+"  "; }
                                    else if (result < 100 && result >= 0) { em1[4] = "  0" + Convert.ToString(result)+"  "; }
                                    else if (result < 1000 && result >= 0) { em1[4] = "  " + Convert.ToString(result)+"  "; }
                                    else if (result < 10000 && result >= 0) { em1[4] = "" + Convert.ToString(result) + "  "; }
                                    else if (result < 10 && result < 0) { em1[4] = "  00" + Convert.ToString(gg) + "-"; }
                                    else if (result < 100 && result < 0) { em1[4] = "  0" + Convert.ToString(gg) + "-"; }
                                    else if (result < 1000 && result < 0) { em1[4] = "  " + Convert.ToString(gg) + "-"; }
                                    else if (result < 10000 && result < 0) { em1[4] = "" + Convert.ToString(gg) + "  "; }
                                    //else { listBox2.Items.Add("Введенное число превышает норму"); return; }
                                    string q = string.Join("|", em1);
                                    em3[j] = q;
                                    break;
                                }

                            }
                            break;
                        }                      
                      
                        else
                        {
                            listBox2.Items.Add("Введенные данные некорректны"); return;
                        }
                    case 13:
                        if (Convert.ToInt32(em[2]) < 100 && Convert.ToInt32(em[3]) < 100 && Convert.ToInt32(em[4]) < 100)
                        {
                            int result = 0;
                            int res1 = 0;
                            int res2 = 0;

                            int z1 = Convert.ToInt32(em[3]);
                            int z2 = Convert.ToInt32(em[4]);
                            for (int i = 0; i < 100; i++)
                            {
                                string[] em1 = em3[i].Split('|');
                                int k = Convert.ToInt32(em1[0]);
                                if (k == z1)
                                {
                                    int pos = em1[4].LastIndexOf('-');

                                    if (pos != -1)
                                    {
                                        em1[4] = em1[4].Substring(0, pos);
                                        res1 = res1 - Convert.ToInt32(em1[4]);
                                    }
                                    else { res1 = Convert.ToInt32(em1[4]); }
                                }
                                if (k == z2)
                                {
                                    int pos = em1[4].LastIndexOf('-');

                                    if (pos != -1)
                                    {
                                        em1[4] = em1[4].Substring(0, pos);
                                        res2 = -Convert.ToInt32(em1[4]);
                                    }
                                    else { res2 = Convert.ToInt32(em1[4]); }
                                }
                            }

                            result = res1 * res2;

                            int r = Convert.ToInt32(em[2]);
                            for (int j = 0; j < 100; j++)
                            {
                                string[] em1 = em3[j].Split('|');
                                int k = Convert.ToInt32(em1[0]);
                                if (k == r)
                                {

                                    int gg = Math.Abs(result);
                                    if (result < 10 && result >= 0) { em1[4] = "  00" + Convert.ToString(result) + "  "; }
                                    else if (result < 100 && result >= 0) { em1[4] = "  0" + Convert.ToString(result) + "  "; }
                                    else if (result < 1000 && result >= 0) { em1[4] = "  " + Convert.ToString(result) + "  "; }
                                    else if (result < 10000 && result >= 0) { em1[4] = "" + Convert.ToString(result) + "  "; }
                                    else if (result < 10 && result < 0) { em1[4] = "  00" + Convert.ToString(gg) + "-"; }
                                    else if (result < 100 && result < 0) { em1[4] = "  0" + Convert.ToString(gg) + "-"; }
                                    else if (result < 1000 && result < 0) { em1[4] = "  " + Convert.ToString(gg) + "-"; }
                                    else if (result < 10000 && result < 0) { em1[4] = "" + Convert.ToString(gg) + "  "; }
                                    ///else { listBox2.Items.Add("Введенное число превышает норму"); return; }
                                    string q = string.Join("|", em1);
                                    em3[j] = q;
                                    break;
                                }

                            } break;
                        }
                        else
                        {
                            listBox2.Items.Add("Введенные данные некорректны"); return;
                        }

                    case 14://em[2]!="000")
                        if (Convert.ToInt32(em[2])<100 && Convert.ToInt32(em[3]) < 100 && Convert.ToInt32(em[4]) < 100 )
                        {
                            int result = 0;
                            int res1 = 0;
                            int res2 = 0;

                            int z1 = Convert.ToInt32(em[3]);
                            int z2 = Convert.ToInt32(em[4]);
                            for (int i = 0; i < 100; i++)
                            {
                                string[] em1 = em3[i].Split('|');
                                int k = Convert.ToInt32(em1[0]);
                                if (k == z1)
                                {
                                    int pos = em1[4].LastIndexOf('-');

                                    if (pos != -1)
                                    {
                                        em1[4] = em1[4].Substring(0, pos);
                                        res1 = res1 - Convert.ToInt32(em1[4]);
                                    }
                                    else { res1 = Convert.ToInt32(em1[4]); }
                                }
                                if (k == z2)
                                {
                                    int pos = em1[4].LastIndexOf('-');

                                    if (pos != -1)
                                    {
                                        em1[4] = em1[4].Substring(0, pos);
                                        res2 = -Convert.ToInt32(em1[4]);
                                    }
                                    else { res2 = Convert.ToInt32(em1[4]); }
                                }
                            }
                            if (res2 == 0) { listBox2.Items.Add("На ноль делить нельзя"); return; }
                            result = res1 / res2;

                            int r = Convert.ToInt32(em[2]);
                            for (int j = 0; j < 100; j++)
                            {
                                string[] em1 = em3[j].Split('|');
                                int k = Convert.ToInt32(em1[0]);
                                if (k == r)
                                {

                                    int gg = Math.Abs(result);
                                    if (result < 10 && result >= 0) { em1[4] = "  00" + Convert.ToString(result) + "  "; }
                                    else if (result < 100 && result >= 0) { em1[4] = "  0" + Convert.ToString(result) + "  "; }
                                    else if (result < 1000 && result >= 0) { em1[4] = "  " + Convert.ToString(result)+"  "; }
                                    else if (result < 10000 && result >= 0) { em1[4] = "" + Convert.ToString(result) + "  "; }
                                    else if (result < 10 && result < 0) { em1[4] = "  00" + Convert.ToString(gg) + "-"; }
                                    else if (result < 100 && result < 0) { em1[4] = "  0" + Convert.ToString(gg) + "-"; }
                                    else if (result < 1000 && result < 0) { em1[4] = "  " + Convert.ToString(gg) + "-"; }
                                    else if (result < 10000 && result < 0) { em1[4] = "" + Convert.ToString(gg) + "  "; }
                                    //else { listBox2.Items.Add("Введенное число превышает норму"); return; }
                                    string q = string.Join("|", em1);
                                    em3[j] = q;
                                    break;
                                }

                            }
                         break;
                        }
                        else
                        {
                            listBox2.Items.Add("Введенные данные некорректны"); return;
                        }
                    case 22:
                        string[] em2 = em3[z - 1].Split('|');
                        int ris = 0;
                        int a22 = Convert.ToInt32(em2[2]);
                        for (int j = 0; j < 100; j++)
                        {
                            string[] em1 = em3[j].Split('|');
                            int k = Convert.ToInt32(em1[0]);
                            if (k == a22)
                            {
                                int pos = em1[4].LastIndexOf('-');

                                if (pos != -1)
                                {
                                    em1[4] = em1[4].Substring(0, pos);
                                    ris = ris - Convert.ToInt32(em1[4]);
                                    break;
                                }
                                else
                                {
                                    ris = Convert.ToInt32(em1[4]);
                                    break;
                                }

                            }
                        }
                        if (ris > 0)
                        {
                           
                            z = Convert.ToInt32(em[3]) - 1;
                            break; 
                        }
                        break;


                    default:
                        richTextBox1.Clear();
                        foreach (string l in em3)
                        {
                            richTextBox1.AppendText(l + "\n");

                        }
                        
                        break;
                    
                }

                z += 1;


            }
            richTextBox1.Clear();
                foreach (string l in em3)
                {
                    richTextBox1.AppendText(l + "\n");

                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
