namespace Image_Viewer
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ImageBox = new PictureBox();
            Start = new Button();
            PathToFileBox = new TextBox();
            Number = new TextBox();
            PageForward = new Button();
            PageBack = new Button();
            PageNumberList = new ComboBox();
            Last = new Button();
            First = new Button();
            Error = new Label();
            ChangeTheme = new Button();
            zipFileLoader = new Panel();
            zipFileLoaderText = new Label();
            DeleteFileButton = new Button();
            GalleryList = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)ImageBox).BeginInit();
            zipFileLoader.SuspendLayout();
            SuspendLayout();
            // 
            // ImageBox
            // 
            ImageBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ImageBox.Location = new Point(18, 41);
            ImageBox.Name = "ImageBox";
            ImageBox.Size = new Size(709, 482);
            ImageBox.SizeMode = PictureBoxSizeMode.Zoom;
            ImageBox.TabIndex = 0;
            ImageBox.TabStop = false;
            ImageBox.WaitOnLoad = true;
            ImageBox.PreviewKeyDown += Form_KeyDown;
            // 
            // Start
            // 
            Start.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Start.Location = new Point(733, 463);
            Start.Name = "Start";
            Start.Size = new Size(128, 60);
            Start.TabIndex = 1;
            Start.Text = "Start";
            Start.UseVisualStyleBackColor = true;
            Start.Click += Start_Click;
            // 
            // PathToFileBox
            // 
            PathToFileBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            PathToFileBox.Location = new Point(733, 434);
            PathToFileBox.Name = "PathToFileBox";
            PathToFileBox.Size = new Size(128, 23);
            PathToFileBox.TabIndex = 2;
            PathToFileBox.Text = "Path to folder";
            PathToFileBox.KeyDown += Enter_KeyDown;
            PathToFileBox.MouseDown += TextBlock_MouseKey;
            // 
            // Number
            // 
            Number.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Number.Location = new Point(733, 316);
            Number.Name = "Number";
            Number.ReadOnly = true;
            Number.Size = new Size(128, 23);
            Number.TabIndex = 3;
            Number.Text = "---";
            // 
            // PageForward
            // 
            PageForward.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            PageForward.Location = new Point(800, 345);
            PageForward.Name = "PageForward";
            PageForward.Size = new Size(61, 32);
            PageForward.TabIndex = 4;
            PageForward.Text = ">";
            PageForward.UseVisualStyleBackColor = true;
            PageForward.Click += PageForward_Click;
            // 
            // PageBack
            // 
            PageBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            PageBack.Location = new Point(733, 345);
            PageBack.Name = "PageBack";
            PageBack.Size = new Size(61, 32);
            PageBack.TabIndex = 5;
            PageBack.Text = "<";
            PageBack.UseVisualStyleBackColor = true;
            PageBack.Click += PageBack_Click;
            // 
            // PageNumberList
            // 
            PageNumberList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PageNumberList.FormattingEnabled = true;
            PageNumberList.Location = new Point(733, 12);
            PageNumberList.Name = "PageNumberList";
            PageNumberList.Size = new Size(128, 23);
            PageNumberList.TabIndex = 6;
            PageNumberList.Text = "Pages";
            PageNumberList.SelectedIndexChanged += PageNumberList_SelectedIndexChanged;
            PageNumberList.KeyDown += Enter_KeyDown;
            // 
            // Last
            // 
            Last.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Last.Location = new Point(800, 383);
            Last.Name = "Last";
            Last.Size = new Size(61, 32);
            Last.TabIndex = 7;
            Last.Text = ">>";
            Last.UseVisualStyleBackColor = true;
            Last.Click += Last_Click;
            // 
            // First
            // 
            First.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            First.Location = new Point(733, 383);
            First.Name = "First";
            First.Size = new Size(61, 32);
            First.TabIndex = 8;
            First.Text = "<<";
            First.UseVisualStyleBackColor = true;
            First.Click += First_Click;
            // 
            // Error
            // 
            Error.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Error.AutoSize = true;
            Error.ForeColor = Color.Green;
            Error.Location = new Point(733, 76);
            Error.Name = "Error";
            Error.Size = new Size(24, 15);
            Error.TabIndex = 9;
            Error.Text = "OK";
            // 
            // ChangeTheme
            // 
            ChangeTheme.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ChangeTheme.Location = new Point(733, 41);
            ChangeTheme.Name = "ChangeTheme";
            ChangeTheme.Size = new Size(32, 32);
            ChangeTheme.TabIndex = 10;
            ChangeTheme.UseVisualStyleBackColor = true;
            ChangeTheme.Click += ChangeTheme_Click;
            // 
            // zipFileLoader
            // 
            zipFileLoader.AllowDrop = true;
            zipFileLoader.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            zipFileLoader.BackColor = SystemColors.Control;
            zipFileLoader.BorderStyle = BorderStyle.FixedSingle;
            zipFileLoader.Controls.Add(zipFileLoaderText);
            zipFileLoader.Location = new Point(733, 246);
            zipFileLoader.Name = "zipFileLoader";
            zipFileLoader.Size = new Size(128, 64);
            zipFileLoader.TabIndex = 11;
            zipFileLoader.DragDrop += zipFile_DragDrop;
            zipFileLoader.DragEnter += zipFile_DragEnter;
            zipFileLoader.DragLeave += zipFile_DragLeave;
            // 
            // zipFileLoaderText
            // 
            zipFileLoaderText.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            zipFileLoaderText.Location = new Point(-1, 0);
            zipFileLoaderText.Name = "zipFileLoaderText";
            zipFileLoaderText.Size = new Size(128, 62);
            zipFileLoaderText.TabIndex = 0;
            zipFileLoaderText.Text = "File.zip";
            zipFileLoaderText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DeleteFileButton
            // 
            DeleteFileButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            DeleteFileButton.Location = new Point(800, 209);
            DeleteFileButton.Name = "DeleteFileButton";
            DeleteFileButton.Size = new Size(61, 31);
            DeleteFileButton.TabIndex = 12;
            DeleteFileButton.Text = "Delete";
            DeleteFileButton.UseVisualStyleBackColor = true;
            DeleteFileButton.Click += DeleteFileButton_Click;
            // 
            // GalleryList
            // 
            GalleryList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GalleryList.FormattingEnabled = true;
            GalleryList.Location = new Point(18, 12);
            GalleryList.Name = "GalleryList";
            GalleryList.Size = new Size(709, 23);
            GalleryList.TabIndex = 13;
            GalleryList.Text = "Files";
            GalleryList.SelectedIndexChanged += GalleryList_SelectedIndexChanged;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 535);
            Controls.Add(GalleryList);
            Controls.Add(DeleteFileButton);
            Controls.Add(zipFileLoader);
            Controls.Add(ChangeTheme);
            Controls.Add(Error);
            Controls.Add(First);
            Controls.Add(Last);
            Controls.Add(PageNumberList);
            Controls.Add(PageBack);
            Controls.Add(PageForward);
            Controls.Add(Number);
            Controls.Add(PathToFileBox);
            Controls.Add(Start);
            Controls.Add(ImageBox);
            KeyPreview = true;
            Name = "Form";
            Text = "Form1";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)ImageBox).EndInit();
            zipFileLoader.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Start;
        public TextBox PathToFileBox;
        public PictureBox ImageBox;
        private TextBox Number;
        private Button PageForward;
        private Button PageBack;
        private ComboBox PageNumberList;
        private Button Last;
        private Button First;
        private TextBox ErrorType;
        private Label Error;
        private Button ChangeTheme;
        private Panel zipFileLoader;
        private Label zipFileLoaderText;
        private Button DeleteFileButton;
        private ComboBox GalleryList;
    }
}
