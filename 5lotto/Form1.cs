using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5lotto
{
    public partial class Form1 : Form
    {
        private List<int> selectedNumbers = new List<int>();

        private List<Button> numberButtons = new List<Button>();

        public Form1()

        {

            InitializeComponent();

            GenerateNumbers();

        }

        private void GenerateNumbers()

        {

            Random rand = new Random();

            for (int i = 1; i <= 90; i++)

            {

                Button button = new Button();

                button.Name = "button" + i.ToString();

                button.Text = i.ToString();

                button.Width = 50;

                button.Height = 50;

                button.Location = new Point(10 + ((i - 1) % 10) * 55, 10 + ((i - 1) / 10) * 55);

                button.Click += Button_Click;

                numberButtons.Add(button);

                panel1.Controls.Add(button);

            }

            btnCheck.Click += BtnCheck_Click;

            label1.Text = "Válasszon ki 5 számot!";

        }

        private void Button_Click(object sender, EventArgs e)

        {

            Button button = sender as Button;

            int num = int.Parse(button.Text);

            if (selectedNumbers.Count < 5 && !selectedNumbers.Contains(num))

            {

                button.BackColor = Color.Red;

                selectedNumbers.Add(num);

            }

            else if (selectedNumbers.Contains(num))

            {

                button.BackColor = SystemColors.Control;

                selectedNumbers.Remove(num);

            }

        }

        private void BtnCheck_Click(object sender, EventArgs e)

        {

            Random rand = new Random();

            List<int> randomNumbers = new List<int>();

            List<int> matchingNumbers = new List<int>();

            foreach (Button button in numberButtons)

            {

                button.BackColor = SystemColors.Control;

            }

            while (randomNumbers.Count < 5)

            {

                int num = rand.Next(1, 91);

                if (!randomNumbers.Contains(num))

                {

                    randomNumbers.Add(num);

                }

            }

            foreach (int num in randomNumbers)

            {

                if (selectedNumbers.Contains(num))

                {

                    matchingNumbers.Add(num);

                    numberButtons[num - 1].BackColor = Color.Red;

                }

            }
            label3.Text = "Nyerőszámok: " + string.Join(", ", randomNumbers);
            label1.Text = "Kiválasztott számok: " + string.Join(", ", selectedNumbers);

            label2.Text = "Találatok: " + matchingNumbers.Count + "\nTalálatok: " + string.Join(", ", matchingNumbers);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
