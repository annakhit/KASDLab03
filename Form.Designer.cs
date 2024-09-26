namespace KASDLab03
{
    partial class Form
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
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.ArrayTypeCombobox = new System.Windows.Forms.ComboBox();
            this.GroupCombobox = new System.Windows.Forms.ComboBox();
            this.start = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(331, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(700, 426);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // ArrayTypeCombobox
            // 
            this.ArrayTypeCombobox.FormattingEnabled = true;
            this.ArrayTypeCombobox.Items.AddRange(new object[] {
            "random",
            "arrays of array",
            "sorted and swap",
            "sorted with repeats"});
            this.ArrayTypeCombobox.Location = new System.Drawing.Point(12, 62);
            this.ArrayTypeCombobox.Name = "ArrayTypeCombobox";
            this.ArrayTypeCombobox.Size = new System.Drawing.Size(121, 21);
            this.ArrayTypeCombobox.TabIndex = 1;
            this.ArrayTypeCombobox.SelectedIndexChanged += new System.EventHandler(this.SelectArrayType);
            // 
            // GroupCombobox
            // 
            this.GroupCombobox.FormattingEnabled = true;
            this.GroupCombobox.Items.AddRange(new object[] {
            "group 1",
            "group 2",
            "group 3"});
            this.GroupCombobox.Location = new System.Drawing.Point(12, 116);
            this.GroupCombobox.Name = "GroupCombobox";
            this.GroupCombobox.Size = new System.Drawing.Size(121, 21);
            this.GroupCombobox.TabIndex = 2;
            this.GroupCombobox.SelectedIndexChanged += new System.EventHandler(this.SelectGroup);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(159, 116);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(151, 23);
            this.start.TabIndex = 4;
            this.start.Text = "Запустить тесты";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.VisGraph);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(159, 415);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Сохранить результаты";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Export);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.start);
            this.Controls.Add(this.GroupCombobox);
            this.Controls.Add(this.ArrayTypeCombobox);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "Form";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ComboBox ArrayTypeCombobox;
        private System.Windows.Forms.ComboBox GroupCombobox;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button button3;
    }
}

