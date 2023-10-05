using Lab_05_RePort.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_05_RePort
{
    public partial class frmStudentManagement : Form
    {
        public frmStudentManagement()
        {
            InitializeComponent();
        }

        private void frmStudentManagement_Load(object sender, EventArgs e)
        {
            StudentDBContext context = new StudentDBContext();
            List<Student> listStudent = context.Students.ToList();
            List<StudentReport> listReport = new List<StudentReport>();
            foreach (Student i in listStudent) 
{
                StudentReport temp = new StudentReport();
                temp.StudentID = i.StudentID;
                temp.FullName = i.FullName;
                temp.AverageScore = i.AverageScore;
                temp.FacultyName = i.Faculty.FacultyName;
                listReport.Add(temp);
            }
            this.reportViewer1.LocalReport.ReportPath = "C:\\Users\\Admin\\Desktop\\2180602115_TrinhTuanDan\\Lab_05_RePort\\StudentReport.rdlc";
            var reportDataSource = new ReportDataSource("StudenDataSet", listReport);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
