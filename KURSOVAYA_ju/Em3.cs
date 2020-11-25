using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KURSOVAYA_ju
{
    class Em3
    {
        //List<Em3> em1 = new List<Em3>();
        public static string kop;

        public static string adr;

        public static string reg1;

        public static string reg2;

        public static string reg3;
        public  string KOP
        {
            get { return kop; }
            set {kop = value; }
        }
        public string ADR
        {
            get { return adr; }
            set { adr = value; }
        }
        public  string REG1
        {
            get { return reg1; }
            set { reg1 = value; }
        }
        public  string REG2
        {
            get { return reg2; }
            set { reg2=value; }
        }
        public  string REG3
        {
            get { return reg3; }
            set { reg3 = value; }
        }
        public int slozenie(string reg1, string reg2, string reg3)
        {
            int result = 0;



            return result;
        }
        public void deistvuem(string adr,string kop,string reg1, string reg2, string reg3)
        {
            string c = kop;
            switch(c)
            {
                case "01":
                    if(reg1!=null && reg2 != null && reg3 != null )
                    {
                        slozenie(reg1,reg2,reg3);
                    }
                    break;
            }
        }
    }
}
