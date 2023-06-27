using Aspose.PSD;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;
using Aspose.PSD.Sources;

namespace ImageWizardCore
{
    public class ImageWizard
    {
        #region Fields
        string m_pathToInput;

        string m_pathToOutput;

        string [] pathToInputImages;

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

        public void CreateSpriteShit(float imgWidth, float imgHeight, int CanvWidth, int CanvHeight,
            string[] imgpaths, bool resize = false)
        {
            var options = new PsdOptions();

            var source = CreatePsd(OutputName);

            options.Source = source;

            Image canvas = Image.Create(options, CanvWidth, CanvHeight);

            Graphics g = new Graphics(canvas);

            int count = imgpaths.Length;

            float x = 0, y = 0;

            for (int i = 0; (i < count) && y<=CanvHeight; i++)
            {
                var img = Image.Load(imgpaths[i]);

                if (resize)
                {
                    Resizer(imgWidth, imgHeight, img);
                }

                g.DrawImage(img,new PointF(x, y));

                x += imgWidth;

                if (x >= CanvWidth)
                {
                    x = 0;
                    y += imgHeight;
                }
            }

            canvas.Save();

            canvas.Dispose();
        }

        public FileCreateSource CreatePsd(string name)
        {
            return new FileCreateSource(m_pathToOutput + Path.DirectorySeparatorChar + name+".psd");
        }

        

        #endregion
    }
}