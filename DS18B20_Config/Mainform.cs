/*******************************************************************************
* Copyright (C) Maxim Integrated Products, Inc., All rights Reserved.
* 
* This software is protected by copyright laws of the United States and
* of foreign countries. This material may also be protected by patent laws
* and technology transfer regulations of the United States and of foreign
* countries. This software is furnished under a license agreement and/or a
* nondisclosure agreement and may only be used or reproduced in accordance
* with the terms of those agreements. Dissemination of this information to
* any party or parties not specified in the license agreement and/or
* nondisclosure agreement is expressly prohibited.
*
* The above copyright notice and this permission notice shall be included
* in all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
* OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
* MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
* IN NO EVENT SHALL MAXIM INTEGRATED BE LIABLE FOR ANY CLAIM, DAMAGES
* OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
* ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
* OTHER DEALINGS IN THE SOFTWARE.
*
* Except as contained in this notice, the name of Maxim Integrated
* Products, Inc. shall not be used except as stated in the Maxim Integrated
* Products, Inc. Branding Policy.
*
* The mere transfer of this software does not imply any licenses
* of trade secrets, proprietary technology, copyrights, patents,
* trademarks, maskwork rights, or any other form of intellectual
* property whatsoever. Maxim Integrated Products, Inc. retains all
* ownership rights.
*******************************************************************************
*/

