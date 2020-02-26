//
/* Student Name: Siddhant Kumar Kandoi
 * Student ID: 19231361
 * Course Name: Masters Information Systems Management
 * Date: 13/11/2019
 * Assignment Number: 4
 * Assignment: InvestMe Financial Application
 * Naming Convention: PascalCasing; For each control I have tried to use the similar naming pattern 
 * i.e. Title of the form + Functionality + Control Type + Numeric digit 
 */


using System;
using System.Drawing;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Text;

namespace Kandoi_SiddhantKumar_BusinessApplicationAssignment4
{
    public partial class InvestMeForm1 : Form
    {
        public InvestMeForm1()
        {
            InitializeComponent();
        }

        //
        // Declaring global variables which is used at every click of Proceed, Confirm and Summary buttons
        decimal InvestmentAmount;
        decimal BalanceAmountAfterPlanSelect;
        string TransactionNumber;
        decimal BalanceOneYearPlan;
        decimal BalanceThreeYearsPlan;
        decimal BalanceFiveYearsPlan;
        decimal BalanceTenYearsPlan;
        int YearsPlanSelected;
        //
        // Declaring constant filename to be used at click of Confirm, Search and Summary buttons
        string FILENAME = "InvestMeTransactionFile.txt";
        //
        // Declaring constant global variables for interest rate up to 250,000Euros Investment which is used at every click of Proceed button
        const decimal ONEYEARINTERESTRATELOW = 0.0050000m;
        const decimal THREEYEARSINTERESTRATELOW = 0.0062500m;
        const decimal FIVEYEARSINTERESTRATELOW = 0.0071250m;
        const decimal TENYEARSINTERESTRATELOW = 0.0101250m;
        //
        // Declaring constant global variables for interest rate more than 250,000Euros Investment which is used at every click of Proceed button
        const decimal ONEYEARINTERESTRATEHIGH = 0.0060000m;
        const decimal THREEYEARSINTERESTRATEHIGH = 0.0072500m;
        const decimal FIVEYEARSINTERESTRATEHIGH = 0.0081250m;
        const decimal TENYEARSINTERESTRATEHIGH = 0.0102500m;
        //
        // Declaring constant global variables for Bonus amount which is used at click of Proceed button
        const decimal BONUSAMOUNT = 25000m;

        //
        // Event and Action defined for the load of Invest Me Application Page
        private void InvestMeForm1_Load(object sender, EventArgs e)
        {
            //
            // Code to let enter Investment amount, Get the summary or search for any transaction
            PlanGroupBox1.Enabled = false;
            // Client details need to be entered only after Investment amount and selecting the plan
            EnterClientDetailsGroupBox1.Enabled = false;
            //
            // Setting the focus on Invest amount text box 
            InvestmentAmountTextBox1.Focus();
        }

        //
        // Event to change the Investment amount textbox on the click of the mouse on the textbox
        private void InvestmentAmountTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            InvestmentAmountTextBox1.Text = "";
            InvestmentAmountTextBox1.Font = new Font(InvestmentAmountTextBox1.Font, FontStyle.Regular);
        }

