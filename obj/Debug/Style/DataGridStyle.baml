   M S B A M L   `   `   `  ����@  <scale, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:scale.Stylescale.Style  5      b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes 5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089&    System.Windows.Controls.DataGrid  �� 
TargetType �� Property $   DataGrid.AlternateRow.Background �� Value  DataGrid.Static.BorderBrush % !DataGrid.Grid.HorizontalLineBrush �� 
TargetType �� Padding J� SnapsToDevicePixels ��Name � ColumnDefinitions � RowDefinitions	    SelectAllCommand
 �� 
ResourceId �� TypeInTargetAssembly7  1System.Windows.Controls.DataGridHeadersVisibility
   All �� ConverterParameter!    HeadersVisibilityConverter �� 	Converter �� RelativeSource �� AncestorTypeG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter  Name   Column ��Name �� CanContentScroll ��Name �� ScrollableHeight � Maximum �� Orientation* �� #ComputedVerticalScrollBarVisibility �� ViewportHeight �� ViewportSize � Value �� Mode �� ScrollableWidth,  �� %ComputedHorizontalScrollBarVisibility! �� ViewportWidth" �� Triggers# ]� 
Conditions$ �� Property% �� Value  ColumnHeaderGripperStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader % !DataGrid.Column.Header.Background , (DataGrid.Column.Header.Static.Foreground& �� Orientation' F�Name 
 SortUp  DataGrid.Column.Icon.Static( �� Stretch  SortDown &	 "DataGrid.Column.Header.Icon.Static) n�Name* �� Triggers+ P� Property, P� Value- �� 
TargetName 
 Sort.Up.Icon.Active*  $System.Windows.Controls.DataGridCell. �� Mode  RowDetailsTemplate + 'DataGrid.Row.Details.Static.BorderBrush)  #System.Windows.Controls.DataGridRow/ ��Name?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid?  9System.Windows.Controls.Primitives.DataGridCellsPresenter0   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter1   DetailsVisibility$2   SelectiveScrollingOrientation;	  5System.Windows.Controls.SelectiveScrollingOrientation3 	  Vertical#4    RowDetailsScrollingConverter:
  4System.Windows.Controls.Primitives.DataGridRowHeader
5   Row  FocusVisual6 �� StrokeDashArray  Button.Static.Background7 �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground  RoundedButtonStyle8 �� CornerRadius9 ��Name  CircleButton�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      #localclr-namespace:scale.Style  5      VThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2  5      %5%  '         &	 
    '  -    7  7  '  �    &	 _    '  �    &	 �    &	 8    &	 [    &	 ~    &	 �    &	 �    &	 �    &	 
    &	 -    &	 P    &	 s    7  7  7  7  7  7  &	 j    7  7  7  7  7  7  7  7  7  7  �� 5      "    6   .�5   
   ��   �@  AlternatingRowBackground# �   5      �� 5	   
    � ��# � ��5
      �� 5   
    � ��$ 0,0,0,1q�5      �� 5   
    � ��# � ��6'   �� 5   
    � ��# �  6(   �� 5   
    �@  GridLinesVisibility$ 
Horizontal=�5      �� 5   
     �@  HorizontalGridLinesBrush# �  5      �� 5   
    �@  HeadersVisibility$ Column=�5      �� 5   
     �@  RowDetailsVisibilityMode$ VisibleWhenSelected=�5      �� 5   
    � �� �	#FF688CAF6(   �� 5   
     �@  RowDetailsVisibilityMode$ VisibleWhenSelected=�65   �� 5   
    � �� .  5      �� 5   
    �@  SelectionMode$ Single=�5      �� 5   
    �@��PanningMode$
 Both=�65   �� 5   
    �@��IsFlicksEnabled .  63   �� 5   
    � �� 5       �� 5!      "   6"   .R�5"      �� #��z��6   #��z��6I   #��z��6}   # z��6�    . ._�5#      �� $ DG_ScrollViewer��6'   |�.  ��5$      �� 5%   "   " ��62   .R�5&   &   �  5'   *   �� 5(   .   $
��Auto �6?   �� 5)   .   $��* �6?   �� 5*   .   $
��Auto �6?    5,   *   �� 5-   .   $
��Auto �6<   �� 5.   .   $��* �6<   �� 5/   .   $
��Auto �6<   .+�51   *   �� #��Z	 61   |�.  ��6r   C� *�� $"
 DataGridSelectAllButtonStyle��"   +y�6�   �� *HeadersVisibility+# Z # Z  �� "   ��6�  �� *CellsPanelHorizontalOffset+ �� "     52   *   $! PART_ColumnHeadersPresenter��6I   $��1��6n   y�6~   �� *HeadersVisibility+# Z # Z  �� "   �� 53   *   $! PART_ScrollContentPresenter��6A   # z��6f   $��2��6�   $��1��6�   �� 54   *   $ PART_VerticalScrollBar��64   $��2��6T   # z 6d   $ Vertical=�6�   $��1��6�   #y�z 6�   # z 6W   6�   �� *VerticalOffset+$ OneWay=� �� *TemplatedParent+6W  � 55   *   $��1��6/   $��2��6?    56   .   �� 57   2   ��6C   �� **(NonFrozenColumnsViewportHorizontalOffset+ �� "   �� 58   2   $��* �6C   .+�5:   .   �� $ PART_HorizontalScrollBar��68   $��1��6Z   # z 6j   $ 
Horizontal=�6�   #y�z  6�   # z! 6U   6�   �� *HorizontalOffset+$ OneWay=� �� *TemplatedParent+6U  5;   +   5<   '   5=   #   .��5?      �� # z 6-   5@      5A      5B      5D      " 5E   
   ]� 5F      # 5G      �� 5H      $ �@��
IsGrouping% . 66   �� 5I      "$ �@%�IsVirtualizingWhenGrouping% .  6X   ./�5K      ��  � �� .  6B   5L      5N      �� 5P      "  n�6-   .�5Q   
   ��  � ��$ 8��6"   �� 5R   
    � ��
 ���� 6'   �� 5S   
    �@�Cursor$ SizeWE��6#   �� 5T   
    � �� 5U      �� 5V      " n�6"   .R�5W      �� #��z��6   # z��6G   5X      5Z      5[      �� 5\      "   6   .�5]   
   ��  � ��# �  5^      �� 5_   
    � ��# �  5`      �� 5a   
    � ��$ SemiBold"�5b      �� 5c   
    � ��$	 5,0q�5d      �� 5e   
    � ��$ 32��5f      �� 5g   
    � ��$ Center=�65   �� 5h   
    � �� 5i      �� 5j      "  6"   .R�5k      � .+�5l      �� #��z��6!   #��z��5m   !   #��z��5n   !   # z��5o   !   ._�5p      � #��z��6#    5q   "   �� 5r   &   �� 5s   &   $
