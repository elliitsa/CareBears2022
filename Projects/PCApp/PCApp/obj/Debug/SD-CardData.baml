   M S B A M L   `   `   `  ����@  <PCApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PCAppPCApp  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	       PCApp.SD_CardData   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PCApp     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   
�������  � Title$  SD-CardData��5
   	   $	��450��6   $	��800��6*   $	��450��66   $	��800��6F   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5      $��	0,155,0,0q�6?      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ User ID��6<   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *id+6<     5      $ 
Heart rate��6C    6%   �� *	heartrate+6C     5      $ Oxygen��6@    6%   �� *oxygen+6@     5      $ Latitude��6B    6%   �� *
latitude+6B     5      $ 	Longitude��6C    6%   �� *	longitude+6C     5      $ 	Emergency��6C    6%   �� *	emergency+6C     5      $
 Date��6>    6%   �� *date+6>     5      $
 Time��6>    6%   �� *time+6>   5      �� 5   
   -   5         ��Name$ listBox��5      $��506,10,10,311q�6N   6e   �� 5    
   -   5         ��Name$ comboBox��5       $
��Left=�6%   $��	10,10,0,0q�6@   $	��Top=�6S   $	��201��6k   $��29��6w   �� 5!   
   -   5         ��Name$ button��5!      $
��Load��6!   $
��Left=�60   $��
228,10,0,0q�6K   $	��Top=�6_   $��29��6w   $��63��6�   6�   �� 5#   
   -   5        $ btnBack��5#   %   $��
90 0 0 375q�6   $��Center=�66    !  MaterialDesignFlatMidBgButton#��[  6S   +  %MaterialDesignThemes.Wpf.ShadowAssist	   ShadowDepth$	 Depth0=�5$      $��25��6J   $��65��6V   +  %MaterialDesignThemes.Wpf.ButtonAssist
   CornerRadius$
 10��5%      $��10(�6G   $
��Back��6U   6d   �� 5'   
   -   5        $ 	btnLogout��5'   %   $��
90 0 0 310q�6   $��Center=�68   #��[  6U   $	 Depth0=�5(      $��25��6J   $��65��6V   $
 10��5)      $��10(�6G   $��Logout��6U   6f   5+      5,      