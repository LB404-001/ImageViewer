using System.IO;
using System.IO.Compression;

namespace Image_Viewer
{
    public partial class Form : System.Windows.Forms.Form
    {

        static string PathToFile;
        static string WorkingDir = "./galleries";
        static string filename;
        static Image Image;
        static int PageNumber = 0;
        static int CountOfPages;
        private static List<string> PageList;
        private static string[] files;
        private static string[] DirFormats = { ".zip" };
        private static bool IsDark = true;
        static string[] galleries;
        static bool ActiveGalleryListingOn = true;

        public Form()
        {
            InitializeComponent();
            ChangeTheme_Click(ChangeTheme, null);
            GalleryListing();
        }

        private void UpdateState()
        {
            if (ActiveGalleryListingOn)
            {
                GalleryListing();
            }
            PageNumberList.Text = PageNumber.ToString();
        }

        private void GalleryListing()
        {
            string str = "";
            //str = PathToFileBox.Text.Replace(WorkingDir + "\\", "");
            
            if (Directory.Exists(WorkingDir))
            {
                
                galleries = Directory.GetDirectories(WorkingDir);
                GalleryList.Items.Clear();
                
                if (galleries.Length != 0)
                {
                    for (int i = 0; i < galleries.Length; i++)
                    {
                        str = galleries[i].Replace(WorkingDir + "\\", "");
                        GalleryList.Items.Add(str);
                    }
                    
                }
                else
                {
                    Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                    Error.Text = "Working dir is empty\n now it's '" + WorkingDir + "'";
                }
                
            }
            else
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Working dir not exist\n now it's '" + WorkingDir + "'";
            }
        }

