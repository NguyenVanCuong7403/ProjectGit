   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5   	       Project.QuestionWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Project     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ QuestionWindow��5	   	   $	��450��6    $	��800��6-    � 	Resources 5
      #   Project.AnswerExistsConverter   AnswerExistsConverter��%   &	          5   
   6&   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   � $��0��6   .+�5      � $��0��6   .+�5      �� $��5q�6   .+�5      �� .��6   Id6    �� 5      -   5        $��txtId��5   |   ��6   �� *Id+ �� Mode$ OneWay=� � DataContext 6>   ��  �� ElementName$ lvList�� �� Path$ SelectedItem�6�   �� 5      .��6   	Lecture6%   �� 5      -   5        $��	cbLecture��5        �� DisplayMemberPath$ DisplayName��61   	 �� SelectedValuePath$	 Id��5      6+   �� 5      .��6   
Question6&   �� 5       -   5        $��txtQuestion��5    �   $��50��6D   ��6   �� *
Question+$ OneWay=� 6P   �� $ lvList��$ SelectedItem�6�   �� 5"      -   5        $��txtans��5"       $
��0 10q�6.   5#      5$      5(      � 5)   
   $��1��6   .+�5*      � $��Center=�6   $
��auto��65   .+�5+      �� -   5        $	��Add��5+      $��70��6'   $��5q�62   6X   �� 5,      -   5        $��Update��5,      $��70��6*   $��5q�65   6_   �� 5-      -   5        $��Remove��5-      $��70��6*   $��5q�65   6X   5.      5/      � 50   
   $��2��6   .+�51      �� -   5        $��lvList��51      
 �� View
 52      �� 53      .P�54      �� $��Id��6)    �� DisplayMemberBinding 65   �� *Id+6[   �� 55      $��Lecture��6)    6:   �� *Lecture.DisplayName+6q   �� 57      $��Question��6)    6;   �� *
Question+6g   �� 58      $��Answer��6)    �� CellTemplate 59      �� 5:   "   .R�5;   &   �� ${�False��6~    d� 	IsChecked 6/   �� *Answer+ �� 	Converter# [  6~   5<   #   5>      5?      5A      5B      5C      5D      