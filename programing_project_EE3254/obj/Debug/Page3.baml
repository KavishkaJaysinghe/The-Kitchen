   M S B A M L   `   `   `  ����  programing_project_EE3254%    programing_project_EE3254.Page3   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5        N� Title$  Page3��5	       � 	Resources 5
         IconImageForeground1 �� Color��%-   &	        �� 5   
   $ 	#FFB99232��67   5      .��5      ��  �� CornerRadius$ 10��6   $��0q�5       J� Opacity$
 0.95Q�5      ��5   
   �� 5       �� 
StartPoint$	 0,1&�6"    �� EndPoint$	 1,0&�63   .��5      �  � Color$ Transparent��6    � Offset$ 0Q�63   � 5      $ 	#FFFFF2B1��6   $ 1Q�61   5      ._�5   
   � 	 � RowDefinitions	 5   
   �� 5      $	��450 �6   .+�5   
   �� $��0��6   $
��Left=�6#   
 �� Orientation$
 
Horizontal=�6>   $��51��6W   $��
25,0,0,382q�6c   $��Bottom=�6w   $	��521��6�   .+�5      � $��Center=�6   $	��361��6.   .+�5      �� -   5         ��Name$ hintTextBlock��5      $��Center=�5       J� IsHitTestVisible .  $��30 10 20 10q�5        K� ZIndex$ 1��5!      $��12(�5"      $��
Montserrat)�5#      $��Enter Phone Number��5$        textHint#��[ 5%      $y�Visible=�5&      ���	#FF8D8D8D � Cursor$ UpArrow��6<   �� 5(      -   5         ��Name$ search_txt2��5)        loginTextBox#��[ 5(      $��
20,10,8,10q�5*      $��12(�5+      $��
Montserrat)�5,      ���	#FF8C8C8C$	 0.4Q�5/   G   ��5-      �� *Key+.��5/   U   51      52      53      �� 55   
   -   5        $��140,24,632,400q�56      $��0q�58      
�������$��12(�5:      $
 Hand��5;      $	 0.6Q�5<       J� RenderTransformOrigin$ 0.796,0.762&�6   ��5>      �� 5?       �� 
TargetType" ��6   .�5@      ��  �� Property � �� �� Value
 ���� 63    �� Triggers 5A      P� 5B       P� Property �@J�IsMouseOver P� Value . . �5C      ��  � �� �	#FFEBEBEB6;   5D      5F      ��5I      �� 5J       �� 
TargetType" ��6"   .R�5K      �� $��30��6   $��30��6(   $ 10��5L   )   #��z��5M   )   ._�5N      �� $��Center=�6+   $��Center=�5O   7   5P      5Q      ��5S      �� 5T      $��/Images/Search.png��6   $��18��64   $��21��6?   $ 0.487,0.515&�6K   $
��Left=�6o   z�5U      V� 5V      .~�5W      �� �� 5X      T� 5Y       T� X$ 4.244Q�61    T� Y$ 1.915Q�6;   5Z      5\      5^      �� 5_   
   $��
0,81,450,0q�6   .+�5`      &   System.Windows.Controls.DataGrid  -   5          Name$ datagr��5`        DataGridRowStyle1   RowStyle# �  6'     DataGridStyle1#���  6V     DataGridCellStyle1   	CellStyle# �  6     DataGridColumnHeaderStyle1   ColumnHeaderStyle# �  6�      AutoGenerateColumns .  ��6�   �� *M+   Columns 5a      4  .System.Windows.Controls.DataGridTemplateColumn  5h      ,  &System.Windows.Controls.DataGridColumn    HeaderStyle  5i      �� 5j      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6$   .�5k   "   ��  � ��
 �   �6?   �� 5l   "    � ��
 ���� 6?   �� 5m   "    � ��$ Center=�6O   5n      !   Header$
! Name��5p   \   "   CellTemplate" 5q      �� 5r      .R�5s   "   �� $��Center=�6B   ��6,   �� *Name+6B   5t      5v        5y        5z      �� 5{      "  6$   .�5|   "   ��  � ��
 �   �6?   �� 5}   "    � ��
 ���� 6?   �� 5~   "    � ��$ Center=�6O   5      $! Email��5�   ]   " 5�      �� 5�      .R�5�   "   �� $
��Left=�6C   $��10 0 5 0q�6^   $
��Wrap=�6p   ��6,   �� *Email+6p   5�      5�        5�        5�      �� 5�      "  6$   .�5�   "   ��  � ��
 �   �6?   �� 5�   "    � ��
 ���� 6?   �� 5�   "    � ��$ Center=�6O   5�      $! Address��5�   _   " 5�      �� 5�      .R�5�   "   �� $
��Left=�6E   $��10 0 5 0q�6`   $
��Wrap=�6r   ��6,   �� *	Address+6r   5�      5�        5�        5�      �� 5�      "  6$   .�5�   "   ��  � ��
 �   �6?   �� 5�   "    � ��
 ���� 6?   �� 5�   "    � ��$ Center=�6O   5�      $! Phone Number��5�   d   " 5�      �� 5�      .R�5�   "   �� $��Center=�6J   ��6,   �� *Phone_Number+6J   5�      5�        5�        5�      �� 5�      "  6$   .�5�   "   ��  � ��
 �   �6?   �� 5�   "    � ��
 ���� 6?   �� 5�   "    � ��$ Center=�6O   5�      $! Option��5�   ^   " 5�      �� 5�      .R�5�   "   �� $
 
Horizontal=�6-   $��Center=�6F   .+�5�   &   �� -   5          gridEditButton#��[ 5�   -   $
��Auto��6j   $
��Auto��6w   $��0 0 2 0q�6�   
�������.��5�   *   �� $
 
Horizontal=�65   .+�5�   .   !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]#   Icon$
# Edit=�6;     menuButtonIcon#��[ 6G    	 
panelColor$   
Foreground#$ � 	 6o   $��0q�6�   5�   +   5�   '   �� 5�   &   -   5        #��[ 5�   -   $
��Auto��6l   $
��Auto��6y   $��0 0 2 0q�6�   
�������.��5�   *   �� $
 
Horizontal=�65   .+�5�   .     $# Remove=�6;   #��[ 6I   #$ � 	 6q   $��0q�6�   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      