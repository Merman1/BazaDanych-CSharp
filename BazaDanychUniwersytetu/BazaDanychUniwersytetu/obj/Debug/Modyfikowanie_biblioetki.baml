   M S B A M L   `   `   `  ����Q  MBazaDanychUniwersytetu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:BazaDanychUniwersytetuBazaDanychUniwersytetu  5   	   5    /BazaDanychUniwersytetu.Modyfikowanie_biblioetki   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:BazaDanychUniwersytetu     5   	   -   5          � Title$  Modyfikowanie_biblioetki��5   	   $	��600��6*   $
��1400��67   .��5	      � -   5         �Name$ MyDataGrid1��5	      .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
MyDataGrid��5
      $
��Left=�6'   $	��569��6B   $��	641,0,0,0q�6O   $	��Top=�6b   $	��751��6z   6�   �� 5   
   -   5         ��Name$ Id_wypozyczenia_txt��5      $
��Left=�6/   $��23��6J   $��328,103,0,0q�6V    �� TextWrapping$
 Wrap=�6k   $	��Top=�6   $	��120��6�   �� 5   
   -   5        $ Ilosc_wypoz_ksiaz_txt��5      $
��Left=�61   $��23��6L   $��328,208,0,0q�6X   $
 Wrap=�6m   $	��Top=�6�   $	��120��6�   �� 5   
   $��ID WYPOŻYCZENIA :��6   $
��Left=�6,   $��112,103,0,0q�6G   $	��Top=�6\   �� 5   
   $(��"ILOŚĆ WYPOŻYCZONYCH KSIĄŻEK :��6   $
��Left=�68   $��112,213,0,0q�6S   $	��Top=�6h   �� 5   
   $��TERMIN ODDANIA :��6   $
��Left=�6+   $��112,313,0,0q�6F   $	��Top=�6[   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ Termin_oddania_txt��5      $
��Left=�61   $��328,313,0,0q�6L   $	��Top=�6a   $	��120��6y   �� 5   
   -   5         ��Name$ 	Dodaj_btn��5      $��DODAJ��6$   $
��Left=�64   $��
10,408,0,0q�6O   $	��Top=�6c   $	��116��6{   ���	#FF060000���	#FFFBFBFB$��Impact)�6�   $��22(�6�   $��33��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      ��5      �� 5       �� EndPoint$ 0.5,1&�6&   	 �� 
StartPoint$	 0.5,0&�67   .��5      � 
 � Color$
 Black��6#    � Offset$ 0Q�61   � 5      $
 	#FF2FA9FD��6#   $ 1Q�65   5      5      �� 5   
   -   5        $ Zresteuj_btn��5      $��ZRESETUJ��6'   $
��Left=�6:   $��164,408,0,0q�6U   $	��Top=�6j   $	��116��6�   ���	#FFF7F7F7���	#FF0E0000$��22(�6�    5        5      ��5       �� 5!      $ 0.5,1&�6&   $	 0.5,0&�67   .��5"      � $
 Black��6#   $ 0Q�61   � 5#      $
 	#FF2FA9FD��6#   $ 1Q�65   5$      5&      �� 5'   
   -	   5        $ Zaktualizuj_btn��5'      $��ZAKTUALIZUJ��6*   $
��Left=�6@   $��460,408,0,0q�6[   $	��Top=�6p   $	��116��6�   
���   �
�������$��18(�6�   $��33��6�    5(        5)      ��5+      �� 5,      $ 0.5,1&�6&   $	 0.5,0&�67   .��5-      � $
 Black��6#   $ 0Q�61   � 5.      $
 	#FF2FA9FD��6#   $ 1Q�65   5/      51      �� 52   
   -
   5        $ Usun_btn��52      $��USUŃ��6#   $
��Left=�62   $��315,408,0,0q�6M   $	��Top=�6b   $	��116��6z   ���	#FFFDFDFD
���   �$��22(�6�    53        54      ��56      �� 57      $ 0.5,1&�6&   $	 0.5,0&�67   .��58      � $
 Black��6#   $ 0Q�61   � 59      $
 	#FF2FA9FD��6#   $ 1Q�65   5:      5<      5>      5?      