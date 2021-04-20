﻿using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceId.Control
{
    class CtlFrmInicio
    {
        FrmInicio frmInicio;
        VideoCaptureDevice webCam;
        FilterInfoCollection filtro;

        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");


        public CtlFrmInicio(FrmInicio frmInicio)
        {
            this.frmInicio = frmInicio;
            frmInicio.Load += new EventHandler(inicialVideo);
        }

        private void inicialVideo(object sender, EventArgs e)
        {
            //Obtener las webcam del equipo
            filtro = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            webCam = new VideoCaptureDevice();
            webCam = new VideoCaptureDevice(filtro[0].MonikerString);
            webCam.NewFrame += Device_NewFrame;
            webCam.Start();
        }

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            Image<Bgr, byte> image = new Image<Bgr, byte>(bitmap);
            Rectangle[] rectangulo = cascadeClassifier.DetectMultiScale(image, 1.2, 1);
            foreach (Rectangle rectangle in rectangulo)
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Pen pen = new Pen(Color.Red, 1))
                    {
                        graphics.DrawRectangle(pen, rectangle);
                    }
                }
            }

            frmInicio.video.Image = bitmap;
        }
    }
}
