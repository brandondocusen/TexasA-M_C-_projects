using System;
using System.Windows.Forms;

namespace ProjectedRaisesGUI {

  public partial class SalaryCalculator : Form {

    private TextBox salaryTextBox;
    private Button calcButton;
    private Label resultLabel;

    public SalaryCalculator() {
      InitializeComponent();
    }

    private void InitializeComponent() {
        
      this.salaryTextBox = new TextBox();
      this.calcButton = new Button();
      this.resultLabel = new Label();
       
      this.salaryTextBox.Location = new System.Drawing.Point(30, 30);
      this.calcButton.Location = new System.Drawing.Point(30, 70);
      this.resultLabel.Location = new System.Drawing.Point(30, 110);

      this.calcButton.Text = "Calculate";
      this.calcButton.Click += CalcButton_Click;

      this.Controls.Add(this.salaryTextBox);
      this.Controls.Add(this.calcButton);
      this.Controls.Add(this.resultLabel);
      
    }

    private void CalcButton_Click(object sender, EventArgs e) {
            
      double salary = Convert.ToDouble(salaryTextBox.Text);
      double projectedSalary = salary * 1.04;

      resultLabel.Text = string.Format("sal {0:C}", projectedSalary);

    }

    static void Main() {
         
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new SalaryCalculator());
       
    }

  }

}