namespace ApplicationControl
{
    partial class AppControlForm
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
            this.appControl1 = new ApplicationControl.AppControl();
            this.SuspendLayout();
            // 
            // appControl1
            // 
            this.appControl1.ExeName = "D:\\[00]Window\\Desktop\\all\\DeskTop\\unity\\gunshot.exe";
            this.appControl1.Location = new System.Drawing.Point(12, 12);
            this.appControl1.Name = "appControl1";
            this.appControl1.Size = new System.Drawing.Size(973, 601);
            this.appControl1.TabIndex = 0;
            // 
            // AppControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 625);
            this.Controls.Add(this.appControl1);
            this.Name = "AppControlForm";
            this.Text = "AppControlForm";
            this.ResumeLayout(false);

        }

        #endregion

        private AppControl appControl1;
    }
}

