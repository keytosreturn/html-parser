namespace htmlParser
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Panel inputContainer;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button parseButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Panel outputContainer;
        private System.Windows.Forms.RichTextBox htmlOutputBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.inputContainer = new System.Windows.Forms.Panel();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.parseButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.outputContainer = new System.Windows.Forms.Panel();
            this.htmlOutputBox = new System.Windows.Forms.RichTextBox();
            this.inputContainer.SuspendLayout();
            this.outputContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(40, 30);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(181, 37);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "HTML Parser";
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(175)))));
            this.subtitleLabel.Location = new System.Drawing.Point(43, 72);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(327, 19);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Введите URL-адрес или HTML-строку для анализа";
            // 
            // inputContainer
            // 
            this.inputContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(37)))), ((int)(((byte)(42)))));
            this.inputContainer.Controls.Add(this.urlTextBox);
            this.inputContainer.Location = new System.Drawing.Point(43, 110);
            this.inputContainer.Name = "inputContainer";
            this.inputContainer.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.inputContainer.Size = new System.Drawing.Size(560, 44);
            this.inputContainer.TabIndex = 2;
            // 
            // urlTextBox
            // 
            this.urlTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(37)))), ((int)(((byte)(42)))));
            this.urlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.urlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlTextBox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.urlTextBox.ForeColor = System.Drawing.Color.Gray;
            this.urlTextBox.Location = new System.Drawing.Point(12, 10);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(536, 20);
            this.urlTextBox.TabIndex = 0;
            this.urlTextBox.Text = "https://example.com";
            this.urlTextBox.Enter += new System.EventHandler(this.urlTextBox_Enter);
            this.urlTextBox.Leave += new System.EventHandler(this.urlTextBox_Leave);
            // 
            // parseButton
            // 
            this.parseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.parseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.parseButton.FlatAppearance.BorderSize = 0;
            this.parseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(82)))), ((int)(((byte)(196)))));
            this.parseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.parseButton.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.parseButton.ForeColor = System.Drawing.Color.White;
            this.parseButton.Location = new System.Drawing.Point(43, 170);
            this.parseButton.Name = "parseButton";
            this.parseButton.Size = new System.Drawing.Size(560, 44);
            this.parseButton.TabIndex = 3;
            this.parseButton.Text = "Запустить парсинг";
            this.parseButton.UseVisualStyleBackColor = false;
            this.parseButton.Click += new System.EventHandler(this.parseButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.resultLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(175)))));
            this.resultLabel.Location = new System.Drawing.Point(43, 235);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(124, 17);
            this.resultLabel.TabIndex = 4;
            this.resultLabel.Text = "Результат (HTML):";
            // 
            // outputContainer
            // 
            this.outputContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(35)))));
            this.outputContainer.Controls.Add(this.htmlOutputBox);
            this.outputContainer.Location = new System.Drawing.Point(43, 260);
            this.outputContainer.Name = "outputContainer";
            this.outputContainer.Padding = new System.Windows.Forms.Padding(12);
            this.outputContainer.Size = new System.Drawing.Size(1466, 541);
            this.outputContainer.TabIndex = 5;
            this.outputContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.outputContainer_Paint);
            // 
            // htmlOutputBox
            // 
            this.htmlOutputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(35)))));
            this.htmlOutputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.htmlOutputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlOutputBox.Font = new System.Drawing.Font("Consolas", 10F);
            this.htmlOutputBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.htmlOutputBox.Location = new System.Drawing.Point(12, 12);
            this.htmlOutputBox.Name = "htmlOutputBox";
            this.htmlOutputBox.ReadOnly = true;
            this.htmlOutputBox.Size = new System.Drawing.Size(1442, 517);
            this.htmlOutputBox.TabIndex = 0;
            this.htmlOutputBox.Text = "// Здесь появится HTML-код страницы...";
            this.htmlOutputBox.WordWrap = false;
            this.htmlOutputBox.TextChanged += new System.EventHandler(this.htmlOutputBox_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1553, 838);
            this.Controls.Add(this.outputContainer);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.parseButton);
            this.Controls.Add(this.inputContainer);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HTML Parser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.inputContainer.ResumeLayout(false);
            this.inputContainer.PerformLayout();
            this.outputContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