/**
* @file       Mainform.cs
* @brief      This is the main form (window) of the DS18B20 Config demo GUI 
*             program.
* @version    1.0
* @notes      Dependent files and compilers:
*             1. maximlogo_YGT_icon.ico -- icon for this GUI.
*             2. SerialUSBForm.cs -- The form/window that appears to connect 
*             the GUI to serial port.
*             3. SplashScreen.cs -- The form/window that displays Maxim's 
*             "Look and Feel" screen for 3 seconds at startup.
*             4. Compiler: Microsoft Visual Studio Professional 2017.
*****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaximStyle;

namespace DS18B20_MAX32630_Config
{
    public partial class Mainform : Form
    {
        SplashScreen maximSplashScreenForm;
        SerialUSBForm USBform;
        string InputString = "";
        string ROM_Compare = "RomID: ";
        string Alarm_Compare = "Active Alarms: ";
        string Version = "Version";
        List<string> KnownRomIDs = new List<string>();


        /* Delagates for Event Handling */
        public delegate void ReadDelegate(string in_data);
        public ReadDelegate mySerialDelegate;

        /**
        Mainform() is the Constructor for the entire Windows Application. <br>
		
        @note	This method instantiates Mainform
        ****************************************************************************/
        public Mainform()
        {
            InitializeComponent();
        }

        /**
        Mainform_Load(Object sender, EventArgs e) draws the main window.  The code in this 
        method sets up the form appropriately.  The splash screen form and the serial port 
        connection form both get instantiated here.  Also, the serial port delegate function 
        (callback) gets setup here -- this.mySerialDelegate = new ReadDelegate(ProcessInData);<br>
                               
        The application's state shall be read from Properties.Settings.Default and restored to 
        the main Window's GUI controls (such as screen position, user settings, etc).<br>
        @code
            maximSplashScreenForm.disableCheckBoxValue = Properties.Settings.Default.disableSplashValue;
        @endcode <br>
                
        Finally, the code sets the application's title and version in the main Windows's title 
        bar and in the middle text region of the status bar.  It also shows (or hides) the 
        splash screen based on state of "Disable" checkbox.
                
        @param	sender	The sender of the event.
        @param	e	The arguments for the event
        <br>
        ****************************************************************************/
        private void Mainform_Load(object sender, EventArgs e)
        {
            /* initialize resolution combo box on the main form */
            maximComboBoxResolution.SelectedIndex = 0;

            maximStatusStrip1.SectionDetails1.TextAlign = ContentAlignment.BottomCenter; 
            
            /* Create delegate for reading data */
            this.mySerialDelegate = new ReadDelegate(ProcessInData);

            /* Create Splash Screen Form */
            maximSplashScreenForm = new SplashScreen("DS18B20 Config", "Version 1.0", "Copyright Maxim Integrated Products", "",3);
            maximSplashScreenForm.disableCheckBoxValue = Properties.Settings.Default.disableSplashValue;
            maximSplashScreenForm.showOKButton(false);
            if (!maximSplashScreenForm.disableCheckBoxValue)
            {
               maximSplashScreenForm.ShowDialog();
            }

            /* Setup SerialUSB Form */
            USBform = new SerialUSBForm(serialPort1);
            USBform.ShowDialog();

            /* Subscribe to event DataReceived with the onDataReceived Function */
            serialPort1.DataReceived += this.SerialPort1_DataReceived;

            /* Initial Communication between GUI & FW */
            try
            {
                serialPort1.WriteLine("INIT");
            }
            catch(System.InvalidOperationException)
            {
                MessageBox.Show("You are not connected to a Serial Port!", "Serial Error");
                return;
            }
        }

        /**
        SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e) -- The code in this 
        event method gets called when serial port activity is sensed.  The code attempts to perform a 
        Readline() and send the result to delegate callback function, ProcessInData, that has write 
        privileges on the output text box called textBoxOutput.<br>
                       
        @param	sender	The sender of the event.
        @param	e	The arguments for the event
        <br>
        ****************************************************************************/
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                InputString = serialPort1.ReadLine();
                if (InputString != string.Empty)
                {
                    textBoxOutput.Invoke(this.mySerialDelegate, new Object[] { InputString });    // Calls the ProcessInData method
                }
            }
            catch (System.IO.IOException err)
            {
                err.Data.Clear();
                return;
            }
            catch (System.InvalidOperationException err)
            {
                err.Data.Clear();
                return;
            }
        }

        /**
        ProcessInData(string in_data) gets called when serial port activity is sensed and 
        the serial port event, SerialPort1_DataReceived(), is triggered. The code in this 
        method takes a line of incoming serial port characters and processes the information. It 
        detects if a firmware version string is coming back and writes to the status bar or if it is data from 
        a 1-Wire transaction, it will send to the output text box (textBoxOutput). <br>
                       
        @param[in] in_data.  This is a string read from the serial port to be processed.
        @pre	SerialPort1_DataReceived() calls this method. 
        <br>
        ****************************************************************************/
        private void ProcessInData(string in_data)
        {
            string RomId;
            string versionNum;
            bool AddToList = true;

            if (in_data.Contains(Version))
            {
                versionNum = in_data.ToString();
                versionNum = versionNum.Replace("\r", ""); // remove linefeed coming from FTHR
                versionNum = versionNum.Replace("0", "");
                maximStatusStrip1.SectionDetails1.TextAlign = ContentAlignment.MiddleCenter;
                maximStatusStrip1.SectionDetails1.Text = versionNum;
                return;
            }

            if (in_data.Contains("Normal Power"))
            {
            }

            textBoxOutput.AppendText($"{in_data}\r\n");

            if (in_data.Contains(ROM_Compare) || in_data.Contains(Alarm_Compare))
            {
                if(in_data.Contains(ROM_Compare))
                {
                    RomId = in_data.Replace(ROM_Compare, "");
                }
                else
                {
                    RomId = in_data.Replace(Alarm_Compare, "");
                }
                
                foreach (string item in KnownRomIDs)
                {
                    if (item == RomId)
                    {
                        AddToList = false;
                    }
                }

                if (AddToList)
                {
                    Dropdown_Rom_Ids.Items.Add(RomId);
                    KnownRomIDs.Add(RomId);
                }
                Dropdown_Rom_Ids.SelectedIndex = 0;
            }

            if(in_data.Contains("successful") || in_data.Contains("Operation Failed"))
            {
                textBoxOutput.AppendText("------------------------------------------------------------------------------------------\r\n");
            }
        }
        /**
        SerialPort1_ErrorReceived(object sender, SerialDataReceivedEventArgs e).  This event gets 
        called by the application when a serial port error is generated. It will show the message 
        "Error reading serial port" and close/disconnect the serial port if it is open<br>
                       
        @param	sender	The sender of the event.
        @param	e	The arguments for the event
        <br>
        ****************************************************************************/
        private void SerialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show("Error reading serial port");
            if(!serialPort1.IsOpen)
            {
                maximStatusStrip1.SectionStatus.Text = "Disconnected (Error Received)";
            }
        }

        /**
        SerialPort1_PinChanged(object sender, SerialPinChangedEventArgs e).  This event gets 
        called by the application when a serial port changes configuration unannounced. It will 
        show the message "Serial Pin Changed" and close/disconnect the serial port if it is open<br>
                              
        @param	sender	The sender of the event.
        @param	e	The arguments for the event
        <br>
        ****************************************************************************/
        private void SerialPort1_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            MessageBox.Show("Serial Pin Changed");
            if (!serialPort1.IsOpen)
            {
                maximStatusStrip1.SectionStatus.Text = "Disconnected (Pin Change)";
            }
        }

        /**
        MainForm_Shown(object sender, EventArgs e).  This event gets 
        called by the application after the Mainform_Load event but before the form 
        becomes visible. This is where the MaximStatusStrip gets updated with serial 
        port connection information, such as COM port number and baud rate.
                              
        @param	sender	The sender of the event.
        @param	e	The arguments for the event
        <br>
        ****************************************************************************/
        private void Mainform_Shown(object sender, EventArgs e)
        {
            maximStatusStrip1.SectionMessages.Text = "";


            if (serialPort1.IsOpen)
            {

                maximStatusStrip1.SectionStatus.Text = "Connected to " + serialPort1.PortName.ToString() + " @" + serialPort1.BaudRate.ToString();

            }
            else
            {
                maximStatusStrip1.SectionStatus.Text = "Disconnected";
                maximStatusStrip1.SectionDetails1.Text = "";
            }
        }

        /**
        ExitToolStripMenuItem_Click(object sender, EventArgs e).  This event gets 
        called by the application when the File -> Exit menu item gets clicked.
                              
        @param	sender	The sender of the event.
        @param	e	The arguments for the event
        <br>
        ****************************************************************************/
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /**
        ConnectToolStripMenuItem_Click(object sender, EventArgs e).  This event gets 
        called by the application when the menu item Device --> Connect gets clicked.
                              
        @param	sender	The sender of the event.
        @param	e	The arguments for the event
        <br>
        ****************************************************************************/
        private void ConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            USBform.ShowDialog();
            if (serialPort1.IsOpen)
            {

                maximStatusStrip1.SectionStatus.Text = "Connected to " + serialPort1.PortName.ToString() + " @" + serialPort1.BaudRate.ToString();

            }
            else
            {
                maximStatusStrip1.SectionStatus.Text = "Disconnected";
            }
        }

        /**
        AboutToolStripMenuItem_Click(object sender, EventArgs e).  This event gets 
        called by the application when the menu item Help --> About gets clicked.
                              
        @param	sender	The sender of the event.
        @param	e	The arguments for the event
        <br>
        ****************************************************************************/
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maximSplashScreenForm.showOKButton(true);
            maximSplashScreenForm.setDismissTime(100000); // set dismiss time to a very long time for the "About" click.
            maximSplashScreenForm.ShowDialog();
        }

        /**
        Mainform_FormClosing(object sender, FormClosingEventArgs e).  This event gets 
        called by the application when the user (or OS) attempts to close/exit the 
        application. This is where the state of the program gets saved.  In this case, 
        it is made up of the Splash Screen's disable radio box checkmark value.
                              
        @param	sender	The sender of the event.
        @param	e	The arguments for the event
        <br>
        ****************************************************************************/
        private void Mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
            Properties.Settings.Default.disableSplashValue = maximSplashScreenForm.disableCheckBoxValue;
            Properties.Settings.Default.Save();
        }

        /**
        maximComboBoxResolution_TextUpdate(object sender, EventArgs e).  This event gets 
        called by the application when the user tries to edit the Resolution drop down 
        combo box text and will replace it with "1F".
                              
        @param	sender	The sender of the event.
        @param	e	The arguments for the event
        <br>
        ****************************************************************************/
        private void maximComboBoxResolution_TextUpdate(object sender, EventArgs e)
        {
            maximComboBoxResolution.ResetText(); // do not allow user to edit combo box text or enter a new value.
            maximComboBoxResolution.Text = "1F";
        }

        /**
        maximButtonWriteConfig_Click(object sender, EventArgs e).  This event gets 
        called by the application when the user clicks the Write Config button. It takes 
        the TH, TL and Resolution values that the user input into the respective fields, and 
        attempt to write them to the DS18B20.  See the DS18B20 Operation Example 2 in the 
        data sheet on page 18:  https://datasheets.maximintegrated.com/en/ds/DS18B20.pdf.
        </br>
        It communicates by sending 3-digit ASCII codes that get translated to 1-Wire commands 
        by the firmware located here:  https://github.com/MaximIntegratedTechSupport/MAX32630FTHR_Raw_One_Wire_Interface
        The ASCII codes are available at the same URL as well.  See the "Decoding" section of 
        the Readme.md file for a description of them.
                           
        @param	sender	The sender of the event.
        @param	e	The arguments for the event
        <br>
        ****************************************************************************/
        private void maximButtonWriteConfig_Click(object sender, EventArgs e)
        {
            string TH = maximNumericUpDownTH.Value.ToString("X2");
            string TL = maximNumericUpDownTL.Value.ToString("X2");
            string Resolution = maximComboBoxResolution.Text;
            //textBoxOutput.AppendText("TH + TL + Resolution = " + TH + TL + Resolution + Environment.NewLine); //debug line
            // write scratchpad (reset, skip rom, then send 0x4E write scratchpad command followed by data)
            serialPort1.WriteLine("Z"); // send a reset
            System.Threading.Thread.Sleep(10); // for .NET serial port help
            serialPort1.WriteLine("RSK"); // send skip rom
            System.Threading.Thread.Sleep(10);
            serialPort1.WriteLine("WWY" + "4E" + TH + TL + Resolution); // send write scratchpad command of 0x4E + TH + TL + Resolution bytes
            System.Threading.Thread.Sleep(10);
            // copy scratchpad (reset, skip rom, then send 0x48 copy scratchpad command followed by strong pullup for at least 10ms)
            serialPort1.WriteLine("Z"); // send a reset
            System.Threading.Thread.Sleep(10);
            serialPort1.WriteLine("RSK"); // send skip rom
            System.Threading.Thread.Sleep(10);
            serialPort1.WriteLine("PWY" + "48");
            System.Threading.Thread.Sleep(15); // wait a little longer than 10ms
            serialPort1.WriteLine("PNO"); // turn off strong pullup
        }

        /**
        maximButtonReadConfig_Click(object sender, EventArgs e).  This event gets 
        called by the application when the user clicks the Read Config button. It reads 
        the scratchpad of the single DS18B20. The data coming from the serial port 
        indicating what was read gets re-directed to the output textbox. See the 
        DS18B20 Operation Example 2 in the data sheet on page 18 for more details:  
        https://datasheets.maximintegrated.com/en/ds/DS18B20.pdf.
        </br>
        It communicates by sending 3-digit ASCII codes that get translated to 1-Wire commands 
        by the firmware located here:  https://github.com/MaximIntegratedTechSupport/MAX32630FTHR_Raw_One_Wire_Interface
        The ASCII codes are available at the same URL as well.  See the "Decoding" section of 
        the Readme.md file for a description of them.
                           
        @param	sender	The sender of the event.
        @param	e	The arguments for the event
        <br>
        ****************************************************************************/
        private void maximButtonReadConfig_Click(object sender, EventArgs e)
        {
            // read scratchpad
            serialPort1.WriteLine("Z"); // send a reset
            System.Threading.Thread.Sleep(10);
            serialPort1.WriteLine("RSK"); // send skip rom
            System.Threading.Thread.Sleep(10);
            serialPort1.WriteLine("WWY" + "BE"); // send read scratchpad command of 0xBE
            System.Threading.Thread.Sleep(10);
            serialPort1.WriteLine("WRY" + "09"); // read back 8 bytes of scratchpad + CRC byte (making 9 bytes total)
        }
    }
}
