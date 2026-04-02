using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading;
//using System.Threading.
using System.Windows.Forms;

namespace Better_Etch_O_Sketch
{
    public partial class Form1 : Form
    {
        SerialPort serialPort1 = new SerialPort();
        public Form1()
        {
            InitializeComponent();
            //PortCombo();
            GetQYAtBoards();
            ClearDrawing();
        }
        Color penColor = Color.Black;
        int penWidth = 1;

        bool isDrawing = false;
        Point PreviousPoint;
        bool trueClear = false;
        bool mouseDraw = true;
        //Program Logic----------------------------------------------------------------------------------------------------------------
        string[] Ports;
        void PortCombo()
        {
            Ports = SerialPort.GetPortNames();
            PortComboBox.Items.Clear();
            foreach (string r in Ports)
            {
                PortComboBox.Items.Add($"{r}");
            }
            if (PortComboBox.Items.Count > 0) 
            {
                PortComboBox.SelectedIndex = 0;
            }
        }
        void SerialConnect(string name)
        {
            serialPort1.Close();
            serialPort1.BaudRate = 115200;
            serialPort1.PortName = name;
            serialPort1.Parity = System.IO.Ports.Parity.None;
            //serialPort1.StopBits = System.IO.Ports.StopBits.None;
            try
            {
                serialPort1.Open();
                if (serialPort1.IsOpen)
                {
                    //MessageBox.Show($"{serialPort1.PortName} Connected Successfully");
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            //ConnectButton.Enabled = false;
        }
        byte[] SendData(byte[] data)
        {
            byte[] buffer = new byte[0];
            try
            {
                
                if (serialPort1.IsOpen)
                {
                    //flush old bytes from buffers
                    serialPort1.DiscardInBuffer();
                    serialPort1.DiscardOutBuffer();

                    //send command
                    serialPort1.Write(data, 0, data.Length);

                    //wait for response
                    Thread.Sleep(100);
                    //make the array the size of the input buffer
                    buffer = new byte[serialPort1.BytesToRead];
                    //actually read the input buffer
                    serialPort1.Read(buffer, 0, buffer.Length);
                }
                return buffer;
            }
            catch 
            {
                return buffer;
            }
        }

        void GetQYAtBoards() 
        {
            PortComboBox.Text = "";
            PortComboBox.Items.Clear();
            string[] names = SerialPort.GetPortNames();
            foreach (string name in names)
            {
                SerialConnect(name);
                if (IsQYAtBoardCheck()) 
                { 
                    PortComboBox.Items.Add(name);
                }
            }
            if (PortComboBox.Items.Count > 0)
            {
                PortComboBox.SelectedIndex = 0;
            }
            serialPort1.Close();
        }


        bool IsQYAtBoardCheck()
        {
            bool QYAt = false;
            byte[] QyAtSettings = { 0xf0 };
            byte[] ReadBuffer = SendData(QyAtSettings);
            if (ReadBuffer.Length == 64 && ReadBuffer[58] == 81 && ReadBuffer[59] == 121 && ReadBuffer[60] == 64)
            {
                //MessageBox.Show($"QY@ Board Connected  to {serialPort1.PortName}");
                QYAt = true;
            }
            return QYAt;
        }

        void WriteDigital(byte pins)
        {
            byte[] data = { 0x20, pins};
            SendData(data);
        }

        int ReadAnalogOne()
        {
            byte[] data = {0x51};
            byte[] response = SendData(data);
            if (response.Length == 2)
            {
                return (response[0] << 2) + (response[1] >> 6);
            }
            return -1;
        }
        int ReadAnalogTwo()
        {
            byte[] data = {0x52};
            byte[] response = SendData(data);
            if (response.Length == 2)
            {
                return  (response[0] << 2) + (response[1] >> 6) ;
            }
            return -1;
        }

        byte[] ReadAnalog(byte analogInputs)
        {
            byte command = 0x50;
            byte[] data = {command};
            byte[] response;
            int highByte;
            int lowByte;
            int value;
            analogInputs = (byte)(0x0F & analogInputs);
            command = (byte)(command | analogInputs);
            //Console.WriteLine($"{command:X2}");

            data[0] = command;
            while (true)
            {
                response = SendData(data);
                //foreach (byte b in response)
                //{
                //    Console.Write($"{b} ");
                //}
                //Console.WriteLine();
                highByte = response[0] << 2;
                lowByte = response[1] >> 6;
                value = highByte + lowByte;
                Console.WriteLine(value);
            }
            return response;
        }

        void UpdateStatus() 
        { 
            if (serialPort1.IsOpen) 
            {
                PortStatusLabel.Text = serialPort1.PortName;
            }
            else 
            {
                PortStatusLabel.Text = "None";
            }
        }

        private void SelectColor()
        {
            ColorDialog colorDialog1 = new ColorDialog();
            colorDialog1.ShowDialog();
            this.penColor = colorDialog1.Color;
        }

        private void DrawWaveform()
        {
            int s = 0;
            int c = 1;
            int t = 2;

            Bitmap bmp = new Bitmap(DisplayPictureBox.Width, DisplayPictureBox.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.Dispose();
            }
            DisplayPictureBox.Image = bmp;

            Graphics grid = Graphics.FromImage(DisplayPictureBox.Image);
            Pen thePen = new Pen(Color.Black, this.penWidth);
            Pen Pen1 = new Pen(Color.Red, this.penWidth);
            Pen Pen2 = new Pen(Color.Green, this.penWidth);
            Pen Pen3 = new Pen(Color.Blue, this.penWidth);

            for (int i = 1; i < 10; i++)
            {
                int h = DisplayPictureBox.Height/10;
                int w = DisplayPictureBox.Width/10;
                grid.DrawLine(thePen, i * w, 0, i * w, 10*h);
                grid.DrawLine(thePen, 0, i * h, 10*w, i * h);
                DisplayPictureBox.Invalidate();
            }

            WaveShape(s, Pen1);
            WaveShape(c, Pen2);
            WaveShape(t, Pen3);

            grid.Dispose();
            thePen.Dispose();
        }

        private void WaveShape(int waveShape, Pen draw)
        {
            int Amplitude = DisplayPictureBox.Height/2;
            double Frequency = (2 * Math.PI) / DisplayPictureBox.Width;
            int OffsetY = DisplayPictureBox.Height/2;
            string Text = "";
            int height = 0;
            Color color = Color.White;

            Graphics Wave = Graphics.FromImage(DisplayPictureBox.Image);

            PointF[] points = new PointF[DisplayPictureBox.Width];
            for (int x = 0; x < DisplayPictureBox.Width; x++)
            {
                double y = 0;
                if (waveShape == 0)
                {
                    y = Amplitude * Math.Sin(Frequency * x);
                    Text = "Sine Wave";
                    height = 420;
                    color = Color.Red;
                }

                if (waveShape == 1)
                {
                    y = Amplitude * Math.Cos(Frequency * x);
                    Text = "Cosine Wave";
                    height = 445;
                    color = Color.Green;
                }

                if (waveShape == 2)
                {
                    double raw = Math.Tan(Frequency * x);
                    if (raw > 10)
                    {
                        raw = 10;
                    }
                    if (raw < -10)
                    {
                        raw = -10;
                    }
                    y = Amplitude * raw;
                    Text = "Tangent Wave";
                    height = 470;
                    color = Color.Blue;
                }

                points[x] = new PointF(x, (float)(OffsetY - y));
            }

            Wave.DrawLines(draw, points);

            Graphics g = Graphics.FromImage(DisplayPictureBox.Image);
            Pen thePen = new Pen(Color.Cyan, 3);


            Font drawFont = new Font("Times New Roman", 18);
            SolidBrush drawBrush = new SolidBrush(color);

            g.DrawString(Text, drawFont, drawBrush, 0, height);

            g.Dispose();
            drawBrush.Dispose();

            draw.Dispose();
            Wave.Dispose();
        }
        private void Sketch(Point XY)
        {
            Graphics g = Graphics.FromImage(DisplayPictureBox.Image);
            Pen thePen = new Pen(this.penColor, this.penWidth);


            g.DrawLine(thePen, PreviousPoint, XY);
            PreviousPoint = XY;

            DisplayPictureBox.Invalidate();
            g.Dispose();
            thePen.Dispose();
        }

        private void ClearDrawing()
        {
            if (trueClear == true)
            {
                for (int i = 0; i < 10; i++)
                {
                    int xOffset = 10;
                    int yOffset = 10;
                    if (i == 1 || i == 3 || i == 5 || i == 7 || i == 9)
                    {
                        xOffset *= -1;
                        yOffset *= -1;
                    }
                    int y = this.Top;
                    int x = this.Left;
                    int NewY = 0;
                    int NewX = 0;

                    NewY = y + yOffset;
                    NewX = x + xOffset;

                    this.Top = NewY;
                    this.Left = NewX;

                    System.Threading.Thread.Sleep(70);
                }
            }
            Bitmap bmp = new Bitmap(DisplayPictureBox.Width, DisplayPictureBox.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.Dispose();
            }
            DisplayPictureBox.Image = bmp;

        }


        //Event Handler--------------------------------------------------------------------------------------------------------------
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            SerialConnect(PortComboBox.SelectedItem.ToString());
            //ReadAnalog(0x02);
            //while (true)
            //{
            //    Console.WriteLine($"{ReadAnalogOne().ToString().PadLeft(5)}{ReadAnalogTwo().ToString().PadLeft(5)}");
            //}
        }

        private void PortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectButton.Enabled = true;
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void AnalogTimer_Tick(object sender, EventArgs e)
        {
            Analog1StatusLabel.Text = ReadAnalogOne().ToString();
            Analog2StatusLabel.Text = ReadAnalogTwo().ToString();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                GetQYAtBoards();
            }
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            SelectColor();
        }

        private void WaveFormButton_Click(object sender, EventArgs e)
        {
            DrawWaveform();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            trueClear = true;
            ClearDrawing();
        }

        private void GraphicsDesign_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                SelectColor();
            }

        }
        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouseDraw == true)
            {
                isDrawing = true;
                PreviousPoint = e.Location;
            }
        }

        private void Picture_MouseMovement(object sender, MouseEventArgs e)
        {
            if (isDrawing == true && mouseDraw == true)
            {
                Point XY = e.Location;

                if (e.Button == MouseButtons.Left)
                {
                    Sketch(XY);
                }
            }
            if (e.Button == MouseButtons.Middle)
            {
                SelectColor();
            }
        }

        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Micah Spencer\n    RCET 3371\n    Spring 2026\n    Better Etch-O-Sketch Program\n    https://github.com/micahspencer-png/EtchOSketch.git");
        }

        private void MouseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MouseRadioButton.Checked == true) 
            { 
                mouseDraw = true;
            }
            if (ExternalRadioButton.Checked == true)
            {
                mouseDraw = false;
            }
        }
    }
}
