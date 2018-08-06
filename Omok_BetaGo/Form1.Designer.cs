namespace Omok
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.메뉴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.시작ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.무르기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.게임모드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.인vsComToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.com흑돌ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.com백돌ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.인vsPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Peru;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 638);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메뉴ToolStripMenuItem,
            this.설정ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(604, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 메뉴ToolStripMenuItem
            // 
            this.메뉴ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.시작ToolStripMenuItem,
            this.무르기ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.메뉴ToolStripMenuItem.Name = "메뉴ToolStripMenuItem";
            this.메뉴ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.메뉴ToolStripMenuItem.Text = "메뉴";
            // 
            // 시작ToolStripMenuItem
            // 
            this.시작ToolStripMenuItem.Name = "시작ToolStripMenuItem";
            this.시작ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.시작ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.시작ToolStripMenuItem.Text = "재시작(&N)";
            this.시작ToolStripMenuItem.Click += new System.EventHandler(this.시작ToolStripMenuItem_Click);
            // 
            // 무르기ToolStripMenuItem
            // 
            this.무르기ToolStripMenuItem.Name = "무르기ToolStripMenuItem";
            this.무르기ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.무르기ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.무르기ToolStripMenuItem.Text = "무르기(&Z)";
            this.무르기ToolStripMenuItem.Click += new System.EventHandler(this.무르기ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.종료ToolStripMenuItem.Text = "종료(&X)";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // 설정ToolStripMenuItem
            // 
            this.설정ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.게임모드ToolStripMenuItem});
            this.설정ToolStripMenuItem.Name = "설정ToolStripMenuItem";
            this.설정ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.설정ToolStripMenuItem.Text = "설정";
            // 
            // 게임모드ToolStripMenuItem
            // 
            this.게임모드ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.인vsComToolStripMenuItem,
            this.인vsPlayerToolStripMenuItem});
            this.게임모드ToolStripMenuItem.Name = "게임모드ToolStripMenuItem";
            this.게임모드ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.게임모드ToolStripMenuItem.Text = "게임모드";
            // 
            // 인vsComToolStripMenuItem
            // 
            this.인vsComToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.com흑돌ToolStripMenuItem,
            this.com백돌ToolStripMenuItem});
            this.인vsComToolStripMenuItem.Name = "인vsComToolStripMenuItem";
            this.인vsComToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.인vsComToolStripMenuItem.Text = "1인 (vs com)";
            // 
            // com흑돌ToolStripMenuItem
            // 
            this.com흑돌ToolStripMenuItem.Name = "com흑돌ToolStripMenuItem";
            this.com흑돌ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.com흑돌ToolStripMenuItem.Text = "Com-흑돌";
            this.com흑돌ToolStripMenuItem.Click += new System.EventHandler(this.com흑돌ToolStripMenuItem_Click);
            // 
            // com백돌ToolStripMenuItem
            // 
            this.com백돌ToolStripMenuItem.Checked = true;
            this.com백돌ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.com백돌ToolStripMenuItem.Name = "com백돌ToolStripMenuItem";
            this.com백돌ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.com백돌ToolStripMenuItem.Text = "Com-백돌";
            this.com백돌ToolStripMenuItem.Click += new System.EventHandler(this.com백돌ToolStripMenuItem_Click);
            // 
            // 인vsPlayerToolStripMenuItem
            // 
            this.인vsPlayerToolStripMenuItem.Name = "인vsPlayerToolStripMenuItem";
            this.인vsPlayerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.인vsPlayerToolStripMenuItem.Text = "2인 (vs player)";
            this.인vsPlayerToolStripMenuItem.Click += new System.EventHandler(this.인vsPlayerToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 662);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "베타고 ver0.019";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 메뉴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 시작ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 무르기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 게임모드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 인vsComToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 인vsPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem com흑돌ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem com백돌ToolStripMenuItem;
    }
}

