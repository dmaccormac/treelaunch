   M S B A M L   `   `   `  ����E  ATreeLaunch, Version=0.8.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TreeLaunch.PropertiesTreeLaunch.Properties  5   	       TreeLaunch.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1p#clr-namespace:TreeLaunch.Properties     5   	     � Title$  
TreeLaunch��5   	   $	��400��6   $	��200��6)    � WindowStyle$ 
ToolWindow=�65   .��5      � .+�5   
   R� -   5        $��treeview��5      $��Stretch=�6#   $��Stretch=�6A   $��10,10,10,25q�6�   ��6]   ��  �� XPath$ Group�� � ContextMenu 5	      �� 5
      .@�5      m� -   5        $��
MenuLaunch��5      $��Launch��61   6A   m� 5      -   5        $��MenuOpen��5      $��Open XML File��6/   6F   m� 5      -   5        $��MenuEdit��5      $��Edit XML��6/   6A   m� 5      -   5        $��MenuRefresh��5      $��Refresh��62   6C   m� 5      -   5        $��MenuLog��5      $��View Log��6.   6@   m� 5      -   5        $��MenuTopmost��5      $��Always on Top��62    m� IsCheckable .  m� 	IsChecked .  6n   m� 5      -   5        $��	MenuAbout��5      $��About��60   6?   5      ��5      �� 5       �� ItemsSource 6+   �� $
 Item��.R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��16��6    $��16��6+   $	��3,0q�67   ��6D   �� $ @Icon���� 5      ��6$   �� $ @Name��5      5      5      �� 5   
   $��Bottom=�6   $��	10,1,10,1q�6/   $��20��6B   
�������.@�5       �� -	   5         ��Name$ TextBlock_Status��5       $
��Left=�62   $
��Wrap=�6M   $��Bottom=�6a   $��11(�6�   ��6|   �� $  TreeLaunch.Properties.Settings	   Default
 �� Source#
 Z	  �� Path$ TreeFile� �� Mode$ TwoWay=�6�   5!      5"      5#      