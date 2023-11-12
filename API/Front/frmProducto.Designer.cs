namespace Front
{
    partial class frmProducto
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
            label1 = new Label();
            txtNumero = new TextBox();
            txtNombre = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            nmcCosto = new NumericUpDown();
            nmcPrecio = new NumericUpDown();
            groupBox1 = new GroupBox();
            btnEliminar = new Button();
            btnCancelar = new Button();
            btnGuardar = new Button();
            txtDescripcion = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nmcCosto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmcPrecio).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 26);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 0;
            label1.Text = "Número";
            // 
            // txtNumero
            // 
            txtNumero.Enabled = false;
            txtNumero.Location = new Point(126, 23);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(125, 27);
            txtNumero.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(126, 72);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 75);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 2;
            label2.Text = "Nombre";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(381, 78);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 6;
            label3.Text = "Precio";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(381, 29);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 4;
            label4.Text = "Costo";
            label4.Click += label4_Click;
            // 
            // nmcCosto
            // 
            nmcCosto.DecimalPlaces = 2;
            nmcCosto.Location = new Point(477, 29);
            nmcCosto.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nmcCosto.Name = "nmcCosto";
            nmcCosto.Size = new Size(150, 27);
            nmcCosto.TabIndex = 8;
            // 
            // nmcPrecio
            // 
            nmcPrecio.DecimalPlaces = 2;
            nmcPrecio.Location = new Point(477, 78);
            nmcPrecio.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nmcPrecio.Name = "nmcPrecio";
            nmcPrecio.Size = new Size(150, 27);
            nmcPrecio.TabIndex = 9;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Location = new Point(30, 120);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(746, 318);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Descripcion";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(456, 271);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(307, 271);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += button1_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(144, 271);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(27, 26);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(665, 213);
            txtDescripcion.TabIndex = 0;
            // 
            // frmProducto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(nmcPrecio);
            Controls.Add(nmcCosto);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(txtNumero);
            Controls.Add(label1);
            Name = "frmProducto";
            Text = "frmProductocs";
            Load += frmProductocs_Load;
            ((System.ComponentModel.ISupportInitialize)nmcCosto).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmcPrecio).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNumero;
        private TextBox txtNombre;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown nmcCosto;
        private NumericUpDown nmcPrecio;
        private GroupBox groupBox1;
        private TextBox txtDescripcion;
        private Button btnCancelar;
        private Button btnGuardar;
        private Button btnEliminar;
    }
}