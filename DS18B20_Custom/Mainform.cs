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
* @brief      This is the main form (window) of the DS18B20 Config custom GUI. 
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
        the main Window's GUI controls. In this case it is the disable Check Box state for the 
        Splash Screen.<br>
        @code
            maximSplashScreenForm.disableCheckBoxValue = Properties.Settings.Default.disableSplashValue;
        @endcode <br>
                
        Finally, the code sets the application's title and version in the main Windows's title 
        bar and in the middle text region of the status bar.  It also shows (or hides) the 
        splash screen based on state of "Disable" checkbox.
                
        @param	sender	The sender of the event.
        @param	e	The arguments for the event.
        <br>
        ****************************************************************************/																		  
        private void Mainform_Load(object sender, EventArgs e)
        {
            /* Create delegate for reading data */
            this.mySerialDelegate = new ReadDelegate(ProcessInData);

            /* Create Splash Screen Form */
            maximSplashScreenForm = new SplashScreen("DS18B20 Config Custom", "Version 1.0", "Copyright Maxim Integrated Products", "",3);
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
        SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e) draws the main window.  
        The code in this event method gets called when serial port activity is sensed.  The code 
        attempts to perform a Readline() and send the result to delegate callback function, 
        ProcessInData, that has write privileges on the output text box called textBoxOutput.<br>
                       
        @param	sender	The sender of the event.
        @param	e	The arguments for the event.
        <br>
        ****************************************************************************/																		  
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                InputString = serialPort1.ReadLine();
                if (InputString != string.Empty)
                {
                    //OutputText.Invoke(this.mySerialDelegate, new Object[] { InputString });    // Calls the ProcessInData method
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
        a 1-Wire transaction, it will send the results to the output text box (textBoxOutput). <br>
                       
        @param[in] in_data.  This is a string read from the serial port to be processed.
        @pre	SerialPort1_DataReceived() calls this method. 
        <br>
        ****************************************************************************/																	  
        private void ProcessInData(string in_data)
        {
            // in_data contains all the information coming back from the MAX32630FTHR
            string versionNum;
            string results = "";

            if (in_data.Contains(Version))
            {
                versionNum = in_data.ToString();
                versionNum = versionNum.Replace("0", "");
                maximStatusStrip1.SectionDetails1.Text = "Firmware " + versionNum;
                return;
            }

            if (in_data.Contains("Normal Power"))
            {
            }

            // on a 1-Wire write operation, the in_data will contain the string "Wrote".  For this example, it will also contains the bytes written.
            // In this case, we are looking for evidence of a write scratchpad attempt, which starts with "0x4E".  
            if (in_data.Contains("Wrote") && in_data.Contains("0x4E"))
            {
                results = in_data.Substring(11, 6);
                results = results.Replace(" ", ""); // remove all spaces from the results
                textBoxOutput.AppendText("Wrote: " + results + "\r\n");
            }
            // On a 1-Wire read operation, the in_data will contain the string "Result:".  
            if (in_data.Contains("Result:"))
            {
                results = in_data.Substring(14, 8);
                textBoxOutput.AppendText("Read Back: " + results.Replace(" ","") + "\r\n");
            }
        }

        /**
        SerialPort1_ErrorReceived(object sender, SerialDataReceivedEventArgs e).  This event gets 
        called by the application when a serial port error is generated. It will show the message 
        "Error reading serial port" and close/disconnect the serial port if it is open<br>
                       
        @param	sender	The sender of the event.
        @param	e	The arguments for the event.
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
        @param	e	The arguments for the event.
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
        @param	e	The arguments for the event.
        <br>
        ****************************************************************************/												
        private void Mainform_Shown(object sender, EventArgs e)
        {
            maximStatusStrip1.SectionMessages.Text = "";


            if (serialPort1.IsOpen)
            {

                maximStatusStrip1.SectionStatus.Text = "Connected: " + serialPort1.PortName.ToString() + " @" + serialPort1.BaudRate.ToString();

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
        @param	e	The arguments for the event.
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
        @param	e	The arguments for the event.
        <br>
        ****************************************************************************/												
        private void ConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            USBform.ShowDialog();
            if (serialPort1.IsOpen)
            {

                maximStatusStrip1.SectionStatus.Text = "Connected: " + serialPort1.PortName.ToString() + " @" + serialPort1.BaudRate.ToString();

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
        @param	e	The arguments for the event.
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
        it is made up of the Splash Screen's disable check box checkmark value.
                              
        @param	sender	The sender of the event.
        @param	e	The arguments for the event.
        <br>
        ****************************************************************************/												
        private void Mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                serialPort1.Close();
                Properties.Settings.Default.disableSplashValue = maximSplashScreenForm.disableCheckBoxValue;
                Properties.Settings.Default.Save();
            }
            catch (System.IO.IOException ioerr)
            {
                MessageBox.Show("Error while closing: " + ioerr.Message.ToString());
            }
        }

        /**
        maximButtonWriteConfig_Click(object sender, EventArgs e).  This event gets 
        called by the application when the user clicks the Write Config button. It takes 
        the TH, TL and Resolution values that the user input into the textBoxInput 
        component as hexadecimal 2-digit values, and attempts to write them to the DS18B20.  
        See the DS18B20 Operation Example 2 in the data sheet on page 18:  
        https://datasheets.maximintegrated.com/en/ds/DS18B20.pdf.
        </br>
        It communicates by sending 3-digit ASCII codes that get translated to 1-Wire commands 
        by the firmware located here:  
        https://github.com/MaximIntegratedTechSupport/MAX32630FTHR_Raw_One_Wire_Interface
        The ASCII codes are available at the same URL as well.  See the "Decoding" section of 
        the Readme.md file for a description of them. After it successfully write, the 
        method will read back the scratchpad of the DS18B20 and display the pertinent 3 bytes.
        No CRC calculation takes place.
                           
        @param	sender	The sender of the event.
        @param	e	The arguments for the event
        <br>
        ****************************************************************************/												
        private void maximButtonWriteConfig_Click(object sender, EventArgs e)
        {
            string inputText = textBoxInput.Text.ToUpper(); // make input string upper case
            // make sure input text is valid
            if (textBoxInput.TextLength <6)
            {
                MessageBox.Show("Input Config text must be 6 hexadecimal digits!"); // make sure input text is 6 digits of hex.
                return;
            }
            // check for hexadecimal by converting hexadecimal string to a UInt64
            try
            {
                UInt64 hexcheck = Convert.ToUInt64(inputText, 16); // convert to base 16 the input string, which is 6 bytes or 48 bit (should fit in 64-bit integer)
            }
            catch (Exception err)
            {
                MessageBox.Show("Please input only hexadecimal digits!"); // make sure input text is 6 digits of hex.
                err.Data.Clear();
                textBoxInput.ResetText();
                return;
            }

            // write scratchpad (reset, skip rom, then send 0x4E write scratchpad command followed by data)
            serialPort1.WriteLine("Z"); // send a reset
            System.Threading.Thread.Sleep(10); // for .NET serial port help
            serialPort1.WriteLine("RSK"); // send skip rom
            System.Threading.Thread.Sleep(10);
            serialPort1.WriteLine("WWY" + "4E" + inputText); // send write scratchpad command of 0x4E + TH + TL + Resolution bytes
            System.Threading.Thread.Sleep(10);
            // copy scratchpad (reset, skip rom, then send 0x48 copy scratchpad command followed by strong pullup for at least 10ms)
            serialPort1.WriteLine("Z"); // send a reset
            System.Threading.Thread.Sleep(10);
            serialPort1.WriteLine("RSK"); // send skip rom
            System.Threading.Thread.Sleep(10);
            serialPort1.WriteLine("PWY" + "48");
            System.Threading.Thread.Sleep(15); // wait a little longer than 10ms
            serialPort1.WriteLine("PNO"); // turn off strong pullup
            // read scratchpad
            serialPort1.WriteLine("Z"); // send a reset
            System.Threading.Thread.Sleep(10);
            serialPort1.WriteLine("RSK"); // send skip rom
            System.Threading.Thread.Sleep(10);
            serialPort1.WriteLine("WWY" + "BE"); // send read scratchpad command of 0xBE
            System.Threading.Thread.Sleep(10);
            serialPort1.WriteLine("WRY" + "09"); // read back 8 bytes of scratchpad + CRC byte (making 9 bytes total)
        }

        /**
        textBoxInput_KeyPress(object sender, KeyPressEventArgs e). This event gets 
        called by the application when the user tries to enter text into the main 
        input text box "textBoxInput".  
                              
        @param	sender	The sender of the event.
        @param	e	The KeyPressEventArgs arguments for the event.
        <br>
        ****************************************************************************/
        private void textBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // quick way to help prevent input of characters other than hex.
            char c = e.KeyChar;

            if (c != '\b' && !((c <= 0x66 && c >= 61) || (c <= 0x46 && c >= 0x41) || (c >= 0x30 && c <= 0x39)))
            {
                e.Handled = true;
            }
        }
    }
}
