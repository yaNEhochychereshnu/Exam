   M S B A M L   `   `   `  ����?  ;Demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DemoDemo  5   	       Demo.ManageShiftsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Demo     5   	     � Title$)  #Управление сменами��5   	    � SizeToContent$ WidthAndHeight=�6$   .��5	      � .+�5
   
   �� .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
ShiftsGrid��5         AutoGenerateColumns$ False��6+      CanUserAddRows$ False��6G   $��10q�6^   $	��400��6j   $	��200��6v      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Начало смены��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *
StartShift+  5      $# Окончание смены��6)    6B   �� *
EndShift+  5      $ Статус смены��6)    6?   �� *StatusShift+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Сотрудники��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6A   	   CellTemplate	 5      �� 5      .R�5   "   �� ��6/   �� *
ShiftUsers+��5   &   �� 5   *   .R�5   .   �� ��68   �� *	User.Name+5   +   5   #   5      5      5      �� 5      -   5        
 ��Name$
 	addButton��5      $*��$Создать новую смену��6E   $��Center=�6c   $��10q�6�   $��Center=�6�   $��10q�6�   $	��200��6�   
�������6�   �� 5       -   5        $
 
backButton��5       $��
Назад��6)   $��Center=�69   $��10q�6V   $��Center=�6c   $��10q�6~   $	��200��6�   
���\\��6�   5!      5"      5#      