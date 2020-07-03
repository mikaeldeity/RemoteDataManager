using System.Windows.Forms;

namespace RemoteDataManager
{
    public partial class ParametersDialog : Form
    {
        public ParametersDialog()
        {
            InitializeComponent();
        }

        private void ParametersDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ParametersDataGrid.BeginEdit(false);
        }
    }
}
