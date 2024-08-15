namespace evaluacion_parcial1.Views
{
    partial class frm_clientes
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lst_clientes = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nombre_cliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_apellido_cliente = new System.Windows.Forms.TextBox();
            this.txt_email_cliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_telefono_cliente = new System.Windows.Forms.TextBox();
            this.btn_guardar_cliente = new System.Windows.Forms.Button();
            this.btn_editar_cliente = new System.Windows.Forms.Button();
            this.btn_eliminar_cliente = new System.Windows.Forms.Button();
            this.btn_cancelar_cliente = new System.Windows.Forms.Button();
            this.btn_salir_cliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Nuevo Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(575, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lista de Clientes";
            // 
            // lst_clientes
            // 
            this.lst_clientes.FormattingEnabled = true;
            this.lst_clientes.ItemHeight = 16;
            this.lst_clientes.Location = new System.Drawing.Point(491, 58);
            this.lst_clientes.Name = "lst_clientes";
            this.lst_clientes.Size = new System.Drawing.Size(279, 276);
            this.lst_clientes.TabIndex = 2;
            this.lst_clientes.SelectedIndexChanged += new System.EventHandler(this.lst_clientes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre";
            // 
            // txt_nombre_cliente
            // 
            this.txt_nombre_cliente.Location = new System.Drawing.Point(46, 77);
            this.txt_nombre_cliente.Name = "txt_nombre_cliente";
            this.txt_nombre_cliente.Size = new System.Drawing.Size(365, 22);
            this.txt_nombre_cliente.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Apellido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Email";
            // 
            // txt_apellido_cliente
            // 
            this.txt_apellido_cliente.Location = new System.Drawing.Point(46, 126);
            this.txt_apellido_cliente.Name = "txt_apellido_cliente";
            this.txt_apellido_cliente.Size = new System.Drawing.Size(365, 22);
            this.txt_apellido_cliente.TabIndex = 8;
            // 
            // txt_email_cliente
            // 
            this.txt_email_cliente.Location = new System.Drawing.Point(46, 176);
            this.txt_email_cliente.Name = "txt_email_cliente";
            this.txt_email_cliente.Size = new System.Drawing.Size(365, 22);
            this.txt_email_cliente.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Telefono";
            // 
            // txt_telefono_cliente
            // 
            this.txt_telefono_cliente.Location = new System.Drawing.Point(46, 232);
            this.txt_telefono_cliente.Name = "txt_telefono_cliente";
            this.txt_telefono_cliente.Size = new System.Drawing.Size(365, 22);
            this.txt_telefono_cliente.TabIndex = 11;
            // 
            // btn_guardar_cliente
            // 
            this.btn_guardar_cliente.Location = new System.Drawing.Point(46, 279);
            this.btn_guardar_cliente.Name = "btn_guardar_cliente";
            this.btn_guardar_cliente.Size = new System.Drawing.Size(89, 40);
            this.btn_guardar_cliente.TabIndex = 12;
            this.btn_guardar_cliente.Text = "Guardar";
            this.btn_guardar_cliente.UseVisualStyleBackColor = true;
            this.btn_guardar_cliente.Click += new System.EventHandler(this.btn_guardar_cliente_Click);
            // 
            // btn_editar_cliente
            // 
            this.btn_editar_cliente.Location = new System.Drawing.Point(138, 279);
            this.btn_editar_cliente.Name = "btn_editar_cliente";
            this.btn_editar_cliente.Size = new System.Drawing.Size(89, 40);
            this.btn_editar_cliente.TabIndex = 13;
            this.btn_editar_cliente.Text = "Editar";
            this.btn_editar_cliente.UseVisualStyleBackColor = true;
            // 
            // btn_eliminar_cliente
            // 
            this.btn_eliminar_cliente.Location = new System.Drawing.Point(587, 353);
            this.btn_eliminar_cliente.Name = "btn_eliminar_cliente";
            this.btn_eliminar_cliente.Size = new System.Drawing.Size(93, 45);
            this.btn_eliminar_cliente.TabIndex = 14;
            this.btn_eliminar_cliente.Text = "Eliminar";
            this.btn_eliminar_cliente.UseVisualStyleBackColor = true;
            this.btn_eliminar_cliente.Click += new System.EventHandler(this.btn_eliminar_cliente_Click);
            // 
            // btn_cancelar_cliente
            // 
            this.btn_cancelar_cliente.Location = new System.Drawing.Point(230, 279);
            this.btn_cancelar_cliente.Name = "btn_cancelar_cliente";
            this.btn_cancelar_cliente.Size = new System.Drawing.Size(89, 40);
            this.btn_cancelar_cliente.TabIndex = 15;
            this.btn_cancelar_cliente.Text = "Cancelar";
            this.btn_cancelar_cliente.UseVisualStyleBackColor = true;
            this.btn_cancelar_cliente.Click += new System.EventHandler(this.btn_cancelar_cliente_Click);
            // 
            // btn_salir_cliente
            // 
            this.btn_salir_cliente.Location = new System.Drawing.Point(322, 279);
            this.btn_salir_cliente.Name = "btn_salir_cliente";
            this.btn_salir_cliente.Size = new System.Drawing.Size(89, 40);
            this.btn_salir_cliente.TabIndex = 16;
            this.btn_salir_cliente.Text = "Salir";
            this.btn_salir_cliente.UseVisualStyleBackColor = true;
            this.btn_salir_cliente.Click += new System.EventHandler(this.btn_salir_cliente_Click);
            // 
            // frm_clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_salir_cliente);
            this.Controls.Add(this.btn_cancelar_cliente);
            this.Controls.Add(this.btn_eliminar_cliente);
            this.Controls.Add(this.btn_editar_cliente);
            this.Controls.Add(this.btn_guardar_cliente);
            this.Controls.Add(this.txt_telefono_cliente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_email_cliente);
            this.Controls.Add(this.txt_apellido_cliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_nombre_cliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lst_clientes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frm_clientes";
            this.Text = "frm_clientes";
            this.Load += new System.EventHandler(this.frm_clientes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lst_clientes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nombre_cliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_apellido_cliente;
        private System.Windows.Forms.TextBox txt_email_cliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_telefono_cliente;
        private System.Windows.Forms.Button btn_guardar_cliente;
        private System.Windows.Forms.Button btn_editar_cliente;
        private System.Windows.Forms.Button btn_eliminar_cliente;
        private System.Windows.Forms.Button btn_cancelar_cliente;
        private System.Windows.Forms.Button btn_salir_cliente;
    }
}