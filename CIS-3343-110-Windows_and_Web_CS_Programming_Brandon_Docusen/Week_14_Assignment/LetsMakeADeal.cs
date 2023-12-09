using System;
using System.Drawing; 
using System.Windows.Forms;

public class LetsMakeADealForm : Form
{
    private Button[] doorButtons = new Button[3];
    private Button yesButton;
    private Button noButton;
    private Label messageLabel;
    private string[] prizes = {"Car", "TV", "Goat"};
    private int[] doors = new int[3];  
    private int userChoice = -1;
    private bool userHasChosen = false;
    private int revealedDoorIndex = -1;

    static void Log(string msg) {
        Console.WriteLine(msg);
    }

    public LetsMakeADealForm()
    {
        InitializeComponents();
        ShufflePrizes();
    }

    private void InitializeComponents()
    {
        this.Size = new Size(300, 200);
        
        for (int i = 0; i < doorButtons.Length; i++) 
        {
            doorButtons[i] = new Button();
            doorButtons[i].Text = (i + 1).ToString();
            doorButtons[i].Location = new Point(10 + i * 60, 10);
            doorButtons[i].Size = new Size(50, 50);
            doorButtons[i].Click += new EventHandler(DoorButton_Click);
            this.Controls.Add(doorButtons[i]); 
        }

        yesButton = new Button();
        yesButton.Text = "Yes";
        yesButton.Location = new Point(10, 70);
        yesButton.Size = new Size(50, 50); 
        yesButton.Click += new EventHandler(YesButton_Click);
        yesButton.Enabled = false;
        this.Controls.Add(yesButton);

        noButton = new Button();
        noButton.Text = "No";  
        noButton.Location = new Point(70, 70);
        noButton.Size = new Size(50, 50);
        noButton.Click += new EventHandler(NoButton_Click); 
        noButton.Enabled = false;
        this.Controls.Add(noButton);

        messageLabel = new Label();
        messageLabel.Text = "Choose Door #1, #2, or #3.";
        messageLabel.Location = new Point(10, 130); 
        messageLabel.Size = new Size(280, 30);
        this.Controls.Add(messageLabel);
    }

    private void ShufflePrizes()
    {
        Random rand = new Random(); 
        int carDoor = rand.Next(0, 3);
        for (int i = 0; i < doors.Length; i++) {
            if (i == carDoor) {
                doors[i] = 0;  
            } else if (i == 1) {
                doors[i] = 1;   
            } else {
                doors[i] = 2;
            }
            
            Log("Doors shuffled. Door " + (i+1) + " has " + prizes[doors[i]]);
        }
    }

    private void DoorButton_Click(object sender, EventArgs e)
    {
        if (!userHasChosen) {
            
            Button clickedButton = sender as Button;
            userChoice = Convert.ToInt32(clickedButton.Text) - 1;

            
            foreach (Button btn in doorButtons) {
                btn.Enabled = false;
            }

           
            for (int i = 0; i < doors.Length; i++) {
                if (i != userChoice && prizes[doors[i]] != "Car") {
                   
                    messageLabel.Text = "Door " + (i + 1) + " has a " + prizes[doors[i]] + ".";
                    revealedDoorIndex = i;
                    break;
                }
            }

           
            yesButton.Enabled = true;
            noButton.Enabled = true;
            userHasChosen = true;
            messageLabel.Text += " Do you want to switch your choice?"; 
        }
        
        Log("User chose door " + (userChoice + 1));
        
        Log("Revealed door " + (revealedDoorIndex + 1) + " with " + prizes[doors[revealedDoorIndex]]);
        
    }

    private void YesButton_Click(object sender, EventArgs e)
    {
       
        for (int i = 0; i < doors.Length; i++) {
            if (i != userChoice && i != revealedDoorIndex) {
                userChoice = i;
                break;
            }
        }
        FinishGame();

        Log("User switched choice to door " + (userChoice + 1));
    }

    private void NoButton_Click(object sender, EventArgs e)
    {
       
        FinishGame();
    }

    private void FinishGame() 
    {
       
        messageLabel.Text = "You won a " + prizes[doors[userChoice]] + "!";  
        yesButton.Enabled = false;
        noButton.Enabled = false;
        

        foreach (Button btn in doorButtons) {
            btn.Enabled = true; 
        }
        ShufflePrizes();
        userHasChosen = false;

        Log("User won " + prizes[doors[userChoice]]);
        
    }

    [STAThread]
    static void Main()
    {
       
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new LetsMakeADealForm());
    }
}