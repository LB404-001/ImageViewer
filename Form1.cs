namespace Image_Viewer
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            ChangeTheme_Click(ChangeTheme, null);
        }
        static string PathToFile;
        static Image Image;
        static int PageNumber;
        static int CountOfPages;
        public static List<string> PageList;
        public static string[] files;
        public static bool IsDark = true;

        private void Start_Click(object sender, EventArgs e)
        {
            PathToFile = PathToFileBox.Text;
            PageNumber = 1;
            Image img;

            try
            {
                files = Directory.GetFiles(PathToFile);
                CountOfPages = files.Length;

                for (int i = 1; i <= files.Length; i++)
                {
                    PageNumberList.Items.Add(i);
                }


                Number.Text = PageNumber.ToString() + " / " + CountOfPages.ToString();

                Image = Image.FromFile(files[0]);

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

        private void PageNumberList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PageNumber = PageNumberList.SelectedIndex;
                Number.Text = PageNumber.ToString() + " / " + CountOfPages.ToString();

                Image = Image.FromFile(files[PageNumber - 1]);
                ImageBox.Image = Image;
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

        private void PageForward_Click(object sender, EventArgs e)
        {
            try
            {
                PageNumber++;
                Number.Text = PageNumber.ToString() + " / " + CountOfPages.ToString();

                Image = Image.FromFile(files[PageNumber - 1]);
                ImageBox.Image = Image;
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

        private void PageBack_Click(object sender, EventArgs e)
        {
            try
            {
                PageNumber--;
                Number.Text = PageNumber.ToString() + " / " + CountOfPages.ToString();

                Image = Image.FromFile(files[PageNumber - 1]);
                ImageBox.Image = Image;
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

        private void Last_Click(object sender, EventArgs e)
        {
            try
            {
                PageNumber = CountOfPages;
                Number.Text = PageNumber.ToString() + " / " + CountOfPages.ToString();

                Image = Image.FromFile(files[PageNumber - 1]);
                ImageBox.Image = Image;
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

        private void First_Click(object sender, EventArgs e)
        {
            try
            {
                PageNumber = 1;
                Number.Text = PageNumber.ToString() + " / " + CountOfPages.ToString();

                Image = Image.FromFile(files[PageNumber - 1]);
                ImageBox.Image = Image;
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
        }

        private void TextBlock_MouseKey(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PathToFileBox.Text = "";
            }
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

                Number.BackColor = Color.FromArgb(242, 242, 242);
                PathToFileBox.BackColor = Color.FromArgb(242, 242, 242);
                Start.BackColor = Color.FromArgb(242, 242, 242);
                PageNumberList.BackColor = Color.FromArgb(242, 242, 242);
                PageForward.BackColor = Color.FromArgb(242, 242, 242);
                PageBack.BackColor = Color.FromArgb(242, 242, 242);
                Last.BackColor = Color.FromArgb(242, 242, 242);
                First.BackColor = Color.FromArgb(242, 242, 242);
                this.BackColor = Color.FromArgb(242, 242, 242);
                ChangeTheme.BackColor = Color.FromArgb(242, 242, 242);
                ChangeTheme.Image = Image.FromFile("Layer2.png");
            }
            IsDark = !IsDark;
        }
    }
}
