   M S B A M L   `   `   `  ����N  JWPFSampleProject.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPFSampleProject.UIWPFSampleProject.UI  5   	   !    WPFSampleProject.UI.Address   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WPFSampleProject.UI     5   	     � Title$  Address��5   	    � WindowState$ 	Maximized=�6   .��5	      � .+�5
   
   �� -   5         ��Name$ createAddressBtn��5
      $��Create address��6+   $	��200��6c   $��
20,10,20,0q�6o   $��5q�6�   ���	#FFE2E2E2$��14(�6�    � Cursor$
 Hand��6�   �� 5   
   -   5        $ 	PersonBtn��5      $��Person��6$   $	��200��6M   $��
20,10,20,0q�6Y   $��5q�6m   ���	#FFE2E2E2$��14(�6�   $
 Hand��6�   ]� 5   
   $��20,10,20,10q�6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ addressDataGrid��5         AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6e   ���	#FFB6B2B2   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 63   �� *Name+  5      $ Floor��6%   	 64   �� *Floor+  5      $ Building��6%   	 67   �� *
Building+  5      $ Street��6%   	 65   �� *Street+  5      $
 City��6%   	 63   �� *City+  5      $ Region��6%   	 65   �� *Region+  5      $ Country��6%   	 66   �� *	Country+  5      $ 	Createdby��6%   	 68   �� *	Createdby+  5      $ 
Modifiedby��6%   	 69   �� *
Modifiedby+  5      $ 	Createdon��6%   	 68   �� *	Createdon+  5      $ 
Modifiedon��6)   	 6=   �� *
Modifiedon+4  .System.Windows.Controls.DataGridTemplateColumn  5      
   Width$	
 210 6-      HeaderTemplate 5      �� 5      .R�5      �� $��Action��6(   5         CellTemplate 5       �� 5!      .R�5"      ��  �� Orientation$ 
Horizontal=�6)   $��Center=�6B   .+�5#   &   �� $ 	updateBtn��6-   -   5        $��Update��5#   @   $��90��6i   $��5q�6t   $	��5 2q�6�   $��12(�6�   $
 Hand��6�   ��6�   Z� �� 5$   &   $ 	deleteBtn��6-   -   5        $��Delete��5$   @   $��90��6i   $��5q�6t   $	��5 2q�6�   ���	#FFFF3737$��12(�6�   $
 Hand��6�   5%      5&      5(         ColumnHeaderStyle 5*      �� 5+       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5,      ��  �� Property � �� �� Value$ Center=�6C   5-      5/      50      51      52      