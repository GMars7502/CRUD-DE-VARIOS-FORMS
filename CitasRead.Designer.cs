namespace CRUD_CITASMEDICAS
{
    partial class CitasRead
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CitasRead));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idCitas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctFechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctFechaCita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctDiagnostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCitas,
            this.idPaciente,
            this.ctCodigo,
            this.ctFechaRegistro,
            this.ctFechaCita,
            this.ctEspecialidad,
            this.ctMedico,
            this.ctEstado,
            this.ctDiagnostico,
            this.ctCosto});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(541, 209);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // idCitas
            // 
            this.idCitas.DataPropertyName = "idCitas";
            this.idCitas.HeaderText = "citas";
            this.idCitas.Name = "idCitas";
            this.idCitas.ReadOnly = true;
            this.idCitas.Visible = false;
            // 
            // idPaciente
            // 
            this.idPaciente.DataPropertyName = "idPaciente";
            this.idPaciente.HeaderText = "Paciente";
            this.idPaciente.Name = "idPaciente";
            this.idPaciente.ReadOnly = true;
            // 
            // ctCodigo
            // 
            this.ctCodigo.DataPropertyName = "ctCodigo";
            this.ctCodigo.HeaderText = "Codigo";
            this.ctCodigo.Name = "ctCodigo";
            this.ctCodigo.ReadOnly = true;
            // 
            // ctFechaRegistro
            // 
            this.ctFechaRegistro.DataPropertyName = "ctFechaRegistro";
            this.ctFechaRegistro.HeaderText = "FechaRegistro";
            this.ctFechaRegistro.Name = "ctFechaRegistro";
            this.ctFechaRegistro.ReadOnly = true;
            // 
            // ctFechaCita
            // 
            this.ctFechaCita.DataPropertyName = "ctFechaCita";
            this.ctFechaCita.HeaderText = "FechaCita";
            this.ctFechaCita.Name = "ctFechaCita";
            this.ctFechaCita.ReadOnly = true;
            // 
            // ctEspecialidad
            // 
            this.ctEspecialidad.DataPropertyName = "ctEspecialidad";
            this.ctEspecialidad.HeaderText = "Especialidad";
            this.ctEspecialidad.Name = "ctEspecialidad";
            this.ctEspecialidad.ReadOnly = true;
            // 
            // ctMedico
            // 
            this.ctMedico.DataPropertyName = "ctMedico";
            this.ctMedico.HeaderText = "Medico";
            this.ctMedico.Name = "ctMedico";
            this.ctMedico.ReadOnly = true;
            // 
            // ctEstado
            // 
            this.ctEstado.DataPropertyName = "ctEstado";
            this.ctEstado.HeaderText = "Estado";
            this.ctEstado.Name = "ctEstado";
            this.ctEstado.ReadOnly = true;
            // 
            // ctDiagnostico
            // 
            this.ctDiagnostico.DataPropertyName = "ctDiagnostico";
            this.ctDiagnostico.HeaderText = "Diagnostico";
            this.ctDiagnostico.Name = "ctDiagnostico";
            this.ctDiagnostico.ReadOnly = true;
            // 
            // ctCosto
            // 
            this.ctCosto.DataPropertyName = "ctCosto";
            this.ctCosto.HeaderText = "Costo";
            this.ctCosto.Name = "ctCosto";
            this.ctCosto.ReadOnly = true;
            // 
            // CitasRead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 209);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CitasRead";
            this.Text = "Ver Citas";
            this.Load += new System.EventHandler(this.CitasRead_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctFechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctFechaCita;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctMedico;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctDiagnostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctCosto;
    }
}