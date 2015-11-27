using System.IO;
using System.Threading;
using System.Windows.Forms;
using Matrix;
using Matrix.Xmpp.Client;

namespace MiniClient
{
    public partial class FrmReceiveFile : Form
    {
        private bool haveResponse;
        private FileTransferManager fm;
        private FileTransferEventArgs ftea;
        public FrmReceiveFile(FileTransferManager ftm, FileTransferEventArgs fea)
        {
            InitializeComponent();

            fm = ftm;
            ftea = fea;

            Text = "File transfer: " + ftea.Jid;
            
            lblSize.Text = Util.HumanReadableFileSize(ftea.FileSize);
            lblFileName.Text = ftea.Filename;
            lblDescription.Text = ftea.Description;

            fm.OnError += fm_OnError;
            fm.OnEnd += fm_OnEnd;
            fm.OnStart += fm_OnStart;
            fm.OnProgress += fm_OnProgress;
        }

        public void StartAccept()
        {
            while(!haveResponse)
            {
                Thread.Sleep(100);
                Application.DoEvents();
            }
            if (!ftea.Accept)
                Close();
        }

        void fm_OnError(object sender, ExceptionEventArgs e)
        {
            var ex = e.Exception as FileTransferException;
            if (ex.Sid != ftea.Sid)
                return;
            
            // file transfer failed because our contact went offline or some
            // other errror occured.
            MessageBox.Show("file transfer failed!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void fm_OnEnd(object sender, FileTransferEventArgs e)
        {
            if (e.Sid != ftea.Sid)
                return;

            MessageBox.Show("file transfer ended with success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        void fm_OnStart(object sender, FileTransferEventArgs e)
        {
            if (e.Sid != ftea.Sid)
                return;
            /// file transfer started
        }

        void fm_OnProgress(object sender, FileTransferEventArgs e)
        {
            if (e.Sid != ftea.Sid)
                return;
            
            progressBar.Value = (int) (((double)e.BytesTransmitted / (double)e.FileSize) * 100);
        }

        private void cmdAbort_Click(object sender, System.EventArgs e)
        {

            
        }

        private void cmdAccept_Click(object sender, System.EventArgs e)
        {
            ftea.Accept = true;
            haveResponse = true;
            cmdAccept.Enabled = false;
        }

        private void cmdRefuse_Click(object sender, System.EventArgs e)
        {
            ftea.Accept = false;
            haveResponse = true;
        }

        private void cmdSaveAs_Click(object sender, System.EventArgs e)
        {
            // set folder and filename
            var sf = new SaveFileDialog();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                ftea.Directory = Path.GetDirectoryName(sf.FileName);
                ftea.Filename = Path.GetFileName(sf.FileName);
            }
        }
    }
}