namespace Livraria.UCs
{
    partial class GanhosUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbAnual = new System.Windows.Forms.RadioButton();
            this.rdbMensal = new System.Windows.Forms.RadioButton();
            this.rdbDiario = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEstimativa = new System.Windows.Forms.Label();
            this.lblTituloPorcento = new System.Windows.Forms.Label();
            this.lblPorcentagem = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.BackColorTransparent = true;
            this.cartesianChart1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cartesianChart1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cartesianChart1.Location = new System.Drawing.Point(5, 98);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(910, 604);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbAnual);
            this.panel1.Controls.Add(this.rdbMensal);
            this.panel1.Controls.Add(this.rdbDiario);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.panel1.Location = new System.Drawing.Point(5, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 58);
            this.panel1.TabIndex = 2;
            // 
            // rdbAnual
            // 
            this.rdbAnual.AutoSize = true;
            this.rdbAnual.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rdbAnual.FlatAppearance.BorderSize = 5;
            this.rdbAnual.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.rdbAnual.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.rdbAnual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbAnual.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAnual.Location = new System.Drawing.Point(204, 17);
            this.rdbAnual.Name = "rdbAnual";
            this.rdbAnual.Size = new System.Drawing.Size(72, 25);
            this.rdbAnual.TabIndex = 5;
            this.rdbAnual.TabStop = true;
            this.rdbAnual.Text = "Anual";
            this.rdbAnual.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.rdbAnual.UseVisualStyleBackColor = true;
            this.rdbAnual.CheckedChanged += new System.EventHandler(this.rdbAnual_CheckedChanged);
            // 
            // rdbMensal
            // 
            this.rdbMensal.AutoSize = true;
            this.rdbMensal.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rdbMensal.FlatAppearance.BorderSize = 5;
            this.rdbMensal.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.rdbMensal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.rdbMensal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbMensal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMensal.Location = new System.Drawing.Point(109, 17);
            this.rdbMensal.Name = "rdbMensal";
            this.rdbMensal.Size = new System.Drawing.Size(82, 25);
            this.rdbMensal.TabIndex = 4;
            this.rdbMensal.TabStop = true;
            this.rdbMensal.Text = "Mensal";
            this.rdbMensal.UseVisualStyleBackColor = true;
            this.rdbMensal.CheckedChanged += new System.EventHandler(this.rdbMensal_CheckedChanged);
            // 
            // rdbDiario
            // 
            this.rdbDiario.AutoSize = true;
            this.rdbDiario.FlatAppearance.BorderSize = 0;
            this.rdbDiario.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.rdbDiario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.rdbDiario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbDiario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDiario.Location = new System.Drawing.Point(23, 17);
            this.rdbDiario.Name = "rdbDiario";
            this.rdbDiario.Size = new System.Drawing.Size(74, 25);
            this.rdbDiario.TabIndex = 3;
            this.rdbDiario.TabStop = true;
            this.rdbDiario.Text = "Diário";
            this.rdbDiario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbDiario.UseVisualStyleBackColor = true;
            this.rdbDiario.CheckedChanged += new System.EventHandler(this.rdbDiario_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(325, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Estimativa de ganhos do mês:";
            // 
            // lblEstimativa
            // 
            this.lblEstimativa.AutoSize = true;
            this.lblEstimativa.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimativa.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblEstimativa.Location = new System.Drawing.Point(324, 40);
            this.lblEstimativa.Name = "lblEstimativa";
            this.lblEstimativa.Size = new System.Drawing.Size(81, 30);
            this.lblEstimativa.TabIndex = 4;
            this.lblEstimativa.Text = "R$0.00";
            // 
            // lblTituloPorcento
            // 
            this.lblTituloPorcento.AutoSize = true;
            this.lblTituloPorcento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloPorcento.Location = new System.Drawing.Point(619, 9);
            this.lblTituloPorcento.Name = "lblTituloPorcento";
            this.lblTituloPorcento.Size = new System.Drawing.Size(305, 42);
            this.lblTituloPorcento.TabIndex = 5;
            this.lblTituloPorcento.Text = "Percentual de ganhos em comparação \r\nao mês de Novembro ";
            // 
            // lblPorcentagem
            // 
            this.lblPorcentagem.AutoSize = true;
            this.lblPorcentagem.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentagem.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblPorcentagem.Location = new System.Drawing.Point(623, 53);
            this.lblPorcentagem.Name = "lblPorcentagem";
            this.lblPorcentagem.Size = new System.Drawing.Size(85, 30);
            this.lblPorcentagem.TabIndex = 6;
            this.lblPorcentagem.Text = "10.15%";
            // 
            // GanhosUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblPorcentagem);
            this.Controls.Add(this.lblTituloPorcento);
            this.Controls.Add(this.lblEstimativa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "GanhosUC";
            this.Size = new System.Drawing.Size(947, 744);
            this.Load += new System.EventHandler(this.GanhosUC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbAnual;
        private System.Windows.Forms.RadioButton rdbMensal;
        private System.Windows.Forms.RadioButton rdbDiario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEstimativa;
        private System.Windows.Forms.Label lblTituloPorcento;
        private System.Windows.Forms.Label lblPorcentagem;






    }
}
