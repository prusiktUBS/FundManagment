   M S B A M L   `   `   `  ����G  CTomaszPrusik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TomaszPrusikTomaszPrusik  5   	       TomaszPrusik.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:TomaszPrusik     5   	     � Title$  
MainWindow��5   	   $��333.582��6   $��1216.045��6-   .��5	      � .+�5
   
   �� $
��10,0q�6   .@�5      �� $��Fund Manager��6   $��	0,0,-4,-2q�6,   .��5      � ���	#FFE5E5E5.+�5      � $
��Left=�6   $	��340��66   $��10,47,-40,0q�6C   $	��Top=�6X   $	��774��6p    � ColumnDefinitions 5      �� 5      $
��647* �6/   �� 5      $
��127* �6/   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ FM_sec_fund_list_dataGrid��5   #    %� IsVirtualizing .     AutoGenerateColumns .  $
��Left=�6�   $��10,0,0,0q�6�   $	��Top=�6�   $	��535��6�    J� RenderTransformOrigin$ 0.087,-0.246&�6�      RowStyle 5      �� 5   "    �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6(   .�5   &   ��  �� Property � ��	 �� Value
	 ����6C   
 �� Triggers
 5   &   P� 5   *    P� Property �@J�IsMouseOver P� Value . . �5   .   ��  � ��
	 � � �6K   �� 5   .    � ��
	 �����6K   5   +   5   #      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Id��65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *Id+  5    "   $
 Name��65    6C   �� *Name+  5!   "   $ 	SecTypeId��65    6H   �� *SecurityTypeId+  5"   "   $ Price��65    6D   �� *Price+  5#   "   $ Quantity��65    6G   �� *Qty+  5$   "   $ MarketValue��65    6J   �� *
MktValue+  5%   "   $ TransactionCost��65    6N   �� *TransactionCost+  5&   "   $ SecWeight %��65    6J   �� *	SecWeight+5(      5)      �� 5*      -   5         ��Name$ groupBox��5*      $��Fund Summary��61   $
��Left=�6G   $��	577,0,0,0q�6b   $	��Top=�6u   $	��145��6�   $	��489��6�   $ -0.521,0.296&�6�   .��5+        -   5        $ fundSummary_dataGrid��5+   #    .   .  $
��Left=�6�   $��28,0,0,0q�6�   $	��Top=�6�   $ 0.333,-1&�6�   $	��405��6�   $	��115��6�    5,        5-   "   $ TypeName��65    6G   �� *Name+  5.   "   $ TotalNumber��65    6J   �� *TotalNumber+  5/   "   $ TotalStockWeight��65    6O   �� *TotalStockWeight+  50   "   $ TotalMktValue��65    6L   �� *TotalMktValue+52      53      �� 54      -   5         ��Name$ label2_Copy��54      $"��Added Securities to the Fund��61   $
��Left=�6X   $��	23,21,0,0q�6s   $	��Top=�6�   56      57      �� 59      $��Equity��6   $��112,0,-115.5,-2q�6&   .��5:      � ���	#FFE5E5E5$��0,3,9,2q�6.    5;      �� 5<      $	��31* �6+   �� 5=      $
��366* �6+   .+�5?      �� -   5        $ label��5?      $��Create new Fund��5@      $
��Left=�5A      $��	10,10,0,0q�5B      $	��Top=�5C      $��2��5D      �� 5E      -   5        $ 
label_Copy��5E      $
��Name��60   $
��Left=�6?   $��	10,41,0,0q�6Z   $	��Top=�6m   �� 5F      $��FundName��6   $
��Left=�6.   $��23��6I   $��	70,44,0,0q�6U    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��240��6�   $��1��6�   �� 5G      $	��Add��6   $
��Left=�6+   $��145,117,0,0q�6F   $	��Top=�6[   $��75��6s   $��1��6~   �� 5H      $��Mark as deleted��6   $
��Left=�66   $��	10,82,0,0q�6Q   $	��Top=�6d   $��2��6|   $	��117��6�   �� 5I      $��1��5J      $
��Left=�5K      $��	70,88,0,0q�5L      $	��Top=�5M      �� 5N      $��Refresh��6   $��1��6/   $
��Left=�6?   $��235,117,0,0q�6Z   $	��Top=�6o   $��75��6�   5O      5P      �� 5Q      $
��Bond��6   $��121.5,0,-125.5,-2q�6$   .��5R      � ���	#FFE5E5E5$��0,-1,-12,-4q�6.   $ 	0.5,0.519&�6C   .+�5S      �� $��Create new security��6   $
��Left=�6;   $��	10,25,0,0q�6V   $	��Top=�6i   �� 5T      $��Security Name��6   $
��Left=�65   $��	10,56,0,0q�6P   $	��Top=�6c   �� 5U      $��Security Type��6   $
��Left=�65   $��	10,89,0,0q�6P   $	��Top=�6c   �� 5V      $��Price��6   $
��Left=�6-   $��
10,122,0,0q�6H   $	��Top=�6\   �� 5W      -   5         ��Name$ AddBond��5W      $	��Add��5X      $
��Left=�5Y      $��216,222,0,0q�5Z      $	��Top=�5[      $��75��5\      �� 5]      $
��Left=�6   $��23��69   $��
122,59,0,0q�6E   $
 Wrap=�6Y   $	��Top=�6m   $	��169��6�   �� 5^      $
��Left=�6   $��23��69   $��122,122,0,0q�6E   $
 Wrap=�6Z   $	��Top=�6n   $	��120��6�   � 5_      $
��Left=�6   $	��292��66   $��
372,25,0,0q�6C   $	��Top=�6W   $	��375��6o    J� Effect 5`      3  -System.Windows.Media.Effects.DropShadowEffect  5a      5c      �� 5d      $��Quantity��6   $
��Left=�6/   $��
10,150,0,0q�6J   $	��Top=�6^   �� 5e      $
��Left=�5f      $��23��5g      $��122,154,0,0q�6*   $
 Wrap=�5h      $	��Top=�5i      $	��120��5j      �� 5k      $
��Left=�6   $��
122,89,0,0q�5l      $	��Top=�5m      $	��169��5n      �� 5o      $��Mark as Deleted��6   $
��Left=�66   $��
10,181,0,0q�6Q   $	��Top=�6e   $	��113��6}   �� 5p      $�� ��6   $
��Left=�6*   $��122,187,0,0q�5q      $	��Top=�5r      5s      5t      5u      5v      5w      