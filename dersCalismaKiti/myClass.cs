using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.IO;
namespace dersCalismaKiti
{
    class library: fileClass
    {
        public string bookName;
        public int totalPages;
        //public int howManyDays;
        public string bookTpye;
        public string strStartReadingDate;
        public string strStopReadingDate;
        public string libFilePath = @" D:\C# Projeleri\dersCalismaKiti\LibraryDataBase.txt";
        public string libFilePathİnfo = @" D:\C# Projeleri\dersCalismaKiti\LibraryİnfoDataBase.txt";
        public bool flag = false;
        int sayac = 1;
        public ArrayList MyList = new ArrayList();

        public int howManyDaysProccess()
        {
            DateTime baslamaTarihi = new DateTime(2020, 07, 15);
            DateTime bitisTarihi = new DateTime(2020, 07, 25);

            DateTime bTarih =Convert.ToDateTime(strStartReadingDate);
            DateTime kTarih =Convert.ToDateTime(strStopReadingDate);
            TimeSpan Sonuc = kTarih - bTarih;
            double toplamGun = Sonuc.TotalDays;
            return Convert.ToInt32(toplamGun);
        }
        public int avarageReadPageProccess()
        {
            try
            {
                return totalPages / Convert.ToInt32(howManyDaysProccess());
            }
            catch
            {
                return 0;
            }
        }
        public library()
        {
            FileStream dt = new FileStream(libFilePathİnfo, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(dt);
            string text = sr.ReadLine();
            while (text != null)
            {
                //MessageBox.Show(text.ToString());
                MyList.Add(text);
                text = sr.ReadLine();
            }
            dt.Close();
            try
            {
                bookName = MyList[0].ToString();
                totalPages = Convert.ToInt32(MyList[1]);
                bookTpye = MyList[2].ToString();
                strStartReadingDate = MyList[3].ToString();
            }
            catch(Exception)
            {

            }
           
        }
        public ArrayList getListFromFile()
        {
            return MyList;
        }
        public void libFileProccesİnfoWrite(string fileWay)
        {
            FileStream fs = new FileStream(fileWay, FileMode.OpenOrCreate, FileAccess.ReadWrite);


            StreamWriter sw = new StreamWriter(fs);

            StreamReader sr = new StreamReader(fs);
            sw.WriteLine(bookName);
            sw.WriteLine(totalPages);
            sw.WriteLine(bookTpye);
            sw.WriteLine(strStartReadingDate);
            sw.Flush();
            fs.Close();
        }
        public void libFileProccesİnfoRead(string fileWay)
        {
            FileStream fs = new FileStream(fileWay, FileMode.Open, FileAccess.ReadWrite);


            StreamWriter sw = new StreamWriter(fs);

            StreamReader sr = new StreamReader(fs);
            string text = "";
            while (text != null)
            {
                MyList.Add(text);
                text = sr.ReadLine();
            }
            sw.Flush();
            fs.Close();
            
        }

        public void libFileProccesRead(string fileWay)
            {//33
            FileStream fs = new FileStream(fileWay, FileMode.Open, FileAccess.ReadWrite);


            StreamWriter sw = new StreamWriter(fs);

            StreamReader sr = new StreamReader(fs);
            int sayac=0;
            string strLine = "";
            int count2 = -3;
            
            while (strLine != null)
            {
                strLine = sr.ReadLine();
                sayac++;
                if (count2 > 2)
                {
                    if (sayac % 2 == 0)
                    {
                        count2++;
                       
                    }
                }
                else if(count2==2)
                {
                   
                        count2++;
                    
                }
                else if(count2 < 2)
                {
                    count2++;
                }

                
                if (strLine == "#")
                {    
                    if (count2 < 10)
                        sw.Write("0"+ count2 + "|");
                    else
                        sw.Write(count2 + "|");
                    
                }
               

            }


          
                sw.Write(strStartReadingDate + " - ");
                sw.Write(strStopReadingDate + "|");
                sw.Write(bookName.ToUpper());
         
            for (int i = 0; i < libEmptyValueProccess(bookName); i++)
            {
                sw.Write(" ");
            }
            sw.Write("|");
            sw.Write(bookTpye.ToUpper());
            for (int i = 0; i < libEmptyValueProccess(bookTpye); i++)
            {
                sw.Write(" ");
            }
            sw.Write("|");
            sw.Write(howManyDaysProccess());//Ne kadar zamanda

            for (int i = 0; i < libEmptyValueProccess(howManyDaysProccess().ToString()); i++)
            {
                sw.Write(" ");
            }
            sw.Write("|");
            sw.Write(totalPages);
            for (int i = 0; i < libEmptyValueProccess(totalPages.ToString()); i++)
            {
                sw.Write(" ");
            }
            sw.Write("|");
            sw.Write(avarageReadPageProccess());//ortalama günlük okunan sayfa sayısı
            for (int i = 0; i < libEmptyValueProccess(avarageReadPageProccess().ToString()); i++)
            {
                sw.Write(" ");
            }
            sw.WriteLine("|");
            sw.WriteLine("-- |-----------------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|------------------------------|");
            sw.Write("#");
            sw.Flush();
            fs.Close();

        }
        
        public int libEmptyValueProccess(string a)
        {
            
                return 30 - a.Length ;
            
        }
    }
    class stopWatchMachine
    {
       
