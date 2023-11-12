namespace Front
{
    partial class frmAltaPedido
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
            dgvDetalle = new DataGridView();
            producto = new DataGridViewTextBoxColumn();
            productoId = new DataGridViewTextBoxColumn();
            cantidad = new DataGridViewTextBoxColumn();
            precio = new DataGridViewTextBoxColumn();
            costo = new DataGridViewTextBoxColumn();
            acciones = new DataGridViewButtonColumn();
            groupBox2 = new GroupBox();
            txtCorreo = new TextBox();
            txtCuit = new TextBox();
            txtNombre = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            groupBox1 = new GroupBox();
            lblEstado = new Label();
            lblPedido = new Label();
            dtpEntrega = new DateTimePicker();
            dtpPedido = new DateTimePicker();
            label7 = new Label();
            label1 = new Label();
            label4 = new Label();
            label6 = new Label();
            groupBox3 = new GroupBox();
            btnAgregar = new Button();
            nmcCantifad = new NumericUpDown();
            cboProducto = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmcCantifad).BeginInit();
            SuspendLayout();
            // 
            // dgvDetalle
            // 
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Columns.AddRange(new DataGridViewColumn[] { producto, productoId, cantidad, precio, costo, acciones });
            dgvDetalle.Location = new Point(33, 359);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.RowHeadersWidth = 51;
            dgvDetalle.RowTemplate.Height = 29;
            dgvDetalle.Size = new Size(755, 190);
            dgvDetalle.TabIndex = 11;
            dgvDetalle.CellContentClick += dgvDetalle_CellContentClick;
            // 
            // producto
            // 
            producto.HeaderText = "Producto";
            producto.MinimumWidth = 6;
            producto.Name = "producto";
            producto.Width = 125;
            // 
            // productoId
            // 
            productoId.HeaderText = "productoId";
            productoId.MinimumWidth = 6;
            productoId.Name = "productoId";
            productoId.Visible = false;
            productoId.Width = 125;
            // 
            // cantidad
            // 
            cantidad.HeaderText = "Cantidad";
            cantidad.MinimumWidth = 6;
            cantidad.Name = "cantidad";
            cantidad.Width = 125;
            // 
            // precio
            // 
            precio.HeaderText = "Precio";
            precio.MinimumWidth = 6;
            precio.Name = "precio";
            precio.Width = 125;
            // 
            // costo
            // 
            costo.HeaderText = "Costo";
            costo.MinimumWidth = 6;
            costo.Name = "costo";
            costo.Width = 125;
            // 
            // acciones
            // 
            acciones.HeaderText = "Acciones";
            acciones.MinimumWidth = 6;
            acciones.Name = "acciones";
            acciones.Text = "Quitar";
            acciones.Width = 125;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtCorreo);
            groupBox2.Controls.Add(txtCuit);
            groupBox2.Controls.Add(txtNombre);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(33, 163);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(755, 89);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cliente";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(561, 35);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(177, 27);
            txtCorreo.TabIndex = 7;
            // 
            // txtCuit
            // 
            txtCuit.Location = new Point(334, 35);
            txtCuit.Name = "txtCuit";
            txtCuit.Size = new Size(140, 27);
            txtCuit.TabIndex = 6;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(93, 35);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(177, 27);
            txtNombre.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 38);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(290, 38);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 2;
            label3.Text = "Cuit:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(498, 38);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 4;
            label5.Text = "Correo:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblEstado);
            groupBox1.Controls.Add(lblPedido);
            groupBox1.Controls.Add(dtpEntrega);
            groupBox1.Controls.Add(dtpPedido);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label6);
            groupBox1.Location = new Point(33, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(755, 121);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pedido";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(519, 34);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(74, 20);
            lblEstado.TabIndex = 10;
            lblEstado.Text = "Pendiente";
            // 
            // lblPedido
            // 
            lblPedido.AutoSize = true;
            lblPedido.Location = new Point(152, 34);
            lblPedido.Name = "lblPedido";
            lblPedido.Size = new Size(27, 20);
            lblPedido.TabIndex = 9;
            lblPedido.Text = "---";
            // 
            // dtpEntrega
            // 
            dtpEntrega.Format = DateTimePickerFormat.Short;
            dtpEntrega.Location = new Point(519, 70);
            dtpEntrega.Name = "dtpEntrega";
            dtpEntrega.Size = new Size(123, 27);
            dtpEntrega.TabIndex = 8;
            // 
            // dtpPedido
            // 
            dtpPedido.Enabled = false;
            dtpPedido.Format = DateTimePickerFormat.Short;
            dtpPedido.Location = new Point(152, 70);
            dtpPedido.Name = "dtpPedido";
            dtpPedido.Size = new Size(118, 27);
            dtpPedido.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(387, 34);
            label7.Name = "label7";
            label7.Size = new Size(57, 20);
            label7.TabIndex = 6;
            label7.Text = "Estado:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 34);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 0;
            label1.Text = "Pedido#:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(387, 75);
            label4.Name = "label4";
            label4.Size = new Size(126, 20);
            label4.TabIndex = 3;
            label4.Text = "Fecha de Entrega:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 75);
            label6.Name = "label6";
            label6.Size = new Size(121, 20);
            label6.TabIndex = 5;
            label6.Text = "Fecha de Pedido:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnAgregar);
            groupBox3.Controls.Add(nmcCantifad);
            groupBox3.Controls.Add(cboProducto);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label9);
            groupBox3.Location = new Point(33, 258);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(755, 81);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Producto";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(628, 34);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // nmcCantifad
            // 
            nmcCantifad.Location = new Point(519, 36);
            nmcCantifad.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            nmcCantifad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmcCantifad.Name = "nmcCantifad";
            nmcCantifad.Size = new Size(69, 27);
            nmcCantifad.TabIndex = 9;
            nmcCantifad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cboProducto
            // 
            cboProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProducto.FormattingEnabled = true;
            cboProducto.Location = new Point(106, 35);
            cboProducto.Name = "cboProducto";
            cboProducto.Size = new Size(296, 28);
            cboProducto.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(20, 38);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 1;
            label8.Text = "Producto";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(441, 38);
            label9.Name = "label9";
            label9.Size = new Size(72, 20);
            label9.TabIndex = 2;
            label9.Text = "Cantidad:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(209, 574);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(485, 574);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmAltaPedido
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 628);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(groupBox3);
            Controls.Add(dgvDetalle);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmAltaPedido";
            Text = "frmAltaPedido";
            Load += frmAltaPedido_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmcCantifad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvDetalle;
        private GroupBox groupBox2;
        private TextBox txtCorreo;
        private TextBox txtCuit;
        private TextBox txtNombre;
        private Label label2;
        private Label label3;
        private Label label5;
        private GroupBox groupBox1;
        private Label lblEstado;
        private Label lblPedido;
        private DateTimePicker dtpEntrega;
        private DateTimePicker dtpPedido;
        private Label label7;
        private Label label1;
        private Label label4;
        private Label label6;
        private GroupBox groupBox3;
        private Label label8;
        private Label label9;
        private ComboBox cboProducto;
        private DataGridViewTextBoxColumn producto;
        private DataGridViewTextBoxColumn productoId;
        private DataGridViewTextBoxColumn cantidad;
        private DataGridViewTextBoxColumn precio;
        private DataGridViewTextBoxColumn costo;
        private DataGridViewButtonColumn acciones;
        private Button btnAgregar;
        private NumericUpDown nmcCantifad;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}