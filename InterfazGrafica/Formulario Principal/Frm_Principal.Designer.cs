﻿
namespace InterfazGrafica
{
    partial class Frm_Principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DtGdVw_ListaViajes = new System.Windows.Forms.DataGridView();
            this.Colum_ListaViajes_Partida_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_ListaViajes_Partida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_ListaViajes_Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_ListaViajes_FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_ListaViajes_Crucero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_ListaViajes_CamarotesPremium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_ListaViajes_CamarotesTurista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_ListaViajes_CostoPremium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_ListaViajes_CostoTurista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_ListaViajes_DuracionViaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_ListaViajes_Partida_Llegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_ListaViajes_TotalPersonas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Btn_AgregarViaje = new System.Windows.Forms.Button();
            this.Btn_ModificarViaje = new System.Windows.Forms.Button();
            this.Btn_EliminarViaje = new System.Windows.Forms.Button();
            this.Btn_AgregarPersona = new System.Windows.Forms.Button();
            this.Btn_EstadisticasHistoricas = new System.Windows.Forms.Button();
            this.btn_AgregarPersona_AlViaje = new System.Windows.Forms.Button();
            this.Btn_ListarPersonasSistema = new System.Windows.Forms.Button();
            this.btn_CrudCrucero = new System.Windows.Forms.Button();
            this.btn_ListarPersonasDelViaje = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtGdVw_ListaViajes)).BeginInit();
            this.SuspendLayout();
            // 
            // DtGdVw_ListaViajes
            // 
            this.DtGdVw_ListaViajes.AllowUserToAddRows = false;
            this.DtGdVw_ListaViajes.AllowUserToDeleteRows = false;
            this.DtGdVw_ListaViajes.AllowUserToResizeColumns = false;
            this.DtGdVw_ListaViajes.AllowUserToResizeRows = false;
            this.DtGdVw_ListaViajes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtGdVw_ListaViajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtGdVw_ListaViajes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Colum_ListaViajes_Partida_ID,
            this.Colum_ListaViajes_Partida,
            this.Colum_ListaViajes_Destino,
            this.Colum_ListaViajes_FechaInicio,
            this.Colum_ListaViajes_Crucero,
            this.Colum_ListaViajes_CamarotesPremium,
            this.Colum_ListaViajes_CamarotesTurista,
            this.Colum_ListaViajes_CostoPremium,
            this.Colum_ListaViajes_CostoTurista,
            this.Colum_ListaViajes_DuracionViaje,
            this.Colum_ListaViajes_Partida_Llegada,
            this.Colum_ListaViajes_TotalPersonas});
            this.DtGdVw_ListaViajes.Location = new System.Drawing.Point(13, 13);
            this.DtGdVw_ListaViajes.Name = "DtGdVw_ListaViajes";
            this.DtGdVw_ListaViajes.RowTemplate.Height = 25;
            this.DtGdVw_ListaViajes.Size = new System.Drawing.Size(1091, 228);
            this.DtGdVw_ListaViajes.TabIndex = 0;
            // 
            // Colum_ListaViajes_Partida_ID
            // 
            this.Colum_ListaViajes_Partida_ID.HeaderText = "ID";
            this.Colum_ListaViajes_Partida_ID.Name = "Colum_ListaViajes_Partida_ID";
            this.Colum_ListaViajes_Partida_ID.ReadOnly = true;
            this.Colum_ListaViajes_Partida_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Colum_ListaViajes_Partida_ID.Width = 50;
            // 
            // Colum_ListaViajes_Partida
            // 
            this.Colum_ListaViajes_Partida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Colum_ListaViajes_Partida.HeaderText = "Partida";
            this.Colum_ListaViajes_Partida.Name = "Colum_ListaViajes_Partida";
            this.Colum_ListaViajes_Partida.ReadOnly = true;
            this.Colum_ListaViajes_Partida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Colum_ListaViajes_Destino
            // 
            this.Colum_ListaViajes_Destino.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Colum_ListaViajes_Destino.HeaderText = "Destino";
            this.Colum_ListaViajes_Destino.Name = "Colum_ListaViajes_Destino";
            this.Colum_ListaViajes_Destino.ReadOnly = true;
            this.Colum_ListaViajes_Destino.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Colum_ListaViajes_FechaInicio
            // 
            this.Colum_ListaViajes_FechaInicio.HeaderText = "Fecha de Inicio";
            this.Colum_ListaViajes_FechaInicio.Name = "Colum_ListaViajes_FechaInicio";
            this.Colum_ListaViajes_FechaInicio.ReadOnly = true;
            this.Colum_ListaViajes_FechaInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Colum_ListaViajes_FechaInicio.Width = 115;
            // 
            // Colum_ListaViajes_Crucero
            // 
            this.Colum_ListaViajes_Crucero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Colum_ListaViajes_Crucero.HeaderText = "Crucero";
            this.Colum_ListaViajes_Crucero.Name = "Colum_ListaViajes_Crucero";
            this.Colum_ListaViajes_Crucero.ReadOnly = true;
            this.Colum_ListaViajes_Crucero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Colum_ListaViajes_CamarotesPremium
            // 
            this.Colum_ListaViajes_CamarotesPremium.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Colum_ListaViajes_CamarotesPremium.HeaderText = "Camarotes Premium";
            this.Colum_ListaViajes_CamarotesPremium.Name = "Colum_ListaViajes_CamarotesPremium";
            this.Colum_ListaViajes_CamarotesPremium.ReadOnly = true;
            this.Colum_ListaViajes_CamarotesPremium.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Colum_ListaViajes_CamarotesTurista
            // 
            this.Colum_ListaViajes_CamarotesTurista.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Colum_ListaViajes_CamarotesTurista.HeaderText = "Camarotes Turista";
            this.Colum_ListaViajes_CamarotesTurista.Name = "Colum_ListaViajes_CamarotesTurista";
            this.Colum_ListaViajes_CamarotesTurista.ReadOnly = true;
            this.Colum_ListaViajes_CamarotesTurista.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Colum_ListaViajes_CostoPremium
            // 
            this.Colum_ListaViajes_CostoPremium.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Colum_ListaViajes_CostoPremium.HeaderText = "Costo Premium";
            this.Colum_ListaViajes_CostoPremium.Name = "Colum_ListaViajes_CostoPremium";
            this.Colum_ListaViajes_CostoPremium.ReadOnly = true;
            this.Colum_ListaViajes_CostoPremium.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Colum_ListaViajes_CostoTurista
            // 
            this.Colum_ListaViajes_CostoTurista.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Colum_ListaViajes_CostoTurista.HeaderText = "Costo Turista";
            this.Colum_ListaViajes_CostoTurista.Name = "Colum_ListaViajes_CostoTurista";
            this.Colum_ListaViajes_CostoTurista.ReadOnly = true;
            this.Colum_ListaViajes_CostoTurista.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Colum_ListaViajes_DuracionViaje
            // 
            this.Colum_ListaViajes_DuracionViaje.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Colum_ListaViajes_DuracionViaje.HeaderText = "Duracion del Viaje";
            this.Colum_ListaViajes_DuracionViaje.Name = "Colum_ListaViajes_DuracionViaje";
            this.Colum_ListaViajes_DuracionViaje.ReadOnly = true;
            this.Colum_ListaViajes_DuracionViaje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Colum_ListaViajes_Partida_Llegada
            // 
            this.Colum_ListaViajes_Partida_Llegada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Colum_ListaViajes_Partida_Llegada.HeaderText = "Fecha de Llegada";
            this.Colum_ListaViajes_Partida_Llegada.Name = "Colum_ListaViajes_Partida_Llegada";
            this.Colum_ListaViajes_Partida_Llegada.ReadOnly = true;
            this.Colum_ListaViajes_Partida_Llegada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Colum_ListaViajes_Partida_Llegada.Width = 115;
            // 
            // Colum_ListaViajes_TotalPersonas
            // 
            this.Colum_ListaViajes_TotalPersonas.HeaderText = "Tripulantes";
            this.Colum_ListaViajes_TotalPersonas.Name = "Colum_ListaViajes_TotalPersonas";
            this.Colum_ListaViajes_TotalPersonas.ReadOnly = true;
            // 
            // Btn_AgregarViaje
            // 
            this.Btn_AgregarViaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_AgregarViaje.Location = new System.Drawing.Point(201, 244);
            this.Btn_AgregarViaje.Name = "Btn_AgregarViaje";
            this.Btn_AgregarViaje.Size = new System.Drawing.Size(140, 43);
            this.Btn_AgregarViaje.TabIndex = 1;
            this.Btn_AgregarViaje.Text = "Crear un Viaje";
            this.Btn_AgregarViaje.UseVisualStyleBackColor = true;
            this.Btn_AgregarViaje.Click += new System.EventHandler(this.Btn_AgregarViaje_Click);
            // 
            // Btn_ModificarViaje
            // 
            this.Btn_ModificarViaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_ModificarViaje.Location = new System.Drawing.Point(347, 244);
            this.Btn_ModificarViaje.Name = "Btn_ModificarViaje";
            this.Btn_ModificarViaje.Size = new System.Drawing.Size(140, 43);
            this.Btn_ModificarViaje.TabIndex = 2;
            this.Btn_ModificarViaje.Text = "Modificar un Viaje";
            this.Btn_ModificarViaje.UseVisualStyleBackColor = true;
            this.Btn_ModificarViaje.Click += new System.EventHandler(this.Btn_ModificarViaje_Click);
            // 
            // Btn_EliminarViaje
            // 
            this.Btn_EliminarViaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_EliminarViaje.Location = new System.Drawing.Point(493, 244);
            this.Btn_EliminarViaje.Name = "Btn_EliminarViaje";
            this.Btn_EliminarViaje.Size = new System.Drawing.Size(140, 43);
            this.Btn_EliminarViaje.TabIndex = 3;
            this.Btn_EliminarViaje.Text = "Eliminar Viaje";
            this.Btn_EliminarViaje.UseVisualStyleBackColor = true;
            this.Btn_EliminarViaje.Click += new System.EventHandler(this.Btn_EliminarViaje_Click);
            // 
            // Btn_AgregarPersona
            // 
            this.Btn_AgregarPersona.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_AgregarPersona.Location = new System.Drawing.Point(424, 293);
            this.Btn_AgregarPersona.Name = "Btn_AgregarPersona";
            this.Btn_AgregarPersona.Size = new System.Drawing.Size(140, 46);
            this.Btn_AgregarPersona.TabIndex = 7;
            this.Btn_AgregarPersona.Text = "Agregar persona al Sistema";
            this.Btn_AgregarPersona.UseVisualStyleBackColor = true;
            this.Btn_AgregarPersona.Click += new System.EventHandler(this.Btn_AgregarPersona_Click);
            // 
            // Btn_EstadisticasHistoricas
            // 
            this.Btn_EstadisticasHistoricas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_EstadisticasHistoricas.Location = new System.Drawing.Point(278, 293);
            this.Btn_EstadisticasHistoricas.Name = "Btn_EstadisticasHistoricas";
            this.Btn_EstadisticasHistoricas.Size = new System.Drawing.Size(140, 46);
            this.Btn_EstadisticasHistoricas.TabIndex = 8;
            this.Btn_EstadisticasHistoricas.Text = "Estadisticas Historicas";
            this.Btn_EstadisticasHistoricas.UseVisualStyleBackColor = true;
            this.Btn_EstadisticasHistoricas.Click += new System.EventHandler(this.Btn_EstadisticasHistoricas_Click);
            // 
            // btn_AgregarPersona_AlViaje
            // 
            this.btn_AgregarPersona_AlViaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AgregarPersona_AlViaje.Location = new System.Drawing.Point(639, 244);
            this.btn_AgregarPersona_AlViaje.Name = "btn_AgregarPersona_AlViaje";
            this.btn_AgregarPersona_AlViaje.Size = new System.Drawing.Size(140, 43);
            this.btn_AgregarPersona_AlViaje.TabIndex = 9;
            this.btn_AgregarPersona_AlViaje.Text = "Agregar Persona al Viaje";
            this.btn_AgregarPersona_AlViaje.UseVisualStyleBackColor = true;
            this.btn_AgregarPersona_AlViaje.Click += new System.EventHandler(this.btn_AgregarPersona_AlViaje_Click);
            // 
            // Btn_ListarPersonasSistema
            // 
            this.Btn_ListarPersonasSistema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_ListarPersonasSistema.Location = new System.Drawing.Point(570, 293);
            this.Btn_ListarPersonasSistema.Name = "Btn_ListarPersonasSistema";
            this.Btn_ListarPersonasSistema.Size = new System.Drawing.Size(140, 46);
            this.Btn_ListarPersonasSistema.TabIndex = 10;
            this.Btn_ListarPersonasSistema.Text = "Listar Personas del Sistema";
            this.Btn_ListarPersonasSistema.UseVisualStyleBackColor = true;
            this.Btn_ListarPersonasSistema.Click += new System.EventHandler(this.Btn_ListarPersonasSistema_Click);
            // 
            // btn_CrudCrucero
            // 
            this.btn_CrudCrucero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CrudCrucero.Location = new System.Drawing.Point(716, 293);
            this.btn_CrudCrucero.Name = "btn_CrudCrucero";
            this.btn_CrudCrucero.Size = new System.Drawing.Size(140, 46);
            this.btn_CrudCrucero.TabIndex = 11;
            this.btn_CrudCrucero.Text = "Opciones Crucero";
            this.btn_CrudCrucero.UseVisualStyleBackColor = true;
            this.btn_CrudCrucero.Click += new System.EventHandler(this.btn_CrudCrucero_Click);
            // 
            // btn_ListarPersonasDelViaje
            // 
            this.btn_ListarPersonasDelViaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ListarPersonasDelViaje.Location = new System.Drawing.Point(785, 244);
            this.btn_ListarPersonasDelViaje.Name = "btn_ListarPersonasDelViaje";
            this.btn_ListarPersonasDelViaje.Size = new System.Drawing.Size(140, 43);
            this.btn_ListarPersonasDelViaje.TabIndex = 12;
            this.btn_ListarPersonasDelViaje.Text = "Listar Personas del Viaje";
            this.btn_ListarPersonasDelViaje.UseVisualStyleBackColor = true;
            this.btn_ListarPersonasDelViaje.Click += new System.EventHandler(this.btn_ListarPersonasDelViaje_Click);
            // 
            // Frm_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 343);
            this.Controls.Add(this.btn_ListarPersonasDelViaje);
            this.Controls.Add(this.btn_CrudCrucero);
            this.Controls.Add(this.Btn_ListarPersonasSistema);
            this.Controls.Add(this.btn_AgregarPersona_AlViaje);
            this.Controls.Add(this.Btn_EstadisticasHistoricas);
            this.Controls.Add(this.Btn_AgregarPersona);
            this.Controls.Add(this.Btn_EliminarViaje);
            this.Controls.Add(this.Btn_ModificarViaje);
            this.Controls.Add(this.Btn_AgregarViaje);
            this.Controls.Add(this.DtGdVw_ListaViajes);
            this.MinimumSize = new System.Drawing.Size(985, 382);
            this.Name = "Frm_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Frm_Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtGdVw_ListaViajes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DtGdVw_ListaViajes;
        private System.Windows.Forms.Button Btn_AgregarViaje;
        private System.Windows.Forms.Button Btn_ModificarViaje;
        private System.Windows.Forms.Button Btn_EliminarViaje;
        private System.Windows.Forms.Button Btn_AgregarPersona;
        private System.Windows.Forms.Button Btn_EstadisticasHistoricas;
        private System.Windows.Forms.Button btn_AgregarPersona_AlViaje;
        private System.Windows.Forms.Button Btn_ListarPersonasSistema;
        private System.Windows.Forms.Button btn_CrudCrucero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_ListaViajes_Partida_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_ListaViajes_Partida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_ListaViajes_Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_ListaViajes_FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_ListaViajes_Crucero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_ListaViajes_CamarotesPremium;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_ListaViajes_CamarotesTurista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_ListaViajes_CostoPremium;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_ListaViajes_CostoTurista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_ListaViajes_DuracionViaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_ListaViajes_Partida_Llegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_ListaViajes_TotalPersonas;
        private System.Windows.Forms.Button btn_ListarPersonasDelViaje;
    }
}

