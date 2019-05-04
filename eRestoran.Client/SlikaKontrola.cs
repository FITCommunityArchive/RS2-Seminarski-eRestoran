using eRestoran.Client.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace eRestoran.Client
{
    public partial class SlikaKontrola : UserControl
    {

        public Image File { get; set; }
        private string _imagesFolderPath;
        private string imagesFolderPath
        {
            get { return _imagesFolderPath; }
            set { _imagesFolderPath = Path.GetFullPath("~/../../../Images/") + Guid.NewGuid().ToString().Substring(0, 5) + value; }
        }

        public SlikaKontrola()
        {
            InitializeComponent();
        }

        private void dodajSlikubutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "JPG(*.JPG)|*.jpg";
            if (f.ShowDialog() == DialogResult.OK)
            {
                File = Image.FromFile(f.FileName);
                imagesFolderPath = f.SafeFileName;
                ProizvodpictureBox.Image = File;
            }
        }
        public void setImage(string lokacijaSlike)
        {
            if (lokacijaSlike != null)
            {
                var sUrl = Resources.apiUrlDevelopment + lokacijaSlike;
                WebRequest req = WebRequest.Create(sUrl);

                WebResponse res = req.GetResponse();

                Stream imgStream = res.GetResponseStream();

                ProizvodpictureBox.Image = new Bitmap(Image.FromStream(imgStream), new Size(120, 100));
                imgStream.Close();
            }
            else
            {
                ProizvodpictureBox.ImageLocation = lokacijaSlike;
            }
        }

        public byte[] GetData()
        {
            return ImageToByteArray(ProizvodpictureBox.Image);
        }

        public void ClearImage()
        {
            ProizvodpictureBox.ResetText();
            ProizvodpictureBox.Image = null;
            ProizvodpictureBox.ImageLocation = string.Empty;
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public string SaveImage()
        {
            if (String.IsNullOrEmpty(imagesFolderPath))
                return ProizvodpictureBox.ImageLocation;

            var imageUrl = imagesFolderPath;
            ProizvodpictureBox.Image.Save(imageUrl);
            return imageUrl;
        }
    }
}
