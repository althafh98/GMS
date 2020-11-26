using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Project
{
    public partial class frmPrint : Form
    {
        List<Receipt> _list;
        string _total, _cash, _balance, _date;  
        public frmPrint(List<Receipt> dataSource, string total,string cash, string balance, string date)
        {
            InitializeComponent();
            _list = dataSource;
            _total = total;
            _cash = cash;
            _balance = balance;
            _date = date;
        }

        private void Print_Load(object sender, EventArgs e)
        {
            ReceiptBindingSource.DataSource = _list;
            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter ("pTotal", _total),
                new Microsoft.Reporting.WinForms.ReportParameter ("pCash", _cash),
                new Microsoft.Reporting.WinForms.ReportParameter ("pBalance", _balance),
                new Microsoft.Reporting.WinForms.ReportParameter ("pDate", _date),

            };
            this.reportViewer.LocalReport.SetParameters(para);
            this.reportViewer.RefreshReport();
        }
    }
}
