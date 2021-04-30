using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using FaceId.Modelo.base_de_datos;
using FaceId.Modelo.Entidades;
using FaceId.Presentacion.Ventanas;
using Modelo.Dao;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FaceId.Control
{
    class CtlFrmInicio
    {

        #region Variables
        private static CtlFrmInicio Frm = null;
        FrmInicio frmInicio;
        public static Persona user = new Persona();
        public static bool captu = false;

        private Capture videoCapture = null;
        private Image<Bgr, Byte> currentFrame = null;
        Mat frame = new Mat();
        private bool facesDetectionEnabled = true;
        CascadeClassifier faceCasacdeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
        
        List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
        List<int> PersonsLabes = new List<int>();
        EigenFaceRecognizer recognizer;
        List<string> PersonsNames = new List<string>();

        private Persona persona = null;
        private string name;
        private string idLogin = null;
        private string path;
        private bool i = true;
        #endregion

        private CtlFrmInicio(FrmInicio frmInicio)
        {
            this.frmInicio = frmInicio;
            DataBase();
            carpetaImagenes();
            frmInicio.Load += new EventHandler(init);
            frmInicio.Load += new EventHandler(inicialVideo);
            frmInicio.timer1.Tick += new EventHandler(timer_tick);

        }

        public static CtlFrmInicio getCtlFrmInicio(FrmInicio frmInicio)
        {
            if (Frm == null)
            {
                Frm = new CtlFrmInicio(frmInicio);
            }
            return Frm;
        }
        public static CtlFrmInicio getCtlFrmInicio()
        {
            return Frm;
        }

        private void timer_tick(object sender, EventArgs e)
        {
            setVentana(Fabrica.getVentana(Ventana.NoLogin));
            i = true;
        }

        private void DataBase()
        {
            ConnectorSQLite.CreateTable();
        }

        private void init(object sender, EventArgs e)
        {
            setVentana(Fabrica.getVentana(Ventana.NoLogin));
        }

        public void setVentana(UserControl panel)
        {
            if (frmInicio.panel2.Controls.Count != 0) frmInicio.panel2.Controls.RemoveAt(0);

            //panel.Dock = DockStyle.Fill;
            panel.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            frmInicio.panel2.Controls.Add(panel);

        }

        private void inicialVideo(object sender, EventArgs e)
        {
            if (videoCapture != null) videoCapture.Dispose();
            videoCapture = new Capture();

            Application.Idle += procesoReconocer;
        }

        private void procesoReconocer(object sender, EventArgs e)
        {
            //Step 1: Video Capture
            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
                videoCapture.Retrieve(frame, 0);
                currentFrame = frame.ToImage<Bgr, Byte>().Resize(frmInicio.picVideo.Width, frmInicio.picVideo.Height, Inter.Cubic);

                //Step 2: Face Detection
                if (facesDetectionEnabled)
                {                    
                    Mat grayImage = new Mat();
                    CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);                    
                    CvInvoke.EqualizeHist(grayImage, grayImage);
                    Rectangle[] faces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                    
                    if (faces.Length > 0)
                    {
                        foreach (var face in faces)
                        {   
                            Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                            resultImage.ROI = face;                            

                            if (CtlFrmInicio.captu)
                            {                                
                                string path = Directory.GetCurrentDirectory() + @"\imagenes";
                                if (!Directory.Exists(path))
                                    Directory.CreateDirectory(path);                            

                                resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + CtlFrmInicio.user.cedula + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                            }

                            CtlFrmInicio.captu = false;

                            if (TrainImagesFromDir())
                            {
                                Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);
                                CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                                var result = recognizer.Predict(grayFaceResult);
                                
                                Debug.WriteLine(result.Label + ". " + result.Distance);
                                
                                if (result.Label != -1 && result.Distance < 1000)
                                {
                                    CvInvoke.PutText(currentFrame, user.nombre, new Point(face.X - 2, face.Y - 2),
                                        FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Green).MCvScalar, 2);
                                }                                
                                else
                                {
                                    CvInvoke.PutText(currentFrame, "Desconocido", new Point(face.X - 2, face.Y - 2),
                                        FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);
                                }
                            }
                        }
                    }
                }

                frmInicio.picVideo.Image = currentFrame.Bitmap;
            }

            if (currentFrame != null)
                currentFrame.Dispose();
        }
        private void carpetaImagenes()
        {
            path = Directory.GetCurrentDirectory() + @"\imagenes";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private bool TrainImagesFromDir()
        {
            int ImagesCount = 0;
            double Threshold = 2000;
            TrainedFaces.Clear();
            PersonsLabes.Clear();
            PersonsNames.Clear();
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\imagenes";
                string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    Image<Gray, byte> trainedImage = new Image<Gray, byte>(file).Resize(200, 200, Inter.Cubic);
                    CvInvoke.EqualizeHist(trainedImage, trainedImage);
                    TrainedFaces.Add(trainedImage);
                    PersonsLabes.Add(ImagesCount);
                    name = file.Split('\\').Last().Split('_')[0];
                    PersonsNames.Add(name);
                    ImagesCount++;
                    Debug.WriteLine(ImagesCount + ". " + name);

                }

                if (TrainedFaces.Count() > 0)
                {
                    recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);
                    recognizer.Train(TrainedFaces.ToArray(), PersonsLabes.ToArray());
                    frmInicio.timer1.Start();

                    if (i || idLogin != name)
                    {
                        PersonaDto dbPersona = new PersonaDto();
                        CtlFrmInicio.user = dbPersona.getPerosna(Int32.Parse(name));
                        setVentana(Fabrica.getVentana(Ventana.Login));
                        idLogin = name;
                        i = false;
                    }
                    return true;
                }
                else
                {
                    isTrained = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                isTrained = false;
                MessageBox.Show("Error in Train Images: " + ex.Message);
                return false;
            }

        }

    }
}
