   M S B A M L   `   `   `  ����N  JWPFSampleProject.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPFSampleProject.UIWPFSampleProject.UI  5   	   &     WPFSampleProject.UI.PersonWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WPFSampleProject.UI     5   	     � Title$  PersonWindow��5   	    � WindowState$ 	Maximized=�6   .��5	      � .+�5
   
   �� -   5         ��Name$ createPersonBtn��5
      $��Create person��6*   $	��200��6`   $��
20,10,20,0q�6l   $��5q�6�   ���	#FFE2E2E2$��14(�6�    � Cursor$
 Hand��6�   �� 5   
   -   5        $ addressesBtn��5      $��	Addresses��6'   $	��200��6V   $��
20,10,20,0q�6b   $��5q�6v   ���	#FFE2E2E2$��14(�6�   $
 Hand��6�   ]� 5   
   $��20,10,20,10q�6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ personDataGrid��5         AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6d   ���	#FFB6B2B2   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 67   �� *Name+  5      $ 	FirstName��6)   	 6<   �� *	FirstName+  5      $ LastName��6)   	 6;   �� *
LastName+  5      $ Email��6)   	 68   �� *Email+  5      $ Gender��6)   	 69   �� *Gender+  5      $ PhoneNumber��6)   	 6>   �� *PhoneNumber+  5      $ DateOfBirth��6)   	 6>   �� *DateOfBirth+  5      $ 	CreatedBy��6)   	 6<   �� *	CreatedBy+  5      $ 
ModifiedBy��6)   	 6=   �� *
ModifiedBy+  5      $ 	CreatedOn��6)   	 6<   �� *	CreatedOn+  5      $ 
ModifiedOn��6)   	 6=   �� *
ModifiedOn+4  .System.Windows.Controls.DataGridTemplateColumn  5      
   Width$	
 210 6-      HeaderTemplate 5      �� 5      .R�5   "   �� $��Action��6,   5         CellTemplate 5       �� 5!      .R�5"   "   ��  �� Orientation$ 
Horizontal=�6-   $��Center=�6F   .+�5#   &   �� $ 	updateBtn��6-   -   5        $��Update��5#   @   $��90��6i   $��5q�6t   $	��5 2q�6�   $��12(�6�   $
 Hand��6�   ��6�   Z� �� 5$   &   $ 	deleteBtn��6-   -   5        $��Delete��5$   A   $��90��6j   $��5q�6u   $	��5 2q�6�   ���	#FFFF3737$��12(�6�   $
 Hand��6�   5%   #   5&      5(         ColumnHeaderStyle 5*      �� 5+       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5,      ��  �� Property � �� �� Value$ Center=�6G   5-      5/      50      51      52      