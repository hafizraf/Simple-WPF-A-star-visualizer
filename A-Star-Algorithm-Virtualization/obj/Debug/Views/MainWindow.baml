   M S B A M L   `   `   `  ����Z  VA-Star-Algorithm-Virtualization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:A_Star_Algorithm_VirtualizationA_Star_Algorithm_Virtualization  5   	   6    0A_Star_Algorithm_Virtualization.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:A_Star_Algorithm_Virtualization     5   	   -   5          � Title$  Fun Time��5   	    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType J� SnapsToDevicePixels � RowDefinitions � ColumnDefinitions	 ��Name
 �� Triggers P� Property P� Value ^� 
Conditions �� Binding �� Value �� 
TargetName �� Value �� Binding��%�  'd�       �� 5
   
   " d�6   .�5      ��  � ��
 �   �6,   �� 5       � ��$ 1q�60   6<   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 1q�6(   �� 5       � �� 5      �� 5      " d�6&   .R�5      �� $��bd��5   "   
���   �
�������$��1q�5       . #��z��5   ,   #��z��6N   ._�5      �  5   "   �� 5   &   66   �� 5   &   66   .+�5   "   � $��0��6'    5   &   �� 5   *   6=   �� 5    *   6=   .+�5"   &   �� $	 text1��60   $
��Left=�6?   $��5,0,0,0q�6Z   $��12(�6�   ��6k   �� *GValue+6�   �� 5#   &   $	 text2��60   $��1��6?   $��Right=�6O   $��0,0,5,0q�6k   $��12(�6�   ��6|   �� *HValue+6�   5$   #   �� 5%   "   $	 text3��6,   $��1��6;   $��Center=�6H   $��5,0,0,0q�6e   $��16(�6�   ��6v   �� *FValue+6�   5'      5(      
 5)      P� 5*       �@J�IsMouseOver . . �5+   "   ��  �@�Cursor$
 Hand��6;   5,      ^� 5-       5.   "   �� 5/   &    60   �� *IsOpen+ True6K   �� 50   &    60   �� *IsStartOrEndPoint+	 False6V   0�52   "   �� 53   &   $ bd��6U    � ��
 �2�2�55      ^� 56       57   "   �� 58   &    60   �� *
IsClosed+ True6M   �� 59   &    60   �� *IsStartOrEndPoint+	 False6V   0�5;   "   �� 5<   &   $ bd��6O    � ��
 �  ��5>      �� 5?      $
 True��6H    6*   �� *	IsBarrier+.a�5@   "   �� $ bd��6M    � ��
 �   �5A      �� 5B      $
 True��6P    6*   �� *IsStartOrEndPoint+.a�5C   "   �� $ bd��6L    � ��
 ��  �5D      5F      5H      5I      5J      .��5K      �  5L   
   �� 5M      $��* �6   6+   �� 5N      $��5* �6   6,   .+�5P   
   �� $��5,5,0,0q�6   $��0��6&   .+�5Q      �� $��	Helvetica)�6   $��Center=�6/   $��20(�6L   	# of Rows6e   �� 5R      $
��0,10q�6   $��	Helvetica)�6$   $��20(�6;   $��50��6I   $��Center=�6T   $��Center=�6x   ��6�   �� *
RowCount+ �� StringFormat$ D�� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5S      $��	Helvetica)�6   $��0,20,0,0q�6/   $��20(�6A   $��Center=�6O   # of Columns6z   �� 5T      $
��0,10q�6   $��20(�6$   $��	Helvetica)�62   $��50��6I   $��Center=�6T   $��Center=�6q   ��6�   �� *ColumnCount+$ D��$ TwoWay=�$ PropertyChanged=�6�   �� 5U      $��50��66   $��0,50,0,0q�6B   $��Center=�6T   $	��100��6q   $��26(�6}   $��	Helvetica)�6�   
���������6   �� *StartCommand+.��6�   	START!!6�   �� 5V      -   5        $��50��5V   #   $��0,50,0,0q�6/   $��Center=�6A   $	��100��6^   $��26(�6j   $��	Helvetica)�6x   
�������.��6�   RESET6�   5W      � 5X   
   -   5        $��MainGrid��5X      $��1��6   61   5Y      5Z      