        private void Show()
        {
            try
            {
                files = Directory.GetFiles(PathToFile);
                CountOfPages = files.Length;

                for (int i = 1; i <= files.Length; i++)
                {
                    PageNumberList.Items.Add(i);
                }


                Number.Text = PageNumber.ToString() + " / " + CountOfPages.ToString();

                Image = Image.FromFile(files[PageNumber - 1]);

                ImageBox.Image = Image;
                ImageBox.Focus();
                Image = null;
                System.GC.Collect();
            }
            catch (IOException)
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Directory is empty\n or not exist";
            }
            catch (OutOfMemoryException)
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Out of memory or\n corrupted file";
            }
            catch
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Unknown Error";
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            PathToFile = PathToFileBox.Text;
            PageNumber = 1;
            Image img;

            //string t = PathToFile.Substring(PathToFile.Length - 4);
            int x = Array.IndexOf(DirFormats, PathToFile.Substring(PathToFile.Length - 4));

            if (x != -1)
            {
                int i = filename.Length - 1;
                while (i > 0 && filename[i] != '.')
                {
                    i--;
                }
                filename = filename.Substring(0, i);
                string dirpath = WorkingDir + @"\" + filename;
                try
                {
                    if (Directory.Exists(dirpath))
                    {
                        dirpath += "-New";
                    }
                    Directory.CreateDirectory(dirpath);
                }
                catch
                {
                    Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                    Error.Text = "Unknown Error when creating dir";
                }

                try
                {
                    ZipFile.ExtractToDirectory(PathToFile, dirpath);
                    PathToFile = dirpath;
                }
                catch
                {
                    Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                    Error.Text = "Unknown Error when unpacking";
                }
                UpdateState();
                string str = GalleryList.Items[GalleryList.Items.Count - 1].ToString();
                GalleryList.Text = str;

                Show();
            }
            else if (Directory.Exists(PathToFile))
            {
                Show();
            }
            else
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Format is not supported\n or directory not exist";
            }
            UpdateState();
        }

        private void PageNumberList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PageNumber = Convert.ToInt32(PageNumberList.SelectedIndex) + 1;
                ////PageNumberList.Text = Convert.ToString(PageNumber);
                //Number.Text = PageNumber.ToString() + " / " + CountOfPages.ToString();

                ////string[] a = files;
                ////int aa = PageNumber;

                //Image = Image.FromFile(files[PageNumber - 1]);
                //ImageBox.Image = Image;
                //Image = null;
                //ImageBox.Focus();
                //System.GC.Collect();
                Show();
            }
            catch (IOException)
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Directory is empty\n or not exist";
            }
            catch (OutOfMemoryException)
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Out of memory or\n corrupted file";
            }
            catch
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Unknown Error";
            }
            UpdateState();
        }

        private void PageForward_Click(object sender, EventArgs e)
        {
            try
            {
                if (PageNumber < CountOfPages)
                {
                    PageNumber++;
                    //Number.Text = PageNumber.ToString() + " / " + CountOfPages.ToString();

                    //Image = Image.FromFile(files[PageNumber - 1]);
                    //ImageBox.Image = Image;
                    //Image = null;
                    //ImageBox.Focus();
                    //System.GC.Collect();
                    Show();
                }
                
            }
            catch (IOException)
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Directory is empty\n or not exist";
            }
            catch (OutOfMemoryException)
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Out of memory or\n corrupted file";
            }
            catch
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Unknown Error";
            }
            UpdateState();
        }

        private void PageBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (PageNumber > 1)
                {
                    PageNumber--;
                    //Number.Text = PageNumber.ToString() + " / " + CountOfPages.ToString();

                    //Image = Image.FromFile(files[PageNumber - 1]);
                    //ImageBox.Image = Image;
                    //Image = null;
                    //ImageBox.Focus();
                    //System.GC.Collect();
                    Show();
                }
                
            }
            catch (IOException)
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Directory is empty\n or not exist";
            }
            catch (OutOfMemoryException)
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Out of memory or\n corrupted file";
            }
            catch
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Unknown Error";
            }
            UpdateState();
        }

        private void Last_Click(object sender, EventArgs e)
        {
            try
            {
                PageNumber = CountOfPages;
                //Number.Text = PageNumber.ToString() + " / " + CountOfPages.ToString();

                //Image = Image.FromFile(files[PageNumber - 1]);
                //ImageBox.Image = Image;
                //Image = null;
                //ImageBox.Focus();
                //System.GC.Collect();
                Show();
            }
            catch (IOException)
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Directory is empty\n or not exist";
            }
            catch (OutOfMemoryException)
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Out of memory or\n corrupted file";
            }
            catch
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Unknown Error";
            }
            UpdateState();
        }

        private void First_Click(object sender, EventArgs e)
        {
            try
            {
                PageNumber = 1;
                //Number.Text = PageNumber.ToString() + " / " + CountOfPages.ToString();

                //Image = Image.FromFile(files[PageNumber - 1]);
                //ImageBox.Image = Image;
                //Image = null;
                //ImageBox.Focus();
                //System.GC.Collect();
                Show();
            }
            catch (IOException)
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Directory is empty\n or not exist";
            }
            catch (OutOfMemoryException)
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Out of memory or\n corrupted file";
            }
            catch
            {
                Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                Error.Text = "Unknown Error";
            }
            UpdateState();
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (PathToFileBox.Focused)
                {
                    Start_Click(Start, null);
                }
                if (PageNumberList.Focused)
                {
                    Start_Click(Start, null);
                }
            }
            UpdateState();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void Form_KeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    PageBack_Click(PageForward, null);
                    e.IsInputKey = true;
                    break;
                case Keys.Right:
                    PageForward_Click(PageForward, null);
                    e.IsInputKey = true;
                    break;
            }
            UpdateState();
        }

        private void TextBlock_MouseKey(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PathToFileBox.Text = "";
            }
            UpdateState();
        }

        private void ChangeTheme_Click(object sender, EventArgs e)
        {
            if (IsDark)
            {
                Number.ForeColor = System.Drawing.Color.FromArgb(0xDCDCDC);
                PathToFileBox.ForeColor = System.Drawing.Color.FromArgb(0xDCDCDC);
                Start.ForeColor = System.Drawing.Color.FromArgb(0xDCDCDC);
                PageNumberList.ForeColor = System.Drawing.Color.FromArgb(0xDCDCDC);
                PageForward.ForeColor = System.Drawing.Color.FromArgb(0xDCDCDC);
                PageBack.ForeColor = System.Drawing.Color.FromArgb(0xDCDCDC);
                Last.ForeColor = System.Drawing.Color.FromArgb(0xDCDCDC);
                First.ForeColor = System.Drawing.Color.FromArgb(0xDCDCDC);
                GalleryList.ForeColor = System.Drawing.Color.FromArgb(0xDCDCDC);
                DeleteFileButton.ForeColor = System.Drawing.Color.FromArgb(0xDCDCDC);

                Number.BackColor = Color.FromArgb(31, 28, 28);
                PathToFileBox.BackColor = Color.FromArgb(31, 28, 28);
                Start.BackColor = Color.FromArgb(31, 28, 28);
                PageNumberList.BackColor = Color.FromArgb(31, 28, 28);
                PageForward.BackColor = Color.FromArgb(31, 28, 28);
                PageBack.BackColor = Color.FromArgb(31, 28, 28);
                Last.BackColor = Color.FromArgb(31, 28, 28);
                First.BackColor = Color.FromArgb(31, 28, 28);
                this.BackColor = Color.FromArgb(31, 28, 28);
                ChangeTheme.BackColor = Color.FromArgb(31, 28, 28);
                ChangeTheme.Image = Image.FromFile("Layer1.png");
                DeleteFileButton.BackColor = Color.FromArgb(31, 28, 28);
                GalleryList.BackColor = Color.FromArgb(31, 28, 28);
            }
            else
            {
                Number.ForeColor = System.Drawing.Color.FromArgb(0x000000);
                PathToFileBox.ForeColor = System.Drawing.Color.FromArgb(0x000000);
                Start.ForeColor = System.Drawing.Color.FromArgb(0x000000);
                PageNumberList.ForeColor = System.Drawing.Color.FromArgb(0x000000);
                PageForward.ForeColor = System.Drawing.Color.FromArgb(0x000000);
                PageBack.ForeColor = System.Drawing.Color.FromArgb(0x000000);
                Last.ForeColor = System.Drawing.Color.FromArgb(0x000000);
                First.ForeColor = System.Drawing.Color.FromArgb(0x000000);
                GalleryList.ForeColor = System.Drawing.Color.FromArgb(0x000000);
                DeleteFileButton.ForeColor = System.Drawing.Color.FromArgb(0x000000);

                Number.BackColor = Color.FromArgb(245, 240, 240);
                PathToFileBox.BackColor = Color.FromArgb(245, 240, 240);
                Start.BackColor = Color.FromArgb(245, 240, 240);
                PageNumberList.BackColor = Color.FromArgb(245, 240, 240);
                PageForward.BackColor = Color.FromArgb(245, 240, 240);
                PageBack.BackColor = Color.FromArgb(245, 240, 240);
                Last.BackColor = Color.FromArgb(245, 240, 240);
                First.BackColor = Color.FromArgb(245, 240, 240);
                this.BackColor = Color.FromArgb(245, 240, 240);
                ChangeTheme.BackColor = Color.FromArgb(245, 240, 240);
                ChangeTheme.Image = Image.FromFile("Layer2.png");
                DeleteFileButton.BackColor = Color.FromArgb(245, 240, 240);
                GalleryList.BackColor = Color.FromArgb(245, 240, 240);
            }
            IsDark = !IsDark;
            ImageBox.Focus();
            UpdateState();
        }

        private void zipFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            PathToFileBox.Text = files[0].ToString();
            //filename = files[0].ToString();
            files = files[0].ToString().Split(new char[] { '\\' });
            zipFileLoaderText.Text = files[files.Length - 1].ToString();
            filename = zipFileLoaderText.Text;
            UpdateState();
        }

        private void zipFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                zipFileLoaderText.Text = "Drop";
            }

        }

        private void zipFile_DragLeave(object sender, EventArgs e)
        {
            zipFileLoaderText.Text = "File.zip";
        }

        private void DeleteFileButton_Click(object sender, EventArgs e)
        {
            GalleryList.Text = "File";
            PathToFileBox.Text = "File";
            PageNumberList.Items.Clear();
            
            if (!string.IsNullOrEmpty(PathToFile))
            {
                ImageBox.Image.Dispose();
                ImageBox.Image = null;
                try
                {
                    Directory.Delete(Path.GetFullPath(PathToFile), true);
                }
                catch
                {
                    Error.ForeColor = System.Drawing.Color.FromArgb(0xDC143C);
                    Error.Text = "Error whed deleting\n Maybe file not exist";
                }
                UpdateState();
            }
            PageNumberList.Text = "0";
            zipFileLoaderText.Text = "File.zip";
        }

        private void GalleryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PathToFile = WorkingDir + "/" + GalleryList.Items[GalleryList.SelectedIndex].ToString();
            //GalleryList.Text = GalleryList.Items[GalleryList.SelectedIndex].ToString();
            string str = GalleryList.Items[GalleryList.SelectedIndex].ToString();
            PathToFileBox.Text = PathToFile;
            PageNumber = 1;
            //Show();
            //UpdateState();
            GalleryList.Text = str;
            PageNumber = 1;
            PageNumberList.Text = PageNumber.ToString();
            Show();
        }
    }
}
