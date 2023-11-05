using System;
using System.Windows.Forms;

namespace MakeChangeGUI {

  public partial class MakeChangeForm : Form {

    private TextBox dollarTextBox;
    private Button calculateButton;
    private Label resultLabel;

    public MakeChangeForm() {
      InitializeComponent();
    }

    private void InitializeComponent() {

      this.dollarTextBox = new TextBox();
      this.calculateButton = new Button();
      this.resultLabel = new Label();

      this.dollarTextBox.Location = new System.Drawing.Point(30, 30);
      this.calculateButton.Location = new System.Drawing.Point(30, 70);
      this.resultLabel.Location = new System.Drawing.Point(30, 110);

      this.calculateButton.Text = "Calculate";
      this.calculateButton.Click += CalculateButton_Click;

      this.Controls.Add(this.dollarTextBox);
      this.Controls.Add(this.calculateButton);
      this.Controls.Add(this.resultLabel);

      resultLabel.AutoSize = true;

    }

    private void CalculateButton_Click(object sender, EventArgs e) {


      double dollars = Convert.ToDouble(dollarTextBox.Text);

      int twenties;
      int tens;
      int fives;
      int ones;

      twenties = (int)(dollars / 20);
      dollars %= 20;

      tens = (int)(dollars / 10);
      dollars %= 10;

      fives = (int)(dollars / 5);
      dollars %= 5; 

      ones = (int)dollars;

    
      resultLabel.Text = string.Format("Twenties: {0} Tens: {1} Fives: {2} Ones: {3}", 
           twenties, tens, fives, ones);

    }

    static void Main() {

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MakeChangeForm());
    }

  }

}