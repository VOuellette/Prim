   M S B A M L   `   `   `  ����G  CTP_ALGO_PRIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TP_ALGO_PRIMTP_ALGO_PRIM  5   	       TP_ALGO_PRIM.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:TP_ALGO_PRIM     5   	     � Title$  
MainWindow��5   	   $
��1080��6   $
��1920��6*   .��5	      �  � ShowGridLines$
 True��6    � ColumnDefinitions 5
   
   �� 5      $��4* �6   6,   �� 5      $��1* �6   6,    � RowDefinitions 5   
   �� 5      $	��100 �6   6+   �� 5      $��* �6   6)   .+�5   
   �� $��1��6   $��0��6"   $��Center=�62   $��Center=�6O   .+�5      � -   5         �Name$ labGrid��5      $	��750��6$   $	��750��61   
�������5      5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��Center=�6K   $
��Auto��6f   $��0��6t   $��1��6�   .+�5      �� $	��L :��6   $��20��6#   �� 5      -   5         ��Name$ txtLongueur��5      $��35��6+   $��20��66   ��6B   �� *
longueur+ �� Mode$ TwoWay=�6k   �� 5      $	��H :��6   $��20��6#   �� 5       -   5        $ 
txtHauteur��5       $��35��6*   $��20��65   ��6A   �� *	hauteur+$ TwoWay=�6i   5!      �� 5$   
   $��1��6   $��1��6"   $	��Top=�62   $��Center=�6J   $ Vertical=�6g   .+�5%      �� -   5         ��Name$ btnGenererGraphe��5%      $��0, 10, 0, 0q�60   $	��100��6_   $��50��6k   .��6w   Générer le graphe6�   �� 5'      $ 
Horizontal=�6   .+�5(      �� $��Executer X fois :��6   $��20��65   �� 5)      -   5        $ txtXFois��5)      $��35��6,   $��20��67   ��6C   �� *xFois+$ TwoWay=�6i   5*      �� 5,      $ 
Horizontal=�6   .+�5-      �� $��n^2 : ��6   $��0, 10, 0, 0q�6*   6A   �� 5.      -   5        	 ��Name$	 n2��5.      $��0, 10, 0, 0q�6<   ��6(   �� *n2+6S   5/      �� 51      $ 
Horizontal=�6   .+�52      �� $#��Nombre d'opérations moyen : ��6   $��0, 10, 0, 0q�6@   6W   �� 53      -   5        $	 nbOperations��53      $��0, 10, 0, 0q�6P   ��62   �� *nbOperations+6g   54      55      56      58      