
namespace FaceId.Presentacion
{
    partial class RegistrarDatos
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.barGuardar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // barGuardar
            // 
            this.barGuardar.Location = new System.Drawing.Point(0, 712);
            this.barGuardar.Name = "barGuardar";
            this.barGuardar.Size = new System.Drawing.Size(726, 25);
            this.barGuardar.TabIndex = 33;
            // 
            // RegistrarDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barGuardar);
            this.Name = "RegistrarDatos";
            this.Size = new System.Drawing.Size(726, 737);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ProgressBar barGuardar;
    }
}
