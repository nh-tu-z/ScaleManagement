   M S B A M L   `   `   `  ����@  <scale, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:scale.View
scale.View  5   	   %    scale.View.SheetsManagementView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:scale.View     5   	   -   5          � Title$  SheetsManagementView��5   	   $	��450��6&   $	��800��63   .��5	      �  � RowDefinitions 5   
   �� 5      $	��10* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ mainDataGrid��5         
IsReadOnly .    AutoGenerateColumns .  $��5q�5      ��5      �� *OutputSheetDataGridItems+ �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Số Phiếu��5         MinWidth$ 50Q�5       	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 5!      1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5"      �� *	SheetID+  5#      $ Số Xe��5$      $ 50Q�5%      $	 * 5&      
 5'      �� *TruckNumber+  5(      $ Khách Hàng��5)      $ 50Q�5*      $	 * 5+      
 5,      �� *Client+  5-      $ TL Vào��5.      $ 50Q�5/      $	 * 50      
 51      �� *
WeightIn+  52      $ TL Ra��53      $ 50Q�54      $	 * 55      
 56      �� *	WeightOut+  57      $ TL Hàng��58      $ 50Q�59      $	 * 5:      
 5;      �� *MerchandiseWeight+  5<      $ 
Quy Đổi��5=      $ 50Q�5>      $	 * 5?      
 5@      �� *
Exchange+  5A      $ 
Đơn Giá��5B      $ 50Q�5C      $	 * 5D      
 5E      �� *	UnitPrice+  5F      $ Thành Tiền��5G      $ 50Q�5H      $	 * 5I      
 5J      �� *Price+5L      5M      �� 5O   
   $��1��5P       �� Orientation$ 
Horizontal=�5Q      $��LeftToRight=�5R      .+�5S      �� -   5         ��Name$ dateCbx��5W      $��Nhiều ngày��5T      $
��Left=�5U      $��
5,5,30,5.2q�5V      5W   <   (  "System.Windows.Controls.DatePicker  5X      -   5          Name$ dateTimePickerFrom��5Y      $��5,0,0,5q�5[        5\      -   5        $ dateTimePickerTo��5]      $��5,0,0,5q�5_      5`      �� 5c   
   $��2��5d      $ 
Horizontal=�5e      $��RightToLeft=�5f      .+�5h      �� $��Thoát��5i      $��75��5j      $��25��5k      ���	#FFFA0808���	#FFF9F9F9$��5,0,0,5q�5n         RoundedButtonStyle#���   5o      �� 5p      $��Xuất File��5q      $��75��5r      $��25��5s      ���	#FF64CCF1���	#FFF9F9F9$��5,0,0,5q�5v      #���   5w      �� 5x      $��Huỷ Phiếu��5y      $��75��5z      $��25��5{      ���	#FF64CCF1���	#FFF9F9F9$��5,0,0,5q�5~      #���   5      �� 5�      $��Xoá Phiếu��5�      $��75��5�      $��25��5�      ���	#FF64CCF1���	#FFF9F9F9$��5,0,0,5q�5�      #���   5�      �� 5�      $��Sửa��5�      $��75��5�      $��25��5�      ���	#FF64CCF1���	#FFF9F9F9$��5,0,0,5q�5�      #���   5�      5�      5�      5�      