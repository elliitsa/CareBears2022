   M S B A M L   `   `   `  ����@  <PCApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PCAppPCApp  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
   	       PCApp.DatabaseData   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PCApp     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0sys&clr-namespace:System;assembly=mscorlib  5
   	   
�������  � Title$  DatabaseData��5   	   $	��450��6   $	��800��6+   $	��450��67   $	��800��6G   .��5      �  � RowDefinitions 5   
   �� 5      $��15��6   $	��15* �6+   �� 5      $	��100��6   $
��100* �6,   �� 5      $��30��6   $	��30* �6+    � ColumnDefinitions 5   
   �� 5      $��50��6   $	��50* �6-   �� 5      $	��300��6   $
��400* �6.   �� 5      $��50��6   $	��50* �6-   .+�5   
   #  LiveCharts.Wpf.CartesianChart  -   5          Name$ myLineChart��5   :   $��1��6   $��1��6*   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$
 Left=�6s   $	��250��6�   $	��550��6�      Series 6O   �� *SeriesCollection+   AxisX 5        LiveCharts.Wpf.Axis  -   5          Name$ myLabel��5         Title$ X��6,   	   Labels	 66   �� *Labels+6R   
   AxisY
 5#        $ Y��6      LabelFormatter 6%   �� *
YFormatter+6M   5%      (  "System.Windows.Controls.DatePicker  5'   
   -   5        $��
DatePicker��5'   2   $��1��6   $��3��6%   $	��200��6D      SelectedDate 5(      �� *SelectedDate+6=   �� 5*   
   -   5         ��Name$ btnBack��5*   .   $��0��6   $��0��6!    !  MaterialDesignFlatMidBgButton#��[  6?   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5+      $��25��6J   $��65��6V   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5,      $��10(�6G   $
��Back��6U   6d   �� 5.   
   -   5        $ 	btnLogout��5.   .   $��0��6   $��2��6   #��[  6A   $ Depth0=�5/      $��25��6J   $��65��6V   $ 10��50      $��10(�6G   $��Logout��6U   6f   51      52      