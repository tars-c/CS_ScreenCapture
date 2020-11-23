
namespace NETF_ScreenCapture
{
	partial class Form1
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.metroListView1 = new MetroFramework.Controls.MetroListView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.화면전체캡쳐하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.metroContextMenu2 = new MetroFramework.Controls.MetroContextMenu(this.components);
			this.삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.metroButton1 = new MetroFramework.Controls.MetroButton();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.metroContextMenu1.SuspendLayout();
			this.metroContextMenu2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.metroListView1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 60);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(560, 370);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// metroListView1
			// 
			this.metroListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.metroListView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.metroListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.metroListView1.FullRowSelect = true;
			this.metroListView1.LargeImageList = this.imageList1;
			this.metroListView1.Location = new System.Drawing.Point(0, 270);
			this.metroListView1.Margin = new System.Windows.Forms.Padding(0);
			this.metroListView1.MultiSelect = false;
			this.metroListView1.Name = "metroListView1";
			this.metroListView1.OwnerDraw = true;
			this.metroListView1.Size = new System.Drawing.Size(560, 100);
			this.metroListView1.TabIndex = 2;
			this.metroListView1.UseCompatibleStateImageBehavior = false;
			this.metroListView1.UseSelectable = true;
			this.metroListView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.metroListView1_MouseClick);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(64, 64);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 70);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(560, 200);
			this.panel1.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.metroLabel1);
			this.panel3.Controls.Add(this.metroComboBox1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Margin = new System.Windows.Forms.Padding(0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(560, 70);
			this.panel3.TabIndex = 3;
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
			this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			this.metroLabel1.Location = new System.Drawing.Point(0, 0);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(42, 25);
			this.metroLabel1.TabIndex = 1;
			this.metroLabel1.Text = "0x0";
			this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// metroComboBox1
			// 
			this.metroComboBox1.FormattingEnabled = true;
			this.metroComboBox1.ItemHeight = 23;
			this.metroComboBox1.Items.AddRange(new object[] {
            "JPG로 저장하기",
            "PNG로 저장하기"});
			this.metroComboBox1.Location = new System.Drawing.Point(158, 3);
			this.metroComboBox1.Name = "metroComboBox1";
			this.metroComboBox1.Size = new System.Drawing.Size(187, 29);
			this.metroComboBox1.TabIndex = 2;
			this.metroComboBox1.UseSelectable = true;
			this.metroComboBox1.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(20, 60);
			this.panel2.Margin = new System.Windows.Forms.Padding(0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(560, 370);
			this.panel2.TabIndex = 1;
			// 
			// metroContextMenu1
			// 
			this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.화면전체캡쳐하기ToolStripMenuItem});
			this.metroContextMenu1.Name = "metroContextMenu1";
			this.metroContextMenu1.Size = new System.Drawing.Size(191, 48);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(190, 22);
			this.toolStripMenuItem2.Text = "보이는 영역 캡쳐하기";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// 화면전체캡쳐하기ToolStripMenuItem
			// 
			this.화면전체캡쳐하기ToolStripMenuItem.Name = "화면전체캡쳐하기ToolStripMenuItem";
			this.화면전체캡쳐하기ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.화면전체캡쳐하기ToolStripMenuItem.Text = "화면 전체 캡쳐하기";
			// 
			// metroContextMenu2
			// 
			this.metroContextMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.삭제ToolStripMenuItem});
			this.metroContextMenu2.Name = "metroContextMenu2";
			this.metroContextMenu2.Size = new System.Drawing.Size(99, 26);
			// 
			// 삭제ToolStripMenuItem
			// 
			this.삭제ToolStripMenuItem.Name = "삭제ToolStripMenuItem";
			this.삭제ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.삭제ToolStripMenuItem.Text = "삭제";
			// 
			// metroButton1
			// 
			this.metroButton1.Location = new System.Drawing.Point(216, 27);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new System.Drawing.Size(75, 23);
			this.metroButton1.TabIndex = 3;
			this.metroButton1.Text = "metroButton1";
			this.metroButton1.UseSelectable = true;
			this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click_1);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(600, 450);
			this.ContextMenuStrip = this.metroContextMenu1;
			this.Controls.Add(this.metroButton1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.panel2);
			this.Name = "Form1";
			this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Style = MetroFramework.MetroColorStyle.Green;
			this.Text = "Screen Capture";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
			this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.metroContextMenu1.ResumeLayout(false);
			this.metroContextMenu2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private System.Windows.Forms.Panel panel2;
		private MetroFramework.Controls.MetroComboBox metroComboBox1;
		private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem 화면전체캡쳐하기ToolStripMenuItem;
		private MetroFramework.Controls.MetroListView metroListView1;
		private System.Windows.Forms.ImageList imageList1;
		private MetroFramework.Controls.MetroContextMenu metroContextMenu2;
		private System.Windows.Forms.ToolStripMenuItem 삭제ToolStripMenuItem;
		private MetroFramework.Controls.MetroButton metroButton1;
		private System.Windows.Forms.Panel panel3;
	}
}