��Auto �67   .+�5u   "   �� #��z��63   ��. # z 5w   3   #��z��5x   3   �� 5y   "   $��1��5z   %   $& 
Horizontal=�5{   %   $��5,0,0,0q�5|   %   .+�5}   &   F� $' 
SortUpIcon��5~   )   #���  5   )   #��z��5�   )   #���  5�   )   $( Uniform=�5�   )   $��10��5�   )   F� 5�   &   $' SortDownIcon��5�   )   #���  5�   )   #��z��5�   )   #��� 	 5�   )   $( Uniform=�5�   )   $��10��5�   )   5�   #   5�      5�      n� 5�      $) PART_LeftHeaderGripper��6    $
��Left=�6@   8��  6[   n� 5�      $) PART_RightHeaderGripper��6    $��Right=�6A   8�� 6]   5�      * 5�      P� 5�      + �@ SortDirection$, 	AscendingX�5�   *   . �5�      �� $- SortDownIcon��6%   # � 
 5�   -    � ��5�      P� 5�      + �@ SortDirection$, 
DescendingX�5�   *   . �5�      �� $- 
SortUpIcon��6%   # � 
 5�   -    � ��5�      5�      5�      5�      �� 5�      "   6   .�5�   
   ��  � �� 5�      �� *
Foreground+ �� $. FindAncestor=�$ DataGridL��� 5�   
    � ��$	 5,0q�6$   �� 5�   
    � ��$ Center=�65   �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      �� #��z��5�      #��z��5�      #��z��5�      ._�5�      �� #��z��5�      #��z��5�      #��z��5�      5�      5�      5�      5�      �� 5�      .R�5�   
   �� $��5q�6   $��1q�5�      #���  5�      ._�5�      �� $��5q�5�      �� 5�      $�Performance Rating:��6   63    �� 5�      �6   �� *Count+6/   �� 5�      �� 5�      $�Status:��6   6'    �� 5�      �6   �� *Status+60   5�      5�      5�      �� 5�      "   6   .�5�   
   ��  � ��# � ��6'   �� 5�   
    �@J�SnapsToDevicePixels . 60   �� 5�   
    �@=�ErrorTemplate 65   Z� �� 5�   
    �@ ValidationErrorTemplate 5�      �� 5�      .R�5�      �� 
