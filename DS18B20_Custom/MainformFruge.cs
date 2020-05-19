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

namespace MAX32630_One_Wire_Interface
{
    public partial class Mainform : Form
    {
        MaximSplashScreenForm Splashform;
        SerialUSBForm USBform;
        int ROM_Selection = -1;
        int Speed_Selection = 0;
        int Pullup_Selection = 0;
        int Prev_Pullup_Selection = 0;
        string OutputString = "";
        string InputString = "";
        string ROM_Compare = "RomID: ";
        string Alarm_Compare = "Active Alarms: ";
        string Version = "Version";
        string MatchRomID;
        List<string> KnownRomIDs = new List<string>();


        /* Delagates for Event Handling */
        public delegate void ReadDelegate(string in_data);
        public ReadDelegate mySerialDelegate;

        public Mainform()
        {
            InitializeComponent();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            /* Create delegate for reading data */
            this.mySerialDelegate = new ReadDelegate(ProcessInData);

            /* Create Splash Screen Form */
            Splashform = new MaximSplashScreenForm(3);
            Splashform.disableCheckBoxValue =Properties.Settings.Default.DisableSplashValue;
            Splashform.showOK_Click(false);
            Splashform.ShowDialog();

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

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                InputString = serialPort1.ReadLine();
                if (InputString != string.Empty)
                {
                    //OutputText.Invoke(this.mySerialDelegate, new Object[] { InputString });    // Calls the ProcessInData method
                }
            }
            catch (System.IO.IOException err)
            {
                return;
            }
            catch (System.InvalidOperationException err)
            {
                return;
            }
        }

        /* The function called by mySerialDelegate */
        private void ProcessInData(string in_data)
        {
            string RomId;
            string versionNum;
            bool AddToList = true;

            if (in_data.Contains(Version))
            {
                versionNum = in_data.ToString();
                versionNum = versionNum.Replace("0", "");
                maximStatusStrip1.SectionDetails1.Text = versionNum;
                return;
            }

            if (in_data.Contains("Normal Power"))
            {
            }

            //OutputText.AppendText($"{in_data}\r\n");

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
                //OutputText.AppendText("------------------------------------------------------------------------------------------\r\n");
            }
        }

        private void SerialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show("Error reading serial port");
            if(!serialPort1.IsOpen)
            {
                maximStatusStrip1.SectionStatus.Text = "Disconnected (Error Received)";
            }
        }

        private void SerialPort1_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            MessageBox.Show("Serial Pin Changed");
            if (!serialPort1.IsOpen)
            {
                maximStatusStrip1.SectionStatus.Text = "Disconnected (Pin Change)";
            }
        }

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


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Splashform.Disable_splash_screen_timer();
            Splashform.showOK_Click(true);
            Splashform.ShowDialog();
        }

   }
}