        public int howManyHours;
        public int minute = 0, second = 1, hour = 0;
        public int cdHour = 0, cdMinute = 59, cdSecond = 60;
        public int countBreaks = 0;
        int totalSec = 0, totalMin = 0, totalHour;
        public string totalBreaks(int tSec, int tMin, int tHour)
        {//55 + 30 1 tam 25
            totalSec += tSec;
            totalMin += tMin;
            totalHour += tHour;


            if (totalSec > 60)
            {
                totalSec = totalSec % 60;
                totalMin++;
            }
            if (totalMin > 60)
            {
                totalMin = totalMin % 60;
                totalHour++;
            }
            return Convert.ToString(addTheZero(totalHour)) + ":" + Convert.ToString(addTheZero(totalMin)) + ":" + Convert.ToString(addTheZero(totalSec));

        }
        public string stopWatchPast()
        {
            increaseTheSeconds();
            return Convert.ToString(addTheZero(hour)) + ":" + Convert.ToString(addTheZero(minute)) + ":" + Convert.ToString(addTheZero(second));
        }

        public string stopWatchRemaining()
        {
            decreaseTheSeconds();
            return Convert.ToString(addTheZero(cdHour)) + ":" + Convert.ToString(addTheZero(cdMinute)) + ":" + Convert.ToString(addTheZero(cdSecond));

        }
        public string startTheBreak()
        {

            increaseTheSeconds();
            return Convert.ToString(addTheZero(hour)) + ":" + Convert.ToString(addTheZero(minute)) + ":" + Convert.ToString(addTheZero(second));
        }



        public void decreaseTheSeconds()
        {
            cdSecond--;
            if (cdSecond == 0)
            {
                cdSecond = 59;
                cdMinute--;
            }
            if (cdMinute == 0)
            {
                cdMinute = 59;

                if(cdHour==1)
                    cdHour = 0;
                else
                    cdHour = 1;
            }

        }
        public void increaseTheSeconds()
        {
            second++;
            if (second == 60)
            {
                second = 0;
                minute++;
            }
            if (minute == 60)
            {
                minute = 0;
                hour = 1;
            }

        }
        public string addTheZero(int num)
        {
            string val = "";
            if (num < 10)
            {
                val = "0" + num;
            }
            else
                val = num.ToString();
            return val;
        }


    }
    class fileClass:stopWatchMachine
    {
        public string totalBreakStr;
        public string passingTimeStr;
        public string dateStart;
        public string dateEnd;
        public string subject;
        public string part;
        public string forWhat;
        public string filePath = @"D:\C# Projeleri\dersCalismaKiti\WorkDataBase.txt";

      
        public void fileProccesRead(string fileWay)
        {//33
            FileStream fs = new FileStream(fileWay, FileMode.Open, FileAccess.ReadWrite);
            
            
            StreamWriter sw = new StreamWriter(fs);

            StreamReader sr = new StreamReader(fs);
            int count = -3;
            int sayac1 = 0;
            string strLine = "";

            while (strLine != null)
            {
                strLine = sr.ReadLine();
                sayac1++;
                if (count > 2)
                {
                    if (sayac1 % 2 == 0)
                    {
                        count++;

                    }
                }
                else if (count == 2)
                {

                    count++;
               
                }
                else if (count < 2)
                {
                    count++;
                }


                if (strLine == "#")
                {
                    if (count < 10)
                        sw.Write("0" + count + "|");
                    else
                        sw.Write(count + "|");

                }


            }

            try
            {
                sw.Write(dateStart + " - ");
                sw.Write(dateEnd + "|");
                sw.Write(subject.ToUpper() + "/" + part.ToUpper());
            }
            catch (Exception)
            {

            }
            for(int i=1;i< emptyValueProccess(subject,part); i++)
            {
                sw.Write(" ");
            }
            sw.Write("|");
            sw.Write(forWhat.ToUpper());
            for (int i = 0; i < emptyValueProccess(forWhat,""); i++)
            {
                sw.Write(" ");
            }
            sw.Write("|");
            sw.Write(passingTimeStr);
            
            for (int i = 0; i < emptyValueProccess(passingTimeStr, ""); i++)
            {
                sw.Write(" ");
            }
            sw.Write("|");
            sw.Write(totalBreakStr);
            for (int i = 0; i < emptyValueProccess(totalBreakStr, ""); i++)
            {
                sw.Write(" ");
            }
            sw.WriteLine("|");
            sw.WriteLine("-- |-----------------------------------------|-----------------------------------|-----------------------------------|-----------------------------------|-----------------------------------|");
            sw.Write("#");
            sw.Flush();
            fs.Close();

          
        }
        public int emptyValueProccess(string a,string b)
        {
            return 35 - (a.Length + b.Length);
        }
        public DateTime dateProccessStart()
        {
            DateTime startWorkTime = DateTime.Now;
            return startWorkTime;
        }
        public DateTime dateProccessEnd()
        {
            DateTime endWorkTime = DateTime.Now;
            return endWorkTime;
        }
    }
}
