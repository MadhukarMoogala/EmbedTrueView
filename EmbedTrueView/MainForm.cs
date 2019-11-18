using System;
using System.Windows.Forms;

namespace EmbedTrueView
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private void browseButton_Click(
      object sender, EventArgs e)
    {
      OpenFileDialog dlg =
        new OpenFileDialog();
      dlg.InitialDirectory =
        System.Environment.CurrentDirectory;

      dlg.Filter = 
        "DWG files (*.dwg)|*.dwg|All files (*.*)|*.*";

      Cursor oc = Cursor;

      String fn = "";

      if (dlg.ShowDialog() ==
        DialogResult.OK)
      {
        Cursor = Cursors.WaitCursor;
        fn = dlg.FileName;
        Refresh();
      }
      if (fn != "")
        this.drawingPath.Text = fn;

      Cursor = oc;
    }
    private void loadButton_Click(
      object sender, EventArgs e)
    {
        if (System.IO.File.Exists(drawingPath.Text))
        {
            //axAcCtrl1.Src = drawingPath.Text;
            axAcCtrl1.PutSourcePath(drawingPath.Text);
        }
        else
            MessageBox.Show("File does not exist");
    }
  }
}