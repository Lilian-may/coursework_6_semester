using System.Windows.Forms;

namespace IAT_Test
{
    partial class ParticipantInfoForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblAge;
        private Label lblGender;
        private Label lblOccupation;
        private TextBox txtAge;
        private ComboBox cmbGender;
        private ComboBox cmbWorkPlace;
        private Label lblFaculty;
        private ComboBox cmbFaculty;
        private Label lblStudyForm;
        private ComboBox cmbStudyForm;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblAge = new Label();
            lblGender = new Label();
            lblOccupation = new Label();
            txtAge = new TextBox();
            cmbGender = new ComboBox();
            cmbWorkPlace = new ComboBox();
            lblFaculty = new Label();
            cmbFaculty = new ComboBox();
            lblStudyForm = new Label();
            cmbStudyForm = new ComboBox();
            lblGrade = new Label();
            cmbGrade = new ComboBox();
            txtWorkPlaceAdditional = new TextBox();
            lblWorkPlaceAdditional = new Label();
            SuspendLayout();
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(23, 31);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(100, 32);
            lblAge.TabIndex = 12;
            lblAge.Text = "Возраст";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(23, 72);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(58, 32);
            lblGender.TabIndex = 11;
            lblGender.Text = "Пол";
            // 
            // lblOccupation
            // 
            lblOccupation.AutoSize = true;
            lblOccupation.Location = new Point(23, 126);
            lblOccupation.Name = "lblOccupation";
            lblOccupation.Size = new Size(148, 32);
            lblOccupation.TabIndex = 10;
            lblOccupation.Text = "Род занятий";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(255, 24);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(200, 39);
            txtAge.TabIndex = 2;
            txtAge.KeyPress += txtAge_KeyPress;
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "М", "Ж" });
            cmbGender.Location = new Point(255, 69);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(200, 40);
            cmbGender.TabIndex = 3;
            // 
            // cmbWorkPlace
            // 
            cmbWorkPlace.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWorkPlace.FormattingEnabled = true;
            cmbWorkPlace.Location = new Point(255, 123);
            cmbWorkPlace.Name = "cmbWorkPlace";
            cmbWorkPlace.Size = new Size(200, 40);
            cmbWorkPlace.TabIndex = 4;
            cmbWorkPlace.SelectedIndexChanged += cmbWorkPlace_SelectedIndexChanged;
            // 
            // lblFaculty
            // 
            lblFaculty.AutoSize = true;
            lblFaculty.Location = new Point(23, 169);
            lblFaculty.Name = "lblFaculty";
            lblFaculty.Size = new Size(125, 32);
            lblFaculty.TabIndex = 8;
            lblFaculty.Text = "Факультет";
            // 
            // cmbFaculty
            // 
            cmbFaculty.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFaculty.FormattingEnabled = true;
            cmbFaculty.Location = new Point(255, 166);
            cmbFaculty.Name = "cmbFaculty";
            cmbFaculty.Size = new Size(200, 40);
            cmbFaculty.TabIndex = 5;
            // 
            // lblStudyForm
            // 
            lblStudyForm.AutoSize = true;
            lblStudyForm.Location = new Point(23, 211);
            lblStudyForm.Name = "lblStudyForm";
            lblStudyForm.Size = new Size(202, 32);
            lblStudyForm.TabIndex = 7;
            lblStudyForm.Text = "Форма обучения";
            // 
            // cmbStudyForm
            // 
            cmbStudyForm.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStudyForm.FormattingEnabled = true;
            cmbStudyForm.Items.AddRange(new object[] { "Бакалавриат", "Магистратура", "Специалитет", "Аспирантура" });
            cmbStudyForm.Location = new Point(255, 211);
            cmbStudyForm.Name = "cmbStudyForm";
            cmbStudyForm.Size = new Size(200, 40);
            cmbStudyForm.TabIndex = 6;
            // 
            // lblGrade
            // 
            lblGrade.AutoSize = true;
            lblGrade.Location = new Point(23, 265);
            lblGrade.Name = "lblGrade";
            lblGrade.Size = new Size(179, 32);
            lblGrade.TabIndex = 14;
            lblGrade.Text = "Курс обучения";
            // 
            // cmbGrade
            // 
            cmbGrade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrade.FormattingEnabled = true;
            cmbGrade.Items.AddRange(new object[] { 1, 2, 3, 4, 5 });
            cmbGrade.Location = new Point(255, 265);
            cmbGrade.Name = "cmbGrade";
            cmbGrade.Size = new Size(200, 40);
            cmbGrade.TabIndex = 15;
            // 
            // txtWorkPlaceAdditional
            // 
            txtWorkPlaceAdditional.Enabled = false;
            txtWorkPlaceAdditional.Location = new Point(256, 344);
            txtWorkPlaceAdditional.Name = "txtWorkPlaceAdditional";
            txtWorkPlaceAdditional.Size = new Size(199, 39);
            txtWorkPlaceAdditional.TabIndex = 16;
            // 
            // lblWorkPlaceAdditional
            // 
            lblWorkPlaceAdditional.AutoSize = true;
            lblWorkPlaceAdditional.Location = new Point(23, 169);
            lblWorkPlaceAdditional.Name = "lblWorkPlaceAdditional";
            lblWorkPlaceAdditional.Size = new Size(211, 32);
            lblWorkPlaceAdditional.TabIndex = 17;
            lblWorkPlaceAdditional.Text = "Вид деятельности";
            // 
            // ParticipantInfoForm
            // 
            ClientSize = new Size(755, 504);
            Controls.Add(lblWorkPlaceAdditional);
            Controls.Add(txtWorkPlaceAdditional);
            Controls.Add(cmbGrade);
            Controls.Add(lblGrade);
            Controls.Add(cmbStudyForm);
            Controls.Add(lblStudyForm);
            Controls.Add(cmbFaculty);
            Controls.Add(lblFaculty);
            Controls.Add(cmbWorkPlace);
            Controls.Add(cmbGender);
            Controls.Add(txtAge);
            Controls.Add(lblOccupation);
            Controls.Add(lblGender);
            Controls.Add(lblAge);
            KeyPreview = true;
            Name = "ParticipantInfoForm";
            Text = "Личные данные";
            KeyPress += ParticipiantInfoForm_KeyPress;
            ResumeLayout(false);
            PerformLayout();

        }

        private Label lblGrade;
        private ComboBox cmbGrade;
        private TextBox txtWorkPlaceAdditional;
        private Label lblWorkPlaceAdditional;
    }
}