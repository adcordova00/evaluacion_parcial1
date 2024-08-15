namespace evaluacion_parcial1.Views
{
    partial class frm_eventos
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
            this.btn_salir_evento = new System.Windows.Forms.Button();
            this.btn_cancelar_evento = new System.Windows.Forms.Button();
            this.btn_eliminar_evento = new System.Windows.Forms.Button();
            this.btn_editar_evento = new System.Windows.Forms.Button();
            this.btn_guardar_evento = new System.Windows.Forms.Button();
            this.txt_ubicacion_evento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_descripcion_evento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_nombre_evento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lst_eventos = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_fecha_evento = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btn_salir_evento
            // 
            this.btn_salir_evento.Location = new System.Drawing.Point(316, 288);
            this.btn_salir_evento.Name = "btn_salir_evento";
            this.btn_salir_evento.Size = new System.Drawing.Size(89, 40);
            this.btn_salir_evento.TabIndex = 32;
            this.btn_salir_evento.Text = "Salir";
            this.btn_salir_evento.UseVisualStyleBackColor = true;
            this.btn_salir_evento.Click += new System.EventHandler(this.btn_salir_evento_Click);
            // 
            // btn_cancelar_evento
            // 
            this.btn_cancelar_evento.Location = new System.Drawing.Point(224, 288);
            this.btn_cancelar_evento.Name = "btn_cancelar_evento";
            this.btn_cancelar_evento.Size = new System.Drawing.Size(89, 40);
            this.btn_cancelar_evento.TabIndex = 31;
            this.btn_cancelar_evento.Text = "Cancelar";
            this.btn_cancelar_evento.UseVisualStyleBackColor = true;
            this.btn_cancelar_evento.Click += new System.EventHandler(this.btn_cancelar_evento_Click);
            // 
            // btn_eliminar_evento
            // 
            this.btn_eliminar_evento.Location = new System.Drawing.Point(581, 366);
            this.btn_eliminar_evento.Name = "btn_eliminar_evento";
            this.btn_eliminar_evento.Size = new System.Drawing.Size(93, 45);
            this.btn_eliminar_evento.TabIndex = 30;
            this.btn_eliminar_evento.Text = "Eliminar";
            this.btn_eliminar_evento.UseVisualStyleBackColor = true;
            this.btn_eliminar_evento.Click += new System.EventHandler(this.btn_eliminar_evento_Click);
            // 
            // btn_editar_evento
            // 
            this.btn_editar_evento.Location = new System.Drawing.Point(132, 288);
            this.btn_editar_evento.Name = "btn_editar_evento";
            this.btn_editar_evento.Size = new System.Drawing.Size(89, 40);
            this.btn_editar_evento.TabIndex = 29;
            this.btn_editar_evento.Text = "Editar";
            this.btn_editar_evento.UseVisualStyleBackColor = true;
            this.btn_editar_evento.Click += new System.EventHandler(this.btn_editar_evento_Click);
            // 
            // btn_guardar_evento
            // 
            this.btn_guardar_evento.Location = new System.Drawing.Point(40, 288);
            this.btn_guardar_evento.Name = "btn_guardar_evento";
            this.btn_guardar_evento.Size = new System.Drawing.Size(89, 40);
            this.btn_guardar_evento.TabIndex = 28;
            this.btn_guardar_evento.Text = "Guardar";
            this.btn_guardar_evento.UseVisualStyleBackColor = true;
            this.btn_guardar_evento.Click += new System.EventHandler(this.btn_guardar_evento_Click);
            // 
            // txt_ubicacion_evento
            // 
            this.txt_ubicacion_evento.Location = new System.Drawing.Point(40, 245);
            this.txt_ubicacion_evento.Name = "txt_ubicacion_evento";
            this.txt_ubicacion_evento.Size = new System.Drawing.Size(365, 22);
            this.txt_ubicacion_evento.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "Ubicacion";
            // 
            // txt_descripcion_evento
            // 
            this.txt_descripcion_evento.Location = new System.Drawing.Point(40, 139);
            this.txt_descripcion_evento.Name = "txt_descripcion_evento";
            this.txt_descripcion_evento.Size = new System.Drawing.Size(365, 22);
            this.txt_descripcion_evento.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Descripcion";
            // 
            // txt_nombre_evento
            // 
            this.txt_nombre_evento.Location = new System.Drawing.Point(40, 90);
            this.txt_nombre_evento.Name = "txt_nombre_evento";
            this.txt_nombre_evento.Size = new System.Drawing.Size(365, 22);
            this.txt_nombre_evento.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Nombre";
            // 
            // lst_eventos
            // 
            this.lst_eventos.FormattingEnabled = true;
            this.lst_eventos.ItemHeight = 16;
            this.lst_eventos.Location = new System.Drawing.Point(485, 71);
            this.lst_eventos.Name = "lst_eventos";
            this.lst_eventos.Size = new System.Drawing.Size(279, 276);
            this.lst_eventos.TabIndex = 19;
            this.lst_eventos.SelectedIndexChanged += new System.EventHandler(this.lst_eventos_SelectedIndexChanged);
            this.lst_eventos.DoubleClick += new System.EventHandler(this.lst_eventos_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(569, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Lista de Eventos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Agregar Nuevo Evento";
            // 
            // dtp_fecha_evento
            // 
            this.dtp_fecha_evento.Location = new System.Drawing.Point(40, 190);
            this.dtp_fecha_evento.Name = "dtp_fecha_evento";
            this.dtp_fecha_evento.Size = new System.Drawing.Size(365, 22);
            this.dtp_fecha_evento.TabIndex = 33;
            // 
            // frm_eventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtp_fecha_evento);
            this.Controls.Add(this.btn_salir_evento);
            this.Controls.Add(this.btn_cancelar_evento);
            this.Controls.Add(this.btn_eliminar_evento);
            this.Controls.Add(this.btn_editar_evento);
            this.Controls.Add(this.btn_guardar_evento);
            this.Controls.Add(this.txt_ubicacion_evento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_descripcion_evento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_nombre_evento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lst_eventos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frm_eventos";
            this.Text = "frm_eventos";
            this.Load += new System.EventHandler(this.frm_eventos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_salir_evento;
        private System.Windows.Forms.Button btn_cancelar_evento;
        private System.Windows.Forms.Button btn_eliminar_evento;
        private System.Windows.Forms.Button btn_editar_evento;
        private System.Windows.Forms.Button btn_guardar_evento;
        private System.Windows.Forms.TextBox txt_ubicacion_evento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_descripcion_evento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_nombre_evento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lst_eventos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_fecha_evento;
    }
}