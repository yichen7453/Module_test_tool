using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace MEA_AP
{
    public partial class Form1 : Form
    {
        SerialPort ConnectPort = null;

        int receiveLength = 26;
        int template_total_size = 242;
        int jmt501_image_size = 28246;
        int jmt103_image_size = 1050;

        byte[] RxBuffer;
        byte[] ImageBuffer;
        string ParameterType = null;

        bool enroll = false;
        bool verify = false;
        bool upload_image = false;

        int enroll_count = 0;
        int verify_fail_count = 0;
        int TemplateNumber = 0;
        int getEnrollTemplate = 0;

        MemoryStream ms;

        Bitmap logoImage;
        Bitmap showImage;

        string getDateTime;
        string imageFile;

        string sensorType;

        Stopwatch sw = new Stopwatch();

        delegate void UpdateRxDataHandler(int ReadLength);

        private Thread t;
        private Boolean receiving;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);

            if (ports.Length > 0)
            {
                comboBoxComPort.Items.AddRange(ports);
                comboBoxComPort.SelectedIndex = comboBoxComPort.Items.Count > 0 ? 0 : -1;
            }
            else
            {
                lb_message.ForeColor = Color.Red;
                lb_message.Text = "\nCan't find fingerprint device.\n";
                btnOpen_Device.Enabled = false;
                comboBoxComPort.Enabled = false;
                comboBoxBaudRate.Enabled = false;
            }

            comboBoxBaudRate.SelectedIndex = comboBoxBaudRate.Items.IndexOf("115200");

            string str = System.Windows.Forms.Application.StartupPath + "\\logo.ico";
            logoImage = new Bitmap(str);
            pb_png.Image = logoImage;

            imageFile = System.Windows.Forms.Application.StartupPath + "\\Fingerprint Image";
        }

        private void btnOpen_Device_Click(object sender, EventArgs e)
        {
            ConnectPort = new SerialPort();
            ConnectPort.PortName = comboBoxComPort.Text;
            ConnectPort.BaudRate = Convert.ToInt32(comboBoxBaudRate.Text);
            ConnectPort.DataBits = 8;
            ConnectPort.Parity = Parity.None;
            ConnectPort.StopBits = StopBits.One;

            ConnectPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            try
            {
                Console.Write("btnOpen_Device Click\n");
                ConnectPort.Open();

                ParameterType = "GetVersion";
                Console.WriteLine("ParameterType = GetVersion");
                ConnectPort.DiscardInBuffer();
                ConnectPort.Write(SetCommandParameter("09", "00", "00", "00"), 0, 26);

                ms = new MemoryStream();

                sw.Reset();
                sw.Start();
            }
            catch (Exception err)
            {
                lb_message.Text = ConnectPort.PortName + " : " + err.Message;
                return;
            }
        }

        private void btnClose_Device_Click(object sender, EventArgs e)
        {
            lb_message.ForeColor = Color.Black;

            if (ConnectPort != null)
            {
                if (ConnectPort.IsOpen)
                {
                    try
                    {
                        ConnectPort.Close();
                    }
                    catch (Exception err)
                    {
                        lb_message.Text = err.ToString();
                        return;
                    }
                    lb_message.Text = " Fingerprint device is disconnect.";

                    proBar_get_image.Visible = false;

                    ButtonEnable(false);
                    btnOpen_Device.Enabled = true;
                    lb_template_count.Text = "0";
                    tb_enroll_number.Text = "0";
                    tb_delete_number.Text = "0";
                    lb_version.Text = "";
                    enroll = verify = false;            
                    return;
                }
            }
        }

        private void btnGetImage_Click(object sender, EventArgs e)
        {
            lb_message.ForeColor = Color.Black;
            lb_message.Text = "Place finger to capture fingerprint \n\non device.";
            ButtonEnable(false);
            btnCancel.Enabled = true;
            ParameterType = "GetImage";
            Console.WriteLine("ParameterType = GetImage");
            ConnectPort.DiscardInBuffer();
            sw.Reset();
            sw.Start();     
            ConnectPort.Write(SetCommandParameter("20", "00", "00", "00"), 0, 26);

            ms = new MemoryStream();
            imageSize = 0;
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            pb_png.Image = logoImage;
            upload_image = false;
            btnSaveImage.Enabled = false;

            lb_message.ForeColor = Color.Black;
            lb_message.Text = "Place finger on device, lift it off, \n\n then repeat.";
            enroll = true;
            ButtonEnable(false);
            btnCancel.Enabled = true;
            ParameterType = "Enroll";
            Console.WriteLine("ParameterType = Enroll");
            ConnectPort.DiscardInBuffer();
            //ConnectPort.Write(SetCommandParameter("80", "00", "00", "00"), 0, 26);
            sw.Reset();
            sw.Start();
            ConnectPort.Write(SetCommandParameter("83", "01", AsciiToHex(Convert.ToInt32(tb_enroll_number.Text)), "00"), 0, 26);

            enroll_count = 0;

            ms = new MemoryStream();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {          
            pb_png.Image = logoImage;
            upload_image = false;
            btnSaveImage.Enabled = false;

            lb_message.ForeColor = Color.Black;
            lb_message.Text = "Place your fingertip on the device \n\n to verify your identity.";
            verify = true;
            ButtonEnable(false);
            btnCancel.Enabled = true;
            ParameterType = "Verify";
            Console.WriteLine("ParameterType = Verify");
            ConnectPort.DiscardInBuffer();
            sw.Reset();
            sw.Start();
            ConnectPort.Write(SetCommandParameter("81", "00", "00", "00"), 0, 26);

            verify_fail_count = 0;

            ms = new MemoryStream();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pb_png.Image = logoImage;
            upload_image = false;
            btnSaveImage.Enabled = false;

            lb_message.ForeColor = Color.Black;

            ParameterType = "Delete";
            Console.WriteLine("ParameterType = Delete");
            ConnectPort.DiscardInBuffer();
            if (Convert.ToInt32(tb_delete_number.Text) == 0)
            {               
                ConnectPort.Write(SetCommandParameter("82", "00", "00", "00"), 0, 26);
                ms = new MemoryStream();
                sw.Reset();
                sw.Start();
                lb_message.Text = "Delete all template ...";
            }
            else
            {
                sw.Reset();
                sw.Start();
                ConnectPort.Write(SetCommandParameter("44", "01", AsciiToHex(Convert.ToInt32(tb_delete_number.Text)), "00"), 0, 26);
                ms = new MemoryStream();
                lb_message.Text = "Delete " + Convert.ToInt32(tb_delete_number.Text) + " template ...";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pb_png.Image = logoImage;
            upload_image = false;
            btnSaveImage.Enabled = false;

            ParameterType = "Cancel";
            Console.WriteLine("ParameterType = Cancel");
            Thread.Sleep(20);
            ConnectPort.DiscardInBuffer();
            ConnectPort.Write(SetCommandParameter("25","00", "00", "00"), 0, 26);

            proBar_get_image.Visible = false;
            ButtonEnable(true);
            btnCancel.Enabled = false;
            btnOpen_Device.Enabled = false;
            if (getEnrollTemplate <= 0)
            {
                btnVerify.Enabled = false;
                btnDelete.Enabled = false;
            }

            lb_message.Text = "Welcome to use fingerprint tool";
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {            
            if (upload_image)
            {
                getDateTime = DateTime.Now.ToString("yyyyMMdd_HHmm");

                if (!System.IO.Directory.Exists(imageFile))
                {
                    System.IO.Directory.CreateDirectory(imageFile);
                }

                SaveFileDialog savefiledialog = new SaveFileDialog();
                savefiledialog.InitialDirectory = imageFile;
                savefiledialog.Filter = "PNG Image|*.png";
                savefiledialog.Title = "Save an Image File";          
                savefiledialog.FileName = getDateTime;         

                if (savefiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && savefiledialog.FileName != "")
                {                  
                    pb_png.Image.Save(savefiledialog.FileName, ImageFormat.Png);
                    lb_message.Text  = "Save image successfully.\n\n";
                    lb_message.Text += "File name : " + Path.GetFileName(savefiledialog.FileName);          
                }
            }
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "PNG Image|*.png";
            openfiledialog.Title = "Open Image File";

            if (System.IO.Directory.Exists(imageFile))
            {
                openfiledialog.InitialDirectory = imageFile;
            }

            if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && openfiledialog.FileName != null)
            {
                pb_png.Image = Image.FromFile(openfiledialog.FileName);
                lb_message.Text  = "Open image successfully.\n\n";
                lb_message.Text += "File name : " + Path.GetFileName(openfiledialog.FileName);
            }
        }

        #region DataReceivedHandler   
    
        int imageSize = 0;

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] r;
            sw.Stop();

            int ReadLength;
            int len = ConnectPort.BytesToRead;

            RxBuffer = new byte[len];

            Console.WriteLine("Received Length = " + len);

            if (len > 0)
            {
                switch (ParameterType)
                {
                    case "GetImage":
                        ReadLength = ConnectPort.Read(RxBuffer, 0, len);
                        imageSize += len;
                        ms.Write(RxBuffer, 0, RxBuffer.Length);

                        r = ms.ToArray();

                        if (r.Length > 3)
                        {
                            for (int x = 0; x < len; x++)
                            {
                                Console.Write(RxBuffer[x].ToString("X2") + "-");
                            }
                            Console.Write("\n");
                            if (r[0].ToString("X2") != "AA" || r[1].ToString("X2") == "55" || r[2].ToString("X2") == "01")
                            {
                                this.Invoke(new UpdateRxDataHandler(UpdateFingerImageToUI), ReadLength);
                            }
                        }                       
                        break;

                    case "TemplateCount":
                        ReadLength = ConnectPort.Read(RxBuffer, 0, len);
                        ms.Write(RxBuffer, 0, RxBuffer.Length);
                        int a = 1;
                       
                        r = ms.ToArray();
                        if (r.Length == template_total_size)
                        {
                            for (int x = 0; x < r.Length; x++)
                            {
                                Console.Write(a + " : " + r[x].ToString("X2") + "\n");
                                if (r[x].ToString("X2") == "20")
                                {
                                    Console.Write("======================\n");
                                    a++;
                                }

                                if (r[x].ToString("X2") == "AA")
                                {
                                    break;
                                }
                            }
                            this.Invoke(new UpdateRxDataHandler(getTemplateCountToUI), ReadLength);
                        }
                        break;

                    case "Enroll":
                        enroll = true;
                        ReadLength = ConnectPort.Read(RxBuffer, 0, len);
                        ms.Write(RxBuffer, 0, RxBuffer.Length);
                        /*
                        for (int x = 0; x < len; x++)
                        {
                            Console.Write(RxBuffer[x].ToString("X2") + "-");
                        }
                        Console.Write("\n");
                        */
                        r = ms.ToArray();
                        if (r.Length == receiveLength)
                        {
                            this.Invoke(new UpdateRxDataHandler(UpdateRxDataToUI), ReadLength);
                        }
                        break;

                    case "Verify":
                        verify = true;
                        ReadLength = ConnectPort.Read(RxBuffer, 0, len);
                        ms.Write(RxBuffer, 0, RxBuffer.Length);
                        /*
                        for (int x = 0; x < len; x++)
                        {
                            Console.Write(RxBuffer[x].ToString("X2") + "-");
                        }
                        Console.Write("\n");
                        */
                        r = ms.ToArray();
                        if (r.Length == receiveLength)
                        {
                            this.Invoke(new UpdateRxDataHandler(UpdateRxDataToUI), ReadLength);
                        }
                        break;

                    case "Delete":
                        ReadLength = ConnectPort.Read(RxBuffer, 0, len);
                        ms.Write(RxBuffer, 0, RxBuffer.Length);
                        /*
                        for (int x = 0; x < len; x++)
                        {
                            Console.Write(RxBuffer[x].ToString("X2") + "-");
                        }
                        Console.Write("\n");
                        */
                        r = ms.ToArray();
                        if (r.Length == receiveLength)
                        {
                            this.Invoke(new UpdateRxDataHandler(UpdateRxDataToUI), ReadLength);
                        }
                        break;

                    case "Cancel":
                        ReadLength = ConnectPort.Read(RxBuffer, 0, len);
                        
                        for (int x = 0; x < len; x++)
                        {
                            Console.Write(RxBuffer[x].ToString("X2") + "-");
                        }
                        Console.Write("\n");
                        
                        break;

                    case "GetVersion":
                        ReadLength = ConnectPort.Read(RxBuffer, 0, len);
                        ms.Write(RxBuffer, 0, RxBuffer.Length);
                        /*
                        for (int x = 0; x < len; x++)
                        {
                            Console.Write(RxBuffer[x].ToString("X2") + "-");
                        }
                        Console.Write("\n");
                        */
                        r = ms.ToArray();
                        if (r.Length == receiveLength)
                        {
                            this.Invoke(new UpdateRxDataHandler(UpdateRxDataToUI), ReadLength);
                        }
                        break;
                    default:
                        //int ReadLength = ConnectPort.Read(RxBuffer, 0, ConnectPort.BytesToRead);
                        //this.Invoke(new UpdateRxDataHandler(UpdateRxData), ReadLength);
                        break;
                }
            }
        }
        #endregion


        private void UpdateRxDataToUI(int ReadLength)
        {
            lb_time.Visible = true;
            lb_time.Text = "Time : " + sw.Elapsed.TotalMilliseconds.ToString() + " ms";

            byte[] receive = ms.ToArray();
            ms.Dispose();

            if (receive[0].ToString("X2") == "AA" && receive[1].ToString("X2") == "55")
            {
                switch (ParameterType)
                {
                    case "Test_Connection":
                        ButtonEnable(true);
                        lb_message.Text = "The fingerprint device already connect.\n";

                        break;

                    case "Enroll":
                        if (receive[4].ToString("X2") == "83")
                        {
                            if (receive[8].ToString("X2") == "00")
                            {
                                if (receive[10].ToString("X2") == "61")
                                {
                                    enroll_count++;
                                    Console.Write("Place finger to enroll template again.\n");
                                    lb_message.Text = "Capture " + enroll_count + " fingerprint,\n\n";
                                    lb_message.Text += "please place finger on device again.";
                                    sw.Reset();
                                    sw.Start();
                                    ms = new MemoryStream();
                                }
                                else if (receive[10].ToString("X2") == "53")
                                {
                                    Console.Write("Enroll Successfully\n");
                                    lb_message.Text = "Enroll Successfully\n\n";
                                    lb_message.Text += "Template number : " + HexToAscii(receive[11].ToString("X2"));

                                    getTemplateCount();

                                    ButtonEnable(true);
                                    btnOpen_Device.Enabled = false;
                                    btnCancel.Enabled = false;
                                }
                                else if (receive[10].ToString("X2") == "7A")
                                {
                                    Console.Write("Fingerprint feature is insufficient\n");
                                    lb_message.Text = "Fingerprint feature is insufficient,\n";
                                    lb_message.Text += "please place finger on device again.";
                                    sw.Reset();
                                    sw.Start();
                                    ms = new MemoryStream();
                                }
                            }
                            else if (receive[8].ToString("X2") == "01")
                            {
                                Console.Write("Enroll time out!\n");
                                lb_message.Text = "The enroll failure,\n\n";
                                lb_message.Text += "because timeout.\n";
                                ButtonEnable(true);
                                btnOpen_Device.Enabled = false;
                                btnCancel.Enabled = false;
                                getTemplateCount();
                            }
                            else if (receive[8].ToString("X2") == "02")
                            {
                                Console.Write("Template not empty!\n");
                                lb_message.Text = "Template number is exist,\n\n";
                                lb_message.Text += "please input another number.";
                                getTemplateCount();
                                ButtonEnable(true);
                                btnOpen_Device.Enabled = false;
                                btnCancel.Enabled = false;
                            }
                        } 
                        break;

                    case "Verify":
                        if (receive[4].ToString("X2") == "81")
                        {
                            if (receive[8].ToString("X2") == "00")
                            {
                                if (receive[10].ToString("X2") == "73")
                                {
                                    Console.Write("Verify Successfully\n");
                                    lb_message.Text = "Verify Successfully\n\n";
                                    lb_message.Text += "Template number : " + HexToAscii(receive[11].ToString("X2"));
                                    ButtonEnable(true);
                                    btnOpen_Device.Enabled = false;
                                    btnCancel.Enabled = false;
                                }
                                else if (receive[10].ToString("X2") == "61")
                                {
                                    verify_fail_count++;
                                    Console.Write("Verify fail " + verify_fail_count + " times.\n");

                                    lb_message.Text = "Verify fail " + verify_fail_count + " times.\n\n";
                                    lb_message.Text += "Place finger to verify template";
                                    sw.Reset();
                                    sw.Start();
                                    ms = new MemoryStream();
                                }
                            }
                            else if (receive[8].ToString("X2") == "01")
                            {
                                if (verify_fail_count == 5)
                                {
                                    lb_message.Text = "The verify of failures has reached 5,\n\n";
                                    lb_message.Text += "so verify function stop.";
                                    verify_fail_count = 0;
                                    ButtonEnable(true);
                                    btnOpen_Device.Enabled = false;
                                    btnCancel.Enabled = false;
                                }
                                else
                                {
                                    lb_message.Text = "The verify of failures,\n\n";
                                    lb_message.Text += "because timeout.";
                                    verify_fail_count = 0;
                                    ButtonEnable(true);
                                    btnOpen_Device.Enabled = false;
                                    btnCancel.Enabled = false;
                                }
                            }
                        }
                       
                        break;                         

                    case "Delete":
                        if (receive[4].ToString("X2") == "82")
                        {
                            if (receive[8].ToString("X2") == "00")
                            {
                                lb_message.Text = "Delete all template successfully !!";
                                getTemplateCount();
                            }
                            else if (receive[8].ToString("X2") == "01")
                            {
                                lb_message.Text = "Delete all template failure !!";
                            }
                        }

                        if (receive[4].ToString("X2") == "44")
                        {
                            if (receive[8].ToString("X2") == "00")
                            {
                                lb_message.Text = "Delete " + Convert.ToInt32(tb_delete_number.Text) + " template successfully !!";
                                getTemplateCount();
                            }
                            else if (receive[8].ToString("X2") == "01")
                            {
                                lb_message.Text = "Delete " + Convert.ToInt32(tb_delete_number.Text) + " template failure !!";
                            }
                        }
                        
                        break; 
                  
                    case "GetVersion":
                        if (receive[10].ToString("X2") == "4D")
                        {
                            if (receive[12].ToString("X2") == "41")
                            {
                                sensorType = "501";
                            } 
                            else if (receive[12].ToString("X2") == "53")
                            {
                                sensorType = "103";
                            }

                            char[] convertToChar = new char[26];

                            for (int x = 10; x < receive.Length - 2; x++)
                            {
                                convertToChar[x] = (char)Convert.ToInt16(receive[x].ToString("X2"), 16);
                            }

                            lb_version.Text = "Firmware Version : ";
                            foreach (char c in convertToChar)
                            {
                                lb_version.Text += c;
                            }

                            getTemplateCount();

                            lb_message.Text = "Fingerprint device is connect.\n\n";
                            lb_message.Text += "You can click the button below\n to operate the funtion.";
                            ButtonEnable(true);
                            btnCancel.Enabled = false;
                            comboBoxComPort.Enabled = false;
                            comboBoxBaudRate.Enabled = false;
                            btnOpen_Device.Enabled = false;
                        }
                        else
                        {
                            lb_message.ForeColor = Color.Red;
                            lb_message.Text = "Fingerprint device is not \nconnected successfully.";
                        }
                        break;
  
                    default:
                        MessageBox.Show("Connection Failure !!");
                        break;

                }
            }
        }

        private void UpdateFingerImageToUI(int ReadLength)
        {
            byte[] receiveImage = ms.ToArray();

            lb_time.Text = "Time : " + sw.Elapsed.TotalMilliseconds.ToString() + " ms";

            proBar_get_image.Visible = true;
            proBar_get_image.Maximum = imageSize;
            proBar_get_image.Value = imageSize;

            // 28246 : 166 * 170 + 26 bytes for 501
            // 1050  : 128 * 8 + 26 bytes for 103
            if ((sensorType == "501" && imageSize == 28246) || (sensorType == "103" && imageSize == 1050)) // 166 * 170 + 26 bytes
            {
                lb_message.Text = "Uploading image .......";
               
                ImageBuffer = new byte[imageSize - 26];

                for (int y = 0; y < imageSize - 26; y++)
                {
                    ImageBuffer[y] = receiveImage[y];
                    ms.Dispose();
                }

                if (sensorType == "501")
                {
                    showImage = ToGrayBitmap(ImageBuffer, 166, 170);
                }
                else if (sensorType == "103")
                {
                    showImage = ToGrayBitmap(ImageBuffer, 128, 8);
                }

                pb_png.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pb_png.Image = showImage;
                proBar_get_image.Visible = false;
                upload_image = true;
                btnSaveImage.Enabled = true;
                //pb_png.Image.Save("123.png", ImageFormat.Png);
                //bmp.Save("1.png", System.Drawing.Imaging.ImageFormat.Png);
                //}

                if (receiveImage[receiveImage.Length - 22].ToString("X2") == "20")
                {
                    if (receiveImage[receiveImage.Length - 16].ToString("X2") == "00")
                    {
                        lb_message.Text = "Upload image successfully.";
                        ButtonEnable(true);
                        btnOpen_Device.Enabled = false;
                    }
                    else if (receiveImage[receiveImage.Length - 16].ToString("X2") == "01")
                    {
                        lb_message.Text = "Upload image failure.";
                        ButtonEnable(true);
                        btnOpen_Device.Enabled = false;
                    }
                }
            }
        }

        private void getTemplateCountToUI(int ReadLength)
        {
            getEnrollTemplate = 0;
            int getTemplateCount = 0;

            TemplateNumber = 0;

            byte[] receiveList = ms.ToArray();
            ms.Dispose();

            /*
            for (int y = 0; y < RxBuffer.Length - 26; y++)
            {
                if (RxBuffer[y].ToString("X2") == "20")
                {
                    if (RxBuffer[y - 2].ToString("X2") == "53")
                    {
                        getEnrollTemplate++;
                    }
                }
            }

            for (int y = 0; y < RxBuffer.Length - 26; y++)
            {
                if (RxBuffer[y].ToString("X2") == "20")
                {
                    TemplateNumber++;

                    if (RxBuffer[y - 2].ToString("X2") == "46")
                    {
                        tb_enroll_number.Text = Convert.ToString(TemplateNumber);
                        break;
                    }
                }
            }
            */

            for (int y = 0; y < receiveList.Length - 26; y++)
            {
                if (receiveList[y].ToString("X2") == "20")
                {
                    if (receiveList[y - 2].ToString("X2") == "53")
                    {
                        getEnrollTemplate++;
                    }
                }
            }

            for (int y = 0; y < receiveList.Length - 26; y++)
            {
                if (receiveList[y].ToString("X2") == "20")
                {
                    TemplateNumber++;

                    if (receiveList[y - 2].ToString("X2") == "46")
                    {
                        tb_enroll_number.Text = Convert.ToString(TemplateNumber);
                        break;
                    }
                }
            }

            if (getEnrollTemplate >= 0)
            {
                getTemplateCount = getEnrollTemplate;

                lb_template_count.Text = Convert.ToString(getTemplateCount);

                
                if (getTemplateCount <= 0)
                {
                    btnVerify.Enabled = false;
                    btnDelete.Enabled = false;
                    tb_delete_number.Enabled = false;
                }
            }

            tb_delete_number.Text = "0";
        }

        #region getTemplateCount
        private void getTemplateCount()
        {
            ParameterType = "TemplateCount";
            Console.WriteLine("ParameterType = TemplateCount");
            ConnectPort.DiscardInBuffer();
            ConnectPort.Write(SetCommandParameter("90", "00", "00", "00"), 0, 26);

            ms = new MemoryStream();
        }
        #endregion

        #region HexToAscii
        private int HexToAscii(string hex)
        {
            int ascii = Convert.ToInt32(hex, 16);

            int value = ascii - 47;

            return value;
        }
        #endregion

        #region AsciiToHex
        private string AsciiToHex(int ascii)
        {
            int value = Convert.ToInt32(ascii);

            int hex = value + 47;

            return String.Format("{0:X2}", hex);
        }
        #endregion

        #region ButtonEnable
        private void ButtonEnable(bool enable)
        {
            if (enable)
            {
                btnClose_Device.Enabled = true;
                btnGetImage.Enabled = true;
                btnOpen_Device.Enabled = true;
                btnEnroll.Enabled = true;
                btnVerify.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = true;
                btnOpenImage.Enabled = true;

                tb_enroll_number.Enabled = true;
                tb_delete_number.Enabled = true;
            }
            else
            {
                btnClose_Device.Enabled = false;
                btnGetImage.Enabled = false;
                btnOpen_Device.Enabled = false;
                btnEnroll.Enabled = false;
                btnVerify.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = false;
                btnOpenImage.Enabled = false;

                tb_enroll_number.Enabled = false;
                tb_delete_number.Enabled = false;
            }
        }
        #endregion

        #region Set Command Parameter
        private byte[] SetCommandParameter(string NameCode, string Length, string ParameterType, string ParameterValue)
        {
            int count = 0;

            byte[] command = { 0x55, 0xAA, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00,
                               0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                               0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            command[4] = Convert.ToByte(Convert.ToInt16(NameCode, 16));         // cmd
            command[6] = Convert.ToByte(Convert.ToInt16(Length, 16));           // length
            command[8] = Convert.ToByte(Convert.ToInt16(ParameterType, 16));    // parameter type
            command[9] = Convert.ToByte(Convert.ToInt16(ParameterValue, 16));   // parameter value

            for (int i = 0; i < 24; i++)
            {
                count = count + Convert.ToInt16(command[i].ToString("X2"), 16);
            }

            string checkSum = count.ToString("X4");

            string checkSum1 = checkSum[0].ToString() + checkSum[1].ToString();
            string checkSum2 = checkSum[2].ToString() + checkSum[3].ToString();

            command[24] = Convert.ToByte(Convert.ToInt16(checkSum2, 16));
            command[25] = Convert.ToByte(Convert.ToInt16(checkSum1, 16));

            return command;
        }
        #endregion

        #region ToGrayBitmap
        public static Bitmap ToGrayBitmap(byte[] rawValues, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            int stride = bmpData.Stride;
            int offset = stride - width;
            IntPtr iptr = bmpData.Scan0;
            int scanBytes = stride * height;

            int posScan = 0, posReal = 0;
            byte[] pixelValues = new byte[scanBytes];

            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    pixelValues[posScan++] = rawValues[posReal++];
                }
                posScan += offset;
            }
            
            Marshal.Copy(pixelValues, 0, iptr, scanBytes);
            bmp.UnlockBits(bmpData);

            
            ColorPalette temPalette;
            //using (Bitmap tempBmp = new Bitmap(1, 1, PixelFormat.Format8bppIndexed))
            //{
            //    temPalette = tempBmp.Palette;
            //}
            Bitmap tempBmp = new Bitmap(1, 1, PixelFormat.Format8bppIndexed);
            temPalette = tempBmp.Palette;

            for (int i = 0; i < 256; i++)
            {
                temPalette.Entries[i] = Color.FromArgb(i, i, i);
            }

            bmp.Palette = temPalette;
            
            return bmp;
        }
        #endregion

        #region ByteArray to string
        private string ByteArrayToString(byte[] arrInput)
        {
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (int i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append("0x" + arrInput[i].ToString("X2") + ", ");
            }
            return sOutput.ToString();
        }
        #endregion    

        private void tb_enroll_number_MouseDown(object sender, MouseEventArgs e)
        {
            lb_message.ForeColor = Color.Red;
            lb_message.Text  = "Input specify template number in\n\n";
            lb_message.Text += "enroll with the range (1 - 48).";

            tb_delete_number.Text = "0";
        }

        private void tb_delete_number_MouseDown(object sender, MouseEventArgs e)
        {
            lb_message.ForeColor = Color.Red;
            lb_message.Text  = "Input range (0 - 48) value in\n";
            lb_message.Text += "delete function.\n\n";
            lb_message.Text += " 0 : delete all template  \n";
            lb_message.Text += "1-48 : specify template number";

            tb_enroll_number.Text = Convert.ToString(TemplateNumber);
        }

        OpenFileDialog openfiledialog;

        List<string> filePath = new List<string>();
        List<string> fileName = new List<string>();
        int fileCount;
        int listViewItemNumber = 0;

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "PNG Image|*.png";
            openfiledialog.Multiselect = true;
            openfiledialog.Title = "Open Image File";

            if (System.IO.Directory.Exists(imageFile))
            {
                openfiledialog.InitialDirectory = imageFile;
            }

            if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && openfiledialog.FileName != null)
            {

                fileCount = openfiledialog.FileNames.Count();

                if (fileCount > 0)
                {
                    listView.Focus();

                    for (int i = 0; i < fileCount; i++)
                    {
                        string filename = Path.GetFileName(openfiledialog.FileNames[i]);
                        string split_filename = filename.Substring(0, filename.Length - 4);

                        listView.Items.Add(split_filename);

                        filePath.Add(openfiledialog.FileNames[i]);
                        fileName.Add(split_filename);
                    }

                    listViewItemNumber += fileCount;

                    Console.WriteLine(listViewItemNumber);

                    for (int a = 0; a < listViewItemNumber; a++)
                    {
                        listView.Items[a].Focused = false;
                        listView.Items[a].Selected = false;
                    }

                    listView.Items[listViewItemNumber - fileCount].Focused = true;
                    listView.Items[listViewItemNumber - fileCount].Selected = true;
                    listView.Items[listViewItemNumber - fileCount].EnsureVisible();
                }
            }          
        }

        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {           
            if (listView.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listViewItemNumber; i++)
                {
                    if (listView.Items[i].Selected == true)
                    {
                        pb_showFile.Image = Image.FromFile(filePath[i]);

                        lb_filename.Text = fileName[i];
                    }
                }
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                listView.Items.Clear();
                filePath.Clear();
                fileName.Clear();
                listViewItemNumber = 0;
            }

            if (tabControl1.SelectedTab == tabPage2)
            {
                Console.WriteLine("tabControl_SelectedIndexChanged");               

                if (System.IO.Directory.Exists(imageFile))
                {                   
                    string[] file = System.IO.Directory.GetFiles(imageFile);

                    fileCount = file.Length;
                    Console.WriteLine("file length = " + file.Length);

                    for (int j = 0; j < fileCount; j++)
                    {
                        string filename = Path.GetFileName(file[j]);
                        if (filename == "Thumbs.db")
                        {
                            File.Delete(file[j]);
                            fileCount = fileCount - 1;
                        }                      
                    }

                    listView.Focus();

                    for (int i = 0; i < fileCount; i++)
                    {
                        string filename = Path.GetFileName(file[i]);
                        string split_filename = filename.Substring(0, filename.Length - 4);

                        listView.Items.Add(split_filename);

                        filePath.Add(file[i]);
                        fileName.Add(split_filename);
                    }

                    listViewItemNumber += fileCount;

                    //Console.WriteLine(listViewItemNumber);

                    for (int a = 0; a < listViewItemNumber; a++)
                    {
                        listView.Items[a].Focused = false;
                        listView.Items[a].Selected = false;
                    }

                    //listView.Items[listViewItemNumber - fileCount].Focused = true;
                    //listView.Items[listViewItemNumber - fileCount].Selected = true;
                    listView.Items[listViewItemNumber - 1].Focused = true;
                    listView.Items[listViewItemNumber - 1].Selected = true;
                    listView.Items[listViewItemNumber - 1].EnsureVisible();
                }
            }
        }
    }
}
