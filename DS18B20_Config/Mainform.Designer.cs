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

namespace DS18B20_MAX32630_Config
{
   partial class Mainform
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Dropdown_Rom_Ids = new MaximStyle.MaximComboBox();
            this.maximStatusStrip1 = new MaximStyle.MaximStatusStrip();
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maximComboBoxResolution = new MaximStyle.MaximComboBox();
            this.maximButtonReadConfig = new MaximStyle.MaximButton();
            this.labelResolution = new System.Windows.Forms.Label();
            this.labelTL = new System.Windows.Forms.Label();
            this.labelTH = new System.Windows.Forms.Label();
            this.maximNumericUpDownTL = new MaximStyle.MaximNumericUpDown();
            this.maximGroupBox1 = new MaximStyle.MaximGroupBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.maximNumericUpDownTH = new MaximStyle.MaximNumericUpDown();
            this.maximButtonWriteConfig = new MaximStyle.MaximButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStripTop.SuspendLayout();
            this.maximGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.SerialPort1_ErrorReceived);
            this.serialPort1.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(this.SerialPort1_PinChanged);
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            // 
            // Dropdown_Rom_Ids
            // 
            this.Dropdown_Rom_Ids.BackColor = System.Drawing.Color.White;
            this.Dropdown_Rom_Ids.DropDownHeight = 200;
            this.Dropdown_Rom_Ids.DropDownWidth = 0;
            this.Dropdown_Rom_Ids.Location = new System.Drawing.Point(0, 0);
            this.Dropdown_Rom_Ids.Name = "Dropdown_Rom_Ids";
            this.Dropdown_Rom_Ids.Size = new System.Drawing.Size(0, 0);
            this.Dropdown_Rom_Ids.TabIndex = 0;
            this.Dropdown_Rom_Ids.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Dropdown_Rom_Ids.TextAlignDropDownList = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // maximStatusStrip1
            // 
            this.maximStatusStrip1.BackColor = System.Drawing.Color.White;
            this.maximStatusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.maximStatusStrip1.Location = new System.Drawing.Point(0, 699);
            this.maximStatusStrip1.Name = "maximStatusStrip1";
            this.maximStatusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.maximStatusStrip1.SectionsNumberOf = 3;
            this.maximStatusStrip1.SectionUseStatusProgressBar = false;
            this.maximStatusStrip1.Size = new System.Drawing.Size(1023, 28);
            this.maximStatusStrip1.TabIndex = 12;
            this.maximStatusStrip1.Text = "maximStatusStrip1";
            // 
            // menuStripTop
            // 
            this.menuStripTop.BackColor = System.Drawing.Color.White;
            this.menuStripTop.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.deviceToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStripTop.Size = new System.Drawing.Size(1023, 35);
            this.menuStripTop.TabIndex = 16;
            this.menuStripTop.Text = "menuStripTop";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // deviceToolStripMenuItem
            // 
            this.deviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem});
            this.deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
            this.deviceToolStripMenuItem.Size = new System.Drawing.Size(76, 29);
            this.deviceToolStripMenuItem.Text = "Device";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(161, 30);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.ConnectToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // maximComboBoxResolution
            // 
            this.maximComboBoxResolution.BackColor = System.Drawing.Color.White;
            this.maximComboBoxResolution.DropDownHeight = 200;
            this.maximComboBoxResolution.DropDownWidth = 0;
            this.maximComboBoxResolution.Font = new System.Drawing.Font("Arial", 8F);
            this.maximComboBoxResolution.Items.AddRange(new object[] {
            "1F",
            "3F",
            "5F",
            "7F"});
            this.maximComboBoxResolution.Location = new System.Drawing.Point(334, 219);
            this.maximComboBoxResolution.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maximComboBoxResolution.Name = "maximComboBoxResolution";
            this.maximComboBoxResolution.Size = new System.Drawing.Size(138, 26);
            this.maximComboBoxResolution.TabIndex = 14;
            this.maximComboBoxResolution.Text = "1F";
            this.maximComboBoxResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maximComboBoxResolution.TextAlignDropDownList = System.Windows.Forms.HorizontalAlignment.Left;
            this.maximComboBoxResolution.TextUpdate += new System.EventHandler(this.maximComboBoxResolution_TextUpdate);
            // 
            // maximButtonReadConfig
            // 
            this.maximButtonReadConfig.Location = new System.Drawing.Point(334, 433);
            this.maximButtonReadConfig.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maximButtonReadConfig.Name = "maximButtonReadConfig";
            this.maximButtonReadConfig.Size = new System.Drawing.Size(138, 62);
            this.maximButtonReadConfig.TabIndex = 11;
            this.maximButtonReadConfig.Text = "&Read Config";
            this.maximButtonReadConfig.UseVisualStyleBackColor = true;
            this.maximButtonReadConfig.Click += new System.EventHandler(this.maximButtonReadConfig_Click);
            // 
            // labelResolution
            // 
            this.labelResolution.AutoSize = true;
            this.labelResolution.Location = new System.Drawing.Point(358, 194);
            this.labelResolution.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(85, 20);
            this.labelResolution.TabIndex = 10;
            this.labelResolution.Text = "Resolution";
            // 
            // labelTL
            // 
            this.labelTL.AutoSize = true;
            this.labelTL.Location = new System.Drawing.Point(235, 194);
            this.labelTL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTL.Name = "labelTL";
            this.labelTL.Size = new System.Drawing.Size(27, 20);
            this.labelTL.TabIndex = 9;
            this.labelTL.Text = "TL";
            // 
            // labelTH
            // 
            this.labelTH.AutoSize = true;
            this.labelTH.Location = new System.Drawing.Point(86, 194);
            this.labelTH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTH.Name = "labelTH";
            this.labelTH.Size = new System.Drawing.Size(30, 20);
            this.labelTH.TabIndex = 8;
            this.labelTH.Text = "TH";
            // 
            // maximNumericUpDownTL
            // 
            this.maximNumericUpDownTL.Cursor = System.Windows.Forms.Cursors.Default;
            this.maximNumericUpDownTL.DecimalPlaces = 0;
            this.maximNumericUpDownTL.EnforceMultiple = false;
            this.maximNumericUpDownTL.Font = new System.Drawing.Font("Arial", 8F);
            this.maximNumericUpDownTL.Increment = 1;
            this.maximNumericUpDownTL.IncrementFloat = 0.5D;
            this.maximNumericUpDownTL.Location = new System.Drawing.Point(193, 219);
            this.maximNumericUpDownTL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maximNumericUpDownTL.Maximum = 255;
            this.maximNumericUpDownTL.MaximumFloat = 5D;
            this.maximNumericUpDownTL.Minimum = 0;
            this.maximNumericUpDownTL.MinimumFloat = 0D;
            this.maximNumericUpDownTL.Name = "maximNumericUpDownTL";
            this.maximNumericUpDownTL.Size = new System.Drawing.Size(105, 31);
            this.maximNumericUpDownTL.TabIndex = 6;
            this.maximNumericUpDownTL.Text = "maximNumericUpDown1";
            this.maximNumericUpDownTL.Thousands = false;
            this.maximNumericUpDownTL.Value = 0;
            this.maximNumericUpDownTL.ValueFloat = 0D;
            this.maximNumericUpDownTL.ValueType = MaximStyle.Common.Helpers.eValueType.Hex;
            // 
            // maximGroupBox1
            // 
            this.maximGroupBox1.BackgroundColor = System.Drawing.Color.White;
            this.maximGroupBox1.Controls.Add(this.textBoxOutput);
            this.maximGroupBox1.Location = new System.Drawing.Point(519, 136);
            this.maximGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maximGroupBox1.Name = "maximGroupBox1";
            this.maximGroupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maximGroupBox1.Size = new System.Drawing.Size(453, 433);
            this.maximGroupBox1.TabIndex = 5;
            this.maximGroupBox1.TabStop = false;
            this.maximGroupBox1.TitleEnable = false;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOutput.Location = new System.Drawing.Point(10, 29);
            this.textBoxOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(435, 382);
            this.textBoxOutput.TabIndex = 0;
            // 
            // maximNumericUpDownTH
            // 
            this.maximNumericUpDownTH.Cursor = System.Windows.Forms.Cursors.Default;
            this.maximNumericUpDownTH.DecimalPlaces = 0;
            this.maximNumericUpDownTH.EnforceMultiple = false;
            this.maximNumericUpDownTH.Font = new System.Drawing.Font("Arial", 8F);
            this.maximNumericUpDownTH.Increment = 1;
            this.maximNumericUpDownTH.IncrementFloat = 0.5D;
            this.maximNumericUpDownTH.Location = new System.Drawing.Point(53, 219);
            this.maximNumericUpDownTH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maximNumericUpDownTH.Maximum = 255;
            this.maximNumericUpDownTH.MaximumFloat = 5D;
            this.maximNumericUpDownTH.Minimum = 0;
            this.maximNumericUpDownTH.MinimumFloat = 0D;
            this.maximNumericUpDownTH.Name = "maximNumericUpDownTH";
            this.maximNumericUpDownTH.Size = new System.Drawing.Size(105, 31);
            this.maximNumericUpDownTH.TabIndex = 4;
            this.maximNumericUpDownTH.Text = "maximNumericUpDown1";
            this.maximNumericUpDownTH.Thousands = false;
            this.maximNumericUpDownTH.Value = 0;
            this.maximNumericUpDownTH.ValueFloat = 0D;
            this.maximNumericUpDownTH.ValueType = MaximStyle.Common.Helpers.eValueType.Hex;
            // 
            // maximButtonWriteConfig
            // 
            this.maximButtonWriteConfig.Location = new System.Drawing.Point(334, 308);
            this.maximButtonWriteConfig.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maximButtonWriteConfig.Name = "maximButtonWriteConfig";
            this.maximButtonWriteConfig.Size = new System.Drawing.Size(138, 62);
            this.maximButtonWriteConfig.TabIndex = 2;
            this.maximButtonWriteConfig.Text = "&Write Config";
            this.maximButtonWriteConfig.UseVisualStyleBackColor = true;
            this.maximButtonWriteConfig.Click += new System.EventHandler(this.maximButtonWriteConfig_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1022, 3);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(0, 660);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1022, 3);
            this.panel2.TabIndex = 19;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1023, 727);
            this.Controls.Add(this.maximGroupBox1);
            this.Controls.Add(this.maximButtonReadConfig);
            this.Controls.Add(this.maximComboBoxResolution);
            this.Controls.Add(this.labelResolution);
            this.Controls.Add(this.maximButtonWriteConfig);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.maximStatusStrip1);
            this.Controls.Add(this.labelTL);
            this.Controls.Add(this.maximNumericUpDownTL);
            this.Controls.Add(this.labelTH);
            this.Controls.Add(this.menuStripTop);
            this.Controls.Add(this.maximNumericUpDownTH);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mainform";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "DS18B20 Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mainform_FormClosing);
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.Shown += new System.EventHandler(this.Mainform_Shown);
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            this.maximGroupBox1.ResumeLayout(false);
            this.maximGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion
      private System.IO.Ports.SerialPort serialPort1;
      private MaximStyle.MaximComboBox Dropdown_Rom_Ids;
      private MaximStyle.MaximStatusStrip maximStatusStrip1;
      private System.Windows.Forms.MenuStrip menuStripTop;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem deviceToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
      private System.Windows.Forms.TextBox textBoxOutput;
      private MaximStyle.MaximButton maximButtonWriteConfig;
      private MaximStyle.MaximNumericUpDown maximNumericUpDownTH;
      private MaximStyle.MaximGroupBox maximGroupBox1;
      private MaximStyle.MaximNumericUpDown maximNumericUpDownTL;
      private System.Windows.Forms.Label labelResolution;
      private System.Windows.Forms.Label labelTL;
      private System.Windows.Forms.Label labelTH;
      private MaximStyle.MaximButton maximButtonReadConfig;
      private MaximStyle.MaximComboBox maximComboBoxResolution;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

