   M S B A M L   `   `   `  ����F  BFileWatcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:FileWatcherFileWatcher  5   	       FileWatcher.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:FileWatcher     5   	   -   5          � Title$  Monitorar Scans��5   	   $	��469��6!   $��815.5��6.   ���	#FF212529 � WindowStyle$ ThreeDBorderWindow=�6l   $	��870��6�   $	��470��6�    � 
ResizeMode$ CanMinimize=�6�   .��5	      � $��	0,0,0,-31q�6    � ColumnDefinitions 5
   
   �� 5      $
��317* �6   �� 5      $
��114* �6   .+�5   
   � $��10,10,10,36q�6   $��2��6$    � RowDefinitions 5      �� 5      $��30 �6    �� 5      $��* �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��0��6O    J� RenderTransformOrigin$ 0.503,0.833&�6\   $��
114,0,87,0q�6�   $	��589��6�   .+�5      �� $��8q�6   $��Caminho��6'   $��48��66   
�������$��Center=�6T   $��Center=�6q   $��20��6�   $ 0.403,0.483&�6�   �� 5      -   5         ��Name$ txtDirectory��5   1   $	��327��6   $��5q�6&    �� TextWrapping$
 Wrap=�6G   �� 5      -   5        	 ��Name$	 	btnBrowse��5      $��69��6,   $��Procurar...��67   $��5q�6M   
 � Cursor$

 Hand��6p   ���	#FFFEFFFF$��1q�6�   $��Calibri)�6�   $��SemiBold"�6�   ���	#FF212529���	#FF212529$��2q�6  �� 5      -   5        $	 	btnListen��5      $��90��6,   $��	Monitorar��67   $��5q�6K   $

 Hand��6n   
�������$��1q�6�   $��Calibri)�6�   $��SemiBold"�6�   ���	#FF212529���	#FF212529$��2q�6�   5      � 5      $��1��6   $ 0.346,0.447&�6     5      �� 5      $
��421* �6'   66   �� 5      $
��302* �6'   66   �� 5      $
��119* �6'   .+�5      � -   5        $��	FilesGrid��5   '   $��0��6   $��	0,0,163,0q�68    5       �� 5!      $��* �6(   65   �� 5"      $��* �6(   65   5$      � 5%      -   5        $��ActivityGrid��5%   '   $��1��6   $��2��6;    5&      �� 5'      $
��207* �6+   �� 5(      $
��214* �6+   .+�5*      �� -   5         ��Name$ 	groupBox1��5*      $��	Atividade��62   $	��100��6E   $
��Left=�6U   $	��Top=�6p   $	��602��6�   $	��340��6�   $��-290,25,0,0q�6�   $��2��6�   ���	#FFFFBB33
�������.��5+      �� -   5         ��Name$ 
lstResults��5+   #   $��10,10,10,18q�67   6O   5,      5-      5.      5/      50      51      