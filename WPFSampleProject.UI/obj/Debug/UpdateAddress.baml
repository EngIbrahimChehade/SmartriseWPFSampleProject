   M S B A M L   `   `   `  ����N  JWPFSampleProject.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPFSampleProject.UIWPFSampleProject.UI  5   	   '    !WPFSampleProject.UI.UpdateAddress   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WPFSampleProject.UI     5   	     � Title$  UpdateAddress��5   	   $	��450��6   $	��800��6,   .��5	      � $��20q�6    � ColumnDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $	��250 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��1��6   .��6   Name:6$   �� 5   
   -   5         ��Name$ txtName��5   A   $��1��6   $��2��6   $��0,0,0,10q�6/   $	��0 5q�6R   �� 5    
   $��2��6   .��6   Floor:6%   �� 5!   
   -   5        $ txtFloor��5!   A   $��2��6   $��2��6   $��0,0,0,10q�6/   $	��0 5q�6S   �� 5#   
   $��3��6   .��6   	Building:6(   �� 5$   
   -   5        $ txtBuilding��5$   A   $��3��6   $��2��6   $��0,0,0,10q�6/   $	��0 5q�6V   �� 5&   
   $��4��6   .��6   	Street:6&   �� 5'   
   -   5        $ 	txtStreet��5'   A   $��4��6   $��2��6   $��0,0,0,10q�6/   $	��0 5q�6T   �� 5)   
   $��5��6   .��6   City:6$   �� 5*   
   -   5        $ txtCity��5*   A   $��5��6   $��2��6   $��0,0,0,10q�6/   $	��0 5q�6R   �� 5,   
   $��6��6   .��6   	Region:6&   �� 5-   
   -   5        $ 	txtRegion��5-   A   $��6��6   $��2��6   $��0,0,0,10q�6/   $	��0 5q�6T   �� 5/   
   $��7��6   .��6   
Country:6'   �� 50   
   -   5        $ 
txtCountry��50   A   $��7��6   $��2��6   $��0,0,0,10q�6/   $	��0 5q�6U   �� 52   
   $��8��6   .��6   Modifiedby:6*   �� 53   
   -   5         ��Name$ 	drpPerson��57      $��8��54      $��2��55      $��0,0,0,10q�56      $	��250��58       �� DisplayMemberPath$
 Name��59       �� SelectedValuePath$ Id��5<       �� SelectedItem 5:      ��  �� Path$ Id�	 �� SelectedValue	 5;      �� $
 Name�5=      �� 5?   
   -	   5        
 ��Name$
 	createBtn��5?   /   $��11��6   $��2��6   $��Update��6B   $
��auto��6k   $	��0 5q�6x   5A      5B      