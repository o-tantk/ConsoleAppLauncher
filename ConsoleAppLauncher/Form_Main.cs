using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;

namespace ConsoleAppLauncher
{
    public partial class Form_Main : Form
    {
        private string appPath = "";
        private bool isParametersEmpty = true;

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width * 2, this.Height);

            RegistryKey subkey = Registry.CurrentUser.OpenSubKey("Software\\ConsoleAppLauncher");
            if (subkey != null)
            {
                appPath = subkey.GetValue("AppPath").ToString();
                tb_appname.Text = Path.GetFileName(appPath);
                tb_appname.Enabled = true;
                btn_launch.Enabled = true;
                btn_launch.Select();

                string parameters = subkey.GetValue("Parameters").ToString();
                if (parameters != "")
                {
                    tb_parameters.Text = parameters;
                    tb_parameters.ForeColor = Color.Black;
                    isParametersEmpty = false;
                }
            }
            else
            {
                btn_findApp.Select();
            }
        }

        private void btn_findApp_Click(object sender, EventArgs e)
        {
            if (appPath != "")
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(appPath);
            }
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                appPath = openFileDialog.FileName;
                tb_appname.Text = Path.GetFileName(appPath);
                tb_appname.Enabled = true;
                btn_launch.Enabled = true;
                btn_launch.Select();
            }
        }

        private void btn_launch_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(appPath))
            {
                string parameters = isParametersEmpty ? "" : tb_parameters.Text;

                Process app = new Process();
                app.StartInfo.FileName = "cmd.exe";
                app.StartInfo.Arguments = "/C " + appPath + " " + parameters + "& pause";
                app.StartInfo.WorkingDirectory = Path.GetDirectoryName(appPath);

                app.Start();
            }
            else
            {
                MessageBox.Show("실행 파일이 존재하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

                appPath = "";
                tb_appname.Text = "";
                tb_appname.Enabled = false;
                btn_findApp.Select();
            }
        }

        private void tb_parameters_Enter(object sender, EventArgs e)
        {
            if (isParametersEmpty)
            {
                tb_parameters.Text = "";
                tb_parameters.ForeColor = Color.Black;
                isParametersEmpty = false;
            }
        }

        private void tb_parameters_Leave(object sender, EventArgs e)
        {
            if (tb_parameters.Text == "")
            {
                tb_parameters.Text = "파라미터를 이곳에 입력하세요.";
                tb_parameters.ForeColor = SystemColors.ScrollBar;
                isParametersEmpty = true;
            }
        }

        private void tb_parameters_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_launch.PerformClick();
            }
        }

        private void Form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (appPath == ""){
                Registry.CurrentUser.DeleteSubKey("Software\\ConsoleAppLauncher", false);
            }
            else
            {
                RegistryKey subkey = Registry.CurrentUser.OpenSubKey("Software\\ConsoleAppLauncher", true);
                if (subkey == null)
                {
                    subkey = Registry.CurrentUser.CreateSubKey("Software\\ConsoleAppLauncher");
                }

                subkey.SetValue("AppPath", appPath, RegistryValueKind.String);
                if (isParametersEmpty)
                {
                    subkey.SetValue("Parameters", "", RegistryValueKind.String);
                }
                else
                {
                    subkey.SetValue("Parameters", tb_parameters.Text, RegistryValueKind.String);
                }
            }
        }

        private void tb_appname_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])(e.Data.GetData(DataFormats.FileDrop));
            if (files.Length == 1 && Path.GetExtension(files[0]) == ".exe")
            {
                e.Effect = DragDropEffects.Link;
            }
        }

        private void tb_appname_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])(e.Data.GetData(DataFormats.FileDrop));
            if (files.Length == 1 && Path.GetExtension(files[0]) == ".exe")
            {
                appPath = files[0];
                tb_appname.Text = Path.GetFileName(appPath);
                tb_appname.Enabled = true;
                btn_launch.Enabled = true;
                btn_launch.Select();
            }
        }
    }
}
