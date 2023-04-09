using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiuYifeng0310Project3CLSApp
{
    public partial class frmCreative : Form
    {
        private Icon m_info = new Icon(SystemIcons.Information, 40, 40);
        private Icon m_error = new Icon(SystemIcons.Error, 40, 40);
        private Icon m_ready = new Icon(SystemIcons.WinLogo, 40, 40);
        public frmCreative()
        {
            InitializeComponent();
        }

        private void tabSource_Click(object sender, EventArgs e)
        {

        }

        private void frmCreative_Load(object sender, EventArgs e)
        {
            txtSource.Text = "D:\\Creative\\Source\\";
            txtProcessedFile.Text = "D:\\Creative\\Processed\\";
            txtDest.Text = "D:\\Creative\\Destination\\";
            optGenerateLog.Checked = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Source
            if (!Directory.Exists(txtSource.Text))
            {
                errMessage.SetError(txtSource, "Invalid Source Directory");
                txtSource.Focus();
                tabControl1.SelectedTab = tabSource;
                return;
            }
            else
                errMessage.SetError(txtSource, "");


            //Dest
            if (!Directory.Exists(txtDest.Text))
            {
                errMessage.SetError(txtDest, "Invalid Destination Directory");
                txtDest.Focus();
                tabControl1.SelectedTab = tabDest;
                return;
            }
            else
                errMessage.SetError(txtDest, "");


            //ProcessedFile
            if (!Directory.Exists(txtProcessedFile.Text))
            {
                errMessage.SetError(txtProcessedFile, "Invalid Source Directory");
                txtProcessedFile.Focus();
                tabControl1.SelectedTab = tabSource;
                return;
            }
            else
                errMessage.SetError(txtProcessedFile,"");
            

            //watch dir
            watchDir.EnableRaisingEvents = true;
            watchDir.Path=txtSource.Text;


            //mnuNotify
            mnuNotify.Icon = m_ready;
            mnuNotify.Visible = true;
            this.ShowInTaskbar = false;
            this.Hide();
        }

        private void txtDest_KeyUp(object sender, KeyEventArgs e)
        {
            if (Directory.Exists(txtDest.Text))
            {
                txtDest.BackColor = Color.White;
            }
            else
                txtDest.BackColor = Color.Pink;
        }

        private void txtSource_KeyUp(object sender, KeyEventArgs e)
        {
            if (Directory.Exists(txtSource.Text))
            {
                txtSource.BackColor = Color.White;
            }
            else
                txtSource.BackColor = Color.Pink;
        }

        private void txtProcessedFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProcessedFile_KeyUp(object sender, KeyEventArgs e)
        {
            if (Directory.Exists(txtProcessedFile.Text))
            {
                txtProcessedFile.BackColor = Color.White;
            }
            else
                txtProcessedFile.BackColor= Color.Pink;
        }

        private void mnuConfigure_Click(object sender, EventArgs e)
        {
            mnuNotify.Visible = false;
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuNotify_DoubleClick(object sender, EventArgs e)
        {
            mnuNotify.Visible=false;
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void watchDir_Created(object sender, FileSystemEventArgs e)
        {
            watchDir.EnableRaisingEvents = false;
            mnuNotify.Icon = m_info;
            mnuNotify.Text = "Processed:" + e.Name;
        }
    }
}
