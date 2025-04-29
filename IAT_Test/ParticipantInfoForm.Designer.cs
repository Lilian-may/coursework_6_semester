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
            this.lblAge = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblOccupation = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.cmbWorkPlace = new System.Windows.Forms.ComboBox();
            this.lblFaculty = new System.Windows.Forms.Label();
            this.cmbFaculty = new System.Windows.Forms.ComboBox();
            this.lblStudyForm = new System.Windows.Forms.Label();
            this.cmbStudyForm = new System.Windows.Forms.ComboBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.cmbGrade = new System.Windows.Forms.ComboBox();
            this.txtWorkPlaceAdditional = new System.Windows.Forms.TextBox();
            this.lblWorkPlaceAdditional = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(23, 27);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(62, 16);
            this.lblAge.TabIndex = 12;
            this.lblAge.Text = "Возраст";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(23, 57);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(33, 16);
            this.lblGender.TabIndex = 11;
            this.lblGender.Text = "Пол";
            // 
            // lblOccupation
            // 
            this.lblOccupation.AutoSize = true;
            this.lblOccupation.Location = new System.Drawing.Point(23, 87);
            this.lblOccupation.Name = "lblOccupation";
            this.lblOccupation.Size = new System.Drawing.Size(89, 16);
            this.lblOccupation.TabIndex = 10;
            this.lblOccupation.Text = "Род занятий";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(164, 27);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(200, 22);
            this.txtAge.TabIndex = 2;
            this.txtAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAge_KeyPress);
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "М",
            "Ж"});
            this.cmbGender.Location = new System.Drawing.Point(164, 57);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(200, 24);
            this.cmbGender.TabIndex = 3;
            // 
            // cmbWorkPlace
            // 
            this.cmbWorkPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkPlace.FormattingEnabled = true;
            this.cmbWorkPlace.Location = new System.Drawing.Point(163, 87);
            this.cmbWorkPlace.Name = "cmbWorkPlace";
            this.cmbWorkPlace.Size = new System.Drawing.Size(200, 24);
            this.cmbWorkPlace.TabIndex = 4;
            this.cmbWorkPlace.SelectedIndexChanged += new System.EventHandler(this.cmbWorkPlace_SelectedIndexChanged);
            // 
            // lblFaculty
            // 
            this.lblFaculty.AutoSize = true;
            this.lblFaculty.Location = new System.Drawing.Point(23, 117);
            this.lblFaculty.Name = "lblFaculty";
            this.lblFaculty.Size = new System.Drawing.Size(78, 16);
            this.lblFaculty.TabIndex = 8;
            this.lblFaculty.Text = "Факультет";
            // 
            // cmbFaculty
            // 
            this.cmbFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFaculty.FormattingEnabled = true;
            this.cmbFaculty.Location = new System.Drawing.Point(164, 117);
            this.cmbFaculty.Name = "cmbFaculty";
            this.cmbFaculty.Size = new System.Drawing.Size(200, 24);
            this.cmbFaculty.TabIndex = 5;
            // 
            // lblStudyForm
            // 
            this.lblStudyForm.AutoSize = true;
            this.lblStudyForm.Location = new System.Drawing.Point(23, 147);
            this.lblStudyForm.Name = "lblStudyForm";
            this.lblStudyForm.Size = new System.Drawing.Size(117, 16);
            this.lblStudyForm.TabIndex = 7;
            this.lblStudyForm.Text = "Форма обучения";
            // 
            // cmbStudyForm
            // 
            this.cmbStudyForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudyForm.FormattingEnabled = true;
            this.cmbStudyForm.Items.AddRange(new object[] {
            "Бакалавриат",
            "Магистратура",
            "Специалитет",
            "Аспирантура"});
            this.cmbStudyForm.Location = new System.Drawing.Point(163, 148);
            this.cmbStudyForm.Name = "cmbStudyForm";
            this.cmbStudyForm.Size = new System.Drawing.Size(200, 24);
            this.cmbStudyForm.TabIndex = 6;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Location = new System.Drawing.Point(23, 178);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(104, 16);
            this.lblGrade.TabIndex = 14;
            this.lblGrade.Text = "Курс обучения";
            // 
            // cmbGrade
            // 
            this.cmbGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrade.FormattingEnabled = true;
            this.cmbGrade.Items.AddRange(new object[] {
            1,
            2,
            3,
            4,
            5});
            this.cmbGrade.Location = new System.Drawing.Point(163, 178);
            this.cmbGrade.Name = "cmbGrade";
            this.cmbGrade.Size = new System.Drawing.Size(200, 24);
            this.cmbGrade.TabIndex = 15;
            // 
            // txtWorkPlaceAdditional
            // 
            this.txtWorkPlaceAdditional.Enabled = false;
            this.txtWorkPlaceAdditional.Location = new System.Drawing.Point(163, 117);
            this.txtWorkPlaceAdditional.Name = "txtWorkPlaceAdditional";
            this.txtWorkPlaceAdditional.Size = new System.Drawing.Size(199, 22);
            this.txtWorkPlaceAdditional.TabIndex = 16;
            // 
            // lblWorkPlaceAdditional
            // 
            this.lblWorkPlaceAdditional.AutoSize = true;
            this.lblWorkPlaceAdditional.Location = new System.Drawing.Point(23, 117);
            this.lblWorkPlaceAdditional.Name = "lblWorkPlaceAdditional";
            this.lblWorkPlaceAdditional.Size = new System.Drawing.Size(126, 16);
            this.lblWorkPlaceAdditional.TabIndex = 17;
            this.lblWorkPlaceAdditional.Text = "Вид деятельности";
            // 
            // ParticipantInfoForm
            // 
            this.ClientSize = new System.Drawing.Size(395, 242);
            this.Controls.Add(this.lblWorkPlaceAdditional);
            this.Controls.Add(this.txtWorkPlaceAdditional);
            this.Controls.Add(this.cmbGrade);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.cmbStudyForm);
            this.Controls.Add(this.lblStudyForm);
            this.Controls.Add(this.cmbFaculty);
            this.Controls.Add(this.lblFaculty);
            this.Controls.Add(this.cmbWorkPlace);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.lblOccupation);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblAge);
            this.Name = "ParticipantInfoForm";
            this.Text = "Личные данные";
            this.KeyPreview = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ParticipiantInfoForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lblGrade;
        private ComboBox cmbGrade;
        private TextBox txtWorkPlaceAdditional;
        private Label lblWorkPlaceAdditional;
    }
}