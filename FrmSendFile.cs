using System.IO;
using System.Windows.Forms;
using Matrix;
using Matrix.Xmpp.Client;

namespace MiniClient
{
    public partial class FrmSendFile : Form
    {
        private string sid = "";
        private Jid _jid;
        private FileTransferManager fm;
        public FrmSendFile(FileTransferManager ftm, Jid jid)
        {
            InitializeComponent();

            fm = ftm;
            _jid = jid;

            Text = "File transfer: " + jid;

            fm.OnError += fm_OnError;
            fm.OnEnd += fm_OnEnd;
            fm.OnStart += fm_OnStart;
            fm.OnProgress += fm_OnProgress;
        }

        void fm_OnError(object sender, ExceptionEventArgs e)
        {
            var ex = e.Exception as FileTransferException;
            if (ex.Sid != sid)
                return;

            // file transfer failed because our contact went offline or some
            // other errror occured.
            MessageBox.Show("file transfer failed!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            cmdChooseFile.Enabled = cmdAbort.Enabled = cmdSend.Enabled = false;
        }

        void fm_OnEnd(object sender, FileTransferEventArgs e)
        {
            if (e.Sid != sid)
                return;

            MessageBox.Show("file transfer ended with success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        void fm_OnStart(object sender, FileTransferEventArgs e)
        {
            if (e.Sid != sid)
                return;
            /// file transfer started
        }

        void fm_OnProgress(object sender, FileTransferEventArgs e)
        {
            if (e.Sid != sid)
                return;

            progressBar.Value = (int) (((double)e.BytesTransmitted / (double)e.FileSize) * 100);
        }

        private void cmdChooseFile_Click(object sender, System.EventArgs e)
        {
            var of = new OpenFileDialog();
            if (of.ShowDialog() == DialogResult.OK)
            {
                lblFileName.Text = of.FileName;
                
                var fi = new FileInfo(of.FileName);
                lblSize.Text = Util.HumanReadableFileSize(fi.Length);

                cmdSend.Enabled = true;
            }
        }

        
        private void cmdSend_Click(object sender, System.EventArgs e)
        {
            sid = fm.Send(_jid, lblFileName.Text, txtDescription.Text);
            cmdSend.Enabled = cmdChooseFile.Enabled = false;
        }
    }
}