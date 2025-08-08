namespace IAT_Test
{
    public partial class ParticipantInfoForm : Form
    {
        public ParticipantData ParticipantData { get; private set; } = null!;

        public ParticipantInfoForm()
        {
            InitializeComponent();
            LoadWorkPlaces();
            LoadFaculties();
            LoadStudyForms();
            cmbGender.SelectedIndex = 0;
            cmbGrade.SelectedIndex = 0;
            txtWorkPlaceAdditional.Visible = false;
        }

        private void LoadWorkPlaces()
        {
            try
            {
                string[] work_places = File.ReadAllText("./exmp/work_places.txt").Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string work_place in work_places)
                {
                    cmbWorkPlace.Items.Add(work_place.Trim());
                }
                cmbWorkPlace.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке родов деятельности: " + ex.Message);
            }
        }

        private void LoadFaculties()
        {
            try
            {
                string[] faculties = File.ReadAllText("./exmp/faculties.txt").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string faculty in faculties)
                {
                    cmbFaculty.Items.Add(faculty.Trim());
                }
                cmbFaculty.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке факультетов: " + ex.Message);
            }
        }

        private void LoadStudyForms()
        {
            string studyFormsPath = Path.Combine(Application.StartupPath, "./exmp/study_forms.txt");
            if (File.Exists(studyFormsPath))
            {
                string[] studyForms = File.ReadAllLines(studyFormsPath);
                cmbStudyForm.Items.AddRange(studyForms);
            }
            cmbStudyForm.SelectedIndex = 0;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtAge.Text) ||
                cmbGender.SelectedItem == null || cmbWorkPlace.SelectedItem == null ||
                cmbFaculty.SelectedItem == null || cmbStudyForm.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void cmbWorkPlace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbWorkPlace?.SelectedItem?.ToString() == "Другой вид деятельности (укажите)")
            {
                txtWorkPlaceAdditional.Enabled = true;
                txtWorkPlaceAdditional.Visible = true;
                lblWorkPlaceAdditional.Visible = true;
                cmbFaculty.Visible = false;
                cmbStudyForm.Visible = false;
                cmbGrade.Visible = false;
                lblFaculty.Visible = false;
                lblStudyForm.Visible = false;
                lblGrade.Visible = false;
            }
            else
            {
                txtWorkPlaceAdditional.Enabled = false;
                txtWorkPlaceAdditional.Visible = false;
                lblWorkPlaceAdditional.Visible = false;
                lblFaculty.Visible = true;
                lblStudyForm.Visible = true;
                lblGrade.Visible = true;
            }

            if (cmbWorkPlace?.SelectedItem?.ToString() == "Студент")
            {
                cmbFaculty.Visible = true;
                cmbStudyForm.Visible = true;
                cmbGrade.Visible = true;
                lblFaculty.Visible = true;
                lblStudyForm.Visible = true;
                lblGrade.Visible = true;
            }
            else
            {
                cmbFaculty.Visible = false;
                cmbStudyForm.Visible = false;
                cmbGrade.Visible = false;
                lblFaculty.Visible = false;
                lblStudyForm.Visible = false;
                lblGrade.Visible = false;
            }

        }

        private void ParticipiantInfoForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32 && ValidateInput())
            {
                ParticipantData = new ParticipantData
                {
                    Age = int.Parse(txtAge.Text),
                    Gender = cmbGender.SelectedItem?.ToString() ?? string.Empty,
                    Occupation = txtWorkPlaceAdditional.Visible ? txtWorkPlaceAdditional.Text.ToString() : cmbWorkPlace.SelectedItem?.ToString() ?? string.Empty,
                    Faculty = cmbFaculty.Visible ? cmbFaculty?.SelectedItem?.ToString() : string.Empty,
                    StudyForm = cmbStudyForm.Visible ? cmbStudyForm.SelectedItem?.ToString() : string.Empty,
                    Course = cmbGrade.Visible ? int.Parse(cmbGrade.SelectedItem?.ToString() ?? string.Empty) : 0
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }

    public partial class ParticipantData
    {
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Occupation { get; set; }
        public string? Faculty { get; set; }
        public string? StudyForm { get; set; }
        public int Course { get; set; }
    }
}