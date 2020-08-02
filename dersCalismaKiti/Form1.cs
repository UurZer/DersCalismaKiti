using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
namespace dersCalismaKiti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ArrayList getTheInfo = new ArrayList();
        private void Form1_Load(object sender, EventArgs e)
        {
            library getTheList = new library();
            getTheInfo = getTheList.getListFromFile();
            clearLabelText(totalBreaksLabel);
            stopWatch.Interval = 1000;
            countDown.Interval = 1000;
            stopWatchBreak.Interval = 1000;
            try
            {
            if (getTheInfo[1] != null)
            {
                
                startTheRead.Visible = false;
                stopTheRead.Visible = true;

                libVar.strStopReadingDate = libVar.dateProccessEnd().ToString();
               
                howManyDaysLabel.Text = libVar.howManyDaysProccess().ToString() + "  Gündür";
              }

            }
            catch(Exception)
            {
                startTheRead.Visible = false;
                stopTheRead.Visible = true;
                libVar.strStopReadingDate = libVar.dateProccessEnd().ToString();
                howManyDaysLabel.Text = "0" + "  Gündür";

            }
           
           
                
                
            
            try
            {
                readingLabel.Text = getTheInfo[0].ToString();
                startingDateLabel.Text = getTheInfo[3].ToString();
                
            }

            catch (Exception)
            {
                startTheRead.Visible = true;
                stopTheRead.Visible = false;
           
            }
            
        }
        fileClass varForFile = new fileClass();
        fileClass dateVar = new fileClass();
        fileClass dateVar2 = new fileClass();
        
        stopWatchMachine swVar = new stopWatchMachine();
        stopWatchMachine swVar2 = new stopWatchMachine();
        stopWatchMachine breakVar = new stopWatchMachine();
        stopWatchMachine totalBreakVar = new stopWatchMachine();

        library libVar = new library();

        private void subjectTextbox_OnValueChanged(object sender, EventArgs e)
        {
            varForFile.subject = subjectTextbox.Text;


        }

        private void partTextbox_OnValueChanged(object sender, EventArgs e)
        {
            varForFile.part = partTextbox.Text;
        }




        private void startButton_Click(object sender, EventArgs e)
        {
            varForFile.dateStart= varForFile.dateProccessStart().ToString();
            swVar2.howManyHours = Convert.ToInt32(hoursTextbox.Text);
            swVar2.cdHour = swVar2.howManyHours - 1;
            stopWatch.Start();
            countDown.Start();
        }



 

        private void stopWatch_Tick(object sender, EventArgs e)
        {
            passingTimeLabel.Text = swVar.stopWatchPast();

        }

        private void countDown_Tick(object sender, EventArgs e)
        {
            remainingTimeLabel.Text = swVar2.stopWatchRemaining();
        }


        private void stopWatchBreak_Tick(object sender, EventArgs e)
        {
            passingTimeBreakLabel.Text = breakVar.startTheBreak();

        }

        private void startBreakButton_Click(object sender, EventArgs e)
        {
            stopWatchBreak.Start();
            stopWatch.Stop();
            countDown.Stop();
            breakVar.hour = 0;
            breakVar.minute = 0;
            breakVar.second = 0;
        }

        private void stopBreakButton_Click(object sender, EventArgs e)
        {
            clearLabelText(passingTimeBreakLabel);
            stopWatch.Start();
            countDown.Start();
            stopWatchBreak.Stop();
            totalBreaksLabel.Text = totalBreakVar.totalBreaks(breakVar.second, breakVar.minute, breakVar.hour);
           
        }

        public void clearLabelText(Label a)
        {
            a.Text = "00:00:00";
        }

        private void endTheWork_Click(object sender ,EventArgs e)
        {
            varForFile.totalBreakStr = totalBreaksLabel.Text;

            varForFile.passingTimeStr = passingTimeLabel.Text;
            stopWatch.Stop();
            countDown.Stop();
            varForFile.dateEnd= varForFile.dateProccessEnd().ToString();
            varForFile.fileProccesRead(varForFile.filePath);
        }

        private void forWhatTextBox_OnValueChanged(object sender, EventArgs e)
        {
            varForFile.forWhat = forWhatTextBox.Text;
        }

        private void startTheRead_Click(object sender, EventArgs e)
        {
            libVar.bookName = bookNameTextbox.Text;
            libVar.bookTpye = bookTypeTextbox.Text;
            libVar.totalPages = Convert.ToInt32(totalPagesTextbox.Text);
            readingLabel.Text = libVar.bookName;
            startingDateLabel.Text = libVar.dateProccessStart().ToString();
            libVar.strStartReadingDate = libVar.dateProccessStart().ToString();

            libVar.libFileProccesİnfoWrite(libVar.libFilePathİnfo);
            startTheRead.Visible = false;
            stopTheRead.Visible = true;
        }
        //Tarih ve kitap ismi türü her şeyi farklı bir not defterine yazdır sonrasında 
        //okumayı bitir dendiğinde o not defterinden bilgileri çekip başlangıç tarihinden bitiş tarihine
        //olan süreyi geçen süre diye hesaplayan bir fonksiyon oluştur ve yazdır.
        private void stopTheRead_Click(object sender, EventArgs e)
        {
            startTheRead.Visible = true;
            stopTheRead.Visible = false;
            libVar.strStopReadingDate = libVar.dateProccessEnd().ToString();
            libVar.libFileProccesİnfoRead(libVar.libFilePathİnfo);
            libVar.dateEnd = libVar.dateProccessEnd().ToString();
            libVar.libFileProccesRead(libVar.libFilePath);
            File.Delete(@"D:\C# Projeleri\dersCalismaKiti\LibraryİnfoDataBase.txt");
            readingLabel.Text = "...";
            howManyDaysLabel.Text = "...";
            startingDateLabel.Text = "...";
        }


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //DialogResult myResult = MessageBox.Show("Çıkış Yapmak İstiyormusunuz ?", "Ders Çalışma Kiti", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            //if (myResult == DialogResult.Yes)
                this.Close();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"D:\C# Projeleri\dersCalismaKiti\WorkDataBase.txt");
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"D:\C# Projeleri\dersCalismaKiti\LibraryDataBase.txt");
        }


    }
}
