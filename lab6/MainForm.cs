using IronBarCode;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Barcode
{
    public partial class MainForm : Form
    {
        GeneratedBarcode barcode;
        GeneratedBarcode qrcode;
        PdfWriter writer;

        public MainForm()
        {
            InitializeComponent();

            qrcode = BarcodeWriter.CreateBarcode("test", BarcodeWriterEncoding.QRCode);
            QRPb.Image = qrcode.Image;

            barcode = BarcodeWriter.CreateBarcode("test", BarcodeWriterEncoding.Code128);
            barcodePb.Image = barcode.Image;
        }

        private void encodeBtn_Click(object sender, EventArgs e)
        {
            var text = stringTextBox.Text;

            qrcode = BarcodeWriter.CreateBarcode(text, BarcodeWriterEncoding.QRCode);
            QRPb.Image = qrcode.Image;

            barcode = BarcodeWriter.CreateBarcode(text, BarcodeWriterEncoding.Code128);
            barcodePb.Image = barcode.Image;
        }

        private void btnDecodeBarcode_click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                var path = openDialog.FileName;
                BarcodeResult result = BarcodeReader.QuicklyReadOneBarcode(path);

                if (result != null)
                    decodedStringTextBox.Text = result.Text;
                else
                    MessageBox.Show("Cannot decode file.\nTry another format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveBarcode_click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                barcode.SaveAsPng(saveDialog.FileName);
            }
        }

        private void btnSaveQR_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                qrcode.SaveAsPng(saveDialog.FileName);
            }
        }

        private void btnSaveMultToPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                writer = new PdfWriter(saveDialog.FileName);
                var document = new Document(new PdfDocument(writer));
                var barcode_img = (Image) barcode.Image.Clone();
                var img = new iText.Layout.Element.Image(ImageDataFactory.Create(barcode_img, null));

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        img.SetFixedPosition(j * 140 + 25, i * 100 + 25);
                        img.Scale(0.5f, 0.2f);
                        document.Add(img);
                    }
                }

                document.Close();
                writer.Close();
            }
        }

        private void btnSaveToPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                writer = new PdfWriter(saveDialog.FileName);
                var document = new Document(new PdfDocument(writer));
                var barcode_img = (Image) barcode.Image.Clone();
                var img = new iText.Layout.Element.Image(ImageDataFactory.Create(barcode_img, null));

                img.SetRelativePosition(0, 0, 0, 0);
                img.Scale(0.5f, 0.2f);
                document.Add(img);

                document.Close();
                writer.Close();
            }
        }
    }
}
