namespace TPFinalNivel2_Nybroe
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
            this.dgVArticulos = new System.Windows.Forms.DataGridView();
            this.pBImagen = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblCampo = new System.Windows.Forms.Label();
            this.cBoxCampo = new System.Windows.Forms.ComboBox();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.cBoxCriterio = new System.Windows.Forms.ComboBox();
            this.txtBoxFiltro = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgVArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // dgVArticulos
            // 
            this.dgVArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgVArticulos.Location = new System.Drawing.Point(12, 12);
            this.dgVArticulos.Name = "dgVArticulos";
            this.dgVArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVArticulos.Size = new System.Drawing.Size(616, 258);
            this.dgVArticulos.TabIndex = 0;
            this.dgVArticulos.SelectionChanged += new System.EventHandler(this.dgVArticulos_SelectionChanged);
            // 
            // pBImagen
            // 
            this.pBImagen.Location = new System.Drawing.Point(634, 12);
            this.pBImagen.Name = "pBImagen";
            this.pBImagen.Size = new System.Drawing.Size(211, 258);
            this.pBImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBImagen.TabIndex = 1;
            this.pBImagen.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 276);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(93, 276);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(174, 276);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Location = new System.Drawing.Point(12, 325);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(40, 13);
            this.lblCampo.TabIndex = 5;
            this.lblCampo.Text = "Campo";
            // 
            // cBoxCampo
            // 
            this.cBoxCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCampo.FormattingEnabled = true;
            this.cBoxCampo.Location = new System.Drawing.Point(53, 322);
            this.cBoxCampo.Name = "cBoxCampo";
            this.cBoxCampo.Size = new System.Drawing.Size(121, 21);
            this.cBoxCampo.TabIndex = 6;
            this.cBoxCampo.SelectedIndexChanged += new System.EventHandler(this.cBoxCampo_SelectedIndexChanged);
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(180, 325);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(39, 13);
            this.lblCriterio.TabIndex = 7;
            this.lblCriterio.Text = "Criterio";
            // 
            // cBoxCriterio
            // 
            this.cBoxCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCriterio.FormattingEnabled = true;
            this.cBoxCriterio.Location = new System.Drawing.Point(225, 322);
            this.cBoxCriterio.Name = "cBoxCriterio";
            this.cBoxCriterio.Size = new System.Drawing.Size(121, 21);
            this.cBoxCriterio.TabIndex = 8;
            // 
            // txtBoxFiltro
            // 
            this.txtBoxFiltro.Location = new System.Drawing.Point(427, 322);
            this.txtBoxFiltro.Name = "txtBoxFiltro";
            this.txtBoxFiltro.Size = new System.Drawing.Size(100, 20);
            this.txtBoxFiltro.TabIndex = 9;
            this.txtBoxFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxFiltro_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(553, 322);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(386, 325);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(29, 13);
            this.lblFiltro.TabIndex = 11;
            this.lblFiltro.Text = "Filtro";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(553, 276);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 12;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 357);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBoxFiltro);
            this.Controls.Add(this.cBoxCriterio);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.cBoxCampo);
            this.Controls.Add(this.lblCampo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.pBImagen);
            this.Controls.Add(this.dgVArticulos);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgVArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgVArticulos;
        private System.Windows.Forms.PictureBox pBImagen;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblCampo;
        private System.Windows.Forms.ComboBox cBoxCampo;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.ComboBox cBoxCriterio;
        private System.Windows.Forms.TextBox txtBoxFiltro;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Button btnActualizar;
    }
}

