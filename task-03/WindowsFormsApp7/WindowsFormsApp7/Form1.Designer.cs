namespace WindowsFormsApp7
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ArrayTypeCombobox = new System.Windows.Forms.ComboBox();
            this.start = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.button3 = new System.Windows.Forms.Button();
            this.GroupCombobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ArrayTypeCombobox
            // 
            this.ArrayTypeCombobox.FormattingEnabled = true;
            this.ArrayTypeCombobox.Items.AddRange(new object[] {
            "Массив случайных чисел",
            "Разбитые на подмассивы",
            "Массивы с перестановками",
            "Массивы с повторением"});
            this.ArrayTypeCombobox.Location = new System.Drawing.Point(58, 62);
            this.ArrayTypeCombobox.Name = "ArrayTypeCombobox";
            this.ArrayTypeCombobox.Size = new System.Drawing.Size(121, 21);
            this.ArrayTypeCombobox.TabIndex = 0;
            this.ArrayTypeCombobox.SelectedIndexChanged += new System.EventHandler(this.SelectArrayType);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(199, 212);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(91, 46);
            this.start.TabIndex = 1;
            this.start.Text = "Запустить тесты";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.VisGraph);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(309, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(556, 426);
            this.zedGraphControl1.TabIndex = 2;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(199, 383);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 43);
            this.button3.TabIndex = 3;
            this.button3.Text = "Сохранить результаты";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Export);
            // 
            // GroupCombobox
            // 
            this.GroupCombobox.FormattingEnabled = true;
            this.GroupCombobox.Items.AddRange(new object[] {
            "Первая группа",
            "Вторая группа",
            "Третья группа"});
            this.GroupCombobox.Location = new System.Drawing.Point(58, 117);
            this.GroupCombobox.Name = "GroupCombobox";
            this.GroupCombobox.Size = new System.Drawing.Size(121, 21);
            this.GroupCombobox.TabIndex = 4;
            this.GroupCombobox.SelectedIndexChanged += new System.EventHandler(this.SelectGroup);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 450);
            this.Controls.Add(this.GroupCombobox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.start);
            this.Controls.Add(this.ArrayTypeCombobox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ArrayTypeCombobox;
        private System.Windows.Forms.Button start;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox GroupCombobox;
    }
}

