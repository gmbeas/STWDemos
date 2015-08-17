using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GadgetPackager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        string zipFilePath;
        string zipFileName;
        string zipFileNameTemp;
        string zipFullName;
        System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
        Timer timer = new Timer();
        List<string> buildFiles = new List<string>();
        bool shiftPressed = false;
          
        private void Form1_Load(object sender, EventArgs e)
        {
            // Clear the text box, this may be a retry
            TextBoxLog.Text = String.Empty;
            WriteMessage("Commence Gadget Build Process", true);
            WriteMessage(new string('-', 50), true);
            ProgressBar.Value = 0;
            // Create the required filenames etc.
            BuildFileNames();
            ProgressBar.Value = 5;
            // Delete the existing temp file
            WriteMessage(String.Empty, true);
            WriteMessage("Remove Existing temporary build file: ");
            if (File.Exists((zipFilePath + ("\\" + zipFileNameTemp))))
            {
                WriteMessage("Found.", true);
                File.Delete((zipFilePath + ("\\" + zipFileNameTemp)));
            }
            else
            {
                WriteMessage("Not Found.", true);
            }
            ProgressBar.Value = 10;

            // Locate all the build files
            getBuildFiles();
            ProgressBar.Value = 15;
            // Display the Build Queue
            WriteMessage(String.Empty, true);
            WriteMessage("Build Queue Contains the following files;", true);
            foreach (string item in buildFiles)
            {
                WriteMessage(item, true);
            }
            WriteMessage((buildFiles.Count.ToString + " item(s)."), true);
            ProgressBar.Value = 20;
            // Generate Gadget
            buildGadget();
            WriteMessage(String.Empty, true);
            // Make / replace existing temp file the final one
            WriteMessage(("Creating final gadget file: " + zipFileName), true);
            File.Copy((zipFilePath + ("\\" + zipFileNameTemp)), (zipFilePath + ("\\" + zipFileName)), true);
            ProgressBar.Value = 95;
            // delete the old temporary build file
            WriteMessage(("Removing temporary gadget file: " + zipFileNameTemp), true);
            File.Delete((zipFilePath + ("\\" + zipFileNameTemp)));
            ProgressBar.Value = 100;
           
            WriteMessage(String.Empty, true);
            WriteMessage("Build Process completed.", true);
            WriteMessage(("Duration: "
                            + (stopWatch.ElapsedMilliseconds.ToString + "ms.")));
            WriteMessage(String.Empty, true);
            WriteMessage("Start Gadget Installation........", true);
            Process.Start(new string((zipFilePath + ("\\" + zipFileName))));
            ButtonReRun.Enabled = true;
            if (shiftPressed)
            {
                WriteMessage("Shift was pressed......not exiting.", true);
            }
            else
            {
                WriteMessage("Closing application", true);
                this.Close();
            }
        }


        private void WriteMessage(string Message)
        {
            // Write the message
            TextBoxLog.AppendText(Message);
            // move to the end
            TextBoxLog.SelectionStart = TextBoxLog.Text.Length;
            // Scroll to the current position
            TextBoxLog.ScrollToCaret();
        }

        private void WriteMessage(string Message, bool AddNewLine)
        {
            TextBoxLog.Focus();
            // Write the message
            WriteMessage(Message);
            // Write the new line / carriage return
            if (AddNewLine)
            {
                TextBoxLog.AppendText("\r\n");
            }
            TextBoxLog.SelectionStart = TextBoxLog.TextLength;
            TextBoxLog.SelectionLength = 0;
            // Scroll to the current position
            TextBoxLog.ScrollToCaret();
        }


    }
}
