namespace Front
{
    partial class frmConsultaPedido
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            groupBox1 = new GroupBox();
            lblEstado = new Label();
            lblPedido = new Label();
            dtpEntrega = new DateTimePicker();
            dtpPedido = new DateTimePicker();
            label7 = new Label();
            groupBox2 = new GroupBox();
            txtCorreo = new TextBox();
            txtCuit = new TextBox();
            txtNombre = new TextBox();
            dgvDetalle = new DataGridView();
            producto = new DataGridViewTextBoxColumn();
            productoId = new DataGridViewTextBoxColumn();
            cantidad = new DataGridViewTextBoxColumn();
            precio = new DataGridViewTextBoxColumn();
            costo = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 34);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 0;
            label1.Text = "Pedido#:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 50);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(295, 50);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 2;
            label3.Text = "Cuit:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(387, 102);
            label4.Name = "label4";
            label4.Size = new Size(126, 20);
            label4.TabIndex = 3;
            label4.Text = "Fecha de Entrega:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(503, 50);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 4;
            label5.Text = "Correo:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 102);
            label6.Name = "label6";
            label6.Size = new Size(121, 20);
            label6.TabIndex = 5;
            label6.Text = "Fecha de Pedido:";
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
            groupBox1.Location = new Point(80, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(755, 157);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pedido";
            groupBox1.Enter += groupBox1_Enter;
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
            dtpEntrega.Enabled = false;
            dtpEntrega.Format = DateTimePickerFormat.Short;
            dtpEntrega.Location = new Point(519, 97);
            dtpEntrega.Name = "dtpEntrega";
            dtpEntrega.Size = new Size(102, 27);
            dtpEntrega.TabIndex = 8;
            // 
            // dtpPedido
            // 
            dtpPedido.Enabled = false;
            dtpPedido.Format = DateTimePickerFormat.Short;
            dtpPedido.Location = new Point(152, 97);
            dtpPedido.Name = "dtpPedido";
            dtpPedido.Size = new Size(123, 27);
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
            // groupBox2
            // 
            groupBox2.Controls.Add(txtCorreo);
            groupBox2.Controls.Add(txtCuit);
            groupBox2.Controls.Add(txtNombre);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(80, 194);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(755, 115);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cliente";
            // 
            // txtCorreo
            // 
            txtCorreo.Enabled = false;
            txtCorreo.Location = new Point(566, 47);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(177, 27);
            txtCorreo.TabIndex = 7;
            // 
            // txtCuit
            // 
            txtCuit.Enabled = false;
            txtCuit.Location = new Point(339, 47);
            txtCuit.Name = "txtCuit";
            txtCuit.Size = new Size(140, 27);
            txtCuit.TabIndex = 6;
            // 
            // txtNombre
            // 
            txtNombre.Enabled = false;
            txtNombre.Location = new Point(98, 47);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(177, 27);
            txtNombre.TabIndex = 5;
            // 
            // dgvDetalle
            // 
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Columns.AddRange(new DataGridViewColumn[] { producto, productoId, cantidad, precio, costo });
            dgvDetalle.Location = new Point(80, 337);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.RowHeadersWidth = 51;
            dgvDetalle.RowTemplate.Height = 29;
            dgvDetalle.Size = new Size(755, 170);
            dgvDetalle.TabIndex = 8;
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
            // frmConsultaPedido
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 562);
            Controls.Add(dgvDetalle);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmConsultaPedido";
            Text = "frmPedido";
            Load += frmConsultaPedido_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label7;
        private DataGridView dgvDetalle;
        private DataGridViewTextBoxColumn producto;
        private DataGridViewTextBoxColumn productoId;
        private DataGridViewTextBoxColumn cantidad;
        private DataGridViewTextBoxColumn precio;
        private DataGridViewTextBoxColumn costo;
        private Label lblEstado;
        private Label lblPedido;
        private DateTimePicker dtpEntrega;
        private DateTimePicker dtpPedido;
        private TextBox txtNombre;
        private TextBox txtCorreo;
        private TextBox txtCuit;
    }
}