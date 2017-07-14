using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BowlingApp
{
    /// <summary>
    /// Interaction logic for FinalBowlerFrame.xaml
    /// </summary>
    public partial class FinalBowlerFrame : UserControl
    {
        #region Static members definition
        public enum SHOT { First, Second, Third };
        #endregion

        #region Members definition
        #region Event members definition
        public event EventHandler<TextChangedEventArgs> TextChanged;
        #endregion Event members definition

        public int Score
        {
            get { return getScore(); }
        }
        #endregion Members definition

        #region Constructors definition
        public FinalBowlerFrame()
        {
            InitializeComponent();
        }
        #endregion Constructors definition

        #region Methods definition
        /// <summary>
        /// Event handler for the "Spare" button's Click event.
        /// </summary>
        /// <param name="sender">Object that fired the event.</param>
        /// <param name="e">Event arguments.</param>
        private void spareButton_Click(object sender, RoutedEventArgs e)
        {
            if (firstBallTextBox.Text == "")
            {

            }
            else if (secondBallTextBox.Text == "")
            {
                this.secondBallTextBox.Text = "/";
            }
        }

        /// <summary>
        /// Event handler for the "Strike" button's Click event.
        /// </summary>
        /// <param name="sender">Object that fired the event.</param>
        /// <param name="e">Event arguments.</param>
        private void strikeButton_Click(object sender, RoutedEventArgs e)
        {
            if (firstBallTextBox.Text == "")
            {
                this.firstBallTextBox.Text = "X";
            }
            else if (secondBallTextBox.Text == "" && !Regex.IsMatch(this.firstBallTextBox.Text, @"[\d]{1}"))
            {
                this.secondBallTextBox.Text = "X";
            }
            else if (thirdBallTextBox.Text == "" && this.secondBallTextBox.Text != "")
            {
                this.thirdBallTextBox.Text = "X";
            }
        }

        /// <summary>
        /// Handles resetting buttons when text boxes are changed.
        /// </summary>
        /// <param name="sender">Object that fired the event.</param>
        /// <param name="e">Event arguments.</param>
        private void commonTextChangedHandler(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(this.secondBallTextBox.Text, @"[\d]{1}"))
            {
                // A digit was entered in the second text box, indicating that they got an open frame.
                // Lock the third text box.
                this.thirdBallTextBox.IsEnabled = false;
            }

            if (!this.thirdBallTextBox.IsEnabled && !(Regex.IsMatch(this.firstBallTextBox.Text, @"[\d]{1}") && Regex.IsMatch(this.secondBallTextBox.Text, @"[\d]{1}")))
            {
                // The Strike button had been clicked and the second text box locked but the first text box is now clear.
                // Re-enable the second text box.
                this.thirdBallTextBox.IsEnabled = true;
            }

            if (this.firstBallTextBox.Text == "" && this.secondBallTextBox.Text == "/")
            {
                // The user entered a number, then clicked spare, and now tried to remove the first number without removing the spare.
                // Remove the spare.
                this.secondBallTextBox.Text = "";
            }

            if (this.secondBallTextBox.Text == "" && this.thirdBallTextBox.Text == "/")
            {
                // The user entered a number, then clicked spare, and now tried to remove the first number without removing the spare.
                // Remove the spare.
                this.thirdBallTextBox.Text = "";
            }

            TextChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Checks if the entered character is valid and rejects the keypress if it is not.
        /// </summary>
        /// <param name="sender">Object that fired the event.</param>
        /// <param name="e">Event arguments.</param>
        private void commonKeyDownEventHandler(object sender, KeyEventArgs e)
        {
            if (!Regex.IsMatch(e.Key.ToString(), @"[\d]{1}"))
            {
                e.Handled = true;
            }
            else if (((TextBox)e.Source).Text != "")
            {
                e.Handled = true;
            }

            // Gets the other TextBox (that is not being entered into) in order to check if
            // this number can be entered.
            TextBox otherTextBox;
            if (((TextBox)e.Source).Name == "firstBallTextBox")
            {
                otherTextBox = secondBallTextBox;
            }
            else
            {
                otherTextBox = firstBallTextBox;
            }

            // Check if the currently typed number and the number in the other TextBox add up to
            // more than 9 (ie, they are too big to be typed together).
            try
            {
                if (keyToNum(e.Key) + Int32.Parse(otherTextBox.Text) > 9)
                {
                    e.Handled = true;
                    return;
                }
            }
            catch (FormatException)
            {
                if (otherTextBox.Text == "")
                {
                    // The other TextBox is empty. We can enter the character.
                }
                else
                {
                    // The other box contains a character of some sort, so that must be
                    // because this is a strike or a spare. We will simply reject the keystroke.
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// Small helper method. If the given Key is a valid digit, returns it as an integer.
        /// </summary>
        /// <param name="key">Key to convert to a digit.</param>
        /// <returns>The integer digit corresponding to the given key value.</returns>
        private int keyToNum(Key key)
        {
            switch (key)
            {
                case Key.D0:
                case Key.NumPad0:
                    return 0;
                case Key.D1:
                case Key.NumPad1:
                    return 1;
                case Key.D2:
                case Key.NumPad2:
                    return 2;
                case Key.D3:
                case Key.NumPad3:
                    return 3;
                case Key.D4:
                case Key.NumPad4:
                    return 4;
                case Key.D5:
                case Key.NumPad5:
                    return 5;
                case Key.D6:
                case Key.NumPad6:
                    return 6;
                case Key.D7:
                case Key.NumPad7:
                    return 7;
                case Key.D8:
                case Key.NumPad8:
                    return 8;
                case Key.D9:
                case Key.NumPad9:
                    return 9;
                default:
                    throw new ArgumentException("The given Key was not a digit", nameof(key));
            }
        }

        /// <summary>
        /// Returns the integer score of the given shot number, either the first shot, the second, or the third.
        /// </summary>
        /// <param name="shot">Enum value representing which number shot to get.</param>
        /// <returns>Integer score of the given shot.</returns>
        public int getShotScore(SHOT shot)
        {
            switch (shot)
            {
                case SHOT.First:
                    if (this.firstBallTextBox.Text == "")
                    {
                        return 0;
                    }
                    else if (this.firstBallTextBox.Text == "/")
                    {
                        return 10;
                    }
                    else if (this.firstBallTextBox.Text == "X")
                    {
                        return 10;
                    }

                    try
                    {
                        return Int32.Parse(this.firstBallTextBox.Text);
                    }
                    catch (FormatException e)
                    {
                        // Shouldn't happen.
                        throw e;
                    }
                case SHOT.Second:
                    if (this.secondBallTextBox.Text == "")
                    {
                        return 0;
                    }
                    else if (this.secondBallTextBox.Text == "/")
                    {
                        return 10;
                    }
                    else if (this.secondBallTextBox.Text == "X")
                    {
                        return 10;
                    }

                    try
                    {
                        return Int32.Parse(this.secondBallTextBox.Text);
                    }
                    catch (FormatException e)
                    {
                        // Shouldn't happen.
                        throw e;
                    }
                case SHOT.Third:
                    if (this.thirdBallTextBox.Text == "")
                    {
                        return 0;
                    }
                    else if (this.thirdBallTextBox.Text == "/")
                    {
                        return 10;
                    }
                    else if (this.thirdBallTextBox.Text == "X")
                    {
                        return 10;
                    }

                    try
                    {
                        return Int32.Parse(this.thirdBallTextBox.Text);
                    }
                    catch (FormatException e)
                    {
                        // Shouldn't happen.
                        throw e;
                    }
                default:
                    throw new ArgumentException("The given enum value was invalid.", nameof(shot));
            }
        }

        /// <summary>
        /// Returns the integer total score of this frame.
        /// </summary>
        /// <returns>Integer score of this frame.</returns>
        public int getScore()
        {
            int total = 0;

            if (this.firstBallTextBox.Text == "")
            {
                total += 0;
            }
            else if (this.firstBallTextBox.Text == "X")
            {
                total += 10;
            }
            else
            {
                try
                {
                    total += Int32.Parse(this.firstBallTextBox.Text);
                }
                catch (FormatException e)
                {
                    throw e;
                }
            }

            if (this.secondBallTextBox.Text == "")
            {
                total += 0;
            }
            else if (this.secondBallTextBox.Text == "/")
            {
                try
                {
                    total += 10 - Int32.Parse(this.firstBallTextBox.Text);
                }
                catch (FormatException e)
                {
                    throw e;
                }
            }
            else if (this.secondBallTextBox.Text == "X")
            {
                total += 10;
            }
            else
            {
                try
                {
                    total += Int32.Parse(this.secondBallTextBox.Text);
                }
                catch (FormatException e)
                {
                    throw e;
                }
            }

            if (this.thirdBallTextBox.Text == "")
            {
                total += 0;
            }
            else if (this.thirdBallTextBox.Text == "X")
            {
                total += 10;
            }
            else
            {
                try
                {
                    total += Int32.Parse(this.thirdBallTextBox.Text);
                }
                catch (FormatException e)
                {
                    throw e;
                }
            }

            return total;
        }
        #endregion Methods definition
    }
}
