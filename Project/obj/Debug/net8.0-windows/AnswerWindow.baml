   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5   	       Project.AnswerWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Project     5   	     � Title$  AnswerWindow��5   	   $	��450��6   $	��800��6+    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5      #   Project.AnswerExistsConverter   AnswerExistsConverter��%   &	          5   
   6&   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   � $��0��6   .+�5      � $��0��6   .+�5      �� $��5q�6   .+�5      �� -   5        $��txtTotal��5   ?   $��20(�6    
���  ��6Q   �� 5      -   5        $��
txtStudent��5       64   �� 5      .��6   
Question6&   �� 5      -   5        $��txtQuestion��5   �   $��50��6F   ��6    �� *
Question+ �� Mode$ OneWay=� � DataContext 6R   ��  �� ElementName$ lvList�� �� Path$ SelectedItem�6�   �� 5      .��6   Answer6$   �� 5       -   5        $��	txtAnswer��5    �   $��50��6B   ��6   �� *Answer+$ OneWay=� 6N   �� $ lvList��$ SelectedItem�6�   5!      5"      5&      � 5'   
   $��1��6   .+�5(      � $��Center=�6   $
��auto��65   .+�5)      �� -   5        $��Answer��5)      $��70��6*   $��5q�65   6^   �� 5*      -   5        $��Update��5*      $��70��6*   $��5q�65   6_   �� 5+      -   5        $��Logout��5+      $��70��6*   $��5q�65   6X   5.      5/      � 50   
   $��2��6   .+�51      �� -   5        $��lvList��51       �� View 52      �� 53      .P�54      �� $��Id��6)   	 �� DisplayMemberBinding	 65   �� *Id+6[   �� 55      $��Student��6)   	 6:   �� *Student.DisplayName+6q   �� 57      $��Question��6)   	 6;   �� *
Question+6g   �� 58      $��Answer��6)   
 �� CellTemplate
 59      �� 5:   "   .R�5;   &   �� ${�False��6~    d� 	IsChecked 6/   �� *Answer+ �� 	Converter# [  6~   5<   #   5>      5@      5B      5C      5D      5E      