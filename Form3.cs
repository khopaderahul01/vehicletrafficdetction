using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using System.Collections;
using Emgu.CV.CvEnum;
using Emgu.CV.VideoSurveillance;
using System.IO;
using System.Net;
using System.IO.Ports;
using System.Data.SqlClient;

namespace VideoCaptureDemo
{
    public partial class Form3 : Form
    {
        private Capture _capture1 = null;       

        Image<Bgr, Byte> frame;
        
        private IBGFGDetector<Bgr> _forgroundDetector;
        
        private static BlobTrackerAuto<Bgr> _tracker;
       
        private static MCvFont _font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_COMPLEX_SMALL, 1.0, 1.0);

        ArrayList rectCnt = new ArrayList();
      

        ArrayList rlrectCnt = new ArrayList();
       

        MemStorage stor = new MemStorage();
        
        Image<Bgr, Byte> framecopy;
       

        Boolean oneCam = true;
       
        int cam = 0;
        double webcam_frm_cnt = 0;
        double FrameRate = 0;
        double TotalFrames = 0;
        double Framesno = 0;
        
        double codec_double = 0;
        int one = 0;       
       
        string startupPath = Environment.CurrentDirectory;
        SqlConnection Connection = new SqlConnection("");
      
        public Form3()
        {
            InitializeComponent();
            SqlCommand cmd = new SqlCommand("", Connection);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            cmbSourceDest.DataSource = new BindingSource(dt, null);
            cmbSourceDest.DisplayMember = "SourceDestination";
            cmbSourceDest.ValueMember = "Id";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select Capture Method");
                button1.Enabled = true;
            }
            else
                if (button1.Text == "Play")
                {
                    button1.Enabled = false;
                    #region cameracapture
                    if (comboBox1.Text == "Capture From Camera")
                    {
                        try
                        {
                            _capture1 = null;
                            _capture1 = new Capture(0);
                            _capture1.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FPS, 30);
                            _capture1.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, 240);
                            _capture1.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, 320);

                            
                            webcam_frm_cnt = 0;
                            cam = 1;
                            Application.Idle += ProcessFrame;
                            button1.Text = "Stop";
                            comboBox1.Enabled = false;
                        }
                        catch (NullReferenceException excpt)
                        {
                            MessageBox.Show(excpt.Message);
                        }
                    }
                    #endregion cameracapture

                    #region filecapture
                    if (comboBox1.Text == "Capture From File")
                    {

                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                _capture1 = null;
                                String filepath = openFileDialog1.FileName;
                                _capture1 = new Capture(filepath);
                               
                                _capture1.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, 240);
                                _capture1.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, 320);

                                

                                FrameRate = _capture1.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FPS);
                                TotalFrames = _capture1.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_COUNT);
                                codec_double = _capture1.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FOURCC);
                                string s = new string(System.Text.Encoding.UTF8.GetString(BitConverter.GetBytes(Convert.ToUInt32(codec_double))).ToCharArray());
                                
                                cam = 0;
                                Application.Idle += ProcessFrame;
                                button1.Text = "Stop";
                                comboBox1.Enabled = false;
                            }
                            catch (NullReferenceException excpt)
                            {
                                MessageBox.Show(excpt.Message);
                            }
                            button1.Enabled = false;
                        }
                        else
                        {
                            button1.Enabled = true;
                        }
                    }
                    #endregion filecapture

                    
                }
                else
                    #region stopcapture
                    if (button1.Text == "Stop")
                    {
                        _capture1.Stop();
                        button1.Enabled = true;
                        Application.Idle -= ProcessFrame;

                        ReleaseData();
                        button1.Text = "Play";


                        


                        comboBox1.Enabled = true;
                       
                        pictureBox3.Image = Properties.Resources.blank;

                       

                        if (cam == 1)
                        {
                            _capture1.Dispose();
                            cam = 0;
                        }


                        rectCnt.Clear();
                        
                        rlrectCnt.Clear();
                       
                       

                    }
                    #endregion stopcapture

        }

        /// <summary>
        /// PROCESS EACH FRAME 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ProcessFrame(object sender, EventArgs arg)
        {

            try
            {
               
                    frame = _capture1.QueryFrame();
                    Framesno = _capture1.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_POS_FRAMES);
                

                framecopy = frame.Rotate(180, new Bgr());
               

                #region framming

                if (frame != null )
                {
                    

                    if (_forgroundDetector == null)
                    {
                        _forgroundDetector = new FGDetector<Bgr>(Emgu.CV.CvEnum.FORGROUND_DETECTOR_TYPE.FGD_SIMPLE);
                        //_forgroundDetector = new BGStatModel<Bgr>(frame, Emgu.CV.CvEnum.BG_STAT_TYPE.FGD_STAT_MODEL);
                        _tracker = new BlobTrackerAuto<Bgr>();
                    }

                    
                    _forgroundDetector.Update(frame);
                    Image<Gray, Byte> todetectF = FillHoles(_forgroundDetector.ForegroundMask);

                    

                    Image<Gray, Byte> todetect = todetectF.Rotate(180, new Gray(255));
                   

                    _tracker.Process(todetect.Convert<Bgr, Byte>(), todetect);
                    

                    {
                        Contour<Point> contours = todetect.FindContours(CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, RETR_TYPE.CV_RETR_LIST, stor);
                        

                        #region contours
                        while (contours != null)
                        {
                            if (contours.Area > 200)// && (contours.BoundingRectangle.Width > 50 && contours.BoundingRectangle.Width < 100) && contours.BoundingRectangle.Height > 200)
                            {
                                Rectangle rect = contours.BoundingRectangle;
                                rect.X = rect.X - 5;
                                rect.Y = rect.Y - 5;
                                rect.Height = (rect.Height + 10);
                                rect.Width = (rect.Width + 10);
                                Bitmap frame22 = framecopy.Bitmap;
                                
                                    framecopy.Draw(rect, new Bgr(Color.Red), 2);
                               
                                label1.Text = "Vehicle Count:" + (_tracker.Count);
                               
                                foreach (MCvBlob blob in _tracker)
                                {
                                    int blob_id = (blob.ID + 1);
                                   // framecopy.Draw(blob_id.ToString(), ref _font, Point.Round(blob.Center), new Bgr(Color.Red));
                                    
                                    if (Point.Round(blob.Center).X > rectangleShape2.Location.X)
                                    {
                                        if (!rectCnt.Contains(blob_id))
                                            rectCnt.Add(blob_id);

                                    }


                                }
                                label1.Text = "Vehicle Count:" + rectCnt.Count;
                                SqlCommand cmd = new SqlCommand("", Connection);
                                cmd.CommandType = CommandType.Text;
                                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                dap.Fill(dt);
                                //MessageBox.Show(contours.Area.ToString());
                            }
                            contours = contours.HNext;
                        }
                        #endregion contours

                       
                        
                        pictureBox3.Image = framecopy.ToBitmap();
                       

                    }
                    if (cam == 0)
                    {

                        double time_index = _capture1.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_POS_MSEC);
                        //Time_Label.Text = "Time: " + TimeSpan.FromMilliseconds(time_index).ToString().Substring(0, 8);

                        double framenumber = _capture1.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_POS_FRAMES);
                        // Frame_lbl.Text = "Frame: " + framenumber.ToString();

                    }

                    if (cam == 1)
                    {
                        // Frame_lbl.Text = "Frame: " + (webcam_frm_cnt++).ToString();
                    }
                }
                #endregion framming





            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.StackTrace);
            }
        }

        /// <summary>
        /// FLOOD FILL IN MASK IMAGE
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>

        private Image<Gray, byte> FillHoles(Image<Gray, byte> image)
        {
            var resultImage = image.CopyBlank();
            Gray white = new Gray(255);
            Gray black = new Gray(0);
            using (var mem = new MemStorage())
            {
                for (var contour = image.FindContours(
                    CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                    RETR_TYPE.CV_RETR_EXTERNAL,
                    mem); contour != null; contour = contour.HNext)
                {
                    if (contour.Area > 200)
                        resultImage.Draw(contour.BoundingRectangle, white, -1);
                    else
                        resultImage.Draw(contour.BoundingRectangle, black, -1);
                }
            }
            return resultImage;
        }

        /// <summary>
        /// RELEASE CAMERA/ FILE CAPTURE RESOURCE
        /// </summary>
        private void ReleaseData()
        {
            if (_capture1 != null)
                _capture1.Dispose();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mtsDataSet1.SourceDestinations' table. You can move, or remove it, as needed.
            this.sourceDestinationsTableAdapter.Fill(this.mtsDataSet1.SourceDestinations);

        }

    }
}
