using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;


using DPUruNet;
using System.Drawing.Imaging;
using System.Threading;
using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Threading.Tasks;

namespace DailyTimeRecord
{
    public partial class DailyTimeRecord : Form
    {

       // SqlConnection conn = new SqlConnection(@"Data Source =192.168.0.100,1433;initial Catalog=DailyTimeRecord_db.mdf;Trusted_Connection=true;Integrated Security=false;Connect Timeout=30;user ID=dtr_new ;password=server");
        ConnectionString cs = new ConnectionString();
        SqlConnection con = null;

        int retCode;
        int hCard;
        int hContext;
        int Protocol;
        public bool connActive = false;
        string readername = "ACS ACR122 0";      // change depending on reader
        public byte[] SendBuff = new byte[263];
        public byte[] RecvBuff = new byte[263];
        public int SendLen, RecvLen, nBytesRet, reqType, Aprotocol, dwProtocol, cbPciLength;
        public Card.SCARD_READERSTATE RdrState;
        public Card.SCARD_IO_REQUEST pioSendRequest;




        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;




        public DailyTimeRecord()
        {
            InitializeComponent();


            ///Load haarcascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            //eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }

            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
                //MessageBox.Show("Nothing in binary database, please add at least a face", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //con = new SqlConnection(cs.DBcon);
            /*  if (con.State == ConnectionState.Open)
              {
                  con.Close();
              }
              con.Open();*/

            SelectDevice();
            establishContext();


            this.bw = new BackgroundWorker();
            this.bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            this.bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            this.bw.WorkerReportsProgress = true;

            /*
            //Load haarcascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            //eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }

            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
                // MessageBox.Show("Nothing in binary database, please add at least a face", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            */


        }
        public void SelectDevice()
        {
            List<string> availableReaders = this.ListReaders();
            this.RdrState = new Card.SCARD_READERSTATE();
            readername = availableReaders[0].ToString();//selecting first device
            this.RdrState.RdrName = readername;
        }

        public List<string> ListReaders()
        {
            int ReaderCount = 0;
            List<string> AvailableReaderList = new List<string>();

            //Make sure a context has been established before 
            //retrieving the list of smartcard readers.
            retCode = Card.SCardListReaders(hContext, null, null, ref ReaderCount);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                MessageBox.Show(Card.GetScardErrMsg(retCode));
                //connActive = false;
            }

            byte[] ReadersList = new byte[ReaderCount];

            //Get the list of reader present again but this time add sReaderGroup, retData as 2rd & 3rd parameter respectively.
            retCode = Card.SCardListReaders(hContext, null, ReadersList, ref ReaderCount);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                MessageBox.Show(Card.GetScardErrMsg(retCode));
            }

