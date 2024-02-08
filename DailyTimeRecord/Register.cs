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
using System.Threading;
using System.Data.Sql;
using System.IO.Ports;
using System.Runtime.InteropServices;

using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.CV.CvEnum;
using DPUruNet;
using System.Drawing.Imaging;

namespace DailyTimeRecord
{
    public partial class Register : Form
    {
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


        ConnectionString cs = new ConnectionString();
        SqlConnection con = null;


        private string DispString;


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



        public void submitText(String Text, String Block)
        {

            String tmpStr = Text;
            int indx;
            if (authenticateBlock(Block))
            {
                ClearBuffers();
                SendBuff[0] = 0xFF;                             // CLA
                SendBuff[1] = 0xD6;                             // INS
                SendBuff[2] = 0x00;                             // P1
                SendBuff[3] = (byte)int.Parse(Block);           // P2 : Starting Block No.
                SendBuff[4] = (byte)int.Parse("16");            // P3 : Data length

                for (indx = 0; indx <= (tmpStr).Length - 1; indx++)
                {
                    SendBuff[indx + 5] = (byte)tmpStr[indx];
                }
                SendLen = SendBuff[4] + 5;
                RecvLen = 0x02;

                retCode = SendAPDUandDisplay(2);

                if (retCode != Card.SCARD_S_SUCCESS)
                {
                    MessageBox.Show("Fail Writing", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("Card Write Sucess!","Sucess",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("FailAuthentication");
            }
        }
        // block authentication
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

        public Register()
        {
            InitializeComponent();

            con = new SqlConnection(cs.DBcon);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();


            cmbdep();
            rbwith.Checked = true;



            SelectDevice();
            establishContext();


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
        }
        public Dictionary<int, Fmd> Fmds
        {
            get { return fmds; }
            set { fmds = value; }
        }
        private Dictionary<int, Fmd> fmds = new Dictionary<int, Fmd>();

        
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
                        return ("Card is removed please do not remove or please insert the card!");
                        

                }
              

            }
           

        }

        private const int PROBABILITY_ONE = 0x7fffffff;
        private Fmd firstFinger;
        int count = 0;
        DataResult<Fmd> resultEnrollment;
        List<Fmd> preenrollmentFmds;

