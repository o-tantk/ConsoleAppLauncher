namespace ConsoleAppLauncher
{
    partial class Form_Main
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_findApp = new System.Windows.Forms.Button();
            this.btn_launch = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tb_parameters = new System.Windows.Forms.TextBox();
            this.tb_appname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_findApp
            // 
            this.btn_findApp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_findApp.Location = new System.Drawing.Point(156, 11);
            this.btn_findApp.Name = "btn_findApp";
            this.btn_findApp.Size = new System.Drawing.Size(75, 23);
            this.btn_findApp.TabIndex = 1;
            this.btn_findApp.Text = "찾기";
            this.btn_findApp.UseVisualStyleBackColor = true;
            this.btn_findApp.Click += new System.EventHandler(this.btn_findApp_Click);
            // 
            // btn_launch
            // 
            this.btn_launch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_launch.Enabled = false;
            this.btn_launch.Location = new System.Drawing.Point(237, 11);
            this.btn_launch.Name = "btn_launch";
            this.btn_launch.Size = new System.Drawing.Size(75, 23);
            this.btn_launch.TabIndex = 2;
            this.btn_launch.Text = "실행";
            this.btn_launch.UseVisualStyleBackColor = true;
            this.btn_launch.Click += new System.EventHandler(this.btn_launch_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "실행 파일|*.exe";
            // 
            // tb_parameters
            // 
            this.tb_parameters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_parameters.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.tb_parameters.Location = new System.Drawing.Point(12, 40);
            this.tb_parameters.Name = "tb_parameters";
            this.tb_parameters.Size = new System.Drawing.Size(299, 21);
            this.tb_parameters.TabIndex = 3;
            this.tb_parameters.Text = "파라미터를 이곳에 입력하세요.";
            this.tb_parameters.Enter += new System.EventHandler(this.tb_parameters_Enter);
            this.tb_parameters.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_parameters_KeyDown);
            this.tb_parameters.Leave += new System.EventHandler(this.tb_parameters_Leave);
            // 
            // tb_appname
            // 
            this.tb_appname.AllowDrop = true;
            this.tb_appname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_appname.Enabled = false;
            this.tb_appname.Location = new System.Drawing.Point(13, 13);
            this.tb_appname.Name = "tb_appname";
            this.tb_appname.ReadOnly = true;
            this.tb_appname.Size = new System.Drawing.Size(135, 21);
            this.tb_appname.TabIndex = 0;
            this.tb_appname.DragDrop += new System.Windows.Forms.DragEventHandler(this.tb_appname_DragDrop);
            this.tb_appname.DragEnter += new System.Windows.Forms.DragEventHandler(this.tb_appname_DragEnter);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 71);
            this.Controls.Add(this.tb_parameters);
            this.Controls.Add(this.btn_launch);
            this.Controls.Add(this.btn_findApp);
            this.Controls.Add(this.tb_appname);
            this.Name = "Form_Main";
            this.Text = "프로그램 실행기";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Main_FormClosed);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_findApp;
        private System.Windows.Forms.Button btn_launch;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox tb_parameters;
        private System.Windows.Forms.TextBox tb_appname;
    }
}

