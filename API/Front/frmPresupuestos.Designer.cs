namespace Front
{
    partial class frmPresupuestos
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
            dgvProductos = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            precio = new DataGridViewTextBoxColumn();
            Costo = new DataGridViewTextBoxColumn();
            Acciones = new DataGridViewButtonColumn();
            groupBox1 = new GroupBox();
            btnLimpiar = new Button();
            btnConsultar = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(477, 506);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 8;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { id, Nombre, precio, Costo, Acciones });
            dgvProductos.Location = new Point(26, 171);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.RowTemplate.Height = 29;
            dgvProductos.Size = new Size(1019, 275);
            dgvProductos.TabIndex = 7;
            // 
            // id
            // 
            id.HeaderText = "Producto#";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.Width = 125;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.Width = 125;
            // 
            // precio
            // 
            precio.HeaderText = "Precio";
            precio.MinimumWidth = 6;
            precio.Name = "precio";
            precio.Width = 125;
            // 
            // Costo
            // 
            Costo.HeaderText = "Costo";
            Costo.MinimumWidth = 6;
            Costo.Name = "Costo";
            Costo.Width = 125;
            // 
            // Acciones
            // 
            Acciones.HeaderText = "Acciones";
            Acciones.MinimumWidth = 6;
            Acciones.Name = "Acciones";
            Acciones.Resizable = DataGridViewTriState.True;
            Acciones.SortMode = DataGridViewColumnSortMode.Automatic;
            Acciones.Text = "VerEditar";
            Acciones.ToolTipText = "Ver/Editar";
            Acciones.Width = 125;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLimpiar);
            groupBox1.Controls.Add(btnConsultar);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(26, 47);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1029, 101);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(925, 33);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(94, 29);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(788, 30);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(94, 29);
            btnConsultar.TabIndex = 2;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 37);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 0;
            label1.Text = "Desde";
            // 
            // frmPresupuestos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 657);
            Controls.Add(btnNuevo);
            Controls.Add(dgvProductos);
            Controls.Add(groupBox1);
            Name = "frmPresupuestos";
            Text = "frmPresupuestos";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnNuevo;
        private DataGridView dgvProductos;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn precio;
        private DataGridViewTextBoxColumn Costo;
        private DataGridViewButtonColumn Acciones;
        private GroupBox groupBox1;
        private Button btnLimpiar;
        private Button btnConsultar;
        private Label label1;
    }
}