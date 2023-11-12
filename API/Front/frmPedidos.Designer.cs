namespace Front
{
    partial class frmPedidos
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
            btnNuevo = new Button();
            dgvPedidos = new DataGridView();
            groupBox1 = new GroupBox();
            label3 = new Label();
            cboEstados = new ComboBox();
            dtpHasta = new DateTimePicker();
            label2 = new Label();
            dtpDesde = new DateTimePicker();
            btnLimpiar = new Button();
            btnConsultar = new Button();
            label1 = new Label();
            id = new DataGridViewTextBoxColumn();
            cliente = new DataGridViewTextBoxColumn();
            cuit = new DataGridViewTextBoxColumn();
            correo = new DataGridViewTextBoxColumn();
            fechaPedido = new DataGridViewTextBoxColumn();
            estado_id = new DataGridViewTextBoxColumn();
            fechaEntrega = new DataGridViewTextBoxColumn();
            estado = new DataGridViewTextBoxColumn();
            accion = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(478, 554);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 8;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // dgvPedidos
            // 
            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Columns.AddRange(new DataGridViewColumn[] { id, cliente, cuit, correo, fechaPedido, estado_id, fechaEntrega, estado, accion });
            dgvPedidos.Location = new Point(26, 147);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.RowHeadersWidth = 51;
            dgvPedidos.RowTemplate.Height = 29;
            dgvPedidos.Size = new Size(1019, 379);
            dgvPedidos.TabIndex = 7;
            dgvPedidos.CellContentClick += dgvPresupuestos_CellContentClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cboEstados);
            groupBox1.Controls.Add(dtpHasta);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dtpDesde);
            groupBox1.Controls.Add(btnLimpiar);
            groupBox1.Controls.Add(btnConsultar);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(26, 47);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1029, 80);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(474, 31);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 8;
            label3.Text = "Estado";
            // 
            // cboEstados
            // 
            cboEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstados.FormattingEnabled = true;
            cboEstados.Location = new Point(545, 27);
            cboEstados.Name = "cboEstados";
            cboEstados.Size = new Size(151, 28);
            cboEstados.TabIndex = 7;
            cboEstados.SelectedIndexChanged += cboEstados_SelectedIndexChanged;
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(308, 26);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(126, 27);
            dtpHasta.TabIndex = 6;
            dtpHasta.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(251, 30);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 5;
            label2.Text = "Hasta:";
            label2.Click += label2_Click;
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(88, 26);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(126, 27);
            dtpDesde.TabIndex = 4;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(912, 27);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(94, 29);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(776, 27);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(94, 29);
            btnConsultar.TabIndex = 2;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 30);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 0;
            label1.Text = "Desde:";
            // 
            // id
            // 
            id.HeaderText = "Pedido#";
            id.MinimumWidth = 6;
            id.Name = "id";
            // 
            // cliente
            // 
            cliente.HeaderText = "Cliente";
            cliente.MinimumWidth = 6;
            cliente.Name = "cliente";
            cliente.Width = 125;
            // 
            // cuit
            // 
            cuit.HeaderText = "Cuit";
            cuit.MinimumWidth = 6;
            cuit.Name = "cuit";
            cuit.Width = 125;
            // 
            // correo
            // 
            correo.HeaderText = "correo";
            correo.MinimumWidth = 6;
            correo.Name = "correo";
            correo.Visible = false;
            correo.Width = 125;
            // 
            // fechaPedido
            // 
            fechaPedido.HeaderText = "fechaPedido";
            fechaPedido.MinimumWidth = 6;
            fechaPedido.Name = "fechaPedido";
            fechaPedido.Visible = false;
            fechaPedido.Width = 300;
            // 
            // estado_id
            // 
            estado_id.HeaderText = "estadoId";
            estado_id.MinimumWidth = 6;
            estado_id.Name = "estado_id";
            estado_id.Visible = false;
            estado_id.Width = 125;
            // 
            // fechaEntrega
            // 
            fechaEntrega.HeaderText = "Fecha Entrega";
            fechaEntrega.MinimumWidth = 6;
            fechaEntrega.Name = "fechaEntrega";
            fechaEntrega.Width = 125;
            // 
            // estado
            // 
            estado.HeaderText = "Estado";
            estado.MinimumWidth = 6;
            estado.Name = "estado";
            estado.Width = 125;
            // 
            // accion
            // 
            accion.HeaderText = "Acciones";
            accion.MinimumWidth = 6;
            accion.Name = "accion";
            accion.Text = "Ver";
            accion.Width = 125;
            // 
            // frmPedidos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 657);
            Controls.Add(btnNuevo);
            Controls.Add(dgvPedidos);
            Controls.Add(groupBox1);
            Name = "frmPedidos";
            Text = "frmPresupuestos";
            Load += frmPresupuestos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnNuevo;
        private DataGridView dgvPedidos;
        private GroupBox groupBox1;
        private Button btnLimpiar;
        private Button btnConsultar;
        private Label label1;
        private DateTimePicker dtpHasta;
        private Label label2;
        private DateTimePicker dtpDesde;
        private Label label3;
        private ComboBox cboEstados;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn cliente;
        private DataGridViewTextBoxColumn cuit;
        private DataGridViewTextBoxColumn correo;
        private DataGridViewTextBoxColumn fechaPedido;
        private DataGridViewTextBoxColumn estado_id;
        private DataGridViewTextBoxColumn fechaEntrega;
        private DataGridViewTextBoxColumn estado;
        private DataGridViewButtonColumn accion;
    }
}