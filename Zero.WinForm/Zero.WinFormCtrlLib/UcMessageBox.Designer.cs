
namespace Zero.WinFormCtrlLib
{
    partial class UcMessageBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOne = new System.Windows.Forms.Button();
            this.btnTwo = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rtbMsg = new System.Windows.Forms.RichTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.picBoxImg = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImg)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.labTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 30);
            this.panel1.TabIndex = 0;
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Location = new System.Drawing.Point(3, 7);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(55, 17);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "Zero-{0}";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(375, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(22, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTwo);
            this.panel2.Controls.Add(this.btnOne);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 188);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 50);
            this.panel2.TabIndex = 1;
            // 
            // btnOne
            // 
            this.btnOne.Location = new System.Drawing.Point(322, 13);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(75, 23);
            this.btnOne.TabIndex = 0;
            this.btnOne.UseVisualStyleBackColor = true;
            // 
            // btnTwo
            // 
            this.btnTwo.Location = new System.Drawing.Point(241, 13);
            this.btnTwo.Name = "btnTwo";
            this.btnTwo.Size = new System.Drawing.Size(75, 23);
            this.btnTwo.TabIndex = 1;
            this.btnTwo.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.picBoxImg);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(119, 158);
            this.panel3.TabIndex = 2;
            // 
            // rtbMsg
            // 
            this.rtbMsg.BackColor = System.Drawing.Color.SkyBlue;
            this.rtbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMsg.Location = new System.Drawing.Point(119, 30);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.ReadOnly = true;
            this.rtbMsg.Size = new System.Drawing.Size(281, 158);
            this.rtbMsg.TabIndex = 3;
            this.rtbMsg.Text = "";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // picBoxImg
            // 
            this.picBoxImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxImg.Image = global::Zero.WinFormCtrlLib.Properties.Resources.MssageInfo;
            this.picBoxImg.InitialImage = global::Zero.WinFormCtrlLib.Properties.Resources.MssageInfo;
            this.picBoxImg.Location = new System.Drawing.Point(0, 0);
            this.picBoxImg.Name = "picBoxImg";
            this.picBoxImg.Size = new System.Drawing.Size(119, 158);
            this.picBoxImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBoxImg.TabIndex = 0;
            this.picBoxImg.TabStop = false;
            // 
            // UcMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbMsg);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UcMessageBox";
            this.Size = new System.Drawing.Size(400, 238);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTwo;
        private System.Windows.Forms.Button btnOne;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox picBoxImg;
        private System.Windows.Forms.RichTextBox rtbMsg;
        private System.Windows.Forms.ImageList imageList1;
    }
}
