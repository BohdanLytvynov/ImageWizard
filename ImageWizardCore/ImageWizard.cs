
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;


namespace ImageWizardCore
{
    public class ImageWizard
    {
        #region Events

        public Action<int> OnImageProcessed;

        #endregion

        #region Fields
        string m_pathToInput;

        string m_pathToOutput;

        string[] pathToInputImages;

        #endregion

        #region Properties

        public string OutputName { get; set; }

        #endregion

        #region Ctor
        public ImageWizard(string pathToInput, string pathToOutput)
        {
            m_pathToInput = pathToInput;

            m_pathToOutput = pathToOutput;

            DirExistsOrCreate(pathToInput);

            DirExistsOrCreate(pathToOutput);

            pathToInputImages = Directory.GetFiles(pathToInput);

            OutputName = "Out1";
        }
        #endregion

        #region Methods

        public bool DirExistsOrCreate(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

                return false;
            }

            return true;
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public void Resizer(float imgWidth, float imgHeight, Image img)
        {
            img.Resize((int)imgWidth, (int)imgHeight);
        }

        public void CreateSpriteShitMultiThread(float imgWidth, float imgHeight, int CanvWidth, int CanvHeight,
            float horOffset = 0, float vertOffset = 0,
            bool resize = false, bool useDispaly = false)
        {
            //Calculate Propriate Thread Amount

            int count = pathToInputImages.Length;

            if (count <= 100)
            {
                CreateSpriteShit(imgWidth, imgHeight, CanvWidth, CanvHeight,
                horOffset, vertOffset,
                resize, useDispaly);

            }


        }

        public void CreateSpriteShit(float imgWidth, float imgHeight, int CanvWidth, int CanvHeight,
            float horOffset = 0, float vertOffset = 0,
            bool resize = false, bool useDispaly = false)
        {
            var options = new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha };

            var source = CreatePNG(OutputName, false);

            options.Source = source;

            Image canvas = Image.Create(options, CanvWidth, CanvHeight + 50);

            canvas.BackgroundColor = Color.Transparent;

            Graphics g = new Graphics(canvas);

            int count = pathToInputImages.Length;

            float x = 0, y = 50;

            for (int i = 0; (i < count) && y <= CanvHeight; i++)
            {
                Image img = Image.Load(pathToInputImages[i], new LoadOptions() { });

                img.BackgroundColor = Color.Transparent;

                if (resize)
                {
                    Resizer(imgWidth, imgHeight, img);
                }

                g.DrawImage(img, new PointF(x, y));

                x += imgWidth + horOffset;

                if (x >= CanvWidth)
                {
                    x = 0;
                    y += imgHeight + vertOffset;
                }

                if (useDispaly)
                {
                    OnImageProcessed.Invoke(i);
                }

            }

            canvas.Save();

            canvas.Dispose();
        }

        public FileCreateSource CreatePNG(string name, bool temporal)
        {
            return new FileCreateSource(m_pathToOutput + Path.DirectorySeparatorChar + name + ".png", temporal);
        }



        #endregion
    }
}