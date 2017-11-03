namespace WinformUnity
{
    partial class ContainerForm
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
            this.selectablePanel = new WinformUnity.SelectablePanel();
            this.SuspendLayout();
            // 
            // selectablePanel
            // 
            this.selectablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectablePanel.Location = new System.Drawing.Point(0, 0);
            this.selectablePanel.Name = "selectablePanel";
            this.selectablePanel.Size = new System.Drawing.Size(1024, 617);
            this.selectablePanel.TabIndex = 0;
            this.selectablePanel.TabStop = true;
            this.selectablePanel.Resize += new System.EventHandler(this.selectablePanel1_Resize);
            // 
            // ContainerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 617);
            this.Controls.Add(this.selectablePanel);
            this.Name = "ContainerForm";
            this.Text = "ContainerForm";
            this.Activated += new System.EventHandler(this.ContainerForm_Activated);
            this.Deactivate += new System.EventHandler(this.ContainerForm_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ContainerForm_FormClosed);
            this.Load += new System.EventHandler(this.ContainerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SelectablePanel selectablePanel;
    }
}

