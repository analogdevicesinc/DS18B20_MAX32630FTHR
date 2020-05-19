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
            this.maximGroupBoxMain = new MaximStyle.MaximGroupBox();
            this.labelConfig = new System.Windows.Forms.Label();
            this.maximGroupBoxInput = new MaximStyle.MaximGroupBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.maximGroupBox1 = new MaximStyle.MaximGroupBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.maximButtonWriteConfig = new MaximStyle.MaximButton();
            this.menuStripTop.SuspendLayout();
            this.maximGroupBoxMain.SuspendLayout();
            this.maximGroupBoxInput.SuspendLayout();
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
            this.maximStatusStrip1.Location = new System.Drawing.Point(0, 237);
            this.maximStatusStrip1.Name = "maximStatusStrip1";
            this.maximStatusStrip1.SectionsNumberOf = 3;
            this.maximStatusStrip1.SectionUseStatusProgressBar = false;
            this.maximStatusStrip1.Size = new System.Drawing.Size(467, 22);
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
            this.menuStripTop.Size = new System.Drawing.Size(467, 24);
            this.menuStripTop.TabIndex = 16;
            this.menuStripTop.Text = "menuStripTop";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // deviceToolStripMenuItem
            // 
            this.deviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem});
            this.deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
            this.deviceToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.deviceToolStripMenuItem.Text = "Device";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.ConnectToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // maximGroupBoxMain
            // 
            this.maximGroupBoxMain.BackgroundColor = System.Drawing.Color.White;
            this.maximGroupBoxMain.Controls.Add(this.labelConfig);
            this.maximGroupBoxMain.Controls.Add(this.maximGroupBoxInput);
            this.maximGroupBoxMain.Controls.Add(this.maximGroupBox1);
            this.maximGroupBoxMain.Controls.Add(this.maximButtonWriteConfig);
            this.maximGroupBoxMain.Location = new System.Drawing.Point(0, 27);
            this.maximGroupBoxMain.Name = "maximGroupBoxMain";
            this.maximGroupBoxMain.Size = new System.Drawing.Size(467, 213);
            this.maximGroupBoxMain.TabIndex = 17;
            this.maximGroupBoxMain.TabStop = false;
            this.maximGroupBoxMain.Text = "maximGroupBox1";
            this.maximGroupBoxMain.TitleEnable = false;
            // 
            // labelConfig
            // 
            this.labelConfig.AutoSize = true;
            this.labelConfig.Location = new System.Drawing.Point(20, 75);
            this.labelConfig.Name = "labelConfig";
            this.labelConfig.Size = new System.Drawing.Size(64, 13);
            this.labelConfig.TabIndex = 18;
            this.labelConfig.Text = "Input Config";
            // 
            // maximGroupBoxInput
            // 
            this.maximGroupBoxInput.BackgroundColor = System.Drawing.Color.White;
            this.maximGroupBoxInput.Controls.Add(this.textBoxInput);
            this.maximGroupBoxInput.Location = new System.Drawing.Point(19, 91);
            this.maximGroupBoxInput.Name = "maximGroupBoxInput";
            this.maximGroupBoxInput.Size = new System.Drawing.Size(65, 21);
            this.maximGroupBoxInput.TabIndex = 17;
            this.maximGroupBoxInput.TabStop = false;
            this.maximGroupBoxInput.TitleEnable = false;
            // 
            // textBoxInput
            // 
            this.textBoxInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInput.Location = new System.Drawing.Point(6, 2);
            this.textBoxInput.MaxLength = 6;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(52, 17);
            this.textBoxInput.TabIndex = 16;
            this.textBoxInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInput_KeyPress);
            // 
            // maximGroupBox1
            // 
            this.maximGroupBox1.BackgroundColor = System.Drawing.Color.White;
            this.maximGroupBox1.Controls.Add(this.textBoxOutput);
            this.maximGroupBox1.Location = new System.Drawing.Point(234, 19);
            this.maximGroupBox1.Name = "maximGroupBox1";
            this.maximGroupBox1.Size = new System.Drawing.Size(202, 176);
            this.maximGroupBox1.TabIndex = 5;
            this.maximGroupBox1.TabStop = false;
            this.maximGroupBox1.TitleEnable = false;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOutput.Location = new System.Drawing.Point(6, 19);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(190, 139);
            this.textBoxOutput.TabIndex = 0;
            // 
            // maximButtonWriteConfig
            // 
            this.maximButtonWriteConfig.Location = new System.Drawing.Point(110, 75);
            this.maximButtonWriteConfig.Name = "maximButtonWriteConfig";
            this.maximButtonWriteConfig.Size = new System.Drawing.Size(92, 47);
            this.maximButtonWriteConfig.TabIndex = 2;
            this.maximButtonWriteConfig.Text = "&Write Config";
            this.maximButtonWriteConfig.UseVisualStyleBackColor = true;
            this.maximButtonWriteConfig.Click += new System.EventHandler(this.maximButtonWriteConfig_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(467, 259);
            this.Controls.Add(this.maximGroupBoxMain);
            this.Controls.Add(this.maximStatusStrip1);
            this.Controls.Add(this.menuStripTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mainform";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "DS18B20 Config Custom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mainform_FormClosing);
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.Shown += new System.EventHandler(this.Mainform_Shown);
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            this.maximGroupBoxMain.ResumeLayout(false);
            this.maximGroupBoxMain.PerformLayout();
            this.maximGroupBoxInput.ResumeLayout(false);
            this.maximGroupBoxInput.PerformLayout();
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
      private MaximStyle.MaximGroupBox maximGroupBoxMain;
      private System.Windows.Forms.TextBox textBoxOutput;
      private MaximStyle.MaximButton maximButtonWriteConfig;
      private MaximStyle.MaximGroupBox maximGroupBox1;
        private MaximStyle.MaximGroupBox maximGroupBoxInput;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label labelConfig;
    }
}

