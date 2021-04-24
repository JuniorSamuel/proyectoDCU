using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceId.Control.Ventanas;
using FaceId.Presentacion.Ventanas;

using AForge.Video;
using AForge.Video.DirectShow;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Modelo.Dao;
using System.Data.SQLite;

namespace FaceId.Control
{
    class CtlFrmInicio
    {
        //Ventana
        FrmInicio frmInicio;

        //Variables para captural video
        private Capture capturaVideo = null;
        private Image<Bgr, byte> image = null;        
        Mat frame = new Mat();

        CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
        Image<Bgr, byte> resulta = null;
        List<Image<Gray, byte>> compararRostro = new List<Image<Gray, byte>>();
        List<int> etiquetaRostro = new List<int>();
        Image<Gray, byte> gris = null;
        Image<Bgr, Byte> imagenResltado;

        bool imganesGuardada = false;
        private bool intentar = false;
        EigenFaceRecognizer reconocer;
        List<string> nombreRostro = new List<string>();
        Bitmap bitmap = null;
        int perosna;

        string path;
        
        

        public CtlFrmInicio(FrmInicio frmInicio)
        {
            this.frmInicio = frmInicio;
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            conn.Close();
            carpetaImagenes();
            frmInicio.Load += new EventHandler(init);
            frmInicio.Load += new EventHandler(inicialVideo);
            
            
        }

        private void init(object sender, EventArgs e)
        {
            VentanaOpciones(Fabrica.getVentana(Ventana.Inicio));
        }

        public void VentanaOpciones(UserControl panel)
        {
            //panel.Dock = DockStyle.Fill;
            panel.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            frmInicio.panel2.Controls.Add(panel);
        }

        private void inicialVideo(object sender, EventArgs e)
        {
            if (capturaVideo != null) capturaVideo.Dispose();
            capturaVideo = new Capture();

            Application.Idle += procesoReconocer;
        }

        private void procesoReconocer(object sender, EventArgs e)
        {
            if (capturaVideo != null && capturaVideo.Ptr != IntPtr.Zero)
            {
                //captural video
                capturaVideo.Retrieve(frame, 0);
                image = frame.ToImage<Bgr, byte>().Resize(frmInicio.picVideo.Width, frmInicio.Height, Inter.Cubic);

                //Detectar Rostro
                //Convertir a escala de grises
                Mat imagenGris = new Mat();
                CvInvoke.CvtColor(image, imagenGris, ColorConversion.Bgr2Gray);
                CvInvoke.EqualizeHist(imagenGris, imagenGris);

                Rectangle[] rostros = cascadeClassifier.DetectMultiScale(imagenGris, 1.1, 3, Size.Empty, Size.Empty);

                //if (rostros.Length > 0)
                //{
                    foreach (var rostro in rostros)
                    {
                //        imagenResltado = image.Convert<Bgr, Byte>();
                //        imagenResltado.ROI = rostro;


                //        Image<Gray, Byte> grayFaceResult = imagenResltado.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);
                //        CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                //        var result = reconocer.Predict(grayFaceResult);
                //        Debug.WriteLine(result.Label + ". " + result.Distance);
                        
                //        if (result.Label != -1 && result.Distance <2000)
                //        {
                //            CvInvoke.PutText(image, nombreRostro[result.Label], new Point(rostro.X - 2, rostro.Y - 2),
                //                FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                //            CvInvoke.Rectangle(image, rostro, new Bgr(Color.Green).MCvScalar, 2);
                //        }
                //        //here results did not found any know faces
                //        else
                //        {
                            CvInvoke.PutText(image, "Desconocido", new Point(rostro.X - 2, rostro.Y - 2),
                                FontFace.HersheyComplex, 1.0, new Bgr(Color.Blue).MCvScalar);
                            CvInvoke.Rectangle(image, rostro, new Bgr(Color.Blue).MCvScalar, 2);

                //        }
                    }
                    
                //}

                frmInicio.picVideo.Image = image.ToBitmap();
            }

            if (image != null)
                image.Dispose();
        }

        private void carpetaImagenes()
        {
            string path = Directory.GetCurrentDirectory() + @"\imagenes";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

       
    }
}
