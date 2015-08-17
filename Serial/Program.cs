using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;


namespace Serial
{
    class Program
    {

        public static string HEX2ASCII(string hex)
        {

            string res = String.Empty;

            for (int a = 0; a < hex.Length; a = a + 2)
            {

                string Char2Convert = hex.Substring(a, 2);

                int n = Convert.ToInt32(Char2Convert, 16);

                char c = (char)n;

                res += c.ToString();

            }

            return res;

        }



        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Debug.Print("Data Received:");
            Debug.Print(indata);
        }

      
        static void Main(string[] args)
        {

            var pp = HEX2ASCII("02");

            char[] chars = { 'a', 'z', '\x0007', '\x03FF' };
            foreach (char ch in chars)
            {
                try
                {
                    byte result = Convert.ToByte(ch);
                    Console.WriteLine("{0} is converted to {1}.", ch, result);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Unable to convert u+{0} to a byte.",
                                      Convert.ToInt16(ch).ToString("X4"));
                }

            }   
            //SerialPort sp = new SerialPort();

            //sp.PortName = "COM4";
            //sp.BaudRate = 115200;
            //sp.DataBits = 8;
            //sp.Parity = Parity.None;
            //sp.StopBits = StopBits.One;
            ////sp.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "N");
            ////sp.Handshake = (Handshake)Enum.Parse(typeof(Handshake), "8");
            ////sp.Parity = (Parity)Enum.Parse(typeof(Parity), "1");
            //sp.DtrEnable = true;
            //sp.RtsEnable = true; 
            //sp.WriteTimeout = 600;
            //sp.Open();

            //<0x02>0200|5000|0|0<0x03>

            //const string inputx = "0200|5000|0|0";

            //// Invoke GetBytes method.
            //// ... You can store this array as a field!
            //byte[] array = Encoding.ASCII.GetBytes(inputx);

            //var xx = new byte[array.Length + 3];
            //xx[0] = 0x02;
            //var cxon = 1;
            //for (int i = 0; i < array.Length; i++)
            //{
            //    xx[cxon] = array[i];

            //    cxon++;
            //}
            //xx[cxon] = 0x03;
            //xx[cxon + 1] = 0x0B;


            //string input = "0200|5000|0|0";
            //char[] values = input.ToCharArray();
            //var xxx = new byte[input.Length + 3];
            //xxx[0] = 0x02;
            //var xa = 1;
            //foreach (char letter in values)
            //{
            //    // Get the integral value of the character. 
            //    int value = Convert.ToInt32(letter);
            //    // Convert the decimal value to a hexadecimal value in string form. 
            //    string hexOutput = String.Format("{0:X}", value);
            //    char aaa = Convert.ToChar(hexOutput);
            //    //Console.WriteLine("Hexadecimal value of {0} is {1}", letter, hexOutput);
            //    xxx[xa] = Convert.ToByte(hexOutput.ToString());

            //    xa++;
            //}


            ////0x7c = |


            using (SerialPort port = new SerialPort("COM4", 115200, Parity.None, 8))
            {
                byte[] bytesToSend = new byte[7] { 0x02, 0x30, 0x38, 0x30, 0x30, 0x03, 0x0B };

                
                port.Open();
                port.WriteTimeout = 500;
                port.Write(bytesToSend, 0, 7);
                port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                Thread.Sleep(5000);
                port.Close();
            }


            ////var uu = "020800030B";

            //var aux = Convert.ToChar(0);
            //var xx = (char)02 + "0800" + (char)03;
            //var nnn = "02 30 38 30 30 03 0B";


            string input = "0800";
            char[] values = input.ToCharArray();
            foreach (char letter in values)
            {
                // Get the integral value of the character. 
                int value = Convert.ToInt32(letter);
                // Convert the decimal value to a hexadecimal value in string form. 
                string hexOutput = String.Format("{0:X}", value);
                Console.WriteLine("Hexadecimal value of {0} is {1}", letter, hexOutput);
            }

            //byte[] bytesToSend = new byte[7] { 0x02, 0, 8, 0, 0, 0x03, 0x0B };

            //byte[] c = new byte[] {
            //   0x02,
            //   0x00,
            //   0x08,
            //   0x00,
            //   0x00,
            //   0x03
            //};

            //char[] mass = new char[]{(char)02,(char)0, (char)8, (char)0, (char)0,(char)03};
            //var stx = (char) "STX";
            //var etx = (char) 03;
            //sp.Write(stx.ToString());
            //sp.Write("0");
            //sp.Write("8");
            //sp.Write("0");

           
          


            //sp.Write("0");

            //sp.Write(buff, 0, buff.Length);
            //sp.Write(buffer, 0, buffer.Length);


            //string command = "\x020800\x03";
            ////byte[] bytesToSend = Encoding.ASCII.GetBytes(command);
            //byte[] bytesToSend = Encoding.GetEncoding(1251).GetBytes(command);

            //sp.Write(bytesToSend, 0, bytesToSend.Length);
            //sp.Write(xx);

            //var data = HexStringToByteArray("\020800\03");

            var au = Convert.ToChar(0x02) + "0800" + Convert.ToChar(0x03);
            //sp.Write("\x020800\x03");

            //sp.Close();
           
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private static byte[] StrToByteArray(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }

        private static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }
       
    }
}
