   M S B A M L   `   `   `  ����E  ABowlingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:BowlingApp
BowlingApp  5          BowlingApp.BowlerFrames   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:BowlingApp     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ 
bowlerName��5      $��0��6&   $��0��63   $��2��6C   $��2,2,2,2q�6W      FrameTextBoxesStyle#��[  6h   �� 5   
   -   5         ��Name$ bowlerNameLock��5      $��0��6)   $��2��66   $��2��6F   $��	Lock Name��6Z   $��2,2,2,2q�6n   6   �� 5   
   -   5        $ bowlerScore��5      $��0��6'   $��9��64   $��2,2,2,2q�6D    �� TextAlignment$ Right=�6U    �� 
IsReadOnly . #��[  6}      BowlingApp.BowlerFrame  5   
   -   5          Name$ 
firstFrame��5         BowlingApp.BowlerFrame   TextChanged$ RecalculateScore��60   $��1��6O   $��0��6\     5    
   -   5        $ secondFrame��5       $ RecalculateScore��61   $��1��6P   $��1��6]     5!   
   -   5        $ 
thirdFrame��5!      $ RecalculateScore��60   $��1��6O   $��2��6\     5"   
   -   5        $ fourthFrame��5"      $ RecalculateScore��61   $��1��6P   $��3��6]     5#   
   -   5        $ 
fifthFrame��5#      $ RecalculateScore��60   $��1��6O   $��4��6\     5$   
   -	   5        $ 
sixthFrame��5$      $ RecalculateScore��60   $��1��6O   $��5��6\     5%   
   -
   5        $ seventhFrame��5%      $ RecalculateScore��62   $��1��6Q   $��6��6^     5&   
   -   5        $ eighthFrame��5&      $ RecalculateScore��61   $��1��6P   $��7��6]     5'   
   -   5        $ 
ninthFrame��5'      $ RecalculateScore��60   $��1��6O   $��8��6\   !   BowlingApp.FinalBowlerFrame  5(   
   -   5          Name$ 
tenthFrame��5(   !   !   BowlingApp.FinalBowlerFrame	   TextChanged$	 RecalculateScore��65   $��1��6T   $��9��6a   5)      5*      