���  ��$��2,0,0,0q�61   $��!��6B   $��Center=�6K   5�      5�      �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      �� $/ 
DGR_Border��6   #��z��61   #��z��6]   #��z��6�    . ._�5�         5�      �� 5�   "   $
��Auto �63   �� 5�   "   $��* �63    5�      �� 5�   "   $��* �60   �� 5�   "   $
��Auto �60   .+�5�        $��1��65   #��z0 6E   # z 6o     5�      $��1��5�   !   $��1��5�   !   #y�z1 5�   !   #���  5�   !   2 5�   !   �� *AreRowDetailsFrozen+# Z3 # Z4  �� "   5�   !   
  5�      $��2��60   $2 Vertical=�6A   y�6�   �� *HeadersVisibility+# Z5 # Z  �� "   5�      5�      5�      5�      " 5�   
   P� 5�      + �@ 	IsNewItem, . . �5�      ��  � �� 6+   �� *NewItemMargin+ �� "   5�      P� 5�      + �@ 
IsSelected, . . �5�      ��  �@ DetailsVisibility$ Visible=�5�      5�      5�      �� 5�      .�5�   
   ��  � �� 5�      �� 5�      .R�5�      �� $��2q�6     . #��� ��6F   $��1��6�   $	6 1 2R�6�   5      5     5     �� 5     $7 	#FFDDDDDD��67   �� 5     $7 	#FF707070��63   �� 5     $7 	#FFBEE6FD��6:   �� 5     $7 	#FF3C7FB1��66   �� 5     $7 	#FFC4E5F6��68   �� 5	     $7 	#FF2C628B��64   �� 5
     $7 	#FFF4F4F4��69   �� 5     $7 	#FFADB2B5��65   �� 5     $7 	#FF838383��69   �� 5     "  ��6'   .�5  
   ��  �@�FocusVisualStyle8   6-   �� 5  
    � ��8  6'   �� 5  
    � ��8  6(   �� 5  
    � ��# � ��6'   �� 5  
    � ��$ 0q�6,   �� 5  
    � ��$ Center=�67   �� 5  
    � ��$ Center=�65   �� 5  
    � ��$ 1q�6$   �� 5  
    � �� 5     �� 5     " ��6"   .R�5     �� $/ border��6   $8 10��6-   #��z��6?   #��z��6k   #��z��6�    . ._�5     �� $9 contentPresenter��6+   |�.  #��z��6W   #��z��6�   ��. # z 6�   #��z��6  5     * 5     P� 5     + �@��IsDefaulted, . . �5     �� $- border��6<   # � ��6P    � ��5     P� 5      + �@J�IsMouseOver, . . �5!     �� $- border��6;    � �� �#EAB01E6O   �� 5"     $- border��6<    � �� �#EAB01E6P   5#     P� 5$     + � ��, . . �5%     �� $- border��6;    � �� �#F1CA686O   �� 5&     $- border��6<    � �� �#F1CA686P   5'     P� 5(     + � {�, .  . �5)     �� $- border��6;   8   � ��6O   �� 5*     $- border��6<   8   � ��6P   �� 5+     $- contentPresenter��6G   8   � ��6e   5,     5.     50     51     �� 52     "  ��6!   .�53  
   ��  �@�FocusVisualStyle8   6-   �� 54  
    � ��8  6'   �� 55  
    � ��8  6(   �� 56  
    � ��# � ��6'   �� 57  
    � ��$ 0q�6,   �� 58  
    � ��$ Center=�67   �� 59  
    � ��$ Center=�65   �� 5:  
    � ��$ 1q�6$   �� 5;  
    � �� 5<     �� 5=     " ��6"   .R�5>     �� $/ border��6   $8 65��6-   #��z��6?   #��z��6k   #��z��6�    . ._�5?     �� $9 contentPresenter��6+   |�.  #��z��6W   #��z��6�   ��. # z 6�   #��z��6  5@     * 5A     P� 5B     + �@��IsDefaulted, . . �5C     �� $- border��6<   # � ��6P    � ��5D     P� 5E     + �@J�IsMouseOver, . . �5F     �� $- border��6;   8   � ��6O   �� 5G     $- border��6<   8   � ��6P   5H     P� 5I     + � ��, . . �5J     �� $- border��6;   8   � ��6O   �� 5K     $- border��6<   8   � ��6P   5L     P� 5M     + � {�, .  . �5N     �� $- border��6;   8   � ��6O   �� 5O     $- border��6<   8   � ��6P   �� 5P     $- contentPresenter��6G   8 	  � ��6e   5Q     5S     5U     5V     5W     