        private enum Action
        {
            UpdateReaderState,
            SendBitmap,
            SendMessage
        }
        /// <summary>
        /// //////////// FOR BIOMETRICS
        /// </summary>
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
        public bool Reset
        {
            get { return reset; }
            set { reset = value; }
        }
        private bool reset;

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
        public bool CheckCaptureResult(CaptureResult captureResult)
        {
            using (Tracer tracer = new Tracer("Register::CheckCaptureResult"))
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
        public void clearbio()
        {

            StopButton.PerformClick();
            FingerPrintButton.Enabled = false;
            StopButton.Enabled = false;
            StatusLabel.Text = "Ready to save.";
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

                //Enrollment Code:
                try
                {
                    count++;
                    // Check capture quality and throw an error if bad.
                    DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);

                    //MessageBox.Show("A finger was captured.  \r\nCount:  " + (count));
                    string statuslabel;
                    if (FingerStatusLabel.InvokeRequired)
                    {
                        FingerStatusLabel.Invoke(new MethodInvoker(delegate { statuslabel = StatusLabel.Text = "A finger was captured.  \r\nCount:  " + (count); }));
                        FingerStatusLabel.Invoke(new MethodInvoker(delegate { StatusLabel.ForeColor = Color.Green; }));
                    }

                    if (resultConversion.ResultCode != Constants.ResultCode.DP_SUCCESS)
                    {
                        Reset = true;
                        throw new Exception(resultConversion.ResultCode.ToString());
                    }

                    preenrollmentFmds.Add(resultConversion.Data);

                    if (count >= 4)
                    {
                        resultEnrollment = DPUruNet.Enrollment.CreateEnrollmentFmd(Constants.Formats.Fmd.ANSI, preenrollmentFmds);
                        if (resultEnrollment.ResultCode == Constants.ResultCode.DP_SUCCESS)
                        {
                            preenrollmentFmds.Clear();
                            count = 0;
                           // clearbio();
                            //obj_bal_ForAll.BAL_StoreCustomerFPData("tbl_Finger", txtledgerId.Text, Fmd.SerializeXml(resultEnrollment.Data));
                            MessageBox.Show("Enrollment was successful, You can now save the data.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CancelCaptureAndCloseReader(this.OnCaptured);
                            string status;
                            if (FingerStatusLabel.InvokeRequired)
                            {
                                FingerStatusLabel.Invoke(new MethodInvoker(delegate { status = FingerStatusLabel.Text = "Reader is close."; }));
                                FingerStatusLabel.Invoke(new MethodInvoker(delegate { FingerStatusLabel.ForeColor = Color.Crimson; }));
                            }
                            if (btnadd.InvokeRequired)
                            {
                                btnadd.Invoke(new MethodInvoker(delegate { btnadd.Enabled = true; }));
                            }

                            if (StopButton.InvokeRequired)
                            {
                                StopButton.Invoke(new MethodInvoker(delegate { StopButton.Enabled = false; }));
                            }
                            //Automaticoff();
                            return;
                            
                        }
                        else if (resultEnrollment.ResultCode == Constants.ResultCode.DP_ENROLLMENT_INVALID_SET)
                        {
                            SendMessage(Action.SendMessage, "Enrollment was unsuccessful. Please try again.");
                            preenrollmentFmds.Clear();
                            count = 0;
                            return;
                        }
                        
                    }
                    MessageBox.Show("Now place the same finger on the reader.");
                }
                catch (Exception ex)
                {
                    // Send error message, then close form
                    SendMessage(Action.SendMessage, "Error:  " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                // Send error message, then close form
                SendMessage(Action.SendMessage, "Error:  " + ex.Message);
            }
        }
        public void GetStatus()
        {
            using (Tracer tracer = new Tracer("Register::GetStatus"))
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
        public bool OpenReader()
        {
            using (Tracer tracer = new Tracer("Register::OpenReader"))
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
        public bool CaptureFingerAsync()
        {
            using (Tracer tracer = new Tracer("Register::CaptureFingerAsync"))
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

        private Reader _reader;
        // private ReaderSelection _readerSelection;
        /// <summary>
        /// Hookup capture handler and start capture.
        /// </summary>
        /// <param name="OnCaptured">Delegate to hookup as handler of the On_Captured event</param>
        /// <returns>Returns true if successful; false if unsuccessful</returns>
        public bool StartCaptureAsync(Reader.CaptureCallback OnCaptured)
        {
            using (Tracer tracer = new Tracer("Register::StartCaptureAsync"))
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

        private void Register_Load(object sender, EventArgs e)
        {
           

            

            // status.Start();
        }
        
      
       
        public bool connectCard()
        {

            connActive = true;

            retCode = Card.SCardConnect(hContext, readername, Card.SCARD_SHARE_SHARED,
                      Card.SCARD_PROTOCOL_T0 | Card.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

            if (retCode != Card.SCARD_S_SUCCESS)
            {
                status.Stop();
                MessageBox.Show(Card.GetScardErrMsg(retCode), "Card Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                lblcardcode.Text = "------";
                lblcardstatus.Text = "------";
                groupBox4.Enabled = false;
                connActive = false;
                return false;
            }
            return true;

        }

        public void cmbdep()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From department_db";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cmbdepartment.Items.Add(dr["DepartmentName"].ToString());

            }

        }
        private void btnupload_Click(object sender, EventArgs e)
        {
            if (txtidnumber.Text == "" || txtfullname.Text == "" || cmbdepartment.Text == "")
            {
                MessageBox.Show("Please fill the fields before uploading pictures.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png;) | *.jpg; *.jpeg; *.gif; *.bmp; *.png; ";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(open.FileName);
                    //lblpath.Text = "Location: " + open.FileName;
                }
            }
        }
        
        public void clear()
        {
            try
            {
                
                txtidnumber.Clear();
                txtfullname.Clear();
                cmbdepartment.Text = "";
                dttimein.ResetText();
                dttimeout.ResetText();
                dtbday.ResetText();
                pictureBox1.Image = null;
                SearchTextbox.Clear();
                lblcardcode.Text = "------";
                lblcardstatus.Text = "------";
                rbwith.Checked = true;
                rbwithout.Checked = false;
                StopCaptureButton.Enabled = false;
                btnCameraOn.Enabled = true;
                LabelRFID.Text = "-----";
                btnCameraOn.Enabled = true;
                txtidnumber.Focus();
                Automatic.Stop();
                LabelStatus.Text = "-----";
                SearchTextbox.Clear();
                groupBox4.Enabled = false;
                SearchTextbox.Enabled = true;
                SearchButton.Enabled = true;
                MissingCardCheckBox.Checked = false;
                btnadd.Enabled = true;
                UniqueIDLabel.Text = "-";
                MissingCardCheckBox.Enabled = false;
                btnstatus.Enabled = true;
                groupBox3.Enabled = false;
                FingerPrintPicturebox.Image = null;
                CancelCaptureAndCloseReader(this.OnCaptured);
                StopButton.Enabled = false;
                FingerStatusLabel.Text = "Reader is offline.";
                FingerStatusLabel.ForeColor = Color.Crimson;
                FingerPrintButton.Enabled = true;
                StatusLabel.Text = "-----";
                

                /*
                if (grabber == null)
                {
                    //return;

                    //grabber.Dispose();
                    imageBoxFrameGrabber.Image = null;
                    imageBox1.Image = null;
                    Application.Idle -= new EventHandler(FrameGrabber);
                }
                else
                {

                    grabber.Dispose();
                    imageBoxFrameGrabber.Image = null;
                    imageBox1.Image = null;
                    Application.Idle -= new EventHandler(FrameGrabber);
                    //this.Dispose();
                    //clear();
                   // Register r = new Register();
                   // r.Show();
                }*/
                status.Stop();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            if (txtidnumber.Text == "" || txtfullname.Text == "" || cmbdepartment.Text == "")
            {
                MessageBox.Show("Field already clear.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            else if (MessageBox.Show("Clear all fields?", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clear();
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
        public Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);

            }

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtidnumber.Text == "" || txtfullname.Text == "" || cmbdepartment.Text == "")
            {
                MessageBox.Show("Please fill the fields before adding", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (lblcardcode.Text == "------")
            {
                MessageBox.Show("Please check card status first before writing", "Check status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtidnumber.Text == "")
            {
                MessageBox.Show("Please input number you want to write in RFID Card", "Input number", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           /* else if (imageBox1.Image == null)
            {
                MessageBox.Show("Capture face recognition first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
            else if (FingerPrintPicturebox.Image == null)
            {
                MessageBox.Show("Capture face recognition first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int i = 0;
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from EmployeeDetails_db where CardCode = '" + lblcardcode.Text + "' or RFIDNumber ='" + txtidnumber.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    if (resultEnrollment != null)
                    {
                        try
                        {
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "INSERT INTO EmployeeDetails_db(CardCode,RFIDNumber,FullName,Birthday,Department,DesigTimeIn,DesigTimeOut,NoonStatus,Photo,FingerPrint)VALUES('" + lblcardcode.Text + "','" + txtidnumber.Text + "','" + txtfullname.Text + "','" + dtbday.Value.ToString("MM/dd/yyyy") + "','" + cmbdepartment.Text + "','" + dttimein.Value.ToString("hh:mm tt") + "','" + dttimeout.Value.ToString("hh:mm tt") + "','" + txtnoon.Text + "',@Photo, '" + Fmd.SerializeXml(resultEnrollment.Data) + "')";
                    cmd1.Parameters.AddWithValue("@Photo", ConvertImageToBytes(pictureBox1.Image));
                    cmd1.ExecuteNonQuery();

                    //WRITE INTO RFID CARD

                    submitText(txtidnumber.Text, "5"); // 5 - is the block we are writing data on the card
                    clear();
                    MessageBox.Show("Data successfully added, You can now remove the card into the reader.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);                      //Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    
                    }
                    ////////////
                }
                else
                {

                    MessageBox.Show("This card is already used by other please use new card", "Card existed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnstatus_Click(object sender, EventArgs e)
        {
            if (connectCard())
            {
                string cardUID = getcardUID();
                lblcardcode.Text = cardUID; //displaying on text block

                status.Start();

            }

           

            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from EmployeeDetails_db where CardCode like'" + lblcardcode.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            foreach (DataRow dr in dt.Rows)
            {


                if (i == 1)
                {
                    lblcardstatus.Text = "Card is used by: " + dr["FullName"].ToString();
                   // MissingCardCheckBox.Checked = false;
                    MissingCardCheckBox.Enabled = false;
                    lblcardstatus.ForeColor = Color.Crimson;
                    SearchTextbox.Text = dr["FullName"].ToString();
                    SearchTextbox.Enabled = false;
                    groupBox4.Enabled = true;
                    SearchButton.PerformClick();
                    btnadd.Enabled = false;
                    groupBox3.Enabled = true;
                    SearchButton.Enabled = false;
                    FingerPrintButton.Enabled = false;
                    btnupdate.Enabled = true;

                }



            }

            if (lblcardcode.Text == "------")
            {
                lblcardstatus.Text = "------";
                groupBox4.Enabled = false;
            }
            else if (i == 0)
            {
                lblcardstatus.Text = "Card is ready to use.";
                lblcardstatus.ForeColor = Color.Green;
                groupBox4.Enabled = true;
                SearchTextbox.Enabled = false;
                SearchButton.Enabled = false;
                MissingCardCheckBox.Enabled = true;
                btnstatus.Enabled = false;
                btnupdate.Enabled = false;
                groupBox3.Enabled = true;
                // groupBox4.Enabled = true;

            }

           
           
           
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
                cardUID = "Error";
            }
            else
            {
                cardUID = BitConverter.ToString(receivedUID.Take(4).ToArray()).Replace("-", string.Empty).ToLower();
            }

            return cardUID;
        }




        private void txtidnumber_TextChanged(object sender, EventArgs e)
        {
            

           
        }

        private void txtfullname_TextChanged(object sender, EventArgs e)
        {
            /*SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Department_db where DepartmentName='" + cmbdepartment.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                cmbdepartment.Text = dr["DepartmentName"].ToString();

            }*/
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            if (txtidnumber.Text == "" || txtfullname.Text == "" || cmbdepartment.Text == "")
            {
                MessageBox.Show("Search data you want to UPDATE", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (lblcardcode.Text == "------")
            {
                MessageBox.Show("Verify card first before UPDATING", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MissingCardCheckBox.Checked == false)
                {
                    
                        try
                        {
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "update EmployeeDetails_db set CardCode = '" + lblcardcode.Text + "', RFIDNumber='" + txtidnumber.Text + "',Fullname='" + txtfullname.Text + "',Birthday='" + dtbday.Value.ToString("MMMM dd, yyyy") + "',Department='" + cmbdepartment.Text + "',DesigTimeIn='" + dttimein.Value.ToString("hh:mm tt") + "',DesigTimeOut='" + dttimeout.Value.ToString("hh:mm tt") + "',NoonStatus='" + txtnoon.Text + "',Photo=@Photo where id='" + UniqueIDLabel.Text + "'";
                            cmd.Parameters.AddWithValue("@Photo", ConvertImageToBytes(pictureBox1.Image));
                            cmd.ExecuteNonQuery();

                           /* SqlCommand cmd1 = con.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = "Update EmployeeDetails_db set FingerPrint = '" + Fmd.SerializeXml(resultEnrollment.Data) + "' where CardCode ='" + lblcardcode.Text +"'";
                            cmd1.ExecuteNonQuery();*/
                        }
                        catch(Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                    
                    
                    // Register r = new Register();
                    // r.Show();
                }
                else if (MissingCardCheckBox.Checked == true)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update EmployeeDetails_db set CardCode = '" + lblcardcode.Text + "',RFIDNumber='" + txtidnumber.Text + "',Fullname='" + txtfullname.Text + "',Birthday='" + dtbday.Value.ToString("MMMM dd, yyyy") + "',Department='" + cmbdepartment.Text + "',DesigTimeIn='" + dttimein.Value.ToString("hh:mm tt") + "',DesigTimeOut='" + dttimeout.Value.ToString("hh:mm tt") + "',NoonStatus='" + txtnoon.Text + "',Photo=@Photo  where id='" + UniqueIDLabel.Text + "'";
                    cmd.Parameters.AddWithValue("@Photo", ConvertImageToBytes(pictureBox1.Image));
                    cmd.ExecuteNonQuery();

                    submitText(txtidnumber.Text, "5");
                }
                clear();
                //this.Dispose();
                MessageBox.Show("Data Successfully Updated", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            //DELETE USERS FROM DATABASE.
            if (txtidnumber.Text == "" || txtfullname.Text == "" || cmbdepartment.Text == "")
            {
                MessageBox.Show("Search data you want to delete", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if ( lblcardcode.Text == "------")
            {
                MessageBox.Show("Verify card first before deleting", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MessageBox.Show("Are you sure you want to delete this data?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
  
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "delete from EmployeeDetails_db where CardCode = '" + lblcardcode.Text + "' and FullName='" + txtfullname.Text + "'";
                    cmd.ExecuteNonQuery();

                    //WRITE INTO RFID CARD

                    submitText("Empty Card", "5"); // 5 - is the block we are writing data on the card
                    clear();
                    MessageBox.Show("Data successfully deleted!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CaptureButton_Click(object sender, EventArgs e)
        {
            
        }

        private void Automatic_Tick(object sender, EventArgs e)
        {
            int j = 2;
            if (lblcounter.Text == "0")
            {
                LabelStatus.Text = "Camera is now finding face.";

            }
            else if (Convert.ToInt32(lblcounter.Text) > j)
            {
                LabelStatus.Text = "Can't capture multiple faces.";
            }
            
            else
            {
                    try
                    {
                        //Trained face counter
                        ContTrain = ContTrain + 1;

                        //Get a gray frame from capture device
                        gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                        //Face Detector
                        MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                        face,
                        1.1,
                        40,
                        Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                        new Size(20, 20));

                        //Action for each element detected
                        foreach (MCvAvgComp f in facesDetected[0])
                        {
                            TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                            break;
                        }

                        //resize face detected image for force to compare the same size with the 
                        //test image with cubic interpolation type method
                        TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                        trainingImages.Add(TrainedFace);
                        labels.Add(txtidnumber.Text);
                        //Show face added in gray scale
                        imageBox1.Image = TrainedFace;

                        //Write the number of triained faces in a file text for further load
                        File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                        //Write the labels of triained faces in a file text for further load
                        for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                        {
                            trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                            File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                        }
                        Automatic.Stop();
                        MessageBox.Show(txtfullname.Text + "´s face detected and added ", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //CaptureButton.Enabled = false;
                        btnCameraOn.Enabled = true;
                        LabelStatus.Text = "Face detected! Camera is now Off.";
                    StopCaptureButton.Enabled = false;

                    }
                    catch
                    {
                        MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                if (grabber == null) return;
                grabber.Dispose();
                imageBoxFrameGrabber.Image = null;
                Application.Idle -= new EventHandler(FrameGrabber);
                LabelStatus.Text = "-----";


            }
            /*else
            {
                LabelStatus.Text = "Face already exist in database.";
                Automatic.Stop();
                if (grabber == null) return;
                grabber.Dispose();
                imageBoxFrameGrabber.Image = null;
                Application.Idle -= new EventHandler(FrameGrabber);
                btnCameraOn.Enabled = true;
                if (MessageBox.Show("Face already exist in database. Turn the camera again?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnCameraOn.PerformClick();
                }
                else
                {
                    LabelStatus.Text = "-----";
                    lblcounter.Text = "0";
                    LabelRFID.Text = "-----";

                }

            }*/

        }

        private void StopCaptureButton_Click(object sender, EventArgs e)
        {
            Automatic.Stop();
            StopCaptureButton.Enabled = false;
            btnCameraOn.Enabled = true;
            if (grabber == null)
            {
                //return;

                //grabber.Dispose();

                imageBoxFrameGrabber.Image = null;
                imageBox1.Image = null;
                Application.Idle -= new EventHandler(FrameGrabber);
                
            }
            else
            {

                grabber.Dispose();
                imageBoxFrameGrabber.Image = null;
                imageBox1.Image = null;
                Application.Idle -= new EventHandler(FrameGrabber);
                //this.Dispose();
                //clear();
                // Register r = new Register();
                // r.Show();

            }
            LabelStatus.Text = "-----";

        }

        private void cmbdepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbdepartment_MouseHover(object sender, EventArgs e)
        {
         
           
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
           
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * FROM EmployeeDetails_db where FullName like'" + SearchTextbox.Text + "'ORDER BY id DESC ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lblcardcode.Text = dr["CardCode"].ToString();
                txtidnumber.Text = dr["RFIDNumber"].ToString();
                txtfullname.Text = dr["FullName"].ToString();
                dtbday.Text = dr["Birthday"].ToString();
                cmbdepartment.Text = dr["Department"].ToString();
                dttimein.Text = dr["DesigTimeIn"].ToString();
                dttimeout.Text = dr["DesigTimeOut"].ToString();
                txtnoon.Text = dr["NoonStatus"].ToString();
                UniqueIDLabel.Text = dr["id"].ToString();


                if (txtnoon.Text == "WITH NOON BREAK")
                {
                    rbwith.Checked = true;
                    rbwithout.Checked = false;
                }
                else if (txtnoon.Text == "WITHOUT NOON BREAK")
                {
                    rbwith.Checked = false; ;
                    rbwithout.Checked = true;
                }


                pictureBox1.Image = ConvertByteArrayToImage((byte[])dr["Photo"]);
                //FingerPrintPicturebox.Image = ConvertByteArrayToImage((byte[])dr["FingerPrint"]);
                // pictureBox2.Image = ConvertByteArrayToImage((byte[])dr["Biometric"]);



            }
            /*

            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from EmployeeDetails_db where id=" + i + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                txtidnumber.Text = dr["RFIDNumber"].ToString();


            }
            */

            /*
            int j = 0;
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from EmployeeDetails_db where CardCode like'" + lblcardcode.Text + "'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            j = Convert.ToInt32(dt1.Rows.Count.ToString());


            if (lblcardcode.Text == "------")
            {
                lblcardstatus.Text = "------";
            }
            else if (j == 0)
            {
                lblcardstatus.Text = "Card is ready to use.";
                lblcardstatus.ForeColor = Color.SeaGreen;
            }
            else if (j == 1)
            {
                lblcardstatus.Text = "Card is used by this employee.";
                lblcardstatus.ForeColor = Color.SeaGreen;
            }*/

        }

        private void SearchTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            SearchedListBox.Visible = true;
            SearchedListBox.Items.Clear();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select FullName from EmployeeDetails_db where FullName like('" + SearchTextbox.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                SearchedListBox.Items.Add(dr["FullName"].ToString());
            }
        }

        private void SearchTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (SearchedListBox.Visible == true)
            {
                if (e.KeyCode == Keys.Down)
                {
                    SearchedListBox.Focus();
                    SearchedListBox.SelectedIndex = 0;
                }

            }
        }

        private void SearchedListBox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                SearchTextbox.Text = SearchedListBox.SelectedItem.ToString();
                SearchedListBox.Visible = false;
                SearchTextbox.Focus();
            }
            catch (Exception)
            {
            }
        }

        private void SearchedListBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    this.SearchedListBox.SelectedIndex = this.SearchedListBox.SelectedIndex + 1;

                }
                if (e.KeyCode == Keys.Up)
                {
                    this.SearchedListBox.SelectedIndex = this.SearchedListBox.SelectedIndex - 1;

                }
                if (e.KeyCode == Keys.Enter)
                {
                    SearchTextbox.Text = SearchedListBox.SelectedItem.ToString();
                    SearchedListBox.Visible = false;
                    //productname_txt.Focus();
                }

            }
            catch (Exception)
            {
            }
        }

        private void SearchTextbox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchTextbox.Clear();
        }

        private void MissingCardCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MissingCardCheckBox.Checked == true)
            {
                MessageBox.Show("You've checked the missing card, You can now search the employee name and update his/her details with new RFID card","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                btnadd.Enabled = false;
                btnupdate.Enabled = true;
                SearchTextbox.Enabled = true;
                SearchButton.Enabled = true;
            }
            else
            {
                btnadd.Enabled = true;
                btnupdate.Enabled = false;
                SearchTextbox.Enabled = false;
                SearchButton.Enabled = false;


            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        public void CancelCaptureAndCloseReader(Reader.CaptureCallback OnCaptured)
        {
            using (Tracer tracer = new Tracer("Register::CancelCaptureAndCloseReader"))
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

                   // clearbio();
                }
            }
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            FingerPrintButton.Enabled = true;
            StopButton.Enabled = false;
            CancelCaptureAndCloseReader(this.OnCaptured);
            FingerStatusLabel.Text = "Reader is offline.";
            FingerStatusLabel.ForeColor = Color.Crimson;
        }

        private void FingerPrintButton_Click(object sender, EventArgs e)
        {
            if (txtidnumber.Text == "" || txtfullname.Text == "")
            {
                MessageBox.Show("Please fill all the fields first before capturing fingerprint.", "FILL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(pictureBox1.Image == null)
            {
                MessageBox.Show("Please upload a picture first before proceeding.", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FingerPrintButton.Enabled = false;
                StopButton.Enabled = true;
                FingerStatusLabel.Text = "Reader is online.";
                FingerStatusLabel.ForeColor = Color.Green;

                LoadScanners();
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
        }

        private void btnCameraOn_Click(object sender, EventArgs e)
        {
            if (txtidnumber.Text == "" || txtfullname.Text == "" || cmbdepartment.Text == "")
            {
                MessageBox.Show("Please fill the fields before turning on the camera", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (lblcardcode.Text == "----------")
            {
                MessageBox.Show("Please check card status first before turning on the camera", "Check status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtidnumber.Text == "")
            {
                MessageBox.Show("Please input number you want to write in RFID Card before turning on the camera", "Input number", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (pictureBox1.Image == null)
            {
                MessageBox.Show("Upload a picture first before turning on the camera", "Input number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                //btnCameraOn.Enabled = false;
                //Initialize the capture device

                if (MessageBox.Show("Camera about to turned on. Please make sure the person you are taking already faced the camera. Continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnCameraOn.Enabled = false;
                    grabber = new Capture();
                    grabber.QueryFrame();
                    //Initialize the FrameGraber event
                    Application.Idle += new EventHandler(FrameGrabber);
                    //CaptureButton.Enabled = false;
                    Automatic.Start(); /////// AUTOMATIC CAPTURE DEVICE
                    StopCaptureButton.Enabled = true;
                    //captureButton.Enabled = false;*/
                }





            }
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
              1.1,
              40,
              Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
              new Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    t = t + 1;
                    result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    //draw the face detected in the 0th (gray) channel with blue color
                    currentFrame.Draw(f.rect, new Bgr(Color.LightGreen), 2);


                    if (trainingImages.ToArray().Length != 0)
                    {
                        //TermCriteria for face recognition with numbers of trained images like maxIteration
                        MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                        //Eigen face recognizer
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                           trainingImages.ToArray(),
                           labels.ToArray(),
                           4000,
                           ref termCrit);

                        name = recognizer.Recognize(result);

                        //Draw the label for each face detected and recognized
                        currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.Red));

                    }

                    NamePersons[t - 1] = name;
                    NamePersons.Add("");


                    //Set the number of faces detected on the scene
                    lblcounter.Text = facesDetected[0].Length.ToString();

                    /*
                    //Set the region of interest on the faces
                        
                    gray.ROI = f.rect;
                    MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                       eye,
                       1.1,
                       10,
                       Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                       new Size(20, 20));
                    gray.ROI = Rectangle.Empty;

                    foreach (MCvAvgComp ey in eyesDetected[0])
                    {
                        Rectangle eyeRect = ey.rect;
                        eyeRect.Offset(f.rect.X, f.rect.Y);
                        currentFrame.Draw(eyeRect, new Bgr(Color.Blue), 2);
                    }
                     */

                }
                t = 0;

                //Names concatenation of persons recognized
                for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
                {
                    names = names + NamePersons[nnn] + "";
                }
                //Show the faces procesed and recognized
                imageBoxFrameGrabber.Image = currentFrame;
                LabelRFID.Text = names;
                names = "";
                //Clear the list(vector) of names
                NamePersons.Clear();

                if (txtidnumber.Text == "")
                { 
                    
                }
                else
                {
                    //AutomaticCapture();

                    //if (grabber == null) return;

                   // grabber.Dispose();
                   // imageBoxFrameGrabber.Image = null;
                    //imageBox1.Image = null;
                   // Application.Idle -= new EventHandler(FrameGrabber);
                    //Close();

                }




            }
            catch (Exception)
            { }

        }
        public void AutomaticCapture()
        {
            
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*
            //this.Close();
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
            this.Dispose();
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.Dispose();
        }

        private void status_Tick(object sender, EventArgs e)
        {
            if (connectCard())
            {
                string cardUID = getcardUID();
                lblcardcode.Text = cardUID; //displaying on text block

            }


               
            if (lblcardcode.Text == "------")
            {
                status.Stop();
                clear();
            }

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from EmployeeDetails_db where CardCode like'" + lblcardcode.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (lblcardcode.Text == "------")
            {
                this.Dispose();
            }
            else if (i == 0 || imageBox1.Image == null)
            {
                if (MessageBox.Show("Data not saved yet. Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    //this.Dispose();
                }
                else
                {
                    this.Close();
                    try
                    {

                        if (grabber == null) return;

                        grabber.Dispose();
                        imageBoxFrameGrabber.Image = null;
                        Application.Idle -= new EventHandler(FrameGrabber);

                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else if (i == 1)
            {
                this.Close();
                try
                {

                    if (grabber == null) return;

                    grabber.Dispose();
                    imageBoxFrameGrabber.Image = null;
                    Application.Idle -= new EventHandler(FrameGrabber);

                }
                catch (Exception)
                {
                }
            }
            
        }

        private void rbwith_CheckedChanged(object sender, EventArgs e)
        {
            if (rbwith.Checked == true)
            {
                txtnoon.Text = "WITH NOON BREAK";
            }
            else if (rbwithout.Checked == true)
            {
                txtnoon.Text = "WITHOUT NOON BREAK";
            }
        }

        private void rbwithout_CheckedChanged(object sender, EventArgs e)
        {
            if (rbwith.Checked == true)
            {
                txtnoon.Text = "WITH NOON BREAK";
            }
            else if (rbwithout.Checked == true)
            {
                txtnoon.Text = "WITHOUT NOON BREAK";
            }
        }
    }
}
