   M S B A M L   `   `   `  ����M  INguyenNhatMinh_285, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:NguyenNhatMinh_285NguyenNhatMinh_285  5   	        NguyenNhatMinh_285.Window2   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:NguyenNhatMinh_285     5   	     � Title$  Window2��5   	   $	��450��6   $	��800��6&   $��15(�62   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �5      �� 5      �� 5      $
��auto �5      .+�5   
   �� $��0��5      $��SALE MANAGEMENT��5      $
��Bold"�5      $��30(�5      $��	0,30,0,10q�5      $��Center=�5      � 5   
   $��1��5      $��20,10,20,10q�5      .+�5       &   System.Windows.Controls.DataGrid  -   5          Name$ dtgrProduct��5!         AutoGenerateColumns$ False��5"         Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ Category ID��5'         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5(      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5)      �� *
CategoryID+ �� Mode$ OneWay=�  5*      $ Category Name��5+      $ 2* 5,       5-      �� *CategoryName+$ OneWay=�  5.      $ Total��5/      $ * 50      	   
Foreground
	 ��  �
   	FontStyle$
 Italic$�53       51      �� *Total+ �� StringFormat$ N0��$ OneWay=�53      55      56      � 59   
   $��2��5:      $��Center=�5;      $��	0,20,0,20q�5<      .+�5=      �� -   5         ��Name$ btnClose��5>      $��Close��5?      $	��100��5@      $��30��5A      $��0,0,30,0q�5B      5C      5D      5E      5F      