            string rName = "";
            int indx = 0;
            if (ReaderCount > 0)
            {
                // Convert reader buffer to string
                while (ReadersList[indx] != 0)
                {

                    while (ReadersList[indx] != 0)
                    {
                        rName = rName + (char)ReadersList[indx];
                        indx = indx + 1;
                    }

                    //Add reader name to list
                    AvailableReaderList.Add(rName);
                    rName = "";
                    indx = indx + 1;

                }
            }
            return AvailableReaderList;

        }

        internal void establishContext()
        {
            retCode = Card.SCardEstablishContext(Card.SCARD_SCOPE_SYSTEM, 0, 0, ref hContext);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                MessageBox.Show("Check your device and please restart again", "Reader not connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connActive = false;
                return;
            }
        }

        //CONVERT YOUR IMAGE INTO BYTES
        public Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);

            }

        }
        //CONVERT YOUR IMAGE INTO BYTES
        byte[] ConvertImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();

            }


        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            for (int i = 0; i < 100; ++i)
            {
                // report your progres
                worker.ReportProgress(i);

                // pretend like this a really complex calculation going on eating up CPU time
                System.Threading.Thread.Sleep(1);
            }
            //e.Result = "42";
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            //ON CAMERA AND BIOMETRIC CODE.

            FingerStatusLabel.Text = " ENTER YOUR FINGER PRINT NOW!";

            FingerStatusLabel.ForeColor = Color.DarkGreen;
            FingerStatusLabel.BackColor = Color.White;

            TimeStatus.Start();

            FormulaBackup.Start();
            ResetTimer.Interval = 200;
            facedetectiontimer.Stop();

            // startfacerecongition();
            // FACE RECOGNITION HERE***********************************************
          //  grabber = new Capture();
            //grabber.QueryFrame();
           // //Initialize the FrameGraber event
           // Application.Idle += new EventHandler(FrameGrabber);

            //////////////////////////END *********************************


            biometric();
            birthday();

            if (cmbtimestatus.Text == "TIME OUT")
            {

                var prevtimein = DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy HH:mm")); ////// TIME IN IDENTIFIER PREVIOUS TIME IN
                var todayout = DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy HH:mm")); ///////// TIME OUT IDENTIFIER/ TIMEOUT TIME PRESENT TIME

                if (Double.Parse(lbltotalhourstoday.Text) > 5) // KUN MORE THAN 5 HOURS FORMULA DOWN BELOW AUTOMATIC MINUS 1
                {

                    /*

                    if (prevtimein > (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 08:15"))) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 09:00"))) && lblnoonstatus.Text == "WITH NOON BREAK") // FORMULA FOR LAPAS 15 MINS GRACE TIME AND LESS THAN 9 AM
                    {
                        lbltotalhourstoday.Text = (todayout - prevtimein.AddMinutes(44)).Hours - 1 + ""; /////// IF MULAPAS NAN 15 MINS GRACE TIME  MINUS 1 HOUR AUTOMATIC
                    }
                    else if (prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 08:15"))) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 09:00"))) && lblnoonstatus.Text == "WITH NOON BREAK")
                    {
                        //lbltotalhourstoday.Text = (todayout - prevtimein.AddMinutes(-44)).Hours - 1 + ""; ////// IF DILI RA MULAPAS NAN 15 MINUTES GRACE TIME 8 HOURS JAUN AUTOMATIC
                        lbltotalhourstoday.Text = "8";
                    }

                   // else if (prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 07:15"))) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 08:00"))) && lblnoonstatus.Text == "WITHOUT NOON BREAK")
                    else if (prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 07:15"))) && lblnoonstatus.Text == "WITHOUT NOON BREAK")
                    {
                        //lbltotalhourstoday.Text = (todayout - prevtimein.AddMinutes(-44)).Hours + ""; ////// IF DILI RA MULAPAS NAN 15 MINUTES GRACE TIME 8 HOURS JAUN AUTOMATIC
                        lbltotalhourstoday.Text = "8";
                    }

                    else if (prevtimein > (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 07:15"))) && lblnoonstatus.Text == "WITHOUT NOON BREAK") // FORMULA FOR LAPAS 15 MINS GRACE TIME AND LESS THAN 9 AM
                    {
                        lbltotalhourstoday.Text = (todayout - prevtimein.AddMinutes(44)).Hours + ""; /////// IF MULAPAS NAN 15 MINS GRACE TIME  MINUS 1 HOUR AUTOMATIC
                    }

                    */


                    ///// for 7 am TIME

                    if (todayout < DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 14:56")) && lblnoonstatus.Text == "WITHOUT NOON BREAK")  ////// KUN 4:55 PM RA SIJA OUT AUTOMATIC 7 HOURS RA GAJUD AN IJA KAILANGAN 4:56 PM GAJUD OUT
                    {
                        lbltotalhourstoday.Text = (todayout.AddMinutes(-56) - prevtimein).Hours + ""; // -56 mins if 4:55 pm ra mu out early raa

                       // lbltotalhourstoday.Text = "7";
                    }
                    else if (todayout < DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 14:56")) && prevtimein > (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 07:15"))) && lblnoonstatus.Text == "WITHOUT NOON BREAK")
                    {
                        lbltotalhourstoday.Text = (todayout.AddMinutes(-56) - prevtimein.AddMinutes(45)).Hours + ""; // -56 mins if 4:55 pm ra mu out early raa
                    }
                    /*else if (todayout < DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 14:56")) && lblnoonstatus.Text == "WITHOUT NOON BREAK")
                    {
                        lbltotalhourstoday.Text = (todayout.AddMinutes(-56) - prevtimein).Hours + "";
                    }*/
                    else if (todayout > DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 14:56")) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 07:15"))) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 06:15"))) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 05:15"))) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 04:15"))) && lblnoonstatus.Text == "WITHOUT NOON BREAK")
                    {
                        lbltotalhourstoday.Text = (todayout - prevtimein).Hours + "";
                    }
                    else if (todayout > DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 14:56")) && prevtimein > (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 07:15"))) && lblnoonstatus.Text == "WITHOUT NOON BREAK")
                    {
                        lbltotalhourstoday.Text = (todayout - prevtimein.AddMinutes(45)).Hours + "";
                    }





                    //////////// FOR 8 AM TIME
                    else if (todayout < DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 16:56")) && prevtimein > (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 08:15"))) && lblnoonstatus.Text == "WITH NOON BREAK")
                    {
                        lbltotalhourstoday.Text = (todayout.AddMinutes(-56) - prevtimein.AddMinutes(45)).Hours + ""; // -56 mins if 4:55 pm ra mu out early raa
                    }
                    else if (todayout < DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 16:56")) && lblnoonstatus.Text == "WITH NOON BREAK")
                    {
                        lbltotalhourstoday.Text = (todayout.AddMinutes(-56) - prevtimein).Hours + "";
                    }
                    else if (todayout > DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 16:56")) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 08:15"))) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 07:15"))) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 06:15"))) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 05:15"))) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 04:15"))) && lblnoonstatus.Text == "WITH NOON BREAK")
                    {
                        lbltotalhourstoday.Text = (todayout - prevtimein).Hours - 1 + ""; //// amu ini an less than 8

                        //lbltotalhourstoday.Text = "8";
                    }
                    
                    else if (todayout > DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 16:56")) && prevtimein > (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 08:15"))) && lblnoonstatus.Text == "WITH NOON BREAK")
                    {
                        lbltotalhourstoday.Text = (todayout - prevtimein.AddMinutes(45)).Hours + ""; // +45 mins if 8:15 am sobra mu in.
                    }


                }

                if (Double.Parse(lbltotalhourstoday.Text) < 4)   //// KUN LESS THAN 4 AN TIME DI NA MINUSAN NAN 1 KAY 4 HOURS MAN BUNTAG SANAN 4 HOURS HAPON MEANS HALFDAY NO MINUS
                {

                    lbltotalhourstoday.Text = (todayout.Hour - prevtimein.Hour) + ""; ////// PREVIOUS TIME MINUSAN NAN PAG OUT NIM NA ORAS WHOLE NUMBER TOTAL DIDTO SA "LBLTOTALHOURSTODAY.TEXT" 
                }

                if (Double.Parse(lbltotalhourstoday.Text) > 7.5 && lblnoonstatus.Text == "WITH NOON BREAK") ////////IF TOTAL HOURS IS DAKO PA SA 8 AUTOMATIC TRIGGER AN OVERTIMEFORMULA
                {

                    var timeout = DateTime.Parse(dttimeoutidentefier.Value.ToString("HH:mm")); ////// TIME IN IDENTIFIER PREVIOUS TIME IN
                    var desigtimeout = DateTime.Parse(dttimeout.Value.ToString("HH:mm")); ///////// TIME OUT IDENTIFIER/ TIMEOUT TIME



                    txttimeoutovertime.Text = Convert.ToString(Double.Parse(lbltotalhourstoday.Text) - 9.3); // TO GET THE FINAL COMPUTATION OF OVERTIME YOU MUST SUBTRACT THE TOTAL HOURS BY 8
                }
                else if (Double.Parse(lbltotalhourstoday.Text) > 7.5 && lblnoonstatus.Text == "WITHOUT NOON BREAK") ////////IF TOTAL HOURS IS DAKO PA SA 8 AUTOMATIC TRIGGER AN OVERTIMEFORMULA
                {

                    var timeout = DateTime.Parse(dttimeoutidentefier.Value.ToString("HH:mm")); ////// TIME IN IDENTIFIER PREVIOUS TIME IN
                    var desigtimeout = DateTime.Parse(dttimeout.Value.ToString("HH:mm")); ///////// TIME OUT IDENTIFIER/ TIMEOUT TIME



                    txttimeoutovertime.Text = Convert.ToString(Double.Parse(lbltotalhourstoday.Text) - 8.3); // TO GET THE FINAL COMPUTATION OF OVERTIME YOU MUST SUBTRACT THE TOTAL HOURS BY 8
                  
                }

                /////////// IF NEGATIVE MAHIMU NA ZERO AN OVERTIME PARA DI MAG NEGATIVE

                if(Double.Parse(txttimeoutovertime.Text) < 0)
                {
                    txttimeoutovertime.Text = "0";
                }


            }
        }
        private void bw_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            LoadProgressBar.Value = e.ProgressPercentage;
        }

        private const CommandType text = CommandType.Text;
        private void txtrfidnumber_TextChanged(object sender, EventArgs e)
        {
            con.Close();
            con.Open();

            //  this.label1.Text = "The answer is: " + e.Result.ToString();
            // this.button1.Enabled = true;

            /////////// AUTOMATIC FILL IF DETECTED TIME OUT IF NOT TIME IN IN TIME IN DATAGRID
            int i = 0;
            SqlCommand cmd0 = con.CreateCommand();
            cmd0.CommandType = text;
            string v1 = $"select IDNumber,Date FROM TimeInStatus_db WHERE IDNumber ='{txtrfidnumber.Text}' and Date = '{dttodayin.Value.ToString("MM/dd/yyyy")}'";
            cmd0.CommandText = v1;
            cmd0.ExecuteNonQuery();
            DataTable dt0 = new DataTable();
            SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
            da0.Fill(dt0);
            i = Convert.ToInt32(dt0.Rows.Count.ToString());

            /*if (i == 0)
            {
                cmbtimestatus.Text = "TIME IN";
            }
            else if (i == 1)
            {
                cmbtimestatus.Text = "TIME OUT";
            }*/
            if (i == 0)
            {
                cmbtimestatus.Text = "TIME IN";
            }
            else
            {
                cmbtimestatus.Text = "TIME OUT";
            }
            //////////


            //////////////// CLEARING
            ///
           // lblemployeename.Text = "";
            lblemployeename.Text = "No User";
            lbldepartment.Text = "(Department)";
            EmployeePicture.Image = null;
            lblstatus.Text = "(Status Time)";
            lblstatus.ForeColor = Color.Black;
            //lbltotalovertimehours.Text = "0";
            lbltotalhourstoday.Text = "0";
            dttimein.ResetText();
            dttimeout.ResetText();

            ////////////////////////CODING

            //////////////////////////////
            //Task task = Task.Factory.StartNew(() =>  });
            
                if (cmbtimestatus.Text == "TIME IN")
                {
                   
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = text;
                    string v = $"SELECT FullName,Department,NoonStatus,DesigTimeIn,DesigTimeout,Photo FROM EmployeeDetails_db WHERE RFIDNumber ='{txtrfidnumber.Text}' ";
                    cmd.CommandText = v;
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        lblemployeename.Text = dr["FullName"].ToString();
                        lbldepartment.Text = dr["Department"].ToString();
                        lblnoonstatus.Text = dr["NoonStatus"].ToString();
                        dttimein.Text = dr["DesigTimeIn"].ToString();
                        dttimeout.Text = dr["DesigTimeOut"].ToString();
                        EmployeePicture.Image = ConvertByteArrayToImage((byte[])dr["Photo"]);
                        // pictureBox2.Focus();
                        //startfacerecongition();


                    }
                    facedetectiontimer.Start();

                }



                //// TIMEOUT
                 if (cmbtimestatus.Text == "TIME OUT")
                 {

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = text;
                    string v = $"SELECT FullName,TimedIn FROM TimeInStatus_db WHERE IDNumber ='{txtrfidnumber.Text}' ";
                    cmd.CommandText = v;
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        lblemployeename.Text = dr["FullName"].ToString();
                        //lbldepartment.Text = dr["Department"].ToString();
                        dtprevioustimein.Text = dr["TimedIn"].ToString();
                    }



                    //////////////////TIMEOUT DESIGNATED TIME
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = text;
                    string v2 = $"SELECT Department,DesigTimeIn,DesigTimeout,NoonStatus,Photo FROM EmployeeDetails_db WHERE RFIDNumber ='{txtrfidnumber.Text}' ";
                    cmd1.CommandText = v2;
                    cmd1.ExecuteNonQuery();
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    da1.Fill(dt1);
                    foreach (DataRow dr in dt1.Rows)
                    {
                        dttimein.Text = dr["DesigTimeIn"].ToString();
                        dttimeout.Text = dr["DesigTimeOut"].ToString();
                        lblnoonstatus.Text = dr["NoonStatus"].ToString();
                        lbldepartment.Text = dr["Department"].ToString();
                    EmployeePicture.Image = ConvertByteArrayToImage((byte[])dr["Photo"]);
                    }


                    //  rfidtimer.Stop();
                    facedetectiontimer.Start();


                    // startfacerecongition();
                 }

               

                TimeStatus.Start();
                LogoPictureBox.Visible = false;   

                
                

            


        }
        public void birthday()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = text;
            cmd.CommandText = "Select FullName,Birthday FROM EmployeeDetails_db WHERE DATEADD(YEAR,DATEPART(YEAR,GETDATE()) - DATEPART(YEAR,Birthday), Birthday) BETWEEN CAST(GETDATE() AS DATE) AND CAST (DATEADD(DAY,0, GETDATE()) AS DATE) ORDER BY DAY(Birthday), Fullname ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgbday.DataSource = dt;
            this.dgbday.Columns["Birthday"].Visible = false;
            dgbday.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgbday.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["FullName"].ToString() == lblemployeename.Text)
                {
                    // label2.Text = "Happy Birthday!";
                    //SplashScreen_frm sf = new SplashScreen_frm();
                    BirthdayLabel.Visible = true;
                    BirthdayLabel.Text = "Happy Birthday to you!";

                }

            }
            BirthdayStatus.Text = dgbday.Rows.Count.ToString();
            if(Convert.ToInt32(BirthdayStatus.Text) == 0)
            {
                BirthdayStatus.Text = "None";
            }
        }

        private void DailyTimeRecord_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBcon);

          

            try
            {
                backuprfidreset.Start();
                facedetectiontimer.Start();
                FormulaBackup.Start();
                birthday();
                rfidstatustimer.Start();
                LoadScanners();
            }
            catch(Exception)
            {
                this.Close();
                MessageBox.Show("System detected a power change. System is close please open it again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
            }

        }

        public void startfacerecongition()
        {
            //btnCameraOn.Enabled = false;
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
            //captureButton.Enabled = false;*/
        }

        void FrameGrabber(object sender, EventArgs e)
        {
            try
            {
                lblcounter.Text = "0";
                //label4.Text = "";
                NamePersons.Add("Empty");


                //Get the current frame form capture device
                currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);


                //Convert it to Grayscale
                gray = currentFrame.Convert<Gray, Byte>();

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
              face,
              1.1,///------->> DISTANCE
              10, ///------->> THE HIGHER THE NUMBER THE STRICT THE SENsOR
              Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
              new Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    t = t + 1;
                    result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    //draw the face detected in the 0th (gray) channel with blue color
                    currentFrame.Draw(f.rect, new Bgr(Color.SteelBlue), 2);


                    if (trainingImages.ToArray().Length != 0)
                    {
                        //TermCriteria for face recognition with numbers of trained images like maxIteration
                        MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                        //Eigen face recognizer
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                           trainingImages.ToArray(),
                           labels.ToArray(),
                           2000, //// THE HIGHER THE MORE AGGRESIVE THE DETECTOR
                           ref termCrit);

                        name = recognizer.Recognize(result);

                        //Draw the label for each face detected and recognized
                        //currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.Red));

                    }

                    NamePersons[t - 1] = name;
                    NamePersons.Add("");


                    //Set the number of faces detected on the scene
                    lblcounter.Text = facesDetected[0].Length.ToString();


                }
                t = 0;

                //Names concatenation of persons recognized
                for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
                {
                    names = names + NamePersons[nnn] + "";
                }
                //Show the faces procesed and recognized
                imageBoxFrameGrabber.Image = currentFrame;
                lblrfid.Text = names;
                names = "";
                //Clear the list(vector) of names
                NamePersons.Clear();


                ///////////// click if your face matched with the camera!
                if (txtrfidnumber.Text == lblrfid.Text)
                {
                    CancelCaptureAndCloseReader(this.OnCaptured);
                    btnenter.PerformClick();

                   // this.Dispose();

                }
                else
                { 
                    
                }
            }
            catch (Exception)
            { }

        }
        public void read()
        {
            txtrfidnumber.Clear();
            string text = verifyCard("5"); // 5 - is the block we are reading
            txtrfidnumber.Text = text.ToString();


          /*  if (connectCard())
            {
                string cardUID = getcardUID();
                lblcardcode.Text = cardUID; //displaying on text block

            }*/
        }

      

        public string verifyCard(String Block)
        {
            string value = "";
            if (connectCard())
            {
                value = readBlock(Block);
            }

            value = value.Split(new char[] { '\0' }, 10, StringSplitOptions.None)[0].ToString(); //-->> 2 IS THE DEFUALT
            return value;
        }
        

        // block authentication
        private bool authenticateBlock(String block)
        {
            ClearBuffers();
            SendBuff[0] = 0xFF;                         // CLA
            SendBuff[2] = 0x00;                         // P1: same for all source types 
            SendBuff[1] = 0x86;                         // INS: for stored key input
            SendBuff[3] = 0x00;                         // P2 : Memory location;  P2: for stored key input
            SendBuff[4] = 0x05;                         // P3: for stored key input
            SendBuff[5] = 0x01;                         // Byte 1: version number
            SendBuff[6] = 0x00;                         // Byte 2
            SendBuff[7] = (byte)int.Parse(block);       // Byte 3: sectore no. for stored key input
            SendBuff[8] = 0x60;                         // Byte 4 : Key A for stored key input
            SendBuff[9] = (byte)int.Parse("1");         // Byte 5 : Session key for non-volatile memory

            SendLen = 0x0A;
            RecvLen = 0x02;

            retCode = SendAPDUandDisplay(0);

            if (retCode != Card.SCARD_S_SUCCESS)
            {
                //MessageBox.Show("FAIL Authentication!");
                return false;
            }

            return true;
        }

        // clear memory buffers
        private void ClearBuffers()
        {
            long indx;

            for (indx = 0; indx <= 262; indx++)
            {
                RecvBuff[indx] = 0;
                SendBuff[indx] = 0;
            }
        }

        // send application protocol data unit : communication unit between a smart card reader and a smart card
        private int SendAPDUandDisplay(int reqType)
        {
            int indx;
            string tmpStr = "";

            pioSendRequest.dwProtocol = Aprotocol;
            pioSendRequest.cbPciLength = 8;

            //Display Apdu In
            for (indx = 0; indx <= SendLen - 1; indx++)
            {
                tmpStr = tmpStr + " " + string.Format("{0:X2}", SendBuff[indx]);
            }

            retCode = Card.SCardTransmit(hCard, ref pioSendRequest, ref SendBuff[0],
                                 SendLen, ref pioSendRequest, ref RecvBuff[0], ref RecvLen);

            if (retCode != Card.SCARD_S_SUCCESS)
            {
                return retCode;
            }

            else
            {
                try
                {
                    tmpStr = "";
                    switch (reqType)
                    {
                        case 0:
                            for (indx = (RecvLen - 2); indx <= (RecvLen - 1); indx++)
                            {
                                tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                            }

                            if ((tmpStr).Trim() != "90 00")
                            {
                                //MessageBox.Show("Return bytes are not acceptable.");
                                return -202;
                            }

                            break;

                        case 1:

                            for (indx = (RecvLen - 2); indx <= (RecvLen - 1); indx++)
                            {
                                tmpStr = tmpStr + string.Format("{0:X2}", RecvBuff[indx]);
                            }

                            if (tmpStr.Trim() != "90 00")
                            {
                                tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                            }

                            else
                            {
                                tmpStr = "ATR : ";
                                for (indx = 0; indx <= (RecvLen - 3); indx++)
                                {
                                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                                }
                            }

                            break;

                        case 2:

                            for (indx = 0; indx <= (RecvLen - 1); indx++)
                            {
                                tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                            }

                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    return -200;
                }
            }
            return retCode;
        }

        //disconnect card reader connection
        public void Closed()
        {
            if (connActive)
            {
                retCode = Card.SCardDisconnect(hCard, Card.SCARD_UNPOWER_CARD);
            }
            retCode = Card.SCardReleaseContext(hCard);
        }


        public string readBlock(String Block)
        {
            string tmpStr = "";
            int indx;

            if (authenticateBlock(Block))
            {
                ClearBuffers();
                SendBuff[0] = 0xFF; // CLA 
                SendBuff[1] = 0xB0;// INS
                SendBuff[2] = 0x00;// P1
                SendBuff[3] = (byte)int.Parse(Block);// P2 : Block No.
                SendBuff[4] = (byte)int.Parse("16");// Le

                SendLen = 5;
                RecvLen = SendBuff[4] + 2;

                retCode = SendAPDUandDisplay(2);

                if (retCode == -200)
                {
                    return "outofrangeexception";
                }

                if (retCode == -202)
                {
                    return "BytesNotAcceptable";
                }

                if (retCode != Card.SCARD_S_SUCCESS)
                {
                    return "FailRead";
                }

                // Display data in text format
                for (indx = 0; indx <= RecvLen - 1; indx++)
                {
                    tmpStr = tmpStr + Convert.ToChar(RecvBuff[indx]);
                }

                return (tmpStr);
            }
            else
            {
                return "";
            }
        }


        public bool connectCard()
        {
            
                connActive = true;

                retCode = Card.SCardConnect(hContext, readername, Card.SCARD_SHARE_SHARED,
                          Card.SCARD_PROTOCOL_T0 | Card.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

                /*
                    if (retCode != Card.SCARD_S_SUCCESS)
                    {
                        MessageBox.Show(Card.GetScardErrMsg(retCode), "Card not available", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connActive = false;
                        return false;
                    }
                  */
                return true;
            
          
        }


        private string getcardUID()//only for mifare 1k cards
        {
            string cardUID = "";
            byte[] receivedUID = new byte[256];
            Card.SCARD_IO_REQUEST request = new Card.SCARD_IO_REQUEST();
            request.dwProtocol = Card.SCARD_PROTOCOL_T1;
            request.cbPciLength = System.Runtime.InteropServices.Marshal.SizeOf(typeof(Card.SCARD_IO_REQUEST));
            byte[] sendBytes = new byte[] { 0xFF, 0xCA, 0x00, 0x00, 0x00 }; //get UID command      for Mifare cards
            int outBytes = receivedUID.Length;
            int status = Card.SCardTransmit(hCard, ref request, ref sendBytes[0], sendBytes.Length, ref request, ref receivedUID[0], ref outBytes);

            if (status != Card.SCARD_S_SUCCESS)
            {
                cardUID = "----------";
            }
            else
            {
                cardUID = BitConverter.ToString(receivedUID.Take(4).ToArray()).Replace("-", string.Empty).ToLower();
            }

            return cardUID;
        }


        public class Card
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct SCARD_IO_REQUEST
            {
                public int dwProtocol;
                public int cbPciLength;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct APDURec
            {
                public byte bCLA;
                public byte bINS;
                public byte bP1;
                public byte bP2;
                public byte bP3;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
                public byte[] Data;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
                public byte[] SW;
                public bool IsSend;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct SCARD_READERSTATE
            {
                public string RdrName;
                public int UserData;
                public int RdrCurrState;
                public int RdrEventState;
                public int ATRLength;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 37)]
                public byte[] ATRValue;
            }

            public const int SCARD_S_SUCCESS = 0;
            public const int SCARD_ATR_LENGTH = 33;


            /* ===========================================================
            '  Memory Card type constants
            '===========================================================*/
            public const int CT_MCU = 0x00;                   // MCU
            public const int CT_IIC_Auto = 0x01;               // IIC (Auto Detect Memory Size)
            public const int CT_IIC_1K = 0x02;                 // IIC (1K)
            public const int CT_IIC_2K = 0x03;                 // IIC (2K)
            public const int CT_IIC_4K = 0x04;                 // IIC (4K)
            public const int CT_IIC_8K = 0x05;                 // IIC (8K)
            public const int CT_IIC_16K = 0x06;                // IIC (16K)
            public const int CT_IIC_32K = 0x07;                // IIC (32K)
            public const int CT_IIC_64K = 0x08;                // IIC (64K)
            public const int CT_IIC_128K = 0x09;               // IIC (128K)
            public const int CT_IIC_256K = 0x0A;               // IIC (256K)
            public const int CT_IIC_512K = 0x0B;               // IIC (512K)
            public const int CT_IIC_1024K = 0x0C;              // IIC (1024K)
            public const int CT_AT88SC153 = 0x0D;              // AT88SC153
            public const int CT_AT88SC1608 = 0x0E;             // AT88SC1608
            public const int CT_SLE4418 = 0x0F;                // SLE4418
            public const int CT_SLE4428 = 0x10;                // SLE4428
            public const int CT_SLE4432 = 0x11;                // SLE4432
            public const int CT_SLE4442 = 0x12;                // SLE4442
            public const int CT_SLE4406 = 0x13;                // SLE4406
            public const int CT_SLE4436 = 0x14;                // SLE4436
            public const int CT_SLE5536 = 0x15;                // SLE5536
            public const int CT_MCUT0 = 0x16;                  // MCU T=0
            public const int CT_MCUT1 = 0x17;                  // MCU T=1
            public const int CT_MCU_Auto = 0x18;               // MCU Autodetect

            /*===============================================================
            ' CONTEXT SCOPE
            ===============================================================	*/
            public const int SCARD_SCOPE_USER = 0;
            /*===============================================================
            ' The context is a user context, and any database operations 
            '  are performed within the domain of the user.
            '===============================================================*/
            public const int SCARD_SCOPE_TERMINAL = 1;
            /*===============================================================
            ' The context is that of the current terminal, and any database 
            'operations are performed within the domain of that terminal.  
            '(The calling application must have appropriate access permissions 
            'for any database actions.)
            '===============================================================*/

            public const int SCARD_SCOPE_SYSTEM = 2;
            /*===============================================================
            ' The context is the system context, and any database operations 
            ' are performed within the domain of the system.  (The calling
            ' application must have appropriate access permissions for any 
            ' database actions.)
            '===============================================================*/
            /*=============================================================== 
            ' Context Scope
            '===============================================================*/
            public const int SCARD_STATE_UNAWARE = 0x00;
            /*===============================================================
            ' The application is unaware of the current state, and would like 
            ' to know. The use of this value results in an immediate return
            ' from state transition monitoring services. This is represented
            ' by all bits set to zero.
            '===============================================================*/
            public const int SCARD_STATE_IGNORE = 0x01;
            /*===============================================================
            ' The application requested that this reader be ignored. No other
            ' bits will be set.
            '===============================================================*/

            public const int SCARD_STATE_CHANGED = 0x02;
            /*===============================================================
            ' This implies that there is a difference between the state 
            ' believed by the application, and the state known by the Service
            ' Manager.When this bit is set, the application may assume a
            ' significant state change has occurred on this reader.
            '===============================================================*/

            public const int SCARD_STATE_UNKNOWN = 0x04;
            /*===============================================================
            ' This implies that the given reader name is not recognized by
            ' the Service Manager. If this bit is set, then SCARD_STATE_CHANGED
            ' and SCARD_STATE_IGNORE will also be set.
            '===============================================================*/
            public const int SCARD_STATE_UNAVAILABLE = 0x08;
            /*===============================================================
            ' This implies that the actual state of this reader is not
            ' available. If this bit is set, then all the following bits are
            ' clear.
            '===============================================================*/
            public const int SCARD_STATE_EMPTY = 0x10;
            /*===============================================================
            '  This implies that there is not card in the reader.  If this bit
            '  is set, all the following bits will be clear.
             ===============================================================*/
            public const int SCARD_STATE_PRESENT = 0x20;
            /*===============================================================
            '  This implies that there is a card in the reader.
             ===============================================================*/
            public const int SCARD_STATE_ATRMATCH = 0x40;
            /*===============================================================
            '  This implies that there is a card in the reader with an ATR
            '  matching one of the target cards. If this bit is set,
            '  SCARD_STATE_PRESENT will also be set.  This bit is only returned
            '  on the SCardLocateCard() service.
             ===============================================================*/
            public const int SCARD_STATE_EXCLUSIVE = 0x80;
            /*===============================================================
            '  This implies that the card in the reader is allocated for 
            '  exclusive use by another application. If this bit is set,
            '  SCARD_STATE_PRESENT will also be set.
             ===============================================================*/
            public const int SCARD_STATE_INUSE = 0x100;
            /*===============================================================
            '  This implies that the card in the reader is in use by one or 
            '  more other applications, but may be connected to in shared mode. 
            '  If this bit is set, SCARD_STATE_PRESENT will also be set.
             ===============================================================*/
            public const int SCARD_STATE_MUTE = 0x200;
            /*===============================================================
            '  This implies that the card in the reader is unresponsive or not
            '  supported by the reader or software.
            ' ===============================================================*/
            public const int SCARD_STATE_UNPOWERED = 0x400;
            /*===============================================================
            '  This implies that the card in the reader has not been powered up.
            ' ===============================================================*/

            public const int SCARD_SHARE_EXCLUSIVE = 1;
            /*===============================================================
            ' This application is not willing to share this card with other 
            'applications.
            '===============================================================*/
            public const int SCARD_SHARE_SHARED = 2;
            /*===============================================================
            ' This application is willing to share this card with other 
            'applications.
            '===============================================================*/
            public const int SCARD_SHARE_DIRECT = 3;
            /*===============================================================
            ' This application demands direct control of the reader, so it 
            ' is not available to other applications.
            '===============================================================*/

            /*===========================================================
            '   Disposition
            '===========================================================*/
            public const int SCARD_LEAVE_CARD = 0;   // Don't do anything special on close
            public const int SCARD_RESET_CARD = 1;   // Reset the card on close
            public const int SCARD_UNPOWER_CARD = 2;   // Power down the card on close
            public const int SCARD_EJECT_CARD = 3;   // Eject the card on close


            /* ===========================================================
            ' ACS IOCTL class
            '===========================================================*/
            public const long FILE_DEVICE_SMARTCARD = 0x310000; // Reader action IOCTLs

            public const long IOCTL_SMARTCARD_DIRECT = FILE_DEVICE_SMARTCARD + 2050 * 4;
            public const long IOCTL_SMARTCARD_SELECT_SLOT = FILE_DEVICE_SMARTCARD + 2051 * 4;
            public const long IOCTL_SMARTCARD_DRAW_LCDBMP = FILE_DEVICE_SMARTCARD + 2052 * 4;
            public const long IOCTL_SMARTCARD_DISPLAY_LCD = FILE_DEVICE_SMARTCARD + 2053 * 4;
            public const long IOCTL_SMARTCARD_CLR_LCD = FILE_DEVICE_SMARTCARD + 2054 * 4;
            public const long IOCTL_SMARTCARD_READ_KEYPAD = FILE_DEVICE_SMARTCARD + 2055 * 4;
            public const long IOCTL_SMARTCARD_READ_RTC = FILE_DEVICE_SMARTCARD + 2057 * 4;
            public const long IOCTL_SMARTCARD_SET_RTC = FILE_DEVICE_SMARTCARD + 2058 * 4;
            public const long IOCTL_SMARTCARD_SET_OPTION = FILE_DEVICE_SMARTCARD + 2059 * 4;
            public const long IOCTL_SMARTCARD_SET_LED = FILE_DEVICE_SMARTCARD + 2060 * 4;
            public const long IOCTL_SMARTCARD_LOAD_KEY = FILE_DEVICE_SMARTCARD + 2062 * 4;
            public const long IOCTL_SMARTCARD_READ_EEPROM = FILE_DEVICE_SMARTCARD + 2065 * 4;
            public const long IOCTL_SMARTCARD_WRITE_EEPROM = FILE_DEVICE_SMARTCARD + 2066 * 4;
            public const long IOCTL_SMARTCARD_GET_VERSION = FILE_DEVICE_SMARTCARD + 2067 * 4;
            public const long IOCTL_SMARTCARD_GET_READER_INFO = FILE_DEVICE_SMARTCARD + 2051 * 4;
            public const long IOCTL_SMARTCARD_SET_CARD_TYPE = FILE_DEVICE_SMARTCARD + 2060 * 4;
            public const long IOCTL_SMARTCARD_ACR128_ESCAPE_COMMAND = FILE_DEVICE_SMARTCARD + 2079 * 4;

            /*===========================================================
            '   Error Codes
            '===========================================================*/
            public const int SCARD_F_INTERNAL_ERROR = -2146435071;
            public const int SCARD_E_CANCELLED = -2146435070;
            public const int SCARD_E_INVALID_HANDLE = -2146435069;
            public const int SCARD_E_INVALID_PARAMETER = -2146435068;
            public const int SCARD_E_INVALID_TARGET = -2146435067;
            public const int SCARD_E_NO_MEMORY = -2146435066;
            public const int SCARD_F_WAITED_TOO_LONG = -2146435065;
            public const int SCARD_E_INSUFFICIENT_BUFFER = -2146435064;
            public const int SCARD_E_UNKNOWN_READER = -2146435063;


            public const int SCARD_E_TIMEOUT = -2146435062;
            public const int SCARD_E_SHARING_VIOLATION = -2146435061;
            public const int SCARD_E_NO_SMARTCARD = -2146435060;
            public const int SCARD_E_UNKNOWN_CARD = -2146435059;
            public const int SCARD_E_CANT_DISPOSE = -2146435058;
            public const int SCARD_E_PROTO_MISMATCH = -2146435057;


            public const int SCARD_E_NOT_READY = -2146435056;
            public const int SCARD_E_INVALID_VALUE = -2146435055;
            public const int SCARD_E_SYSTEM_CANCELLED = -2146435054;
            public const int SCARD_F_COMM_ERROR = -2146435053;
            public const int SCARD_F_UNKNOWN_ERROR = -2146435052;
            public const int SCARD_E_INVALID_ATR = -2146435051;
            public const int SCARD_E_NOT_TRANSACTED = -2146435050;
            public const int SCARD_E_READER_UNAVAILABLE = -2146435049;
            public const int SCARD_P_SHUTDOWN = -2146435048;
            public const int SCARD_E_PCI_TOO_SMALL = -2146435047;

            public const int SCARD_E_READER_UNSUPPORTED = -2146435046;
            public const int SCARD_E_DUPLICATE_READER = -2146435045;
            public const int SCARD_E_CARD_UNSUPPORTED = -2146435044;
            public const int SCARD_E_NO_SERVICE = -2146435043;
            public const int SCARD_E_SERVICE_STOPPED = -2146435042;

            public const int SCARD_W_UNSUPPORTED_CARD = -2146435041;
            public const int SCARD_W_UNRESPONSIVE_CARD = -2146435040;
            public const int SCARD_W_UNPOWERED_CARD = -2146435039;
            public const int SCARD_W_RESET_CARD = -2146435038;
            public const int SCARD_W_REMOVED_CARD = -2146435037;

            /*===========================================================
            '   PROTOCOL
            '===========================================================*/
            public const int SCARD_PROTOCOL_UNDEFINED = 0x00;          // There is no active protocol.
            public const int SCARD_PROTOCOL_T0 = 0x01;                 // T=0 is the active protocol.
            public const int SCARD_PROTOCOL_T1 = 0x02;                 // T=1 is the active protocol.
            public const int SCARD_PROTOCOL_RAW = 0x10000;             // Raw is the active protocol.
            //public const int SCARD_PROTOCOL_DEFAULT = 0x80000000;      // Use implicit PTS.
            /*===========================================================
            '   READER STATE
            '===========================================================*/
            public const int SCARD_UNKNOWN = 0;
            /*===============================================================
            ' This value implies the driver is unaware of the current 
            ' state of the reader.
            '===============================================================*/
            public const int SCARD_ABSENT = 1;
            /*===============================================================
            ' This value implies there is no card in the reader.
            '===============================================================*/
            public const int SCARD_PRESENT = 2;
            /*===============================================================
            ' This value implies there is a card is present in the reader, 
            'but that it has not been moved into position for use.
            '===============================================================*/
            public const int SCARD_SWALLOWED = 3;
            /*===============================================================
            ' This value implies there is a card in the reader in position 
            ' for use.  The card is not powered.
            '===============================================================*/
            public const int SCARD_POWERED = 4;
            /*===============================================================
            ' This value implies there is power is being provided to the card, 
            ' but the Reader Driver is unaware of the mode of the card.
            '===============================================================*/
            public const int SCARD_NEGOTIABLE = 5;
            /*===============================================================
            ' This value implies the card has been reset and is awaiting 
            ' PTS negotiation.
            '===============================================================*/
            public const int SCARD_SPECIFIC = 6;
            /*===============================================================
            ' This value implies the card has been reset and specific 
            ' communication protocols have been established.
            '===============================================================*/

            /*==========================================================================
            ' Prototypes
            '==========================================================================*/


            [DllImport("winscard.dll")]
            public static extern int SCardEstablishContext(int dwScope, int pvReserved1, int pvReserved2, ref int phContext);

            [DllImport("winscard.dll")]
            public static extern int SCardReleaseContext(int phContext);

            [DllImport("winscard.dll")]
            public static extern int SCardConnect(int hContext, string szReaderName, int dwShareMode, int dwPrefProtocol, ref int phCard, ref int ActiveProtocol);

            [DllImport("winscard.dll")]
            public static extern int SCardBeginTransaction(int hCard);

            [DllImport("winscard.dll")]
            public static extern int SCardDisconnect(int hCard, int Disposition);

            [DllImport("winscard.dll")]
            public static extern int SCardListReaderGroups(int hContext, ref string mzGroups, ref int pcchGroups);

            [DllImport("winscard.DLL", EntryPoint = "SCardListReadersA", CharSet = CharSet.Ansi)]
            public static extern int SCardListReaders(
                int hContext,
                byte[] Groups,
                byte[] Readers,
                ref int pcchReaders
                );


            [DllImport("winscard.dll")]
            public static extern int SCardStatus(int hCard, string szReaderName, ref int pcchReaderLen, ref int State, ref int Protocol, ref byte ATR, ref int ATRLen);

            [DllImport("winscard.dll")]
            public static extern int SCardEndTransaction(int hCard, int Disposition);

            [DllImport("winscard.dll")]
            public static extern int SCardState(int hCard, ref uint State, ref uint Protocol, ref byte ATR, ref uint ATRLen);

            [DllImport("WinScard.dll")]
            public static extern int SCardTransmit(IntPtr hCard,
                                                   ref SCARD_IO_REQUEST pioSendPci,
                                                   ref byte[] pbSendBuffer,
                                                   int cbSendLength,
                                                   ref SCARD_IO_REQUEST pioRecvPci,
                                                   ref byte[] pbRecvBuffer,
                                                   ref int pcbRecvLength);

            [DllImport("winscard.dll")]
            public static extern int SCardTransmit(int hCard, ref SCARD_IO_REQUEST pioSendRequest, ref byte SendBuff, int SendBuffLen, ref SCARD_IO_REQUEST pioRecvRequest, ref byte RecvBuff, ref int RecvBuffLen);

            [DllImport("winscard.dll")]
            public static extern int SCardTransmit(int hCard, ref SCARD_IO_REQUEST pioSendRequest, ref byte[] SendBuff, int SendBuffLen, ref SCARD_IO_REQUEST pioRecvRequest, ref byte[] RecvBuff, ref int RecvBuffLen);

            [DllImport("winscard.dll")]
            public static extern int SCardControl(int hCard, uint dwControlCode, ref byte SendBuff, int SendBuffLen, ref byte RecvBuff, int RecvBuffLen, ref int pcbBytesReturned);

            [DllImport("winscard.dll")]
            public static extern int SCardGetStatusChange(int hContext, int TimeOut, ref  SCARD_READERSTATE ReaderState, int ReaderCount);

            public static string GetScardErrMsg(int ReturnCode)
            {
                switch (ReturnCode)
                {
                    case SCARD_E_CANCELLED:
                        return ("The action was canceled by an SCardCancel request.");
                    case SCARD_E_CANT_DISPOSE:
                        return ("The system could not dispose of the media in the requested manner.");
                    case SCARD_E_CARD_UNSUPPORTED:
                        return ("The smart card does not meet minimal requirements for support.");
                    case SCARD_E_DUPLICATE_READER:
                        return ("The reader driver didn't produce a unique reader name.");
                    case SCARD_E_INSUFFICIENT_BUFFER:
                        return ("The data buffer for returned data is too small for the returned data.");
                    case SCARD_E_INVALID_ATR:
                        return ("An ATR string obtained from the registry is not a valid ATR string.");
                    case SCARD_E_INVALID_HANDLE:
                        return ("The supplied handle was invalid.");
                    case SCARD_E_INVALID_PARAMETER:
                        return ("One or more of the supplied parameters could not be properly interpreted.");
                    case SCARD_E_INVALID_TARGET:
                        return ("Registry startup information is missing or invalid.");
                    case SCARD_E_INVALID_VALUE:
                        return ("One or more of the supplied parameter values could not be properly interpreted.");
                    case SCARD_E_NOT_READY:
                        return ("The reader or card is not ready to accept commands.");
                    case SCARD_E_NOT_TRANSACTED:
                        return ("An attempt was made to end a non-existent transaction.");
                    case SCARD_E_NO_MEMORY:
                        return ("Not enough memory available to complete this command.");
                    case SCARD_E_NO_SERVICE:
                        return ("The smart card resource manager is not running.");
                    case SCARD_E_NO_SMARTCARD:
                        return ("The operation requires a smart card, but no smart card is currently in the device.");
                    case SCARD_E_PCI_TOO_SMALL:
                        return ("The PCI receive buffer was too small.");
                    case SCARD_E_PROTO_MISMATCH:
                        return ("The requested protocols are incompatible with the protocol currently in use with the card.");
                    case SCARD_E_READER_UNAVAILABLE:
                        return ("The specified reader is not currently available for use.");
                    case SCARD_E_READER_UNSUPPORTED:
                        return ("The reader driver does not meet minimal requirements for support.");
                    case SCARD_E_SERVICE_STOPPED:
                        return ("The smart card resource manager has shut down.");
                    case SCARD_E_SHARING_VIOLATION:
                        return ("The smart card cannot be accessed because of other outstanding connections.");
                    case SCARD_E_SYSTEM_CANCELLED:
                        return ("The action was canceled by the system, presumably to log off or shut down.");
                    case SCARD_E_TIMEOUT:
                        return ("The user-specified timeout value has expired.");
                    case SCARD_E_UNKNOWN_CARD:
                        return ("The specified smart card name is not recognized.");
                    case SCARD_E_UNKNOWN_READER:
                        return ("The specified reader name is not recognized.");
                    case SCARD_F_COMM_ERROR:
                        return ("An internal communications error has been detected.");
                    case SCARD_F_INTERNAL_ERROR:
                        return ("An internal consistency check failed.");
                    case SCARD_F_UNKNOWN_ERROR:
                        return ("An internal error has been detected, but the source is unknown.");
                    case SCARD_F_WAITED_TOO_LONG:
                        return ("An internal consistency timer has expired.");
                    case SCARD_S_SUCCESS:
                        return ("No error was encountered.");
                    case SCARD_W_REMOVED_CARD:
                        return ("The smart card has been removed, so that further communication is not possible.");
                    case SCARD_W_RESET_CARD:
                        return ("The smart card has been reset, so any shared state information is invalid.");
                    case SCARD_W_UNPOWERED_CARD:
                        return ("Power has been removed from the smart card, so that further communication is not possible.");
                    case SCARD_W_UNRESPONSIVE_CARD:
                        return ("The smart card is not responding to a reset.");
                    case SCARD_W_UNSUPPORTED_CARD:
                        return ("The reader cannot communicate with the card, due to ATR string configuration conflicts.");
                    default:
                        return ("?");
                }
            }
        }

          

            private void cmbtimestatus_SelectedValueChanged(object sender, EventArgs e)
            {
                /*//////////////// CLEARING
                lblemployeename.Text = "(Name)";
                lbldepartment.Text = "(Department)";
                pictureBox1.Image = null;
                lblstatus.Text = "(Status Time)";
                lblstatus.ForeColor = Color.Black;
                lbltotalovertimehours.Text = "(Total Overtime Hours)";
                lbltotalhourstoday.Text = "(Total Hours Today)";

                dttimein.ResetText();
                dttimeout.ResetText();
                txtrfidnumber.Clear();
                txtrfidnumber.Focus();*/



            }
            
            private void btnenter_Click(object sender, EventArgs e)
            {
                ///////////////////////////// ENTER BUTTON FUNCTIONS
               
                    if (lblemployeename.Text == "(Name)" || lbldepartment.Text == "(Department)" || txtrfidnumber.Text == "")
                    {

                        MessageBox.Show("Empty data entered", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 
                    }
                    else if (cmbtimestatus.Text == "TIME IN")
                    {
                                con.Close();
                                con.Open();
                                SqlCommand cmd2 = con.CreateCommand();
                                cmd2.CommandType = text;
                                cmd2.CommandText = "INSERT INTO TimeIn_db(Date,IDNumber,FullName,Department,TimeIn)VALUES('" + dttodayin.Value.ToString("MM/dd/yyyy") + "','" + txtrfidnumber.Text + "','" + lblemployeename.Text + "','" + lbldepartment.Text + "','" + dttodayin.Value.ToString("MM/dd/yyyy hh:mm tt") + "')";
                                //cmd2.Parameters.AddWithValue("@Photo", ConvertImageToBytes(EmployeePicture.Image));
                                cmd2.ExecuteNonQuery();


                                SqlCommand cmd3 = con.CreateCommand();
                                cmd3.CommandType = text;
                                cmd3.CommandText = "INSERT INTO TimeInStatus_db(Date,IDNumber,FullName,TimedIn)VALUES('" + dttodayin.Value.ToString("MM/dd/yyyy") + "','" + txtrfidnumber.Text + "','" + lblemployeename.Text + "','" + dttodayin.Value.ToString("MM/dd/yyyy hh:mm tt") + "')";
                                cmd3.ExecuteNonQuery();



                                SqlCommand cmd4 = con.CreateCommand();
                                cmd4.CommandType = text;
                                cmd4.CommandText = "INSERT INTO ActivityLogs_db(ClearID,Date,EmployeeID,EmployeeName,Time,Status)VALUES('"+ 1 +"','" + dttodayin.Value.ToString("MMMM dd, yyyy") + "','" + txtrfidnumber.Text + "','" + lblemployeename.Text + "','" + dttodayin.Value.ToString("hh:mm tt") + "','" + lblstatus.Text + "')";
                                cmd4.ExecuteNonQuery();
                                
                                lbldepartment.Text = "(Department)";
                                lblstatus.Text = "(Status Time)";
                                lblstatus.ForeColor = Color.Black;
                                dttimein.ResetText();
                                dttimeout.ResetText();

                /*
                                if (grabber == null) return;
                                grabber.Dispose();
                                imageBoxFrameGrabber.Image = null;
                                Application.Idle -= new EventHandler(FrameGrabber);
                */
                                SplashScreen_frm ss = new SplashScreen_frm();
                                ss.lblname.Text = lblemployeename.Text + "!";
                                //ss.pictureBox2.Image = EmployeePicture.Image;
                                ss.picwelcome.Visible = true;
                                ss.picseeyou.Visible = false;
                                ss.lblgreetings.Text = "TIMED IN!";

                    if(BirthdayLabel.Text == "Happy Birthday to you!")

                    {
                        ss.BirthdayLabel.Visible = true;
                        ss.BirthdayLabel.Text = "Happy Birthday to you!";
                    }
                                ss.Show();

                                

                    }

                    else if (cmbtimestatus.Text == "TIME OUT")
                    {
               

                if (Double.Parse(lbltotalhourstoday.Text) > 8 ) ///////////////////// IF TOTAL HOURS IS DAKO PA SA 8 MU STAY RA GHAP SIJA PAG SAVE AUTOMATIC
                    {
                    con.Close();
                    con.Open();
                    SqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = text;
                        cmd2.CommandText = "INSERT INTO DTRRecords_db(Date,IDNumber,FullName,Department,TimeIn,TimeOut,TimeOutOverTimeHours,TotalHours,OverTimeHours,Remarks)VALUES('" + dttodayout.Value.ToString("MM/dd/yyyy") + "','" + txtrfidnumber.Text + "','" + lblemployeename.Text + "','" + lbldepartment.Text + "','" + dtprevioustimein.Value.ToString("MM/dd/yyyy hh:mm tt") + "','" + dttodayout.Value.ToString("MM/dd/yyyy hh:mm tt") + "','" + (Double.Parse(txttimeoutovertime.Text)) + "','" + "8" + "','" + (Double.Parse(txttimeoutovertime.Text)) + "','" + "NO REMARKS" + "')";
                        cmd2.ExecuteNonQuery();


                        SqlCommand cmd3 = con.CreateCommand();
                        cmd3.CommandText = "delete from TimeInStatus_db where Date='" + dtprevioustimein.Value.ToString("MM/dd/yyyy") + "' and IDNumber='" + txtrfidnumber.Text + "' and FullName='" + lblemployeename.Text + "'";
                        cmd3.ExecuteNonQuery();


                        SqlCommand cmd4 = con.CreateCommand();
                        cmd4.CommandType = text;
                        cmd4.CommandText = "INSERT INTO ActivityLogs_db(ClearID,Date,EmployeeID,EmployeeName,Time,Status)VALUES('" + 1 + "','" + dttodayin.Value.ToString("MMMM dd, yyyy") + "','" + txtrfidnumber.Text + "','" + lblemployeename.Text + "','" + dttodayin.Value.ToString("hh:mm tt") + "','" + lblstatus.Text + "')";
                        cmd4.ExecuteNonQuery();


                        lbldepartment.Text = "(Department)";
                        lblstatus.Text = "(Status Time)";
                        lblstatus.ForeColor = Color.Black;
                        lbltotalhourstoday.Text = "(Total Hours Today)";
                        dttimein.ResetText();
                        dttimeout.ResetText();

                    /*
                        if (grabber == null) return;
                        grabber.Dispose();
                        imageBoxFrameGrabber.Image = null;
                        Application.Idle -= new EventHandler(FrameGrabber);
                    */


                SplashScreen_frm ss = new SplashScreen_frm();
                        ss.lblname.Text = lblemployeename.Text + "!";
                       // ss.pictureBox2.Image = EmployeePicture.Image;
                        ss.picwelcome.Visible = false;
                        ss.picseeyou.Visible = true;
                        ss.lblgreetings.Text = "TIMED OUT!";

                        if (BirthdayLabel.Text == "Happy Birthday to you!")

                        {
                            ss.BirthdayLabel.Visible = true;
                            ss.BirthdayLabel.Text = "Goodbye Birthday person enjoy your day!";
                        }

                        ss.Show();

                    }
                    else if (Double.Parse(lbltotalhourstoday.Text) < 8 || Double.Parse(lbltotalhourstoday.Text) == 8) ///// IF TOTAL HOURS IS GAMAY PA SA 8 AUTOMATIC MU SAVE SIJA SA FORMULA WHICH IS THE "LBLTOTALHOURS.TEXT" EQUATION AND DONT ACCEPT NEGATIVE OVERTIMEHOURS IF EVER MA TRIGGER AND OVERTIME EQUATION.
                        {

                            SqlCommand cmd2 = con.CreateCommand();
                            cmd2.CommandType = text;
                            cmd2.CommandText = "INSERT INTO DTRRecords_db(Date,IDNumber,FullName,Department,TimeIn,TimeOut,TimeOutOverTimeHours,TotalHours,OverTimeHours,Remarks)VALUES('" + dttodayout.Value.ToString("MM/dd/yyyy") + "','" + txtrfidnumber.Text + "','" + lblemployeename.Text + "','" + lbldepartment.Text + "','" + dtprevioustimein.Value.ToString("MM/dd/yyyy hh:mm tt") + "','" + dttodayout.Value.ToString("MM/dd/yyyy hh:mm tt") + "','" + "0" + "','" + (Double.Parse(lbltotalhourstoday.Text)) + "','" + "0" + "','" + "No Remarks" + "')";
                            cmd2.ExecuteNonQuery();


                            SqlCommand cmd3 = con.CreateCommand();
                            cmd3.CommandText = "delete from TimeInStatus_db where Date='" + dtprevioustimein.Value.ToString("MM/dd/yyyy") + "' and IDNumber='" + txtrfidnumber.Text + "' and FullName='" + lblemployeename.Text + "'";
                            cmd3.ExecuteNonQuery();


                            SqlCommand cmd4 = con.CreateCommand();
                            cmd4.CommandType = text;
                            cmd4.CommandText = "INSERT INTO ActivityLogs_db(ClearID,Date,EmployeeID,EmployeeName,Time,Status)VALUES('" + 1 + "','" + dttodayin.Value.ToString("MMMM dd, yyyy") + "','" + txtrfidnumber.Text + "','" + lblemployeename.Text + "','" + dttodayin.Value.ToString("hh:mm tt") + "','" + lblstatus.Text + "')";
                            cmd4.ExecuteNonQuery();


                            lbldepartment.Text = "(Department)";
                            lblstatus.Text = "(Status Time)";
                            lblstatus.ForeColor = Color.Black;
                            lbltotalhourstoday.Text = "(Total Hours Today)";
                            dttimein.ResetText();
                            dttimeout.ResetText();

                    /*
                            if (grabber == null) return;
                            grabber.Dispose();
                            imageBoxFrameGrabber.Image = null;
                            Application.Idle -= new EventHandler(FrameGrabber);

                    */

                            SplashScreen_frm ss = new SplashScreen_frm();
                            ss.lblname.Text = lblemployeename.Text + "!";
                           // ss.pictureBox2.Image = EmployeePicture.Image;
                            ss.lblgreetings.Text = "TIMED OUT!";
                        if (BirthdayLabel.Text == "Happy Birthday to you!")

                        {
                            ss.BirthdayLabel.Visible = true;
                            ss.BirthdayLabel.Text = "Goodbye Birthday person enjoy your day!";
                        }

                        ss.Show();
                        }
                          

                        }

               /* if (grabber == null) return;
                grabber.Dispose();
                imageBoxFrameGrabber.Image = null;
                Application.Idle -= new EventHandler(FrameGrabber);*/
                lblrfid.Text = "(Empty)";
            //CancelCaptureAndCloseReader(this.OnCaptured);
            this.Dispose();
            }

            public void progresssample()
            {
                lblpercent.Text = progressBar1.Value + "%";

            
            }
            private void ResetTimer_Tick(object sender, EventArgs e)
            
            {
                //progress();
                progresssample();
                progressBar1.Increment(1);

                if (progressBar1.Value == 100)
                {

                CancelCaptureAndCloseReader(this.OnCaptured);

                facedetectiontimer.Stop();
                progressBar1.Value = 0;
                lblpercent.Text ="0%";
                txtrfidnumber.Clear();
                txttimeoutovertime.Text = "0";
                lblemployeename.Text = "(Name)";
                lblnoonstatus.Text = "(Noon Status)";
                cmbtimestatus.Text = "-----";
                TimeStatus.Stop();// stop time status
                BirthdayLabel.Visible = false;
                BirthdayLabel.Text = "-----";
                FingerStatusLabel.Text = "Tap your ID again.";
                FingerStatusLabel.ForeColor = Color.Green;
                FingerStatusLabel.BackColor = Color.White;
                LoadProgressBar.Value = 0;
                LogoPictureBox.Visible = true;
                firstFinger = null;
                resultEnrollment = null;
                preenrollmentFmds = new List<Fmd>();
                FingerPrintPicturebox.Image = null;
                
                read();
                
                /*
                    if (grabber == null) return; 
                    grabber.Dispose();
                    imageBoxFrameGrabber.Image = null;
                    Application.Idle -= new EventHandler(FrameGrabber);
                  */
                

                }
            }
            private void DailyTimeRecord_FormClosed(object sender, FormClosedEventArgs e)
            {

                this.Closed();
            /*
                try
                {

                    if (grabber == null) return;

                    grabber.Dispose();
                    imageBoxFrameGrabber.Image = null;
                    Application.Idle -= new EventHandler(FrameGrabber);
                    
                }
                catch (Exception)
                { 
                }*/
            CancelCaptureAndCloseReader(this.OnCaptured);
           // this.Dispose();


        }

            private void backuprfidreset_Tick(object sender, EventArgs e)
            {


          /* txtrfidnumber.Clear();
            string text1 = verifyCard("5"); // 5 - is the block we are reading
            txtrfidnumber.Text = text1.ToString();*/


            if (lblemployeename.Text == "(Name)")
                {

                    if (connActive)
                    {
                        retCode = Card.SCardDisconnect(hCard, Card.SCARD_UNPOWER_CARD);
                    }
                    retCode = Card.SCardReleaseContext(hCard);

                    progressBar1.Value = 0;
                    ResetTimer.Stop();
                //////////////RFID READER
                //read();

                //txtrfidnumber.Clear();
                string text = verifyCard("5"); // 5 - is the block we are reading
                txtrfidnumber.Text = text.ToString();


            }

            else
                {
                    ResetTimer.Start();
                }
            }


            int card_status = 0;
        private Reader currentReader;
        public Reader CurrentReader
        {
            get { return currentReader; }
            set
            {
                currentReader = value;
                SendMessage(Action.UpdateReaderState, value);
            }
        }
        private ReaderCollection _readers;
        private void LoadScanners()
        {
            FingerprintDriverText.Text = string.Empty;
            FingerprintDriverText.Items.Clear();
            FingerprintDriverText.SelectedIndex = -1;

            try
            {
                _readers = ReaderCollection.GetReaders();

                foreach (Reader Reader in _readers)
                {
                    FingerprintDriverText.Items.Add(Reader.Description.Name);
                }

                if (FingerprintDriverText.Items.Count > 0)
                {
                    FingerprintDriverText.SelectedIndex = 0;
                    //btnCaps.Enabled = true;
                    //btnSelect.Enabled = true;
                }
                else
                {
                    //btnSelect.Enabled = false;
                    //btnCaps.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                //message box:
                String text = ex.Message;
                text += "\r\n\r\nPlease check if DigitalPersona service has been started";
                String caption = "Cannot access readers";
                MessageBox.Show(text, caption);
            }
        }
        private const int PROBABILITY_ONE = 0x7fffffff;
        private Fmd firstFinger;
        int count = 0;
        DataResult<Fmd> resultEnrollment;
        List<Fmd> preenrollmentFmds;
        public bool OpenReader()
        {
            using (Tracer tracer = new Tracer("DailyTimeRecord::OpenReader"))
            {
                reset = false;
                Constants.ResultCode result = Constants.ResultCode.DP_DEVICE_FAILURE;

                // Open reader
                result = currentReader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);

                if (result != Constants.ResultCode.DP_SUCCESS)
                {
                    MessageBox.Show("Error:  " + result);
                    reset = true;
                    return false;
                }

                return true;
            }
        }

        public void biometric()
        {
            //LoadScanners();
            firstFinger = null;
            resultEnrollment = null;
            preenrollmentFmds = new List<Fmd>();
            FingerPrintPicturebox.Image = null;
            if (CurrentReader != null)
            {
                CurrentReader.Dispose();
                CurrentReader = null;
            }
            CurrentReader = _readers[FingerprintDriverText.SelectedIndex];
            if (!OpenReader())
            {
                //this.Close();
            }

            if (!StartCaptureAsync(this.OnCaptured))
            {
                //this.Close();
            }
        }
        public bool CheckCaptureResult(CaptureResult captureResult)
        {
            using (Tracer tracer = new Tracer("DailyTimeRecord::CheckCaptureResult"))
            {
                if (captureResult.Data == null || captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                    {
                        reset = true;
                        throw new Exception(captureResult.ResultCode.ToString());
                    }

                    // Send message if quality shows fake finger
                    if ((captureResult.Quality != Constants.CaptureQuality.DP_QUALITY_CANCELED))
                    {
                        throw new Exception("Quality - " + captureResult.Quality);
                    }
                    return false;
                }

                return true;
            }
        }

        public bool StartCaptureAsync(Reader.CaptureCallback OnCaptured)
        {
            using (Tracer tracer = new Tracer("DailyTimeRecord::StartCaptureAsync"))
            {
                // Activate capture handler
                currentReader.On_Captured += new Reader.CaptureCallback(OnCaptured);

                // Call capture
                if (!CaptureFingerAsync())
                {
                    return false;
                }

                return true;
            }
        }

        public void GetStatus()
        {
            using (Tracer tracer = new Tracer("DailyTimeRecord::GetStatus"))
            {
                Constants.ResultCode result = currentReader.GetStatus();

                if ((result != Constants.ResultCode.DP_SUCCESS))
                {
                    reset = true;
                    throw new Exception("" + result);
                }

                if ((currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_BUSY))
                {
                    Thread.Sleep(50);
                }
                else if ((currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_NEED_CALIBRATION))
                {
                    currentReader.Calibrate();
                }
                else if ((currentReader.Status.Status != Constants.ReaderStatuses.DP_STATUS_READY))
                {
                    throw new Exception("Reader Status - " + currentReader.Status.Status);
                }
            }
        }

        public bool CaptureFingerAsync()
        {
            using (Tracer tracer = new Tracer("DailyTimeRecord::CaptureFingerAsync"))
            {
                try
                {
                    GetStatus();

                    Constants.ResultCode captureResult = currentReader.CaptureAsync(Constants.Formats.Fid.ANSI, Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT, currentReader.Capabilities.Resolutions[0]);
                    if (captureResult != Constants.ResultCode.DP_SUCCESS)
                    {
                        reset = true;
                        throw new Exception("" + captureResult);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:  " + ex.Message);
                    return false;
                }
            }
        }

        public Bitmap CreateBitmap(byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];

            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt64() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);

            return bmp;
        }
        

        public void OnCaptured(CaptureResult captureResult)
        {
            try
            {
                // Check capture quality and throw an error if bad.
                if (!CheckCaptureResult(captureResult)) return;

                // Create bitmap
                foreach (Fid.Fiv fiv in captureResult.Data.Views)
                {
                    SendMessage(Action.SendBitmap, CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                }

                //Verification Code
                try
                {

                    // Check capture quality and throw an error if bad.
                    if (!CheckCaptureResult(captureResult)) return;

                   // SendMessage(Action.SendMessage, "A finger was captured.");

                    DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);
                    if (resultConversion.ResultCode != Constants.ResultCode.DP_SUCCESS)
                    {
                        if (resultConversion.ResultCode != Constants.ResultCode.DP_TOO_SMALL_AREA)
                        {
                            Reset = true;
                        }
                        throw new Exception(resultConversion.ResultCode.ToString());
                    }
                    
                    
                            firstFinger = resultConversion.Data;
                            con.Close();
                            con.Open();
                            SqlCommand cmd0 = con.CreateCommand();
                            cmd0.CommandType = text;
                            cmd0.CommandText = "SELECT RFIDNumber,FingerPrint FROM EmployeeDetails_db";
                            cmd0.ExecuteNonQuery();
                            DataTable dt = new DataTable();
                            SqlDataAdapter da = new SqlDataAdapter(cmd0);
                            da.Fill(dt);
                            List<string> lstledgerIds = new List<string>();
                            count = 0;
                    if (dt.Rows.Count > 0)
                    {
                        for(int i = 0; i < dt.Rows.Count; i++)
                        //foreach (DataRow dr in dt.Rows)
                         {

                                    lstledgerIds.Add(dt.Rows[i]["RFIDNumber"].ToString());
                                    Fmd val = Fmd.DeserializeXml(dt.Rows[i]["FingerPrint"].ToString());
                                    CompareResult compare = Comparison.Compare(firstFinger, 0, val, 0);
                                    if (compare.ResultCode != Constants.ResultCode.DP_SUCCESS)
                                    {
                                        Reset = true;
                                        throw new Exception(compare.ResultCode.ToString());
                                    }

                            if (Convert.ToDouble(compare.Score.ToString()) == 0)
                            {
                                
                                    string status;
                             if (FingerStatusLabel.InvokeRequired)
                             {
                                        FingerStatusLabel.Invoke(new MethodInvoker(delegate { status = FingerStatusLabel.Text = lstledgerIds[i].ToString(); }));
                                        FingerStatusLabel.Invoke(new MethodInvoker(delegate { FingerStatusLabel.ForeColor = Color.DarkGreen; }));
                                        FingerStatusLabel.Invoke(new MethodInvoker(delegate { FingerStatusLabel.BackColor = Color.White; }));
                           
                            }
                            if (FingerStatusLabel.Text == txtrfidnumber.Text)
                            {
                                //// INVOKE TO WORK 
                                if (btnenter.InvokeRequired)
                                {
                                    btnenter.Invoke(new MethodInvoker(delegate { btnenter.PerformClick(); }));
                                }
                                CancelCaptureAndCloseReader(this.OnCaptured);
                                count++;
                                break;

                            }
                                /*else
                                {

                                if (progressBar1.InvokeRequired)
                                {
                                   progressBar1.Invoke(new MethodInvoker(delegate { progressBar1.Value = 100; }));

                                }
                                
                                CancelCaptureAndCloseReader(this.OnCaptured);
                                string status1;
                                    if (FingerStatusLabel.InvokeRequired)
                                    {
                                        FingerStatusLabel.Invoke(new MethodInvoker(delegate { status1 = FingerStatusLabel.Text = "Invalid fingerprint try again."; }));
                                        FingerStatusLabel.Invoke(new MethodInvoker(delegate { FingerStatusLabel.ForeColor = Color.Crimson; }));
                                        FingerStatusLabel.Invoke(new MethodInvoker(delegate { FingerStatusLabel.BackColor = Color.White; }));

                                    }

                                }*/
                               
                            }


                         }
                        
                        if (count == 0)
                        {


                       // if (progressBar1.InvokeRequired)
                        //{
                        //    progressBar1.Invoke(new MethodInvoker(delegate { progressBar1.Value = 100; }));

                        //}

                            // CancelCaptureAndCloseReader(this.OnCaptured);
                            string status;
                            if (FingerStatusLabel.InvokeRequired)
                            {
                                FingerStatusLabel.Invoke(new MethodInvoker(delegate { status = FingerStatusLabel.Text = "REMOVE YOUR HAND AND TRY AGAIN!"; }));
                                FingerStatusLabel.Invoke(new MethodInvoker(delegate { FingerStatusLabel.ForeColor = Color.Crimson; }));
                                FingerStatusLabel.Invoke(new MethodInvoker(delegate { FingerStatusLabel.BackColor = Color.White; }));

                            }
                        }



                    }
                }
                
                catch (Exception ex)
                {
                    // Send error message, then close form
                    this.Close();
                    SendMessage(Action.SendMessage, "Error:  " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                // Send error message, then close form
                this.Close();
                SendMessage(Action.SendMessage, "Error:  " + ex.Message);
                
            }

            
        }
        private Dictionary<int, Fmd> fmds = new Dictionary<int, Fmd>();
        public Dictionary<int, Fmd> Fmds
        {
            get { return fmds; }
            set { fmds = value; }
        }

        public bool Reset
        {
            get { return reset; }
            set { reset = value; }
        }

        private bool reset;

        private enum Action
        {
            UpdateReaderState,
            SendBitmap,
            SendMessage
        }

        private void lbltime_TextChanged(object sender, EventArgs e)
        {

        }

        private void bw_DoWork_1(object sender, DoWorkEventArgs e)
        {

        }

        private void BirthdayLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            // username_txt.Focus();
            password_txt.Focus();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void authorize_btn_Click(object sender, EventArgs e)
        {
            if(password_txt.Text == "Admin")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid login details! Please try again","INVALID",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void DailyTimeRecord_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private delegate void SendMessageCallback(Action state, object payload);
        private void SendMessage(Action action, object payload)
        {
            try
            {
                if (this.FingerPrintPicturebox.InvokeRequired)
                {
                    SendMessageCallback d = new SendMessageCallback(SendMessage);
                    this.Invoke(d, new object[] { action, payload });
                }
                else
                {
                    switch (action)
                    {
                        case Action.SendMessage:
                            MessageBox.Show((string)payload);
                            break;
                        case Action.SendBitmap:
                            FingerPrintPicturebox.Image = (Bitmap)payload;
                            FingerPrintPicturebox.Refresh();
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void CancelCaptureAndCloseReader(Reader.CaptureCallback OnCaptured)
        {
            using (Tracer tracer = new Tracer("DailyTimeRecord::CancelCaptureAndCloseReader"))
            {
                if (currentReader != null)
                {
                    currentReader.CancelCapture();

                    // Dispose of reader handle and unhook reader events.
                    currentReader.Dispose();

                    if (reset)
                    {
                        CurrentReader = null;
                    }
                }
            }
        }
        private void facedetectiontimer_Tick(object sender, EventArgs e)
            {

            con.Close();
            con.Open();
            int i = 0;
            SqlCommand cmd0 = con.CreateCommand();
            cmd0.CommandType = text;
            cmd0.CommandText = "select RFIDNumber FROM EmployeeDetails_db WHERE RFIDNumber ='" + txtrfidnumber.Text + "' ";
            cmd0.ExecuteNonQuery();
            DataTable dt0 = new DataTable();
            SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
            da0.Fill(dt0);
            i = Convert.ToInt32(dt0.Rows.Count.ToString());
           
            if(i==1)
           {
              // facedetectiontimer.Stop();
               // startfacerecongition();
                if (!this.bw.IsBusy)
                {
                    this.bw.RunWorkerAsync();
                }
            }
            else if (i == 0)
            {

                if (lblemployeename.Text == "No User" || lblemployeename.Text == "" || lblemployeename.Text == "(No User)")
                {
                    //grabber.Dispose();
                    this.Dispose();

                    //ResetTimer.Interval = 10;
                    CancelCaptureAndCloseReader(this.OnCaptured);
                   //
                   //imageBoxFrameGrabber.Image = null;
                    Application.Idle -= new EventHandler(FrameGrabber);
                    SplashScreen_frm ss = new SplashScreen_frm();
                    // ss.Height = 250;
                    // ss.Width = 900;
                    ss.BackColor = Color.Red;
                    ss.Timer.Interval = 20;
                    ss.BirthdayLabel.Visible = true;
                    ss.BirthdayLabel.BackColor = Color.White;
                    ss.BirthdayLabel.ForeColor = Color.Red;
                    ss.BirthdayLabel.Text = "Empty Card Detected, Remove your card now, resetting reader" + "!";
                    ss.picwelcome.Visible = false;
                    ss.picseeyou.Visible = false;
                    ss.Show();
                }
                /* else
                 {
                     //grabber.Dispose();
                     this.Dispose();

                     //ResetTimer.Interval = 10;
                     CancelCaptureAndCloseReader(this.OnCaptured);
                     imageBoxFrameGrabber.Image = null;
                     Application.Idle -= new EventHandler(FrameGrabber);
                     SplashScreen_frm ss = new SplashScreen_frm();
                     // ss.Height = 250;
                     // ss.Width = 900;
                     ss.BackColor = Color.Red;
                     ss.Timer.Interval = 20;
                     ss.BirthdayLabel.Visible = true;
                     ss.BirthdayLabel.BackColor = Color.White;
                     ss.BirthdayLabel.ForeColor = Color.Red;
                     ss.BirthdayLabel.Text = "Empty Card Detected, Remove your card now, resetting reader" + "!";
                     ss.picwelcome.Visible = false;
                     ss.picseeyou.Visible = false;
                     ss.Show();
                 }

                 //grabber.Dispose();
                 this.Dispose();

                 //ResetTimer.Interval = 10;
                 CancelCaptureAndCloseReader(this.OnCaptured);
                 imageBoxFrameGrabber.Image = null;
                 Application.Idle -= new EventHandler(FrameGrabber);
                 SplashScreen_frm ss = new SplashScreen_frm();
                 // ss.Height = 250;
                 // ss.Width = 900;
                 ss.BackColor = Color.Red;
                 ss.Timer.Interval = 20;
                 ss.BirthdayLabel.Visible = true;
                 ss.BirthdayLabel.BackColor = Color.White;
                 ss.BirthdayLabel.ForeColor = Color.Red;
                 ss.BirthdayLabel.Text = "Empty Card Detected, Remove your card now, resetting reader" + "!";
                 ss.picwelcome.Visible = false;
                 ss.picseeyou.Visible = false;
                 ss.Show();*/


            }
        }

            private void FormulaBackup_Tick(object sender, EventArgs e)
            {
            //birthday();
            //samplebday();
            lbltime.Text = DateTime.Now.ToLongTimeString(); ////////// TIME TODAY
            lbldate.Text = DateTime.Now.ToLongDateString(); ////////// DATE TODAY
            dttodayin.Text = DateTime.Now.ToLongTimeString(); ////// TIME IN IDENTIFIER right side.
            dttodayout.Text = DateTime.Now.ToLongTimeString(); ///// TIME OUT IDENTIFIER right side.
            dttimeoutidentefier.Text = DateTime.Now.ToLongTimeString(); ////// TIME FOR TIMEOUT MINUSED BY DESIGNATED TIMEOUT
/*
            if (cmbtimestatus.Text == "TIME OUT")
                {
                    
                        var prevtimein = DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy HH:mm")); ////// TIME IN IDENTIFIER PREVIOUS TIME IN
                        var todayout = DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy HH:mm")); ///////// TIME OUT IDENTIFIER/ TIMEOUT TIME PRESENT TIME

                        if (Double.Parse(lbltotalhourstoday.Text) > 5) // KUN MORE THAN 5 HOURS FORMULA DOWN BELOW AUTOMATIC MINUS 1
                        {



                            if (prevtimein > (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 08:15"))) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 09:00"))) && lblnoonstatus.Text == "WITH NOON BREAK") // FORMULA FOR LAPAS 15 MINS GRACE TIME AND LESS THAN 9 AM
                            {
                                lbltotalhourstoday.Text = (todayout - prevtimein.AddMinutes(44)).Hours -1 + ""; /////// IF MULAPAS NAN 15 MINS GRACE TIME  MINUS 1 HOUR AUTOMATIC
                            }
                            else if (prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 08:15"))) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 09:00"))) && lblnoonstatus.Text == "WITH NOON BREAK")
                            {
                                lbltotalhourstoday.Text = (todayout - prevtimein.AddMinutes(-44)).Hours - 1 + ""; ////// IF DILI RA MULAPAS NAN 15 MINUTES GRACE TIME 8 HOURS JAUN AUTOMATIC

                            }

                            else if (prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 07:15"))) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 08:00"))) && lblnoonstatus.Text == "WITHOUT NOON BREAK")
                            {
                                lbltotalhourstoday.Text = (todayout - prevtimein.AddMinutes(-44)).Hours + ""; ////// IF DILI RA MULAPAS NAN 15 MINUTES GRACE TIME 8 HOURS JAUN AUTOMATIC

                            }

                            else if (prevtimein > (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 07:15"))) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 08:00"))) && lblnoonstatus.Text == "WITHOUT NOON BREAK") // FORMULA FOR LAPAS 15 MINS GRACE TIME AND LESS THAN 9 AM
                            {
                                lbltotalhourstoday.Text = (todayout - prevtimein.AddMinutes(44)).Hours + ""; /////// IF MULAPAS NAN 15 MINS GRACE TIME  MINUS 1 HOUR AUTOMATIC
                            }




                            ///// for 7 am TIME

                            if (todayout < DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 14:56")) && todayout < DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 14:56")) && lblnoonstatus.Text == "WITHOUT NOON BREAK")  ////// KUN 4:55 PM RA SIJA OUT AUTOMATIC 7 HOURS RA GAJUD AN IJA KAILANGAN 4:56 PM GAJUD OUT
                            {
                                lbltotalhourstoday.Text = (todayout.AddMinutes(-55) - prevtimein).Hours + ""; // -56 mins if 4:55 pm ra mu out early raa
                            }
                            else if (todayout < DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 14:56")) && prevtimein > (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 07:15"))) && lblnoonstatus.Text == "WITHOUT NOON BREAK")
                            {
                                lbltotalhourstoday.Text = (todayout.AddMinutes(-56) - prevtimein.AddMinutes(45)).Hours + ""; // -56 mins if 4:55 pm ra mu out early raa
                            }
                            else if (todayout < DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 14:56")) && lblnoonstatus.Text == "WITHOUT NOON BREAK")
                            {
                                lbltotalhourstoday.Text = (todayout.AddMinutes(-56) - prevtimein).Hours + "";
                            }
                            else if (todayout > DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 14:56")) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 07:15"))) && lblnoonstatus.Text == "WITHOUT NOON BREAK")
                            {
                                lbltotalhourstoday.Text = (todayout - prevtimein).Hours + "";
                            }
                            else if (todayout > DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 14:56")) && prevtimein > (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 07:15"))) && lblnoonstatus.Text == "WITHOUT NOON BREAK")
                            {
                                lbltotalhourstoday.Text = (todayout - prevtimein).Hours  + ""; // -56 mins if 4:55 pm ra mu out early raa
                            }





                                //////////// FOR 8 AM TIME
                            else if (todayout < DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 16:56")) && prevtimein > (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 08:15"))) && lblnoonstatus.Text == "WITH NOON BREAK")
                            {
                                lbltotalhourstoday.Text = (todayout.AddMinutes(-56) - prevtimein.AddMinutes(45)).Hours + ""; // -56 mins if 4:55 pm ra mu out early raa
                            }
                            else if (todayout < DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 16:56")) && lblnoonstatus.Text == "WITH NOON BREAK")
                           {
                               lbltotalhourstoday.Text = (todayout.AddMinutes(-56) - prevtimein).Hours + "";
                           }
                            else if (todayout > DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 16:56")) && prevtimein < (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 08:15"))) && lblnoonstatus.Text == "WITH NOON BREAK")
                            {
                                lbltotalhourstoday.Text = (todayout - prevtimein).Hours - 1 + "";
                            }
                            else if (todayout > DateTime.Parse(dttodayout.Value.ToString("MM/dd/yyyy 16:56")) && prevtimein > (DateTime.Parse(dtprevioustimein.Value.ToString("MM/dd/yyyy 08:15"))) && lblnoonstatus.Text == "WITH NOON BREAK")
                            {
                                lbltotalhourstoday.Text = (todayout.AddMinutes(-56) - prevtimein).Hours + ""; // -56 mins if 4:55 pm ra mu out early raa
                            }


                        }

                         if (Double.Parse(lbltotalhourstoday.Text) < 4)   //// KUN LESS THAN 4 AN TIME DI NA MINUSAN NAN 1 KAY 4 HOURS MAN BUNTAG SANAN 4 HOURS HAPON MEANS HALFDAY NO MINUS
                        {

                            lbltotalhourstoday.Text = (todayout.Hour - prevtimein.Hour) + ""; ////// PREVIOUS TIME MINUSAN NAN PAG OUT NIM NA ORAS WHOLE NUMBER TOTAL DIDTO SA "LBLTOTALHOURSTODAY.TEXT" 
                        }

                        if (Double.Parse(lbltotalhourstoday.Text) > 8 ) ////////IF TOTAL HOURS IS DAKO PA SA 8 AUTOMATIC TRIGGER AN OVERTIMEFORMULA
                        {

                            var timeout = DateTime.Parse(dttimeoutidentefier.Value.ToString("HH:mm")); ////// TIME IN IDENTIFIER PREVIOUS TIME IN
                            var desigtimeout = DateTime.Parse(dttimeout.Value.ToString("HH:mm")); ///////// TIME OUT IDENTIFIER/ TIMEOUT TIME

 

                            txttimeoutovertime.Text = Convert.ToString(Double.Parse(lbltotalhourstoday.Text) - 8); // TO GET THE FINAL COMPUTATION OF OVERTIME YOU MUST SUBTRACT THE TOTAL HOURS BY 8
                        }

                       // else if (Double.Parse(lbltotalhourstoday.Text) == 8) ////////IF 8 RA GAJUD SIJA ZERO AN OT KAY 8 RAMAN
                        //{

                         //   txttimeoutovertime.Text = "0";// TO GET THE FINAL COMPUTATION OF OVERTIME YOU MUST SUBTRACT THE TOTAL HOURS BY 8
                        //}
                
                    }

                

            */

            }
          

            private void TimeStatus_Tick(object sender, EventArgs e)
            {
           

                ////////// FORMULA INI SIJA PARA STATUS SA TIMEOUT OR TIME IN 
                var TimeinStatusPresent = DateTime.Parse(dttimeoutidentefier.Value.ToString("HH:mm:ss"));
                var DesignatedTimein = DateTime.Parse(dttimein.Value.ToString("HH:mm:ss "));
                var DesignatedTimeout = DateTime.Parse(dttimeout.Value.ToString("HH:mm:ss "));

              
                if (lblemployeename.Text == "(Name)" || lblemployeename.Text == "No User")
                {
                    TimeStatus.Stop();
                    lblstatus.Text = "(Status Time)";
                }
                else
                {
                    
                    if (cmbtimestatus.Text == "TIME IN")
                    {
                        if (TimeinStatusPresent > DateTime.Parse(dttimeoutidentefier.Value.ToString("08:15:59 ")) && lblnoonstatus.Text == "WITH NOON BREAK")
                        {
                            lblstatus.Text = "Timed in late.";
                            lblstatus.ForeColor = Color.Crimson;
                        }
                        else if (TimeinStatusPresent < DateTime.Parse(dttimeoutidentefier.Value.ToString("08:00:59 ")) && lblnoonstatus.Text == "WITH NOON BREAK")
                        {
                            lblstatus.Text = "Timed In early nice!";
                            lblstatus.ForeColor = Color.White;

                        }
                        else if (TimeinStatusPresent < DateTime.Parse(dttimeoutidentefier.Value.ToString("08:15:59 ")) && lblnoonstatus.Text == "WITH NOON BREAK")
                        {
                            lblstatus.Text = "Timed In grace time used.";
                            lblstatus.ForeColor = Color.White;

                        }


                        else if (TimeinStatusPresent == DesignatedTimein && lblnoonstatus.Text == "WITH NOON BREAK")
                        {
                            lblstatus.Text = "Timed in on-time!";
                            lblstatus.ForeColor = Color.White;

                        }


                        if (TimeinStatusPresent > DateTime.Parse(dttimeoutidentefier.Value.ToString("07:15:59 ")) && lblnoonstatus.Text == "WITHOUT NOON BREAK")
                        {
                            lblstatus.Text = "Timed in late.";
                            lblstatus.ForeColor = Color.Crimson;
                        }
                        else if (TimeinStatusPresent < DateTime.Parse(dttimeoutidentefier.Value.ToString("07:00:59 ")) && lblnoonstatus.Text == "WITHOUT NOON BREAK")
                        {
                            lblstatus.Text = "Timed In early nice!";
                            lblstatus.ForeColor = Color.White;

                        }
                        else if (TimeinStatusPresent < DateTime.Parse(dttimeoutidentefier.Value.ToString("07:15:59 ")) && lblnoonstatus.Text == "WITHOUT NOON BREAK")
                        {
                            lblstatus.Text = "Timed In grace time used.";
                            lblstatus.ForeColor = Color.White;

                        }


                        else if (TimeinStatusPresent == DesignatedTimein && lblnoonstatus.Text == "WITHOUT NOON BREAK")
                        {
                            lblstatus.Text = "Timed in on-time!";
                            lblstatus.ForeColor = Color.White;

                        }


                    }
                    else if (cmbtimestatus.Text == "TIME OUT")
                    {
                        if (TimeinStatusPresent > DesignatedTimeout)
                        {
                            lblstatus.Text = "Timed out";
                            lblstatus.ForeColor = Color.White;
                        }
                        else if (TimeinStatusPresent < DesignatedTimeout)
                        {
                            lblstatus.Text = "Timed out early.";
                            lblstatus.ForeColor = Color.Crimson;

                        }
                        else if (TimeinStatusPresent == DesignatedTimeout)
                        {
                            lblstatus.Text = "Timed out on-time!";
                            lblstatus.ForeColor = Color.White;

                        }

                    }
                }
            }

            private void OvertimeComputer_Tick(object sender, EventArgs e)
            {
                
            }

            private void groupBox2_Enter(object sender, EventArgs e)
            {

            }
            

          
        private void bdaytimer_Tick(object sender, EventArgs e)
            {
               
            }

            private void rfdistatustimer_Tick(object sender, EventArgs e)
            {
                if (lblemployeename.Text == "(Name)")
                {
                    lblrfidstatus.Text = "RFID + Biometric fingerprint System Ready.";
                    lblrfidstatus.ForeColor = Color.DodgerBlue;
                lblrfidstatus.BackColor = Color.White;
                //lblrfidstatus.BackColor = Color.White;

            }
                else if (lblemployeename.Text == "No User")
                {
                    lblrfidstatus.Text = "Card is empty refreshing reader.";
                    lblrfidstatus.ForeColor = Color.Red;
                   // lblrfidstatus.BackColor = Color.White;
                }
                else
                {
                lblrfidstatus.Text = "Remove card and Enter your fingerprint now.";
                lblrfidstatus.ForeColor = Color.Green;
                lblrfidstatus.BackColor = Color.White;


               // lblrfidstatus.ForeColor = Color.DodgerBlue;
                //lblrfidstatus.BackColor = Color.White;
                }
            }

           
        
        
        }
    }
