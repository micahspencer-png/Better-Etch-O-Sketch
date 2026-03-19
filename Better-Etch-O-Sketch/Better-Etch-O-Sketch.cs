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
        }

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
            IsQYAtBoardCheck();
            //ConnectButton.Enabled = false;
        }
        byte[] SendData(byte[] data)
        {
            byte[] buffer = new byte[0];
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

        void GetQYAtBoards() 
        {
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

        //Event Handler--------------------------------------------------------------------------------------------------------------
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (PortComboBox.SelectedItem == null)
            {
                MessageBox.Show("Select Port");
            }
            else
            {
                SerialConnect(PortComboBox.SelectedItem.ToString());
            }
            if (serialPort1.IsOpen) 
            {
                PortStatusLabel.Text = serialPort1.PortName;
            }
            else 
            {
                PortStatusLabel.Text = "None";
            }
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
    }
}
