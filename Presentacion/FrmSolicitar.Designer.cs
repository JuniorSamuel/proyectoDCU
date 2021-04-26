
namespace FaceId.Presentacion
{
    partial class FrmSolicitar
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbSolicitarS = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Que desea Solicitar?";
            // 
            // cbSolicitarS
            // 
            this.cbSolicitarS.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSolicitarS.FormattingEnabled = true;
            this.cbSolicitarS.Items.AddRange(new object[] {
            "Acta de Nacimiento ",
            "Cedula",
            "Acta de Matrimonio"});
            this.cbSolicitarS.Location = new System.Drawing.Point(37, 110);
            this.cbSolicitarS.Name = "cbSolicitarS";
            this.cbSolicitarS.Size = new System.Drawing.Size(427, 39);
            this.cbSolicitarS.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 57);
            this.button1.TabIndex = 2;
            this.button1.Text = "&Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FrmSolicitar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 356);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbSolicitarS);
            this.Controls.Add(this.label1);
            this.Name = "FrmSolicitar";
            this.Text = "Solicitud";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSolicitarS;
        private System.Windows.Forms.Button button1;
    }
}