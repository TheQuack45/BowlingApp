using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for BowlerFrames.xaml
    /// </summary>
    public partial class BowlerFrames : UserControl
    {
        #region Constructors definition
        public BowlerFrames()
        {
            InitializeComponent();
        }
        #endregion Constructors definition

        #region Methods definition
        /// <summary>
        /// Calculates the total score of the game and displays it in bowlerScore TextBox.
        /// </summary>
        /// <param name="sender">Object which fired the event.</param>
        /// <param name="e">Event arguments.</param>
        public void RecalculateScore(object sender, TextChangedEventArgs e)
        {
            int total = 0;

            #region Frame scores
            Tuple<int, BowlerFrame.SCORE_STATE> s1 = firstFrame.Score;
            Tuple<int, BowlerFrame.SCORE_STATE> s2 = secondFrame.Score;
            Tuple<int, BowlerFrame.SCORE_STATE> s3 = thirdFrame.Score;
            Tuple<int, BowlerFrame.SCORE_STATE> s4 = fourthFrame.Score;
            Tuple<int, BowlerFrame.SCORE_STATE> s5 = fifthFrame.Score;
            Tuple<int, BowlerFrame.SCORE_STATE> s6 = sixthFrame.Score;
            Tuple<int, BowlerFrame.SCORE_STATE> s7 = seventhFrame.Score;
            Tuple<int, BowlerFrame.SCORE_STATE> s8 = eighthFrame.Score;
            Tuple<int, BowlerFrame.SCORE_STATE> s9 = ninthFrame.Score;
            #endregion Frame scores

            #region Frame one
            total += s1.Item1;
            if (s1.Item2 == BowlerFrame.SCORE_STATE.Spare)
            {
                if (secondFrame.firstBallTextBox.Text == "")
                {
                    bowlerScore.Text = "?";
                    return;
                }
                else
                {
                    total += secondFrame.getShotScore(BowlerFrame.SHOT.First);
                }
            }
            else if (s1.Item2 == BowlerFrame.SCORE_STATE.Strike)
            {
                if (secondFrame.firstBallTextBox.Text == "" || secondFrame.secondBallTextBox.Text == "" && s2.Item2 != BowlerFrame.SCORE_STATE.Strike)
                {
                    bowlerScore.Text = "?";
                    return;
                }

                if (s2.Item2 == BowlerFrame.SCORE_STATE.Spare)
                {
                    total += 10;
                }
                else
                {
                    if (s2.Item2 == BowlerFrame.SCORE_STATE.Strike)
                    {
                        total += 10;
                        total += thirdFrame.getShotScore(BowlerFrame.SHOT.First);
                    }
                    else
                    {
                        total += secondFrame.getShotScore(BowlerFrame.SHOT.First);
                        total += secondFrame.getShotScore(BowlerFrame.SHOT.Second);
                    }
                }
            }
            #endregion Frame one

            #region Frame two
            total += s2.Item1;
            if (s2.Item2 == BowlerFrame.SCORE_STATE.Spare)
            {
                if (thirdFrame.firstBallTextBox.Text == "")
                {
                    bowlerScore.Text = "?";
                    return;
                }
                else
                {
                    total += thirdFrame.getShotScore(BowlerFrame.SHOT.First);
                }
            }
            else if (s2.Item2 == BowlerFrame.SCORE_STATE.Strike)
            {
                if (thirdFrame.firstBallTextBox.Text == "" || thirdFrame.secondBallTextBox.Text == "" && s3.Item2 != BowlerFrame.SCORE_STATE.Strike)
                {
                    bowlerScore.Text = "?";
                    return;
                }

                if (s3.Item2 == BowlerFrame.SCORE_STATE.Spare)
                {
                    total += 10;
                }
                else
                {
                    if (s3.Item2 == BowlerFrame.SCORE_STATE.Strike)
                    {
                        total += 10;
                        total += fourthFrame.getShotScore(BowlerFrame.SHOT.First);
                    }
                    else
                    {
                        total += thirdFrame.getShotScore(BowlerFrame.SHOT.First);
                        total += thirdFrame.getShotScore(BowlerFrame.SHOT.Second);
                    }
                }
            }
            #endregion Frame two

            #region Frame three
            total += s3.Item1;
            if (s3.Item2 == BowlerFrame.SCORE_STATE.Spare)
            {
                if (fourthFrame.firstBallTextBox.Text == "")
                {
                    bowlerScore.Text = "?";
                    return;
                }
                else
                {
                    total += fourthFrame.getShotScore(BowlerFrame.SHOT.First);
                }
            }
            else if (s3.Item2 == BowlerFrame.SCORE_STATE.Strike)
            {
                if (fourthFrame.firstBallTextBox.Text == "" || fourthFrame.secondBallTextBox.Text == "" && s4.Item2 != BowlerFrame.SCORE_STATE.Strike)
                {
                    bowlerScore.Text = "?";
                    return;
                }

                if (s4.Item2 == BowlerFrame.SCORE_STATE.Spare)
                {
                    total += 10;
                }
                else
                {
                    if (s4.Item2 == BowlerFrame.SCORE_STATE.Strike)
                    {
                        total += 10;
                        total += fifthFrame.getShotScore(BowlerFrame.SHOT.First);
                    }
                    else
                    {
                        total += fourthFrame.getShotScore(BowlerFrame.SHOT.First);
                        total += fourthFrame.getShotScore(BowlerFrame.SHOT.Second);
                    }
                }
            }
            #endregion Frame three

            #region Frame four
            total += s4.Item1;
            if (s4.Item2 == BowlerFrame.SCORE_STATE.Spare)
            {
                if (fifthFrame.firstBallTextBox.Text == "")
                {
                    bowlerScore.Text = "?";
                    return;
                }
                else
                {
                    total += fifthFrame.getShotScore(BowlerFrame.SHOT.First);
                }
            }
            else if (s4.Item2 == BowlerFrame.SCORE_STATE.Strike)
            {
                if (fifthFrame.firstBallTextBox.Text == "" || fifthFrame.secondBallTextBox.Text == "" && s5.Item2 != BowlerFrame.SCORE_STATE.Strike)
                {
                    bowlerScore.Text = "?";
                    return;
                }

                if (s5.Item2 == BowlerFrame.SCORE_STATE.Spare)
                {
                    total += 10;
                }
                else
                {
                    if (s5.Item2 == BowlerFrame.SCORE_STATE.Strike)
                    {
                        total += 10;
                        total += sixthFrame.getShotScore(BowlerFrame.SHOT.First);
                    }
                    else
                    {
                        total += fifthFrame.getShotScore(BowlerFrame.SHOT.First);
                        total += fifthFrame.getShotScore(BowlerFrame.SHOT.Second);
                    }
                }
            }
            #endregion Frame four

            #region Frame five
            total += s5.Item1;
            if (s5.Item2 == BowlerFrame.SCORE_STATE.Spare)
            {
                if (sixthFrame.firstBallTextBox.Text == "")
                {
                    bowlerScore.Text = "?";
                    return;
                }
                else
                {
                    total += sixthFrame.getShotScore(BowlerFrame.SHOT.First);
                }
            }
            else if (s5.Item2 == BowlerFrame.SCORE_STATE.Strike)
            {
                if (sixthFrame.firstBallTextBox.Text == "" || sixthFrame.secondBallTextBox.Text == "" && s6.Item2 != BowlerFrame.SCORE_STATE.Strike)
                {
                    bowlerScore.Text = "?";
                    return;
                }

                if (s6.Item2 == BowlerFrame.SCORE_STATE.Spare)
                {
                    total += 10;
                }
                else
                {
                    if (s6.Item2 == BowlerFrame.SCORE_STATE.Strike)
                    {
                        total += 10;
                        total += seventhFrame.getShotScore(BowlerFrame.SHOT.First);
                    }
                    else
                    {
                        total += sixthFrame.getShotScore(BowlerFrame.SHOT.First);
                        total += sixthFrame.getShotScore(BowlerFrame.SHOT.Second);
                    }
                }
            }
            #endregion Frame five

            #region Frame six
            total += s6.Item1;
            if (s6.Item2 == BowlerFrame.SCORE_STATE.Spare)
            {
                if (seventhFrame.firstBallTextBox.Text == "")
                {
                    bowlerScore.Text = "?";
                    return;
                }
                else
                {
                    total += seventhFrame.getShotScore(BowlerFrame.SHOT.First);
                }
            }
            else if (s6.Item2 == BowlerFrame.SCORE_STATE.Strike)
            {
                if (seventhFrame.firstBallTextBox.Text == "" || seventhFrame.secondBallTextBox.Text == "" && s7.Item2 != BowlerFrame.SCORE_STATE.Strike)
                {
                    bowlerScore.Text = "?";
                    return;
                }

                if (s7.Item2 == BowlerFrame.SCORE_STATE.Spare)
                {
                    total += 10;
                }
                else
                {
                    if (s7.Item2 == BowlerFrame.SCORE_STATE.Strike)
                    {
                        total += 10;
                        total += eighthFrame.getShotScore(BowlerFrame.SHOT.First);
                    }
                    else
                    {
                        total += seventhFrame.getShotScore(BowlerFrame.SHOT.First);
                        total += seventhFrame.getShotScore(BowlerFrame.SHOT.Second);
                    }
                }
            }
            #endregion Frame six

            #region Frame seven
            total += s7.Item1;
            if (s7.Item2 == BowlerFrame.SCORE_STATE.Spare)
            {
                if (eighthFrame.firstBallTextBox.Text == "")
                {
                    bowlerScore.Text = "?";
                    return;
                }
                else
                {
                    total += eighthFrame.getShotScore(BowlerFrame.SHOT.First);
                }
            }
            else if (s7.Item2 == BowlerFrame.SCORE_STATE.Strike)
            {
                if (eighthFrame.firstBallTextBox.Text == "" || eighthFrame.secondBallTextBox.Text == "" && s8.Item2 != BowlerFrame.SCORE_STATE.Strike)
                {
                    bowlerScore.Text = "?";
                    return;
                }

                if (s8.Item2 == BowlerFrame.SCORE_STATE.Spare)
                {
                    total += 10;
                }
                else
                {
                    if (s8.Item2 == BowlerFrame.SCORE_STATE.Strike)
                    {
                        total += 10;
                        total += ninthFrame.getShotScore(BowlerFrame.SHOT.First);
                    }
                    else
                    {
                        total += eighthFrame.getShotScore(BowlerFrame.SHOT.First);
                        total += eighthFrame.getShotScore(BowlerFrame.SHOT.Second);
                    }
                }
            }
            #endregion Frame seven

            #region Frame eight
            total += s8.Item1;
            if (s8.Item2 == BowlerFrame.SCORE_STATE.Spare)
            {
                if (ninthFrame.firstBallTextBox.Text == "")
                {
                    bowlerScore.Text = "?";
                    return;
                }
                else
                {
                    total += ninthFrame.getShotScore(BowlerFrame.SHOT.First);
                }
            }
            else if (s8.Item2 == BowlerFrame.SCORE_STATE.Strike)
            {
                if (ninthFrame.firstBallTextBox.Text == "" || ninthFrame.secondBallTextBox.Text == "" && s9.Item2 != BowlerFrame.SCORE_STATE.Strike)
                {
                    bowlerScore.Text = "?";
                    return;
                }

                if (s9.Item2 == BowlerFrame.SCORE_STATE.Spare)
                {
                    total += 10;
                }
                else
                {
                    if (s8.Item2 == BowlerFrame.SCORE_STATE.Strike)
                    {
                        total += 10;
                        total += tenthFrame.getShotScore(FinalBowlerFrame.SHOT.First);
                    }
                    else
                    {
                        total += ninthFrame.getShotScore(BowlerFrame.SHOT.First);
                        total += ninthFrame.getShotScore(BowlerFrame.SHOT.Second);
                    }
                }
            }
            #endregion Frame eight

            #region Frame nine
            total += s9.Item1;
            if (s9.Item2 == BowlerFrame.SCORE_STATE.Spare)
            {
                if (tenthFrame.firstBallTextBox.Text == "")
                {
                    bowlerScore.Text = "?";
                    return;
                }
                else
                {
                    total += tenthFrame.getShotScore(FinalBowlerFrame.SHOT.First);
                }
            }
            else if (s9.Item2 == BowlerFrame.SCORE_STATE.Strike)
            {
                if (tenthFrame.firstBallTextBox.Text == "" || tenthFrame.secondBallTextBox.Text == "")
                {
                    bowlerScore.Text = "?";
                    return;
                }

                if (tenthFrame.secondBallTextBox.Text == "/")
                {
                    total += 10;
                }
                else
                {
                    total += tenthFrame.getShotScore(FinalBowlerFrame.SHOT.First);
                    total += tenthFrame.getShotScore(FinalBowlerFrame.SHOT.Second);
                }
            }
            #endregion Frame nine

            #region Frame ten
            total += tenthFrame.Score;
            #endregion Frame ten

            this.bowlerScore.Text = total.ToString();
        }

        /// <summary>
        /// Handles locking and unlocking the bowlerName Textbox.
        /// </summary>
        /// <param name="sender">Object that fired the event.</param>
        /// <param name="e">Event arguments.</param>
        private void bowlerNameLock_Click(object sender, RoutedEventArgs e)
        {
            if (bowlerName.IsReadOnly == false)
            {
                bowlerName.IsReadOnly = true;
                bowlerNameLock.Content = "Unlock Name";
            }
            else if (bowlerName.IsReadOnly == true)
            {
                bowlerName.IsReadOnly = false;
                bowlerNameLock.Content = "Lock Name";
            }
        }
        #endregion Methods definition
    }
}