        //
        // Event defiened when the user clicks on Display button
        private void DisplayButton1_Click(object sender, EventArgs e)
        {
            //
            // Try to check if the value entered in the Investment Amount Textbox is only numeric
            try
            {
                InvestmentAmount = decimal.Parse(InvestmentAmountTextBox1.Text);
                //
                //  To check if the value entered in the Investment Amount Textbox is non negative
                if (InvestmentAmount <= 0)
                {
                    MessageBox.Show("Investment amount should be positive value", "I/P Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    //
                    // Bringing the focus back to discountfare passenger textbox for user edit
                    InvestmentAmountTextBox1.Focus();
                    InvestmentAmountTextBox1.SelectAll();
                }
                else
                {
                    //
                    // If condition when the investment amount is less than or equal to 250000 Euros
                    if (InvestmentAmount <= 250000)
                    {
                        BalanceOneYearPlan = Math.Round(Convert.ToDecimal(Convert.ToDouble(InvestmentAmount) * Math.Pow((1 + Convert.ToDouble(ONEYEARINTERESTRATELOW)), 12)),2);
                        BalanceThreeYearsPlan = Math.Round(Convert.ToDecimal(Convert.ToDouble(InvestmentAmount) * Math.Pow((1 + Convert.ToDouble(THREEYEARSINTERESTRATELOW)), 36)),2);
                        BalanceFiveYearsPlan = Math.Round(Convert.ToDecimal(Convert.ToDouble(InvestmentAmount) * Math.Pow((1 + Convert.ToDouble(FIVEYEARSINTERESTRATELOW)), 60)),2);
                        BalanceTenYearsPlan = Math.Round(Convert.ToDecimal(Convert.ToDouble(InvestmentAmount) * Math.Pow((1 + Convert.ToDouble(TENYEARSINTERESTRATELOW)), 120)),2);
                        OneYearPlanRadioButton1.Text = "One Year Plan | Rate - " + ONEYEARINTERESTRATELOW + " | Balance Total - " + BalanceOneYearPlan + String.Format("\u20AC");
                        ThreeYearsPlanRadioButton1.Text = "Three Years Plan | Rate - " + THREEYEARSINTERESTRATELOW + " | Balance Total - " + BalanceThreeYearsPlan + String.Format("\u20AC");
                        FiveYearsPlanRadioButton1.Text = "Five Years Plan | Rate - " + FIVEYEARSINTERESTRATELOW + " | Balance Total - " + BalanceFiveYearsPlan + String.Format("\u20AC");
                        TenYearsPlanRadioButton1.Text = "Ten Years Plan | Rate - " + TENYEARSINTERESTRATELOW + " | Balance Total - " + BalanceTenYearsPlan + String.Format("\u20AC");
                    }
                    //
                    // Else if condition when investment amount is greater than 250000 Euros but less than 1000000 
                    else if (InvestmentAmount > 250000 && InvestmentAmount <= 1000000)
                    {
                        BalanceOneYearPlan = Math.Round(Convert.ToDecimal(Convert.ToDouble(InvestmentAmount) * Math.Pow((1 + Convert.ToDouble(ONEYEARINTERESTRATEHIGH)), 12)),2);
                        BalanceThreeYearsPlan = Math.Round(Convert.ToDecimal(Convert.ToDouble(InvestmentAmount) * Math.Pow((1 + Convert.ToDouble(THREEYEARSINTERESTRATEHIGH)), 36)),2);
                        BalanceFiveYearsPlan = Math.Round(Convert.ToDecimal(Convert.ToDouble(InvestmentAmount) * Math.Pow((1 + Convert.ToDouble(FIVEYEARSINTERESTRATEHIGH)), 60)),2);
                        BalanceTenYearsPlan = Math.Round(Convert.ToDecimal(Convert.ToDouble(InvestmentAmount) * Math.Pow((1 + Convert.ToDouble(TENYEARSINTERESTRATEHIGH)), 120)),2);
                        OneYearPlanRadioButton1.Text = "One Year Plan | Rate - " + ONEYEARINTERESTRATEHIGH + " | Balance Total - " + BalanceOneYearPlan + String.Format("\u20AC");
                        ThreeYearsPlanRadioButton1.Text = "Three Years Plan | Rate - " + THREEYEARSINTERESTRATEHIGH + " | Balance Total - " + BalanceThreeYearsPlan + String.Format("\u20AC");
                        FiveYearsPlanRadioButton1.Text = "Five Years Plan | Rate - " + FIVEYEARSINTERESTRATEHIGH + " | Balance Total - " + BalanceFiveYearsPlan + String.Format("\u20AC");
                        TenYearsPlanRadioButton1.Text = "Ten Years Plan | Rate - " + TENYEARSINTERESTRATEHIGH + " | Balance Total - " + BalanceTenYearsPlan + String.Format("\u20AC");
                    }
                    //
                    // Else condition when investment amount is greater than 1000000
                    else
                    {
                        BalanceOneYearPlan = Math.Round(Convert.ToDecimal(Convert.ToDouble(InvestmentAmount) * Math.Pow((1 + Convert.ToDouble(ONEYEARINTERESTRATEHIGH)), 12)),2);
                        BalanceThreeYearsPlan = Math.Round((Convert.ToDecimal(Convert.ToDouble(InvestmentAmount) * Math.Pow((1 + Convert.ToDouble(THREEYEARSINTERESTRATEHIGH)), 36))) + 25000,2);
                        BalanceFiveYearsPlan = Math.Round((Convert.ToDecimal(Convert.ToDouble(InvestmentAmount) * Math.Pow((1 + Convert.ToDouble(FIVEYEARSINTERESTRATEHIGH)), 60))) + 25000,2);
                        BalanceTenYearsPlan = Math.Round((Convert.ToDecimal(Convert.ToDouble(InvestmentAmount) * Math.Pow((1 + Convert.ToDouble(TENYEARSINTERESTRATEHIGH)), 120))) + 25000,2);
                        OneYearPlanRadioButton1.Text = "One Year Plan | Rate - " + ONEYEARINTERESTRATEHIGH + " | Balance Total - " + BalanceOneYearPlan + String.Format("\u20AC");
                        ThreeYearsPlanRadioButton1.Text = "Three Years Plan | Rate - " + THREEYEARSINTERESTRATEHIGH + " | Balance Total (Incl. Bonus) - " + BalanceThreeYearsPlan + String.Format("\u20AC");
                        FiveYearsPlanRadioButton1.Text = "Five Years Plan | Rate - " + FIVEYEARSINTERESTRATEHIGH + " | Balance Total (Incl. Bonus) - " + BalanceFiveYearsPlan + String.Format("\u20AC");
                        TenYearsPlanRadioButton1.Text = "Ten Years Plan | Rate - " + TENYEARSINTERESTRATEHIGH + " | Balance Total (Incl. Bonus) - " + BalanceTenYearsPlan + String.Format("\u20AC");
                    }
                    //
                    // After display button is clicked and amount entered is valid Investment Plan groupbox is enabled to select the investment plan
                    PlanGroupBox1.Enabled = true;
                    //
                    // Once the user has entered the amount we disable the user investment amount text box and Display button
                    DisplayButton1.Font = new Font(DisplayButton1.Font.Name, DisplayButton1.Font.Size, FontStyle.Regular);
                    InvestmentAmountGroupBox1.Enabled = false;
                    ProceedButton1.Font = new Font(ProceedButton1.Font.Name, ProceedButton1.Font.Size, FontStyle.Bold);
                }
            }
            catch
            {
                MessageBox.Show("Investment amount should be non empty positive value", "I/P Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                //
                // Bringing the focus back to Investment amount textbox for user edit
                InvestmentAmountTextBox1.Focus();
                InvestmentAmountTextBox1.SelectAll();
            }
        }

        //
        // Method defiened for checking the uniqueness of each random number which is getting generated. This method is being used by another method GenerateUniqueTransnum
        private Boolean CheckUnique(string Transnum, string FileName)
        {
            Boolean Unique = false;
            StreamReader InputFile;
            InputFile = File.OpenText(FileName);
            while (!InputFile.EndOfStream)
            {
                if (Transnum.Equals(InputFile.ReadLine()))
                {
                    InputFile.Close();
                    return Unique;
                }
            }
            Unique = true;
            InputFile.Close();
            return Unique;
        }

        //
        // Method defiened for generating the random 6 digit number and also calling the Unique method defined above to check the uniqueness 
        private string GenerateUniqueTransnum()
        {
            Random generator = new Random();
            string Transnum;
            Boolean IsThisUnique;
            do
            {
                Transnum = generator.Next(0, 999999).ToString("D6");
                IsThisUnique = CheckUnique(Transnum, FILENAME);
            } while (!IsThisUnique);
            return Transnum;
        }

        //
        // Code for Event and action for the click of Proceed button 
        private void ProceedButton1_Click(object sender, EventArgs e)
        {
            bool IsInvestmentPlanRadioButtonChecked = false;
            //
            // To check if any radio button has been selected by the user or not
            foreach (RadioButton rdbutton in PlanGroupBox1.Controls.OfType<RadioButton>())
            {
                if (rdbutton.Checked)
                {
                    IsInvestmentPlanRadioButtonChecked = true;
                    break;
                }
            }
            //
            // If no radio button is selected for the plan the user gets a message
            if (!IsInvestmentPlanRadioButtonChecked)
            {
                // Print message no button is selected 
                MessageBox.Show("Please select one investment plan", "Investment selection error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                //
                // Bringing the focus back to driver name textbox which is blank and needs user input
                PlanGroupBox1.Focus();

            }
            else
            {
                //
                // Calling the GenerateUniqueTransnum method for generating the unique transaction number
                TransactionNumber = GenerateUniqueTransnum();
                TransactionNumberAnswerClientDetailsLabel1.Text = TransactionNumber;
                //
                // Based on user radio button selection for the plan the values are stored in the global variables defiened 
                if (OneYearPlanRadioButton1.Checked == true)
                {
                    BalanceAmountAfterPlanSelect = BalanceOneYearPlan;
                    YearsPlanSelected = 1;
                }
                else if (ThreeYearsPlanRadioButton1.Checked == true)
                {
                    BalanceAmountAfterPlanSelect = BalanceThreeYearsPlan;
                    YearsPlanSelected = 3;
                }
                else if (FiveYearsPlanRadioButton1.Checked == true)
                {
                    BalanceAmountAfterPlanSelect = BalanceFiveYearsPlan;
                    YearsPlanSelected = 5;
                }
                else
                {
                    BalanceAmountAfterPlanSelect = BalanceTenYearsPlan;
                    YearsPlanSelected = 10;
                }
                //
                // Once the proceed button is clicked the user can enter client information and the groupbox is enabled
                EnterClientDetailsGroupBox1.Enabled = true;
                ConfirmButton1.Font = new Font(ConfirmButton1.Font.Name, ConfirmButton1.Font.Size, FontStyle.Bold);
            }
        }

        //
        // Event and Action defiened for the click of Confirm button
        private void ConfirmButton1_Click(object sender, EventArgs e)
        {
            string ClientName;
            string EmailId;
            int Telephone;
            ClientName = ClientNameAnsTextBox1.Text;
            //
            // To check if client name is not empty
            if (ClientName == "")
            {
                MessageBox.Show("Client Name should not be empty", "I/P Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                //
                // Bringing the focus back to discountfare passenger textbox for user edit
                ClientNameAnsTextBox1.Focus();
                ClientNameAnsTextBox1.SelectAll();
            }
            else
            {
                EmailId = EmailIDAnsTextBox1.Text;
                //
                // To check if EmailId contains @
                if (EmailId == "" || !EmailId.Contains("@"))
                {
                    MessageBox.Show("Client Email ID should be valid and not be empty", "I/P Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    //
                    // Bringing the focus back to discountfare passenger textbox for user edit
                    EmailIDAnsTextBox1.Focus();
                    EmailIDAnsTextBox1.SelectAll();
                }
                else
                {
                    //
                    // Try to check if telephone number is only integer but not decimal or text character
                    try
                    {
                        Telephone = int.Parse(TelephoneAnsTextBox1.Text);
                        //
                        // Setting the minimum length for telephone
                        if (TelephoneAnsTextBox1.Text.Length <= 5 || Telephone < 0)
                        {
                            MessageBox.Show("Client Telephone should be valid positive number of atleast 6 digits", "I/P Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            //
                            // Bringing the focus back to telephone textbox for user edit
                            TelephoneAnsTextBox1.Focus();
                            TelephoneAnsTextBox1.SelectAll();
                        }
                        else
                        {
                            if ((MessageBox.Show("Details of the transaction is below : \n\nClient : " + ClientName + "\nEmail ID : " + EmailId + "\nTelephone number : " + Telephone + "\nInvestment Amount : " + String.Format("\u20AC") + InvestmentAmount + "\nYears Selected" + YearsPlanSelected + " years \nBalance Amount : " + String.Format("\u20AC") + BalanceAmountAfterPlanSelect + "\nTransaction Number : " + TransactionNumber + "\n\nGet final confirmation from the client and click on yes", "Final Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                            {
                                //
                                // Incase user want to proceed after getting final confirmation from client
                                using (TextWriter TXT = File.AppendText(FILENAME))
                                {
                                    //TXT.WriteLine("");
                                    TXT.WriteLine(TransactionNumber);
                                    TXT.WriteLine(EmailId);
                                    TXT.WriteLine(InvestmentAmount);
                                    TXT.WriteLine(BalanceAmountAfterPlanSelect);
                                    TXT.WriteLine(YearsPlanSelected);
                                    TXT.WriteLine(ClientName);
                                    TXT.WriteLine(Telephone);
                                }
                                //
                                // Message box confirming the user about the successful investment
                                MessageBox.Show("Congratulations! Your client \n" + ClientName + " investment is succesfully done", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //
                                // Brings the user back for next investment and client
                                ClearButton1_Click(sender, e);
                            }
                            else
                            {
                                ClearButton1_Click(sender, e);
                            }
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Telephone number should be numeric positive number only", "Application Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        TelephoneAnsTextBox1.Focus();
                        TelephoneAnsTextBox1.SelectAll();
                    }
                }
            }
        }

        //
        // Method to get the radio buttons which are checked
        public IEnumerable<Control> GetAllRadButton(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrls => GetAllRadButton(ctrls, type)).Concat(controls).Where(c => c.GetType() == type);
        }

        private void ClearButton1_Click(object sender, EventArgs e)
        {
            //
            // Disabling the Investment Plan group box, Confirm group box, User input text boxes are cleared
            ConfirmButton1.Font = new Font(ConfirmButton1.Font.Name, ConfirmButton1.Font.Size, FontStyle.Regular);
            ProceedButton1.Font = new Font(ProceedButton1.Font.Name, ProceedButton1.Font.Size, FontStyle.Regular);
            TransactionNumberAnswerClientDetailsLabel1.Text = "";
            ClientNameAnsTextBox1.Text = "";
            EmailIDAnsTextBox1.Text = "";
            TelephoneAnsTextBox1.Text = "";
            EnterClientDetailsGroupBox1.Enabled = false;
            PlanGroupBox1.Enabled = false;
            //
            // Enabling the User input investment amount text box and group box
            InvestmentAmountGroupBox1.Enabled = true;
            DisplayButton1.Font = new Font(DisplayButton1.Font.Name, DisplayButton1.Font.Size, FontStyle.Bold);
            InvestmentAmountTextBox1.Text = "";
            //
            // Clearing the summary and search group box
            SummaryTransactionNumberListBox1.Items.Clear();
            SearchTransactionsListBox1.Items.Clear();
            TotalAmountInvestedAnsLabel1.Text = "";
            TotalInterestAnsLabel1.Text = "";
            AverageDurationAnsLabel1.Text = "";
            SearchResultEmailIdAnsLabel1.Text = "";
            SearchResultInvestedAmountAnswerLabel1.Text = "";
            SearchResultClientNameAnswerLabel1.Text = "";
            SearchResultBalanceAmountAnswerLabel1.Text = "";
            SearchResultTelephoneAnswerLabel1.Text = "";
            SearchResultTermPlanAnswerLabel1.Text = "";
            //
            // Changing the text of radio button to default
            OneYearPlanRadioButton1.Text = "1 Year Plan";
            ThreeYearsPlanRadioButton1.Text = "3 Years Plan";
            FiveYearsPlanRadioButton1.Text = "5 Years Plan";
            TenYearsPlanRadioButton1.Text = "10 Years Plan";
            SummaryButton1.Enabled = true;
            SummaryButton1.Font = new Font(SummaryButton1.Font.Name, SummaryButton1.Font.Size, FontStyle.Bold);
            //
            // Code for unchecking all the radio buttons selected in the plan group box
            var Cntl = GetAllRadButton(this, typeof(RadioButton));
            foreach (Control cntrl in Cntl)
            {
                RadioButton _RadButton = (RadioButton)cntrl;
                if (_RadButton.Checked)
                {
                    _RadButton.Checked = false;
                }
            }
            SearchTextBox1.Text = "";
            //
            // Setting the focus back to investment amount text box
            InvestmentAmountTextBox1.Focus();
        }

        //
        // Event and action defiened for the click of Summary button
        private void SummaryButton1_Click(object sender, EventArgs e)
        {
            //
            // Try to see if any data exist in the file or if the file exists
            try
            {
                StreamReader InputFile;
                InputFile = File.OpenText(FILENAME);
                string[] AllLines = new string[200];
                int count = 1;
                string Line;
                decimal TotalInvestedAmount = 0;
                decimal TotalBalanceAmount = 0;
                decimal TotalYearsPlan = 0;
                SummaryGroupBox1.Enabled = true;
                //
                // While loop to fetch the data from text file and calculate the summary
                while (!InputFile.EndOfStream)
                {
                    //AllLines[count-1] = InputFile.ReadLine();
                    Line = InputFile.ReadLine();
                    if ((count - 1) % 7 == 0)
                    {
                        SummaryTransactionNumberListBox1.Items.Add(Line);
                    }
                    else if ((count - 1) % 7 == 2)
                    {
                        TotalInvestedAmount = TotalInvestedAmount + decimal.Parse(Line);
                    }
                    else if ((count - 1) % 7 == 3)
                    {
                        TotalBalanceAmount = TotalBalanceAmount + decimal.Parse(Line);
                    }
                    else if ((count - 1) % 7 == 4)
                    {
                        TotalYearsPlan = TotalYearsPlan + decimal.Parse(Line);
                    }
                    count++;
                }
                SummaryButton1.Font = new Font(SummaryButton1.Font.Name, SummaryButton1.Font.Size, FontStyle.Regular);
                SummaryButton1.Enabled = false;
                TotalAmountInvestedAnsLabel1.Text = TotalInvestedAmount.ToString();
                TotalInterestAnsLabel1.Text = (TotalBalanceAmount - TotalInvestedAmount).ToString();
                //
                // To calculate the Average duration for the summary
                AverageDurationAnsLabel1.Text = Math.Round((TotalYearsPlan * 7 / (count - 1)), 2).ToString() + " Years";
            }
            catch
            {
                // Print message no transaction found and Summary button is enabled
                MessageBox.Show("Couldn't find any transaction in the file to show summary", "No Transaction Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SummaryButton1.Enabled = true;
                SummaryButton1.Font = new Font(SummaryButton1.Font.Name, SummaryButton1.Font.Size, FontStyle.Bold);
            }
        }

        //
        // Method defiened for search of transactions by transaction number. This method acceptds the search string
        private void SearchByTransactionNumber(string TransNum)
        {
            string ReadText;
            string Details;
            StreamReader InputFile;
            InputFile = File.OpenText(FILENAME);
            int count = 1;
            bool IsAvailable = false;
            while (!InputFile.EndOfStream)
            {
                ReadText = InputFile.ReadLine();
                if ((count - 1) % 7 == 0 && ReadText == TransNum)
                {
                    IsAvailable = true;
                    Details = InputFile.ReadLine();
                    SearchResultEmailIdAnsLabel1.Text = Details;
                    Details = InputFile.ReadLine();
                    SearchResultInvestedAmountAnswerLabel1.Text = Details;
                    Details = InputFile.ReadLine();
                    SearchResultBalanceAmountAnswerLabel1.Text = Details;
                    Details = InputFile.ReadLine();
                    SearchResultTermPlanAnswerLabel1.Text = Details + " Years";
                    Details = InputFile.ReadLine();
                    SearchResultClientNameAnswerLabel1.Text = Details;
                    Details = InputFile.ReadLine();
                    SearchResultTelephoneAnswerLabel1.Text = Details;
                }
                count++;
            }
            //
            // Message to show when the search couldn't find the search string user was looking for
            if (IsAvailable == false)
            {
                MessageBox.Show("Couldn't find the transaction number you entered", "Search Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //
                // Bringing the focus back to Search string text box textbox which is blank and needs user input
                SearchTextBox1.Focus();
            }
        }

        //
        // Method defiened for search of transactions by Email ID. This method acceptds the search string
        private void SearchByEmailId(string EmailId)
        {
            string ReadTranNum;
            string ReadEmailId;
            string Dump;
            //string Details;
            StreamReader InputFile;
            InputFile = File.OpenText(FILENAME);
            bool IsAvailable = false;
            while (!InputFile.EndOfStream)
            {
                ReadTranNum = InputFile.ReadLine();
                ReadEmailId = InputFile.ReadLine();
                if (ReadEmailId == EmailId)
                {
                    IsAvailable = true;
                    SearchTransactionsListBox1.Items.Add(ReadTranNum);
                    Dump = InputFile.ReadLine();
                    Dump = InputFile.ReadLine();
                    Dump = InputFile.ReadLine();
                    Dump = InputFile.ReadLine();
                    Dump = InputFile.ReadLine();

                }
                else
                {
                    Dump = InputFile.ReadLine();
                    Dump = InputFile.ReadLine();
                    Dump = InputFile.ReadLine();
                    Dump = InputFile.ReadLine();
                    Dump = InputFile.ReadLine();
                }
            }
            //
            // Message to show when the search couldn't find the search string user was looking for
            if (IsAvailable == false)
            {
                MessageBox.Show("Couldn't find the transaction number for Email ID you entered", "Search Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //
                // Bringing the focus back to Search string text box textbox which is blank and needs user input
                SearchTextBox1.Focus();
            }
        }

        //
        // Event coded for the click of Search button 
        private void SearchButton1_Click(object sender, EventArgs e)
        {
            bool IsSearchButtonChecked = false;
            string SearchTranNum = SearchTextBox1.Text;
            //
            // To check if any radio button (Transaction number or Email ID) is selected for the search
            foreach (RadioButton rdbutton in SearchGroupBox1.Controls.OfType<RadioButton>())
            {
                if (rdbutton.Checked)
                {
                    IsSearchButtonChecked = true;
                    break;
                }
            }
            if (!IsSearchButtonChecked)
            {
                // Print message no button is selected
                MessageBox.Show("Please select one search type", "Search type selection error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                //
                // Bringing the focus back to SEARCH button which is blank and needs user input
                SearchButton1.Focus();

            }
            else
            {
                SearchResultEmailIdAnsLabel1.Text = "";
                SearchResultInvestedAmountAnswerLabel1.Text = "";
                SearchResultClientNameAnswerLabel1.Text = "";
                SearchResultBalanceAmountAnswerLabel1.Text = "";
                SearchResultTelephoneAnswerLabel1.Text = "";
                SearchResultTermPlanAnswerLabel1.Text = "";
                SearchTransactionsListBox1.Items.Clear();
                //
                // Calling the method based on user radio button selection and passing the search string
                if (SearchTransNumRadioButton1.Checked == true)
                {
                    SearchByTransactionNumber(SearchTranNum);
                }
                else
                {
                    SearchByEmailId(SearchTranNum);
                }
            }
        }

        //
        // Event marked to show the transaction details of each transaction when clicked on the list box which gets poppulated with the list of transactions based on email id search
        private void TransactionsListBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                SearchByTransactionNumber(SearchTransactionsListBox1.SelectedItem.ToString());
            }
            catch
            {
                // Print message to show no transaction found 
                MessageBox.Show("There is no transaction as per your search", "No Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //
                // Bringing the focus back to Search button which is blank and needs user input
                SearchButton1.Focus();
            }
        }

        //
        // Action for the click of Exit button
        private void ExitButton1_Click(object sender, EventArgs e)
        {
            //
            // If condition to confirm with user if the user really wants to exit or not, if yes the application is closed
            if ((MessageBox.Show("Are you sure you want to exit?", "Exit Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
            {
                Application.Exit();
            } 
        }
    }
}