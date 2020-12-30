namespace QualificationJobDirectory
{
    partial class QJD
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.To_add = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // To_add
            // 
            this.To_add.BackColor = System.Drawing.Color.SpringGreen;
            this.To_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.To_add.Location = new System.Drawing.Point(1, 2);
            this.To_add.Name = "To_add";
            this.To_add.Size = new System.Drawing.Size(91, 34);
            this.To_add.TabIndex = 0;
            this.To_add.Text = "Добавить";
            this.To_add.UseVisualStyleBackColor = false;
            this.To_add.Click += new System.EventHandler(this.To_add_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.IndianRed;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.Location = new System.Drawing.Point(98, 2);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(91, 34);
            this.Delete.TabIndex = 1;
            this.Delete.Text = "Удалить";
            this.Delete.UseVisualStyleBackColor = false;
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Search.Location = new System.Drawing.Point(707, 2);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(91, 34);
            this.Search.TabIndex = 2;
            this.Search.Text = "Поиск";
            this.Search.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(195, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "Найти:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(256, 10);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(440, 20);
            this.SearchBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.To_add);
            this.Name = "Form1";
            this.Text = "Квалификационный справочник должностей";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button To_add;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchBox;
    }
}

