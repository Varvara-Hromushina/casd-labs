namespace task_29
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.drawPanel = new System.Windows.Forms.Panel();
            this.resultLabel = new System.Windows.Forms.Label();

            // Инициализация кнопок
            this.btnTarjan = new System.Windows.Forms.Button();
            this.btnDinic = new System.Windows.Forms.Button();
            this.btnClique = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // btnTarjan
            this.btnTarjan.Location = new System.Drawing.Point(550, 50);
            this.btnTarjan.Name = "btnTarjan";
            this.btnTarjan.Size = new System.Drawing.Size(200, 40); 
            this.btnTarjan.TabIndex = 2;
            this.btnTarjan.Text = "Поиск SCC (Тарьян)";
            this.btnTarjan.UseVisualStyleBackColor = true;
            this.btnTarjan.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold); 
            this.btnTarjan.Click += new System.EventHandler(this.btnTarjan_Click);

            // btnDinic
            this.btnDinic.Location = new System.Drawing.Point(550, 100);
            this.btnDinic.Name = "btnDinic";
            this.btnDinic.Size = new System.Drawing.Size(200, 40); 
            this.btnDinic.TabIndex = 3;
            this.btnDinic.Text = "Макс. поток (Диниц)";
            this.btnDinic.UseVisualStyleBackColor = true;
            this.btnDinic.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold); 
            this.btnDinic.Click += new System.EventHandler(this.btnDinic_Click);

            // btnClique
            this.btnClique.Location = new System.Drawing.Point(550, 150);
            this.btnClique.Name = "btnClique";
            this.btnClique.Size = new System.Drawing.Size(200, 40); 
            this.btnClique.TabIndex = 4;
            this.btnClique.Text = "Макс. клика";
            this.btnClique.UseVisualStyleBackColor = true;
            this.btnClique.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold); 
            this.btnClique.Click += new System.EventHandler(this.btnClique_Click);

            // Вставить кнопки в управление формы
            this.Controls.Add(this.btnTarjan);
            this.Controls.Add(this.btnDinic);
            this.Controls.Add(this.btnClique);

            // drawPanel
            this.drawPanel.Location = new System.Drawing.Point(12, 12);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(700, 700); 
            this.drawPanel.TabIndex = 0;
            this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPanel_Paint);

            // resultLabel
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(800, 50);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(85, 17);
            this.resultLabel.TabIndex = 2;
            this.resultLabel.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold); 

            // Form1
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.drawPanel);
            this.Name = "Form1";
            this.Text = "Визуализатор графов";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.Label resultLabel;
    }
}